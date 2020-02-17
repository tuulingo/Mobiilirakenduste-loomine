using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmTutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagesPage : ContentPage
    {
        public IList<Language> Languages { get; private set; }

        public LanguagesPage()
        {
            InitializeComponent();

            Languages = new List<Language>();
            Languages.Add(new Language { Name = "Arabic", ShortName = "ARAB"});
            Languages.Add(new Language { Name = "Estonia", ShortName = "EE" });
            Languages.Add(new Language { Name = "Germany", ShortName = "GER" });

            BindingContext = this;
        }

    }
}