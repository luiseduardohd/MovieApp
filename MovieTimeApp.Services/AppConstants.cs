using System;

namespace MovieTimeApp.Constants
{
    public static class AppConstants
    {
        public const string ApiKey = "cb4d810e85f2c4dfa9c14b657b1e1454";
        public const string ApiUrl = "https://api.themoviedb.org/3";

        public const string DBFileName = "MovieTimeApp";
        public const string DBFileExtension = "db3";
        public static string DBCompleteFileExtension { get => $"{DBFileName}.{DBFileExtension}"; }

        public const string YouTubeUrl = "https://www.youtube.com/watch?v=";
    }
}
