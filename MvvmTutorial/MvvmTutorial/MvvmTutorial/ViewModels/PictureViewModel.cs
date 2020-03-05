using MvvmTutorial.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public PictureViewModel()
        {

            Pictures = new List<PictureModel>();
            Pictures.Add(new PictureModel { Title = RandomString(10), Date = DateTime.Now/*, PickPhoto = PickPhoto */});
            Pictures.Add(new PictureModel { Title = RandomString(10), Date = DateTime.Now/*, PickPhoto = */ });
            Pictures.Add(new PictureModel { Title = RandomString(10), Date = DateTime.Now/*, PhotoImage = PickPhoto()*/});
        }



        public List<PictureModel> Pictures
        {
            get; set;
        }

        public async void PickPhoto() 
        {
            /*await CrossMedia.Current.Initialize();

            var file = await CrossMedia.Current.PickPhotoAsync();
            PhotoImage = ImageSource.FromStream(() =>
            {

                if (file == null)
                {
                    return null;
                };
                var stream = file.GetStream();
                file.Dispose();
                return stream;
                
            });*/
        }
    }
}
