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
            Category = (Image)Properties.Resources.category;
            Application = (Image)Properties.Resources.application;
            Book = (Image)Properties.Resources.book;
            Music = (Image)Properties.Resources.music;
            Orther= (Image)Properties.Resources.orther;
            Video = (Image)Properties.Resources.video;
        }
    }
}
