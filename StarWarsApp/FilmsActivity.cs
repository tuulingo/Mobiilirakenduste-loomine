﻿using System;
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
using StarWarsApp.Core;
using static Android.Widget.AdapterView;
using static StarWarsApp.FilmsAdapter;

namespace StarWarsApp
{
    [Activity(Label = "FilmsActivity")]
    public class FilmsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.search_Layout);

            var searchField = FindViewById<EditText>(Resource.Id.searchBarEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var listView = FindViewById<ListView>(Resource.Id.searchListView);

            searchButton.Click += async delegate
            {
                var searchText = searchField.Text;
                var queryString = "https://swapi.co/api/films/?search=" + searchText;
                var data = await DataService.GetStarWarsFilms(queryString);
                listView.Adapter = new StarWarsFilmsAdapter(this, data.Results);
            };

            listView.ItemClick += async (object sender, ItemClickEventArgs e) =>
            {
                var queryString = "https://swapi.co/api/films/?search=";
                var films = await DataService.GetStarWarsFilms(queryString);
                var filmDetails = films.Results[e.Position];

                var a = Convert.ToString(listView.GetItemIdAtPosition(e.Position));
                var b = Convert.ToString(e.Position);

                Context context = Application.Context;

                ToastLength duration = ToastLength.Short;
                var toast = Toast.MakeText(context , filmDetails.Title, duration);
                toast.Show();

                var Intent = new Intent(this, typeof(FilmDetailsActivity));
                Intent.PutExtra("filmDetails", JsonConvert.SerializeObject(filmDetails));
                StartActivity(Intent);
            };

        }
    }
}