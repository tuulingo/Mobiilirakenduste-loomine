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
using StarWarsApp.Core;
using static StarWarsApp.PeopleAdapter;

namespace StarWarsApp
{
    [Activity(Label = "PeopleActivity")]
    public class PeopleActivity : Activity
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
                var queryString = "https://swapi.co/api/people/?search=" + searchText;
                var data = await DataService.GetStarWarsPeople(queryString);
                listView.Adapter = new StarWarsPeopleAdapter(this, data.Results);
            };
        }
    }
}