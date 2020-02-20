using MvvmTutorial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MvvmTutorial.ViewModels
{
    public class PictureViewModel : BindableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        public PictureViewModel()
        {
            Pictures = new List<PictureModel>();
            Pictures.Add(new PictureModel { Title = "Cute short-tailed kangaroo", Date = DateTime.Now, ImageUrl = "https://www.zastavki.com/pictures/640x480/2015/Animals_Cute_short-tailed_kangaroo_107358_29.jpg" });
            Pictures.Add(new PictureModel { Title = "Jesus", Date = DateTime.Now, ImageUrl = "https://s31807.pcdn.co/wp-content/uploads/2019/12/1_9fct0mOWKz-9TZ_Q7Gky1w.jpeg" });
            Pictures.Add(new PictureModel { Title = "Matu", Date = DateTime.Now, ImageUrl = "https://img.favpng.com/9/0/4/mater-cars-2-youtube-lightning-mcqueen-png-favpng-bxbLsV2SjHMvVSVhyPtpj3uiC.jpg" });
        }

        public List<PictureModel> Pictures
        {
            get; set;
        }
    }
}
