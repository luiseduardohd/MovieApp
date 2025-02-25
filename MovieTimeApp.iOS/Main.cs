using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Foundation;
using UIKit;

namespace MovieTimeApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
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
