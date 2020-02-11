﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MvvmTutorial
{
    public class DoubleRoundingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Round((double)value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Round((double)value, parameter);
        }

        double Round (double number, object parameter)
        {
            double precision = 0.1;
            if (parameter != null)
            {
                precision = double.Parse((string)parameter);
            }
            return precision * Math.Round(number / precision);
        }
    }
}
