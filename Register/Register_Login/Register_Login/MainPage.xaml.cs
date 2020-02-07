using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Register_Login
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        UserDB userData;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.mainPage, true);
            userData = new UserDB();
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = userData.LoginValidate(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    await Navigation.PushModalAsync(new HomePage());
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
