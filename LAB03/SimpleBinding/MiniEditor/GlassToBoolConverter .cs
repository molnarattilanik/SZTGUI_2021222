using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MiniEditor
{
    public class GlassToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string to bool
            if ((string)value == "igen")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool to string

            if ((bool)value)
            {
                return "igen";
            }
            else
            {
                return "nem";
            }

            throw new NotImplementedException();
        }
    }
}
