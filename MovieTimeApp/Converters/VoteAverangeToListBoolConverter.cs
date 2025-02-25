using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace MovieTimeApp.Converters
{
    class VoteAverangeToListBoolConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double voteAverange = Double.Parse("" + value) / 2;
            voteAverange = Math.Round(voteAverange, 0);

            var list = Enumerable.Range(1, 5).Select(x => x < voteAverange);

            return list;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
