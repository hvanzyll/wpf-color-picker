using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Dsafa.WpfColorPicker.Converters
{
    internal class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color color))
                return "error";

            return string.Format("#{0:X}{1:X}{2:X}", color.R, color.G, color.B);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string txt))
                return null;

            if (txt.Length != 7)
                return null;

            if (!txt.StartsWith("#"))
                return null;

            string hex = txt.Substring(1, 2);
            byte r = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            hex = txt.Substring(3, 2);
            byte g = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            hex = txt.Substring(5, 2);
            byte b = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

            return Color.FromRgb(r, g, b);
        }
    }
}