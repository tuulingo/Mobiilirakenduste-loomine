using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmTutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicturesPage : ContentPage
    {
        public PicturesPage()
        {
            InitializeComponent();

            CameraButton.Clicked += CameraButton_Clicked;
            PickAPhotoButton.Clicked += PickAPhotoButton_Clicked;
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        private async void PickAPhotoButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var file = await CrossMedia.Current.PickPhotoAsync();
            PhotoImage.Source = ImageSource.FromStream(() =>
            {
                
                if (file == null)
                {
                    return null;
                };
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }



    }
}