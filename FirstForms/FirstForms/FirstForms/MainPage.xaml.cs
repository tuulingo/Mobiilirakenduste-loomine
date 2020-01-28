using Android.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstForms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {       
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lambi.txt");

        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                Editor.Text = File.ReadAllText(_fileName);
            }
        }

        int count = 0;
        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, Editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            Editor.Text = string.Empty;
        }

        void OnOpenClick(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                var
            }
            else
            {
                FileName.Text = "File doesn't exist";
            }
        }

        public string GetFilePath()
        {
            Context context = AppContext;
            var filepath = context.get
        }
    }
}