using MovieTimeApp.Constants;
using MovieTimeApp.Models;
using MovieTimeApp.Services.TheMovieDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviewTimeApp.UnitTests
{
    public class TheMovieDBDummy : ITheMovieDB
    {
        public Task<SearchResponse<Movie>> GetNowPlayingAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1)
        {
            var newMovie = new Movie()
            {
                Title = "Title",
                IsAdult = true,
                BackdropPath = "backdrop_path",
                Budget = 1000000,
                //Genres = "genres",
                Homepage = "homepage",
                ImdbId = "imdb_id",
                OriginalLanguage = "original_language",
                OriginalTitle = "original_title",
                Overview = "overview",
                Popularity = 10,
                PosterPath = "poster_path",
                //ProductionCountries = "production_countries",
                //ReleaseDate = "release_date",
                Revenue = 10000000,
                Runtime = 3,
                //SpokenLanguages = "spoken_languages",
                Status = "status",
                Tagline = "tagline",
                HasVideo = true,
                VoteAverage = 4,
                VoteCount = 200,
            };
            var searchResponse = new SearchResponse<Movie>()
            {
                Results = new List<Movie>() { newMovie }
            };
            return Task.FromResult(searchResponse);
        }

        public Task<SearchResponse<Movie>> GetPopularAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1)
        {
            //throw new System.NotImplementedException();
            var newMovie = new Movie()
            {
                Title = "Title",
                IsAdult = true,
                BackdropPath = "backdrop_path",
                Budget = 1000000,
                //Genres = "genres",
                Homepage = "homepage",
                ImdbId = "imdb_id",
                OriginalLanguage = "original_language",
                OriginalTitle = "original_title",
                Overview = "overview",
                Popularity = 10,
                PosterPath = "poster_path",
                //ProductionCountries = "production_countries",
                //ReleaseDate = "release_date",
                Revenue = 10000000,
                Runtime = 3,
                //SpokenLanguages = "spoken_languages",
                Status = "status",
                Tagline = "tagline",
                HasVideo = true,
                VoteAverage = 4,
                VoteCount = 200,
            };
            var searchResponse = new SearchResponse<Movie>()
            {
                Results = new List<Movie>() { newMovie }
            };
            return Task.FromResult(searchResponse);

        }

        public Task<SearchResponse<Movie>> GetTopRatedAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1)
        {
            //throw new System.NotImplementedException();
            var newMovie = new Movie()
            {
                Title = "Title",
                IsAdult = true,
                BackdropPath = "backdrop_path",
                Budget = 1000000,
                //Genres = "genres",
                Homepage = "homepage",
                ImdbId = "imdb_id",
                OriginalLanguage = "original_language",
                OriginalTitle = "original_title",
                Overview = "overview",
                Popularity = 10,
                PosterPath = "poster_path",
                //ProductionCountries = "production_countries",
                //ReleaseDate = "release_date",
                Revenue = 10000000,
                Runtime = 3,
                //SpokenLanguages = "spoken_languages",
                Status = "status",
                Tagline = "tagline",
                HasVideo = true,
                VoteAverage = 4,
                VoteCount = 200,


            };
            var searchResponse = new SearchResponse<Movie>()
            {
                Results = new List<Movie>() { newMovie }
            };
            return Task.FromResult(searchResponse);


        }

        public Task<SearchResponse<Movie>> GetUpcomingAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1)
        {
            var newMovie = new Movie()
            {
                Title = "Title",
                IsAdult = true,
                BackdropPath = "backdrop_path",
                Budget = 1000000,
                //Genres = "genres",
                Homepage = "homepage",
                ImdbId = "imdb_id",
                OriginalLanguage = "original_language",
                OriginalTitle = "original_title",
                Overview = "overview",
                Popularity = 10,
                PosterPath = "poster_path",
                //ProductionCountries = "production_countries",
                //ReleaseDate = "release_date",
                Revenue = 10000000,
                Runtime = 3,
                //SpokenLanguages = "spoken_languages",
                Status = "status",
                Tagline = "tagline",
                HasVideo = true,
                VoteAverage = 4,
                VoteCount = 200,
            };
            var searchResponse = new SearchResponse<Movie>()
            {
                Results = new List<Movie>() { newMovie }
            };
            return Task.FromResult(searchResponse);
        }

        public Task<MovieVideo> GetVideosAsync(long movieId, string apiKey = AppConstants.ApiKey, string language = "en")
        {
            //throw new System.NotImplementedException();
            var VideoItem = new MovieVideoItem()
            {
                Key = "key",
                Name = "name",
                Site = "site",
                Size = 10,
                Type = "type"
            };
            var MovieVideo = new MovieVideo()
            {
                Id = 0,
                Videos = new List<MovieVideoItem>()

            };
            return Task.FromResult(MovieVideo);

        }
    }
}
