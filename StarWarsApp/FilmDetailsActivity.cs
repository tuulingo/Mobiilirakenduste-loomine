using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace StarWarsApp
{
    [Activity(Label = "FilmDetailsActivity")]
    public class FilmDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.film_details_layout);

            var filmNameTextView = FindViewById<TextView>(Resource.Id.filmNameTextView);
            var filmDetailsTextView1 = FindViewById<TextView>(Resource.Id.filmDetailsTextView1);
            var filmDetailsTextView2 = FindViewById<TextView>(Resource.Id.filmDetailsTextView2);
            var filmDetailsTextView3 = FindViewById<TextView>(Resource.Id.filmDetailsTextView3);
            var filmDetailsTextView4 = FindViewById<TextView>(Resource.Id.filmDetailsTextView4);

            var filmDetails = JsonConvert.DeserializeObject<Core.Models.FilmResult>(Intent.GetStringExtra("filmDetails"));
            //List<Uri> list = new List<Uri>();
            //list.Add(filmDetails.characters[0]);
            //list.Add(filmDetails.characters[1]);
            //list.Add(filmDetails.characters[2]);
            //list.Add(filmDetails.characters[3]);
            //list.Add(filmDetails.characters[4]);
            //list.Add(filmDetails.characters[5]);
            //list.Add(filmDetails.characters[6]);
            //list.Add(filmDetails.characters[7]);
            //list.Add(filmDetails.characters[8]);
            //list.Add(filmDetails.characters[9]);
            //list.Add(filmDetails.characters[10]);


            filmNameTextView.Text = filmDetails.Title;
            filmDetailsTextView1.Text = filmDetails.producer;
            filmDetailsTextView2.Text = filmDetails.director;
            //filmDetailsTextView3.Text = filmDetails.characters[0].ToString();
            //filmDetailsTextView4.Text = filmDetails.vehicles.ToString();

        }
    }
}