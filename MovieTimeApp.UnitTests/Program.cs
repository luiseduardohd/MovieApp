using System;
using NUnit;
using NUnitLite;

namespace MovieTimeApp.UnitTests
{
    class Program
    {
        public static int Main(string[] args)
        {
            var result = new AutoRun().Execute(args);
            Console.ReadLine();
            return result;
        }
    }
}
