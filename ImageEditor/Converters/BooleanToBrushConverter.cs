using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace ImageEditor.Converters
{
    public class BooleanToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case 0:
                    return Brushes.Black;
                case 1:
                    return Brushes.White;
                case 2:
                    return Brushes.Red;
                default:
                    return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}