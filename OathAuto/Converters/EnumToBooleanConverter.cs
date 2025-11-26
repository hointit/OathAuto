using System;
using System.Globalization;
using System.Windows.Data;

namespace OathAuto.Converters
{
  /// <summary>
  /// Converts an enum value to a boolean for radio button binding.
  /// The converter parameter should be the enum value to compare against.
  /// </summary>
  public class EnumToBooleanConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null || parameter == null)
        return false;

      return value.ToString().Equals(parameter.ToString(), StringComparison.OrdinalIgnoreCase);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null || parameter == null)
        return null;

      if ((bool)value)
      {
        return Enum.Parse(targetType, parameter.ToString());
      }

      return null;
    }
  }
}
