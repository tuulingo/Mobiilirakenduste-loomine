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
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.mainPage, true);
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new LoginPage());
        }
        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
