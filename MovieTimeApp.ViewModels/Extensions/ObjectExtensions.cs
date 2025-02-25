using System;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace MovieTimeApp.Extensions
{
    public static class ObjectExtensions
    {

        public static async Task TryAsync(this object objectExtension, Func<Task> func)
        {
            try
            {
                await func?.Invoke();
            }
            catch (Exception exception)
            {
                await UserDialogs.Instance.AlertAsync("Error", "" + exception.Message, "Ok");
            }
        }
    }
}
