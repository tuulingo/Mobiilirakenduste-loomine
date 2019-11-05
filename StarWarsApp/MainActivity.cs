using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using StarWarsApp.Core;
using static StarWarsApp.PeopleAdapter;

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
            var planetsButton = FindViewById<Button>(Resource.Id.PlanetsButton);

            searchButton.Click += async delegate
            {
                var searchText = searchField.Text;
                var queryString = "https://swapi.co/api/people/?search=" + searchText;
                var Peopledata = await DataService.GetStarWarsPeople(queryString);
                peopleListView.Adapter = new StarWarsPeopleAdapter(this, Peopledata.Results);
            };

            planetsButton.Click += async delegate
            {
                var queryString = "https://swapi.co/api/starships/";
                var Starshipsdata = await DataService.GetStarWarsStarships(queryString);
                peopleListView.Adapter = new StarWarsStarShipsAdapter(this, Starshipsdata.Results);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}