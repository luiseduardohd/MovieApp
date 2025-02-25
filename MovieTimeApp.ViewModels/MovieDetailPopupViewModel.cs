using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using MovieTimeApp.Constants;
using MovieTimeApp.Extensions;
using MovieTimeApp.Models;
using MovieTimeApp.Services.TheMovieDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
//using Rg.Plugins.Popup.Extensions;
//using MovieTimeApp.Views;

namespace MovieTimeApp.ViewModels
{
    public class MovieDetailPopupViewModel : BaseViewModel
    {

        public MovieDetailPopupViewModel(Movie movie,ICommand closeCommand)
        {
            this.Movie = movie;
            this.CloseCommand = closeCommand;
        }


        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                OnPropertyChanged(nameof(Movie));
            }
        }
        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get { return _closeCommand; }
            set
            {
                _closeCommand = value;
                OnPropertyChanged(nameof(CloseCommand));
            }
        }
    }
}
