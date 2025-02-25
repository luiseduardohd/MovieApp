using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MovieTimeApp.Constants;
using MovieTimeApp.Models;
using MovieTimeApp.Services.TheMovieDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MovieTimeApp.Views.ContentViews
{
    public partial class PopupView : ContentView
    {
        public static readonly BindableProperty MovieProperty = BindableProperty.Create(nameof(Movie), typeof(Movie), typeof(PopupView), default(Movie), BindingMode.TwoWay, null, MoviePropertyChanged);

        public Movie Movie
        {
            get
            {
                var val = GetValue(MovieProperty);
                var movie = val as Movie;
                return movie;
            }
            set => SetValue(MovieProperty, value);
        }
        private static void MoviePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Debug.WriteLine("oldValue:" + oldValue);
            Debug.WriteLine("newValue:" + newValue);
        }

        public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(PopupView), default(ICommand), BindingMode.TwoWay, null, CloseCommandPropertyChanged);

        public ICommand CloseCommand
        {
            get
            {
                var val = GetValue(CloseCommandProperty);
                var command = val as ICommand;
                return command;
            }
            set => SetValue(CloseCommandProperty, value);
        }
        private static void CloseCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Debug.WriteLine("oldValue:" + oldValue);
            Debug.WriteLine("newValue:" + newValue);
        }

        public PopupView()
        {
            InitializeComponent();
            //this.Movie = new Movie();
            //this.CloseCommand = new Command(o=>{ });
            //this.BindingContext = this.Movie;
            Content.BindingContext = this;
        }

        protected void OnAppearing()
        {

        }
        /*
        public PopupView(Movie movie, ICommand CloseCommand)
        {
            InitializeComponent();
            this.Movie = movie;
            this.CloseCommand = CloseCommand;
            this.BindingContext = this.Movie;
        }*/

        /*
        private Movie _movie;
        public Movie Movie
        {
            get {
                return _movie;
            }
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }*/



        //Close
        public void CloseEventHandler(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PopAsync();
            //await DisplayAlert("Action", "Closed", "Ok");
            CloseCommand?.Execute(null);
        }

        //Close
        public async void ViewTrailerHandler(System.Object sender, System.EventArgs e)
        {
            try
            {
                await ViewTrailer();
            }
            catch (Exception exception)
            {
                await UserDialogs.Instance.AlertAsync("Error", "" + exception.Message, "Ok");
            }
        }
        public async Task ViewTrailer()
        {
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

            var videos = await theMovieDBService.GetVideosAsync(Movie.Id);

            var youtubeVideos = videos.Videos.Where( video => video.Site == "YouTube" );

            if ( youtubeVideos.Any() )
            {
                var video = youtubeVideos.FirstOrDefault();
                var videUrl = string.Format("{0}{1}", AppConstants.YouTubeUrl, video?.Key);
                await Browser.OpenAsync(videUrl, BrowserLaunchMode.SystemPreferred);
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Error", "No video available", "Ok");
            }
        }

        public void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
        }

        void TapGestureRecognizer_Tapped_2(System.Object sender, System.EventArgs e)
        {
        }

        void TapGestureRecognizer_Tapped_3(System.Object sender, System.EventArgs e)
        {
        }
    }
}