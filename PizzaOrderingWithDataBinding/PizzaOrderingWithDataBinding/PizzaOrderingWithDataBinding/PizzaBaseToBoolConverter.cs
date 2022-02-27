using System;
using System.Globalization;
using System.Windows.Data;

namespace PizzaOrderingWithDataBinding
{
    public class PizzaBaseToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == "paradicsomos" ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "paradicsomos" : "tejfölös";
        }
    }
}
