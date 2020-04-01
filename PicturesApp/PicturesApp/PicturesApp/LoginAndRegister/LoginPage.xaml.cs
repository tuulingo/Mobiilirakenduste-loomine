using PicturesApp.Data;
using PicturesApp.Models;
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
            EmailEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (EmailEntry.Text != null && passwordEntry.Text != null)
            {
                string username = EmailEntry.Text;
                string password = passwordEntry.Text;
                List<UserModel> users = await App.UserDatabase.GetUsers();
                foreach (var user in users)
                {
                    var validData = App.UserDatabase.LoginValidate(EmailEntry.Text, passwordEntry.Text);
                    if (validData)
                    {
                        var myTabbedPage = new MyTabbedPage();
                        myTabbedPage.BindingContext = user;
                        await Navigation.PushModalAsync(new NavigationPage(myTabbedPage));
                    }
                    else
                    {
                        await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                    }
                }
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}