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
using static StarWarsApp.PlanetsAdapter;

namespace StarWarsApp
{
    [Activity(Label = "PlanetsActivity")]
    public class PlanetsActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

                var queryString = "https://swapi.co/api/planets/";
                var Planetsdata = await DataService.GetStarWarsPlanets(queryString);
                //peopleListView.Adapter = new StarWarsPlanetsAdapter(this, Planetsdata.Results);
            
        }
    }
}