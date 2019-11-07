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
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleDataListView);
            var starShipsButton = FindViewById<Button>(Resource.Id.StarShipsButton);
            var starShipsListView = FindViewById<ListView>(Resource.Id.starShipsListView);
            var planetsButton = FindViewById<Button>(Resource.Id.planetsButton);
           // var StarShips_search +=

            void StarShips_search(object sender, EventArgs e) 
            {
                var ShipsActivity = new Intent(this, typeof(StarShipsActivity));
                this.StartActivity(ShipsActivity);
            }

            searchButton.Click += async delegate
            {
                var searchText = searchField.Text;
                var queryString = "https://swapi.co/api/people/?search=" + searchText;
                var Peopledata = await DataService.GetStarWarsPeople(queryString);
                peopleListView.Adapter = new StarWarsPeopleAdapter(this, Peopledata.Results);
            };

            starShipsButton.Click += async delegate
            {
                SetContentView(Resource.Layout.Starships_layout);
                var queryString = "https://swapi.co/api/starships/";
                var Starshipsdata = await DataService.GetStarWarsStarships(queryString);
                starShipsListView.Adapter = new StarWarsShipsAdapter(this, Starshipsdata.Results);
            };

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