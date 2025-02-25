using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Extensions;
using MovieTimeApp.Models;
using MovieTimeApp.Services;
using Refit;
using MovieTimeApp.Services.TheMovieDB;
using MovieTimeApp.Constants;
using Acr.UserDialogs;
using System.Windows.Input;
using MovieTimeApp.ViewModels;

namespace MovieTimeApp
{
    public partial class MainPage : ContentPage
    {

        ITheMovieDB theMovieDBService;

        public Movie currentMovie;

        public MainPageViewModel MainPageViewModel;

        public MainPage(ITheMovieDB theMovieDB)
        {
            InitializeComponent();
            this.theMovieDBService = theMovieDB;
            MainPageViewModel = new MainPageViewModel(theMovieDBService);
            MainPageViewModel.GoToMovieDetailCommand = new Command(async (movie) => await GoToMovieDetailAsync(movie as Movie));
            MainPageViewModel.RefreshCommand = new Command(async () =>
            {
                //Because of an specific android emulator issue
                //mainPageViewModel.IsRefreshing = true;
                //await mainPageViewModel.InitializeAsync();
                //mainPageViewModel.IsRefreshing = false;

                await LoadAllWithLoadingAsync();
            });
            BindingContext = MainPageViewModel;
        }

        protected override async void OnAppearing()
        {
            //var viewModel = BindingContext as MainPageViewModel;
            //Because of an specific android emulator issue
            //await viewModel.InitializeAsync();
            /*
            using (var loading = UserDialogs.Instance.Loading())
            {
                await viewModel.InitializeAsync();
            }
            */
            await MainPageViewModel.LoadAllAsync();
        }

        private async Task LoadAllWithLoadingAsync()
        {
            //Because of an specific android emulator issue
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    MainPageViewModel.IsRefreshing = true;
                    await MainPageViewModel.LoadAllAsync();
                    MainPageViewModel.IsRefreshing = false;
                    break;
                case Device.Android:
                    using (var loading = UserDialogs.Instance.Loading())
                    {
                        await MainPageViewModel.LoadAllAsync();
                    }
                    break;
                default:
                    await MainPageViewModel.LoadAllAsync();
                    break;
            }
        }

        public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var previousMovie = e.PreviousSelection?.ElementAtOrDefault(0) as Movie;
            currentMovie = e.CurrentSelection?.ElementAtOrDefault(0) as Movie;

            if (currentMovie != null)
            {
                NowPlayingCollectionView.SelectedItems.Clear();
                NowPlayingCollectionView.SelectedItem = null;
                PopularCollectionView.SelectedItems.Clear();
                PopularCollectionView.SelectedItem = null;
                TopRatedCollectionView.SelectedItems.Clear();
                TopRatedCollectionView.SelectedItem = null;
                UpcomingCollectionView.SelectedItems.Clear();
                UpcomingCollectionView.SelectedItem = null;
            }
        }

        public async Task GoToMovieDetailAsync(Movie movie)
        {
            await GoToMovieDetailPopupAsync(movie);
        }

        public async Task GoToMovieDetailPageAsync(Movie movie)
        {

            var page = new MovieDetailPage(movie);
            await Navigation.PushAsync(page);
        }

        public async Task GoToMovieDetailPopupAsync(Movie movie)
        {
            var popup = new MovieDetailPopup(movie);
            await Navigation.PushPopupAsync(popup);
        }
    }
}
