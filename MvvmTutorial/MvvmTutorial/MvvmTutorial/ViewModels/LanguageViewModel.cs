using MvvmTutorial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MvvmTutorial
{
    public class LanguageViewModel : BindableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        public LanguageViewModel()
        {
            Languages = new List<Language>();
            Languages.Add(new Language { Name = "Arabic", ShortName = "ARAB" });
            Languages.Add(new Language { Name = "English", ShortName = "ENG" });
            Languages.Add(new Language { Name = "Estonia", ShortName = "EE" });
            Languages.Add(new Language { Name = "Germany", ShortName = "GER" });
        }

        private List<Language> _languages;

        public List<Language> Languages
        {
            get { return _languages; }
            set
            {
                if(_languages != value)
                {
                    _languages = value;
                    OnPropertyChanged(nameof(Languages));
                }
            }
        }

        private List<Language> _selectedLanguages;

        public List<Language> SelectedLanguages
        {
            get { return _selectedLanguages; }
            set
            {
                if (_selectedLanguages != value)
                {
                    _selectedLanguages = value;
                    OnPropertyChanged(nameof(SelectedLanguages));
                }
            }
        }

    }
}
