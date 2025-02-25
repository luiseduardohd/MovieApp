using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace MovieTimeApp
{
    public class VoteAverangeToFormattedTextStarsConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double voteAverange = Double.Parse("" + value);
            voteAverange = Math.Round(voteAverange, 0);
            var formattedString = new FormattedString();

            for (int i = 1; i <= 10; i += 2)
            {
                var span = new Span { Text = "★", TextColor = (i < voteAverange) ? Color.Yellow : Color.White, FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
                formattedString.Spans.Add(span);
            }

            return formattedString;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
