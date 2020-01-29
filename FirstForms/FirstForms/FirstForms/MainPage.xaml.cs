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
        string _localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string _filePath = "";
        string[] _files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        Dictionary<string, string> filesDict = new Dictionary<string, string>();

        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_filePath))
            {
                Editor.Text = File.ReadAllText(_filePath);
            }
        }

        int count = 0;
        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_filePath, Editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            Editor.Text = string.Empty;
        }

        void OnOpenClick(object sender, EventArgs e)
        {
            if (FileName.Text != "")
            {
                _filePath = Path.Combine(_localFolder, FileName.Text + ".txt");
            }

            if (File.Exists(_filePath))
            {
                Editor.Text = File.ReadAllText(_filePath);
            }
            else
            {
                Editor.Text = "File doesn't exist.";
            }
        }
        public void GetFiles(string[] filePaths)
        {
            foreach (string path in filePaths)
            {
                string[] currFilePathParts = path.Split(new[] { "\\" }, StringSplitOptions.None);
                string currFileName = currFilePathParts[currFilePathParts.Length - 1];
                filesDict.Add(currFileName, path);
            }
        }
    }
}