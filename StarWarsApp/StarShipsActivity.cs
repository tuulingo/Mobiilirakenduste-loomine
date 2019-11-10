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
using StarWarsApp.Core;
using static StarWarsApp.StarshipsAdapter;


namespace StarWarsApp
{
    [Activity(Label = "StarShipsActivity")]
    public class StarShipsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var starShipsListView = FindViewById<ListView>(Resource.Id.starShipsListView);

            SetContentView(Resource.Layout.Starships_layout);
            var queryString = "https://swapi.co/api/starships/";
            var Starshipsdata = DataService.GetStarWarsStarships(queryString);
           // starShipsListView.Adapter = new StarWarsShipsAdapter(this, Starshipsdata.Results);
        }
    }
}