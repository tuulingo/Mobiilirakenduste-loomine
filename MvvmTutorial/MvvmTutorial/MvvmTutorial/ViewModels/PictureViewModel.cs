﻿using MvvmTutorial.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
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

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //INavigation navigation
        //public INavigation Navigation { get; set; }
        //            this.Navigation = navigation;
        public PictureViewModel()
        {

            Pictures = new ObservableCollection<PictureModel>();
            TakePictureCommand = new Command(OnTakePictureCommand);
            PickPictureCommand = new Command(OnPickPictureCommand);
        }

        public ICommand TakePictureCommand { get; private set; }
        public ICommand PickPictureCommand { get; private set; }


        public ObservableCollection<PictureModel> Pictures
        {
            get; set;
        }

        public async void OnPickPictureCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Photos Not supported", "Permission not granted", "Ok");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });

            var image = new PictureModel();
            image.Title = RandomString(8);
            image.Date = DateTime.Now;

            image.Image = ImageSource.FromStream(() =>
            {

                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            //var picture = (PictureModel)BindingContext;
            //await App.Database.SavePicturesAsync(picture);
            //await Navigation.PopAsync();
            Pictures.Add(image);
        }

        public async void OnTakePictureCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Camera can't be opened right now", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });
            if (file == null)
                return;

            var image = new PictureModel();
            image.Title = RandomString(8);
            image.Date = DateTime.Now;


            image.Image = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            Pictures.Add(image);
        }
    }
}
