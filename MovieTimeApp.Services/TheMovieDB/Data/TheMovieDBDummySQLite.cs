using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using MovieTimeApp.Models;
using SQLite;
using System.Threading;
using NeoSmart.AsyncLock;
using MovieTimeApp.Services.TheMovieDB;

namespace MovieTimeApp.Data
{
    public class TheMovieDBDummySQLite : ITheMovieDB
    {
        public readonly SQLiteAsyncConnection SQLiteAsyncConnection;

        readonly AsyncLock asyncLock = new AsyncLock();

        private bool isInitialized = false;

        public readonly SQLiteAsyncConnection db;

        public TheMovieDBDummySQLite(string dbPath)
        {

            SQLiteAsyncConnection = new SQLiteAsyncConnection(dbPath);
            _ = Task.Run
                (
                    async () =>
                        await InitializeAsync()
                );
        }

        public async Task InitializeAsync()
        {
            using (await asyncLock.LockAsync())
            {
                try
                {
                    if (!isInitialized)
                    {

                        await db.CreateTableAsync<Movie>();
                        await db.CreateTableAsync<Country>( );
                        await db.CreateTableAsync<Genre>();
                        await db.CreateTableAsync<Language>();
                        await db.CreateTableAsync<Movie>();
                        await db.CreateTableAsync<MovieVideo>();
                        await db.CreateTableAsync<MovieVideoItem>();
                        isInitialized = true;
                    }
                }
                catch (Exception Exception)
                {
                    Debug.WriteLine("Exception:" + Exception);
                }
                finally
                {

                }
            }
        }

        public Task<SearchResponse<Movie>> GetNowPlayingAsync(string apiKey = "cb4d810e85f2c4dfa9c14b657b1e1454", string language = "en", int pageNumber = 1)
        {
            //await InitializeAsync();
            //return await SQLiteAsyncConnection.Table<Movie>().ToListAsync();
            throw new NotImplementedException();
        }

        public Task<SearchResponse<Movie>> GetPopularAsync(string apiKey = "cb4d810e85f2c4dfa9c14b657b1e1454", string language = "en", int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        public Task<SearchResponse<Movie>> GetTopRatedAsync(string apiKey = "cb4d810e85f2c4dfa9c14b657b1e1454", string language = "en", int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        public Task<SearchResponse<Movie>> GetUpcomingAsync(string apiKey = "cb4d810e85f2c4dfa9c14b657b1e1454", string language = "en", int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        public Task<MovieVideo> GetVideosAsync(long movieId, string apiKey = "cb4d810e85f2c4dfa9c14b657b1e1454", string language = "en")
        {
            throw new NotImplementedException();
        }
    }
}
