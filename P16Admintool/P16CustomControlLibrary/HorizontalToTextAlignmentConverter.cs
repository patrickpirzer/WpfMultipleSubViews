using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace P16CustomControlLibrary
{
    /// <summary>
    /// Class for conversion of type HorizontalAlignment to TextAlignment and back.
    /// </summary>
    public class HorizontalToTextAlignmentConverter : IValueConverter
    {
        /// <summary>
        /// Converts from type HorizontalAlignment to TextAlignment.
        /// </summary>
        /// <param name="value">The value which was created by the bindingsource.</param>
        /// <param name="targetType">The type of the bindingtarget-property.</param>
        /// <param name="parameter">The convertparameter wich shall be used.</param>
        /// <param name="culture">The culture which shall be used in the converter.</param>
        /// <returns>Returns an object of type object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextAlignment textAlignment;

            switch ((HorizontalAlignment)value)
            {
                case HorizontalAlignment.Left:
                    textAlignment = TextAlignment.Left;
                    break;
                case HorizontalAlignment.Center:
                    textAlignment = TextAlignment.Center;
                    break;
                case HorizontalAlignment.Right:
                    textAlignment = TextAlignment.Right;
                    break;
                default:
                    textAlignment = TextAlignment.Justify;
                    break;
            }

            return textAlignment;
        }

        /// <summary>
        /// Converts from type TextAlignment to HorizontalAlignment.
        /// </summary>
        /// <param name="value">The value which was created by the bindingtarget.</param>
        /// <param name="targetType">The type to which shall be converted.</param>
        /// <param name="parameter">The convertparameter which shall be used.</param>
        /// <param name="culture">The culture which shall be used in the converter.</param>
        /// <returns>Returns an object of type object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HorizontalAlignment horizontalAlignment;

            switch ((TextAlignment)value)
            {
                case TextAlignment.Left:
                    horizontalAlignment = HorizontalAlignment.Left;
                    break;
                case TextAlignment.Center:
                    horizontalAlignment = HorizontalAlignment.Center;
                    break;
                case TextAlignment.Right:
                    horizontalAlignment = HorizontalAlignment.Right;
                    break;
                default:
                    horizontalAlignment = HorizontalAlignment.Stretch;
                    break;
            }

            return horizontalAlignment;
        }

    }
}
