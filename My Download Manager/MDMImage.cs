using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace My_Download_Manager
{
    [Serializable()]
    public class MDMImage
    {
        public Image Category;
        public Image Application;
        public Image Book;
        public Image Music;
        public Image Orther;
        public Image Video;
        public MDMImage()
        {
            this.Category = (Image)global::My_Download_Manager.Properties.Resources.category;
            this.Application = (Image)global::My_Download_Manager.Properties.Resources.application;
            this.Book = (Image)global::My_Download_Manager.Properties.Resources.book;
            this.Music = (Image)global::My_Download_Manager.Properties.Resources.music;
            this.Orther= (Image)global::My_Download_Manager.Properties.Resources.orther;
            this.Video = (Image)global::My_Download_Manager.Properties.Resources.video;
        }
    }
}
