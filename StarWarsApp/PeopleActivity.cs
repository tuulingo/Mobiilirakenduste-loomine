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

namespace StarWarsApp
{
    [Activity(Label = "PeopleActivity")]
    public class PeopleActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //var peopleSearch = FindViewById<Button>(Resource.Id.peopleSearch);
            //var searchField = FindViewById<EditText>(Resource.Id.searchBarEditText);
            //var peopleListView = FindViewById<ListView>(Resource.Id.peopleDataListView);

            //var searchText = searchField.Text;
            //var queryString = "https://swapi.co/api/people/?search=" + searchText;
            //var Peopledata = await DataService.GetStarWarsPeople(queryString);
            //peopleListView.Adapter = new StarWarsPeopleAdapter(this, Peopledata.Results);
        }
    }
}