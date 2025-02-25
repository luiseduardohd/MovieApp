using System;
using System.Collections.Generic;
using System.Windows.Input;
using MovieTimeApp.Models;
using Xamarin.Forms;

namespace MovieTimeApp
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage(Movie movie, ICommand closeCommand = default(ICommand))
        {
            InitializeComponent();
            this.BindingContext = this;
            this.Movie = movie;
            this.CloseCommand = closeCommand;

            if( this.CloseCommand ==  default )
            {
                this.CloseCommand = new Command(
                    async () =>
                    {
                        await Navigation.PopAsync();
                    }
                );
            }
        }
        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get { return _closeCommand; }
            set
            {
                _closeCommand = value;
                OnPropertyChanged();
            }
        }


        public void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        //Close
        public async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PopAsync();
            await DisplayAlert("Action", "Closed", "Ok");
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