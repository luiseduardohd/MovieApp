using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using MovieTimeApp.Constants;
using MovieTimeApp.Models;
using MovieTimeApp.Services.TheMovieDB;
using MoviewTimeApp.UnitTests;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace MovieTimeApp
{
    public partial class App : Application
    {
        public App()
        {
            Xamarin.Forms.Internals.Log.Listeners.Add(new DelegateLogListener((arg1, arg2) => Debug.WriteLine(arg2)));

            InitializeComponent();

            Sharpnado.MaterialFrame.Initializer.Initialize(loggerEnable: false, debugLogEnable: false);

            var theMovieDBService = RestService.For<ITheMovieDB>(new HttpClient(new CustomHttpMessageHandler(new HttpClientHandler()))
            {
                BaseAddress = new Uri(AppConstants.ApiUrl)
            }
            ,
            new RefitSettings(
                new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }
                    )
                )
            );

            //var theMovieDBService = new TheMovieDBDummy();

            var mainPage = new MainPage(theMovieDBService);

            MainPage = new NavigationPage(mainPage)
            {
                BarBackgroundColor = Color.FromHex("#1A1A1A"),
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
