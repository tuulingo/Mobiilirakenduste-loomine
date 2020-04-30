using PicturesApp.Data;
using PicturesApp.Models;
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

namespace PicturesApp.ViewModels
{
    public class PictureViewModel : BindableObject
    {
          
        public PictureViewModel()
        {
            Pictures = new ObservableCollection<PictureModel>();
            TakePictureCommand = new Command(OnTakePictureCommand);
            PickPictureCommand = new Command(OnPickPictureCommand);
            //DeletePictureCommand = new Command(OnDeletePictureCommand);
            DisplayOnLoad();
        }

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
        

        public ICommand TakePictureCommand { get; private set; }
        public ICommand PickPictureCommand { get; private set; }
       // public ICommand DeletePictureCommand { get; private set; }


        public ObservableCollection<PictureModel> Pictures
        {
            get; set;
        }

        //public async void OnDeletePictureCommand()
        //{
        //    await CrossMedia.Current.Initialize();

        //    var picture = (ImageData)BindingContext;
        //    await App.Database.DeletePictureAsync(picture);

        //}

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
            if (file == null)
            {
                return;
            }


            var dbImage = new ImageData();
            dbImage.Title = RandomString(10);
            dbImage.Date = DateTime.Now;
            dbImage.Path = file.Path.ToString();
            await App.Database.SavePicturesAsync(dbImage);
            AddToList();
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

            var dbImage = new ImageData();
            dbImage.Title = RandomString(10);
            dbImage.Date = DateTime.Now;
            dbImage.Path = file.Path.ToString();
            await App.Database.SavePicturesAsync(dbImage);
            AddToList();
        }

        private async void AddToList()
        {
            
            List<ImageData> images = await App.Database.GetPicturesAsync();
            var image = images[images.Count - 1];
            var user = App.LoggedInUser;
            var imageModel = new PictureModel();
            imageModel.Title = RandomString(10);
            imageModel.Image = ImageSource.FromFile(image.Path);
            imageModel.Name = user.Name;
            imageModel.PostProfilePic = ImageSource.FromFile(user.ProfilePicturePath);
            imageModel.Date = DateTime.Now;
            Pictures.Add(imageModel);
        }
        private async void DisplayOnLoad()
        {
            List<ImageData> images = await App.Database.GetPicturesAsync();
            if (images.Count == 0)
            {
                return;
            }
            else
            {
                foreach (var image in images)
                {
                    var user = App.LoggedInUser;
                    var imageModel = new PictureModel();
                    imageModel.Title = image.Title;
                    imageModel.Date = image.Date;
                    imageModel.Image = ImageSource.FromFile(image.Path);
                    imageModel.PostProfilePic = image.PostProfilePic;
                    imageModel.Name = user.Name;
                    Pictures.Add(imageModel);
                }
            }
        }
    }
}
