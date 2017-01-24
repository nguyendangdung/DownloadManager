using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ByteSizeLib;
using Serilog;
using Serilog.Core;

namespace DL
{
    public class Part : INotifyPropertyChanged
    {
        //private readonly SemaphoreSlim _readLock = new SemaphoreSlim(1, 1);
        private readonly Logger _log;
        private int _maxTry = 10;
        private readonly HttpClient _client;
        private long _downloadedSize;
        readonly IProgress<PartReport> _progress = new Progress<PartReport>();
        private bool _completed;
        public string Name { get; set; }
        public PartStatus PartStatus { get; set; }

        public bool Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                OnPropertyChanged();
            }
        }

        public Part(File file)
        {
            File = file;
            _client = new HttpClient()
            {
                Timeout = Timeout.InfiniteTimeSpan
            };
            ((Progress<PartReport>)_progress).ProgressChanged += _progress_ProgressChanged;
            PartStatus = PartStatus.Created;
            Name = $"{File.Name}-{Guid.NewGuid()}";
            _log = new LoggerConfiguration()
                .WriteTo.File($"{Name}.txt")
                .CreateLogger();
        }

        private void _progress_ProgressChanged(object sender, PartReport e)
        {
            _log.Information("ProgressChanged on Thread {thread}. This should be main thread", Thread.CurrentThread.ManagedThreadId);
            DownloadedSize += e.Count;
            PartStatus = e.PartStatus;
            //if (e.PartStatus == PartStatus.Completed)
            //{
            //    File.AvaiableConnectionNumber++;
            //}
            File.DownloadedSize += e.Count;

        }

        public File File { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
        public string LocalPath { get; set; }

        public long DownloadedSize
        {
            get { return _downloadedSize; }
            set
            {
                _downloadedSize = value;
                OnPropertyChanged();
            }
        }

        public async Task DownloadAsync()
        {
            _log.Information("Starting download {Name} On ThreadId {ThreadId}", Name,
                Thread.CurrentThread.ManagedThreadId);
            if (_maxTry <= 0)
            {
                _progress.Report(new PartReport() {PartStatus = PartStatus.WaitAnother});
                return;
            }
            _maxTry--;
            
            LocalPath = Path.Combine(Constants.Dir, Name);
            var request = new HttpRequestMessage(HttpMethod.Get, File.Url);
            request.Headers.Range = new RangeHeaderValue(Start, End);
            request.Headers.ConnectionClose = true;
            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.PartialContent)
            {
                _log.Information("Got OK Status Code, begin streaming file to the local");
                var report = 0;
                int bufferSize = 4096;
                using (var des = System.IO.File.OpenWrite(LocalPath))
                using (var src = await response.Content.ReadAsStreamAsync())
                {
                    int count;
                    byte[] buffer = new byte[bufferSize];

                    while ((count = src.Read(buffer, 0, bufferSize)) != 0)
                    {
                        report += count;
                        if (report >= 102400)
                        {
                            _progress.Report(new PartReport() {Count = report});
                            report = 0;
                        }
                        des.Write(buffer, 0, count);
                    }
                    _progress.Report(new PartReport() { Count = report, PartStatus = PartStatus.Completed });
                    _log.Information("Completed to download the PartFile");
                }
            }
            else
            {
                _log.Information("Get error response from Server, Wait 1s");
                await Task.Delay(5000);
                await DownloadAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
