using PicturesApp.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicturesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            ProfilePicture.BindingContext = new ChangePFPPopUpPage();
            BindingContext = App.LoggedInUser;
            
        }

        private async void ShowPopup(object sender, EventArgs e)
        {
           await PopupNavigation.Instance.PushAsync(new ChangePFPPopUpPage());
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Quit", "You want Quit", "OK");
            await Navigation.PushModalAsync(new LoginPage());
        }

        public async void SaveChanges_Clicked(object sender, EventArgs e)
        {
            var user = App.LoggedInUser;
            if (user.Name == null || user.Name == "")
            {
                await DisplayAlert("Invalid Info", "Invalid Username", "OK");
            }
            else
            {
                user.Name = UserNameEntry.Text;
                var userpfp = user.ProfilePicturePath;
                ProfilePicture.Source = userpfp;


                await App.UserDatabase.SaveUserAsync(user);
                await DisplayAlert("Save Changes", "Changes saved", "OK");
            }
        }

        
    }
}