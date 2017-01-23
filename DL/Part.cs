using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ByteSizeLib;

namespace DL
{
    class Part : INotifyPropertyChanged
    {
        private HttpClient _client;
        private long _downloadedSize;
        IProgress<int> _progress = new Progress<int>((t) =>
        {
            
        });

        private string _downloadedSizeMb;

        public Part()
        {
            _client = new HttpClient()
            {
                Timeout = System.Threading.Timeout.InfiniteTimeSpan
            };
            ((Progress<int>)_progress).ProgressChanged += _progress_ProgressChanged; ;
        }

        private void _progress_ProgressChanged(object sender, int e)
        {
            DownloadedSize += e;
            File.DownloadedSize += e;
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
                DownloadedSizeMb = ByteSize.FromBytes(value).MegaBytes.ToString();
                OnPropertyChanged();
            }
        }

        public string DownloadedSizeMb
        {
            get { return _downloadedSizeMb; }
            private set
            {
                _downloadedSizeMb = value;
                OnPropertyChanged();
            }
        }

        public async Task DownloadAsync()
        {
            var name = $"{File.Name}-{Guid.NewGuid()}";
            LocalPath = Path.Combine(Constants.Dir, name);
            var request = new HttpRequestMessage(HttpMethod.Get, File.Url);
            request.Headers.Range = new RangeHeaderValue(Start, End);
            request.Headers.ConnectionClose = true;
            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.PartialContent)
            {
                var report = 0;
                int bufferSize = 4096;
                using (var des = System.IO.File.OpenWrite(LocalPath))
                using (var src = await response.Content.ReadAsStreamAsync())
                {
                    int count;
                    byte[] buffer = new byte[bufferSize];

                    while ((count = src.Read(buffer, 0, bufferSize)) != 0)
                    {
                        //report += count;
                        //if (report >= 10485)
                        //{
                        //    report = 0;
                        //    _progress.Report(count);
                        //}
                        _progress.Report(count);
                        des.Write(buffer, 0, count);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
