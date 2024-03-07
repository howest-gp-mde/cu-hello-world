using HelloWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HelloWorld.Converters
{
    public class ItemStateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemState = (ItemState)value;

            switch(itemState)
            {
                case ItemState.New:
                    return Color.Green;
                case ItemState.Used:
                    return Color.GreenYellow;
                case ItemState.Damaged:
                    return Color.Orange;
                case ItemState.Broken:
                    return Color.Red;
                default:
                    return Color.Purple;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
