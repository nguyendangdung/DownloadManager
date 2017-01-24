using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Serilog.Core;

namespace DL
{
    public class File : INotifyPropertyChanged
    {
        private readonly Logger _log;
        private readonly HttpClient _client;
        private long _downloadedSize;
        //private int _avaiableConnectionNumber;

        public File()
        {
            
            _client = new HttpClient()
            {
                Timeout = Timeout.InfiniteTimeSpan
            };
            // _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue());
            Name = "Test.exe";
            _log = new LoggerConfiguration()
                .WriteTo.File($"{Name}.txt")
                .CreateLogger();
        }

        ////public long DownloadedSize { get; set; }

        public string Url { get; set; }

        public BindingList<Part> Parts { get; set; } = new BindingList<Part>();

        public string Name { get; set; }
        public long Size { get; set; }
        public string SizeMb { get; set; }
        public long DownloadedSize
        {
            get { return _downloadedSize; }
            set
            {
                _downloadedSize = value;
                OnPropertyChanged();
                //if (_time == null)
                //{
                //    _time = DateTime.Now;
                //    _downloadedSize = value;
                //    OnPropertyChanged();
                //}
                //else
                //{
                //    //var currentTime = DateTime.Now;
                //    //var deltaTime = currentTime - _time.Value;
                //    //var deltaSize = value - _downloadedSize;
                //    _downloadedSize = value;
                //    OnPropertyChanged();

                //    //var velocity = deltaSize/deltaTime.Seconds;
                //}
            }
        }

        public async Task RequestInfoAsync()
        {
            _log.Information("Start request file info {Url}, THreadId {threadid}", Url,
                Thread.CurrentThread.ManagedThreadId);
            var request = await _client.GetAsync(Url, HttpCompletionOption.ResponseHeadersRead);
            if (request.StatusCode == HttpStatusCode.OK)
            {
                var size = request.Content.Headers.ContentLength.GetValueOrDefault();
                Size = size;
                var num = 15;
                var partSize = size / num;
                for (int i = 0; i < num; i++)
                {
                    if (i != num - 1)
                    {
                        var part = new Part(this, _client)
                        {
                            Start = i * partSize,
                            End = (i + 1) * partSize - 1,
                            //File = this
                        };
                        Parts.Add(part);
                    }
                    else
                    {
                        var part = new Part(this, _client)
                        {
                            Start = (num - 1) * partSize,
                            End = size - 1,
                            //File = this
                        };
                        Parts.Add(part);
                    }
                }

                _log.Information("Request Info done size = {size}, num = {num}", Size, num);
            }
        }

        public async Task DownloadAsync()
        {
            _log.Information("Start download {Name} on Thread {Thread}", Name, Thread.CurrentThread.ManagedThreadId);
            try
            {
                var tasks = new List<Task>();
                foreach (var part in Parts)
                {
                    var task = Task.Run(part.DownloadAsync);
                    tasks.Add(task);
                }
                await Task.WhenAll(tasks.ToArray());
                var waitParts = Parts.Where(s => s.PartStatus == PartStatus.WaitAnother);
                var tasks2 = new List<Task>();

                foreach (var part in waitParts)
                {
                    var task = Task.Run(part.DownloadAsync);
                    tasks2.Add(task);
                }
                await Task.WhenAll(tasks2.ToArray());
            }


            catch (Exception ex)
            {
                _log.Error(ex, "Download Error");
                MessageBox.Show("Download error");
                return;
            }

            try
            {
                _log.Information("Start joining parts");
                var path = Path.Combine(Constants.Dir, Name);
                using (var des = System.IO.File.Create(path))
                {
                    foreach (var part in Parts)
                    {
                        using (var sor = System.IO.File.OpenRead(part.LocalPath))
                        {
                            await sor.CopyToAsync(des);
                        }
                        System.IO.File.Delete(part.LocalPath);
                    }
                }
                _log.Information("Join done");
            }
            catch (Exception ex)
            {
                _log.Error(ex, "join error");
                // throw;
                MessageBox.Show("Join error");
            }
            
        }

        //public int AvaiableConnectionNumber
        //{
        //    get { return _avaiableConnectionNumber; }
        //    set
        //    {
        //        lock (this)
        //        {
        //            _avaiableConnectionNumber = value;
        //        }
                
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
