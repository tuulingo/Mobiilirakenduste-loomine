using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        UserDB userData = new UserDB();
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            var sourceData = userData.GetUsers();
            userList.ItemsSource = sourceData;
        }
        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Quit", "You want Quit", "OK");
            Application.Current.Quit();
        }
    }
}