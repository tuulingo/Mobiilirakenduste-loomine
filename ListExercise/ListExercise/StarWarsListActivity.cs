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
using ListExercise.Core.Oige;
using Microsoft.AspNetCore.JsonPatch.Internal;

namespace ListExercise
{
    [Activity(Label = "StarWarsListActivity")]
    public class StarWarsListActivity : ListActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var queryString = "https://metaweather.com/api/location/search/?query=darth";
            var data = await Core.Oige.DataService.GetStarWarsPeople(queryString);
            var people = data;
            ListAdapter = new StarWarsPeopleAdapter(this, people.Results);
        }
    }
}