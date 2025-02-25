//using DryIoc;
using MovieTimeApp;
using MovieTimeApp.Constants;
using MovieTimeApp.Models;
using MovieTimeApp.Services.TheMovieDB;
using MoviewTimeApp.UnitTests;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace MovieTimeApp.UnitTests
{
    public class Tests
    {
        //private IContainer _container;
        private IUnityContainer _container;
        [SetUp]
        public void Setup()
        {

            //_container = new Container();
            //_container.Register<ITheMovieDB, TheMovieDBDummy>();

            _container = new UnityContainer();
            _container.RegisterType<ITheMovieDB, TheMovieDBDummy>();
            //_container.RegisterType<ITheMovieDB>();
            //_container.RegisterType<ITheMovieDB>(new ContainerControlledLifetimeManager(), new InjectionFactory(CreateClient));
        }
        private static ITheMovieDB CreateClient(IUnityContainer container)
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
            return theMovieDBService;
        }
#if !DEBUG
        [Test]
        public void Test1()
        {
            Assert.Pass();
            //Assert.Fail();
        }
#endif
        [Test]
        public void TestGetNowPlayingAsync()
        {
            //var iTheMoviewDB = new TheMovieDBDummy(); 
            var iTheMovieDB = _container.Resolve<ITheMovieDB>();

            var result = iTheMovieDB.GetNowPlayingAsync();

            Assert.NotNull(result);
        }


        [Test]
        public void TestGetPopularAsync()
        {
            //var iTheMoviewDB = new TheMovieDBDummy(); 
            var iTheMovieDB = _container.Resolve<ITheMovieDB>();

            var result = iTheMovieDB.GetPopularAsync();

            Assert.NotNull(result);
        }

        [Test]
        public void TestGetTopRatedAsync()
        {
            //var iTheMoviewDB = new TheMovieDBDummy(); 
            var iTheMovieDB = _container.Resolve<ITheMovieDB>();

            var result = iTheMovieDB.GetTopRatedAsync();

            Assert.NotNull(result);
        }

        [Test]
        public void TestGetUpcomingAsync()
        {
            //var iTheMoviewDB = new TheMovieDBDummy(); 
            var iTheMovieDB = _container.Resolve<ITheMovieDB>();

            var result = iTheMovieDB.GetUpcomingAsync();

            Assert.NotNull(result);
        }

        [Test]
        public void TestGetVideosAsync()
        {
            //var iTheMoviewDB = new TheMovieDBDummy(); 
            var iTheMovieDB = _container.Resolve<ITheMovieDB>();

            var result = iTheMovieDB.GetVideosAsync(0);

            Assert.NotNull(result);
            
        }


    }

    
}