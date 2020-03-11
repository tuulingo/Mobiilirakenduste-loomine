using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PicturesApp.Models
{
    public class PictureModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ImageSource Image { get; set; }
    }

}
