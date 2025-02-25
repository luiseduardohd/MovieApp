using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
//using ;

namespace MovieTimeApp.Droid
{
    [Activity(Label = "MovieTimeApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            UserDialogs.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        static async void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            var exception = e.Exception;
            Console.WriteLine("FirstChanceException event raised in {0}: {1}",
                AppDomain.CurrentDomain.FriendlyName, exception.Message);
            await UserDialogs.Instance.AlertAsync("Error", "" + exception.Message, "Ok");
        }
        private async void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            var exception = e.Exception;
            Console.WriteLine("MyHandler caught : " + exception.Message);
            await UserDialogs.Instance.AlertAsync("Error", "" + exception.Message, "Ok");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }

        private static async void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var exception = unobservedTaskExceptionEventArgs.Exception;
            Console.WriteLine("MyHandler caught : " + exception.Message);
            await UserDialogs.Instance.AlertAsync("Error", "" + exception.Message, "Ok");
        }

        static async void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception exception = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + exception.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
            await UserDialogs.Instance.AlertAsync("Error", "" + exception.Message, "Ok");
        }

    }
}