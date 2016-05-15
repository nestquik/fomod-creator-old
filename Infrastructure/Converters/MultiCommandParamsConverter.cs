﻿using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace FomodInfrastructure.Converters
{
    public class MultiCommandParamsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}