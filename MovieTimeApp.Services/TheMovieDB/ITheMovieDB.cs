using System;
using System.Threading.Tasks;
using Refit;
using MovieTimeApp.Constants;
using MovieTimeApp.Models;

namespace MovieTimeApp.Services.TheMovieDB
{
    public interface ITheMovieDB
    {

        [Get("/movie/now_playing?api_key={apiKey}&language={language}&page={pageNumber}")]
        Task<SearchResponse<Movie>> GetNowPlayingAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1);

        [Get("/movie/popular?api_key={apiKey}&language={language}&page={pageNumber}")]
        Task<SearchResponse<Movie>> GetPopularAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1);

        [Get("/movie/top_rated?api_key={apiKey}&language={language}&page={pageNumber}")]
        Task<SearchResponse<Movie>> GetTopRatedAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1);

        [Get("/movie/upcoming?api_key={apiKey}&language={language}&page={pageNumber}")]
        Task<SearchResponse<Movie>> GetUpcomingAsync(string apiKey = AppConstants.ApiKey, string language = "en", int pageNumber = 1);

        [Get("/movie/{movieId}/videos?api_key={apiKey}&language={language}")]
        Task<MovieVideo> GetVideosAsync(long movieId,string apiKey = AppConstants.ApiKey, string language = "en");

    }
}
