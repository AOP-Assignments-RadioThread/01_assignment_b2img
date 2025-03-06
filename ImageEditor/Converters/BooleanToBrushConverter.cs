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
                case 3:
                    return Brushes.Green;
                case 4:
                    return Brushes.Blue;
                case 5:
                    return Brushes.Yellow;
                case 6:
                    return Brushes.Magenta;
                case 7:
                    return Brushes.Cyan;
                case 8:
                    return Brushes.Gray;
                case 9:
                    return Brushes.DarkRed;
                case 10:
                    return Brushes.DarkGreen;
                case 11:
                    return Brushes.DarkBlue;
                case 12:
                    return Brushes.Orange;
                case 13:
                    return Brushes.Pink;
                case 14:
                    return Brushes.Brown;
                case 15:
                    return Brushes.Purple;
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