
using System.Diagnostics;
using System.Windows.Input;
using MovieTimeApp.Models;
using Xamarin.Forms;

namespace MovieTimeApp
{
    public partial class MovieDetailView : ContentView
    {
        public static readonly BindableProperty MovieProperty = BindableProperty.Create(nameof(Movie), typeof(Movie), typeof(MovieDetailView), default(Movie), BindingMode.TwoWay, null, MoviePropertyChanged);

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

        public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(MovieDetailView), default(ICommand), BindingMode.TwoWay, null, CloseCommandPropertyChanged);

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

        public MovieDetailView()
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
        public MovieDetailView(Movie movie, ICommand CloseCommand)
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


        public void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        //Close
        public void CloseEventHandler(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PopAsync();
            //await DisplayAlert("Action", "Closed", "Ok");
            CloseCommand?.Execute(null);
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