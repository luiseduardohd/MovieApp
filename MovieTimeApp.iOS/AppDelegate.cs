using System;
using System.Collections.Generic;
using System.Linq;
using Sharpnado.MaterialFrame.iOS;

using Foundation;
using UIKit;
using System.Threading.Tasks;
using Acr.UserDialogs;
using ObjCRuntime;
using System.Runtime.ExceptionServices;

namespace MovieTimeApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Runtime.MarshalManagedException += (object sender, MarshalManagedExceptionEventArgs args) =>
            {
                Console.WriteLine("Marshaling managed exception");
                Console.WriteLine("    Exception: {0}", args.Exception);
                Console.WriteLine("    Mode: {0}", args.ExceptionMode);

            };
            Runtime.MarshalObjectiveCException += (object sender, MarshalObjectiveCExceptionEventArgs args) =>
            {
                Console.WriteLine("Marshaling Objective-C exception");
                Console.WriteLine("    Exception: {0}", args.Exception);
                Console.WriteLine("    Mode: {0}", args.ExceptionMode);
            };
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            Rg.Plugins.Popup.Popup.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            global::Xamarin.Forms.Forms.Init();

            iOSMaterialFrameRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        static async void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
        {
            var exception = e.Exception;
            Console.WriteLine("FirstChanceException event raised in {0}: {1}",
                AppDomain.CurrentDomain.FriendlyName, exception.Message);
            await UserDialogs.Instance.AlertAsync("Error", "" + exception.Message, "Ok");
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
