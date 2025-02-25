using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MovieTimeApp.Constants;
using MovieTimeApp.Extensions;
using MovieTimeApp.Models;
using MovieTimeApp.Services.TheMovieDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;


namespace MovieTimeApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        ITheMovieDB theMovieDBService;

        public Movie currentMovie;

        private ObservableCollection<Movie> _nowPlayingMovies;
        public ObservableCollection<Movie> NowPlayingMovies
        {
            get { return _nowPlayingMovies; }
            set
            {
                _nowPlayingMovies = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Movie> _popularMovies;
        public ObservableCollection<Movie> PopularMovies
        {
            get { return _popularMovies; }
            set
            {
                _popularMovies = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Movie> _topRatedmovies;
        public ObservableCollection<Movie> TopRatedMovies
        {
            get { return _topRatedmovies; }
            set
            {
                _topRatedmovies = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Movie> _upcomingMovies;
        public ObservableCollection<Movie> UpcomingMovies
        {
            get { return _upcomingMovies; }
            set
            {
                _upcomingMovies = value;
                OnPropertyChanged();
            }
        }

        private ICommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get { return _RefreshCommand; }
            set
            {
                _RefreshCommand = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        #region CONTRUCTOR
        public MainPageViewModel(ITheMovieDB theMovieDBService)
        {
            this.theMovieDBService = theMovieDBService;
        }
        #endregion


        public async Task InitializeAsync()
        {
            //var ApiUrl = "https://api.themoviedb.org/3/";
            //IsRefreshing = true;
            await LoadAllAsync();
            //IsRefreshing = false;
        }

        #region COMMANDS

        private ICommand _GoToMovieDetailCommand;
        public ICommand GoToMovieDetailCommand
        {
            get { return _GoToMovieDetailCommand; }
            set
            {
                _GoToMovieDetailCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion


        


        public async Task LoadAllAsync()
        {
            await this.TryAsync(LoadNowPlayingMoviesAsync);
            await this.TryAsync(LoadPopularMoviesAsync);
            await this.TryAsync(LoadTopRatedMoviesAsync);
            await this.TryAsync(LoadUpcomingMoviesAsync);
            await Task.Delay(2000);
        }

        private async Task LoadNowPlayingMoviesAsync()
        {
            var response = await theMovieDBService.GetNowPlayingAsync();
            var results = response.Results;
            NowPlayingMovies = new ObservableCollection<Movie>(results);
        }
        private async Task LoadPopularMoviesAsync()
        {
            var response = await theMovieDBService.GetPopularAsync();
            var results = response.Results;
            PopularMovies = new ObservableCollection<Movie>(results);
        }
        private async Task LoadTopRatedMoviesAsync()
        {
            var response = await theMovieDBService.GetTopRatedAsync();
            var results = response.Results;
            TopRatedMovies = new ObservableCollection<Movie>(results);
        }
        private async Task LoadUpcomingMoviesAsync()
        {
            var response = await theMovieDBService.GetUpcomingAsync();
            var results = response.Results;
            UpcomingMovies = new ObservableCollection<Movie>(results);
        }

    }


}

