using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using StarWarsApp.Core;
using static StarWarsApp.PeopleAdapter;
using static StarWarsApp.StarshipsAdapter;
using static StarWarsApp.PlanetsAdapter;
using Android.Content;
using System;

namespace StarWarsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var searchField = FindViewById<EditText>(Resource.Id.searchBarEditText);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleDataListView);
            var starShipsButton = FindViewById<Button>(Resource.Id.StarShipsButton);
            var planetsButton = FindViewById<Button>(Resource.Id.planetsButton);
            var peopleSearch = FindViewById<Button>(Resource.Id.peopleSearch);

            starShipsButton.Click += StarShips_search;

            void StarShips_search(object sender, EventArgs e) 
            {
                var ShipsActivity = new Intent(this, typeof(StarShipsActivity));
                StartActivity(ShipsActivity);
            };

            peopleSearch.Click += people_Search;

            void people_Search(object sender, EventArgs e)
            {
                var ShipsActivity = new Intent(this, typeof(StarShipsActivity));
                StartActivity(ShipsActivity);
            }

            planetsButton.Click += async delegate
            {
                var queryString = "https://swapi.co/api/planets/";
                var Planetsdata = await DataService.GetStarWarsPlanets(queryString);
                peopleListView.Adapter = new StarWarsPlanetsAdapter(this, Planetsdata.Results);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}