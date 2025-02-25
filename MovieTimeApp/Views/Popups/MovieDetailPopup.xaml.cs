using System;
using System.Collections.Generic;
using System.Windows.Input;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using MovieTimeApp.Models;
using MovieTimeApp.ViewModels;
using Xamarin.Forms;

namespace MovieTimeApp
{
    public partial class MovieDetailPopup : PopupPage
    {
        public MovieDetailPopup(Movie movie)
        {
            InitializeComponent();

            ICommand closeCommand = new Command(async () => await Navigation.PopPopupAsync() );

            BindingContext = new MovieDetailPopupViewModel(movie, closeCommand);
        }
    }
}