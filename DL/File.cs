using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DL
{
    class File : INotifyPropertyChanged
    {
        private DateTime? _time;
        private HttpClient _client;
        private long _downloadedSize;

        public File()
        {
            _client = new HttpClient()
            {
                Timeout = System.Threading.Timeout.InfiniteTimeSpan
            };
            Name = "Test.exe";
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
                if (_time == null)
                {
                    _time = DateTime.Now;
                    _downloadedSize = value;
                    OnPropertyChanged();
                }
                else
                {
                    var currentTime = DateTime.Now;
                    var deltaTime = currentTime - _time.Value;
                    var deltaSize = value - _downloadedSize;
                    _downloadedSize = value;
                    OnPropertyChanged();

                    //var velocity = deltaSize/deltaTime.Seconds;
                }
            }
        }

        public async Task RequestInfoAsync()
        {
            var request = await _client.GetAsync(Url, HttpCompletionOption.ResponseHeadersRead);
            if (request.StatusCode == HttpStatusCode.OK)
            {
                var size = request.Content.Headers.ContentLength.GetValueOrDefault();
                Size = size;
                var partSize = size / 13;
                for (int i = 0; i < 13; i++)
                {
                    if (i != 12)
                    {
                        var part = new Part()
                        {
                            Start = i * partSize,
                            End = (i + 1) * partSize - 1,
                            File = this
                        };
                        Parts.Add(part);
                    }
                    else
                    {
                        var part = new Part()
                        {
                            Start = 12 * partSize,
                            End = size - 1,
                            File = this
                        };
                        Parts.Add(part);
                    }
                }
            }
        }

        public async Task DownloadAsync()
        {
            //var start = DateTime.Now;
            var tasks = new List<Task>();
            foreach (var part in Parts)
            {
                var task = Task.Run(part.DownloadAsync);
                tasks.Add(task);
            }
            await Task.WhenAll(tasks.ToArray());

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
            //var end = DateTime.Now;
            //var time = end - start;
            //MessageBox.Show("Download complete, time = " + time.Seconds);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
