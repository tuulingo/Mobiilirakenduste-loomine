using MvvmTutorial.Data;
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

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
