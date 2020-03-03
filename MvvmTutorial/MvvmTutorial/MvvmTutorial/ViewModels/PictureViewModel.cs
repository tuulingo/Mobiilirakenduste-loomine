using MvvmTutorial.Models;
using Plugin.Media;
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
            Pictures.Add(new PictureModel { Title = "Cute short-tailed kangaroo", Date = DateTime.Now, PickPhoto = PickPhoto });
            Pictures.Add(new PictureModel { Title = "Jesus", Date = DateTime.Now, PickPhoto =  });
            Pictures.Add(new PictureModel { Title = "Matu", Date = DateTime.Now, PickPhoto = });
        }

        public List<PictureModel> Pictures
        {
            get; set;
        }

        public async void PickPhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Device.BeginInvokeOnMainThread(await DisplayAlert("Alert", "No internet connection", "Ok") );
                return;
            }
            return;
        }
    }
}
