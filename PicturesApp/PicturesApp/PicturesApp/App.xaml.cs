using MvvmTutorial.Data;
using PicturesApp.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicturesApp
{
    public partial class App : Application
    {
        static PictureDb database;
        public static PictureDb Database
        {
            get
            {
                if (database == null)
                {
                    database = new PictureDb(Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), "pictures.db3"));
                }
                return database;
            }
        }

        static UserDb userDatabase;
        public static UserDb UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDb(Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), "users.db3"));
                }
                return userDatabase;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
            new NavigationPage(new MyTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
