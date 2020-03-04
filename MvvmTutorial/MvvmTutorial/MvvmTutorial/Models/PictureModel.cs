using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MvvmTutorial.Models
{
    public class PictureModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ImageSource PhotoImage { get; set; }
        public String PickPhoto { get; set; }
        public String TakePhoto { get; set; }

    }
}
