using PicturesApp.Data;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.loginPage, true);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyTabbedPage()));
            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                string username = userNameEntry.Text;
                string password = passwordEntry.Text;

                var validData = App.UserDatabase.LoginValidate(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new MyTabbedPage()));
                }
                else
                {
                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}