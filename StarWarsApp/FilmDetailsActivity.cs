﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace StarwarsApp
{
    [Activity(Label = "FilmDetailsActivity", Theme = "@style/SecondTheme")]
    public class FilmDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.film_details_layout);

            var filmNameTextView = FindViewById<TextView>(Resource.Id.filmTitleTextView);
            var filmYearTextView = FindViewById<TextView>(Resource.Id.filmYearTextView);
            var filmDescTextView = FindViewById<TextView>(Resource.Id.filmDescTextView);

            var filmDetails = JsonConvert.DeserializeObject<StarWarsApp.Core.Models.Films.Results>(Intent.GetStringExtra("filmDetails"));
            filmNameTextView.Text = filmDetails.Title;
            filmYearTextView.Text = filmDetails.release_date.Year.ToString();
            filmDescTextView.Text = filmDetails.opening_crawl;
        }
    }
}