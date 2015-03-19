//-----------------------------------------------------------------------
// <copyright file="ValueConverter.cs" company="LouisTakePILLz">
// Copyright © 2015 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/*
 * This program is free software: you can redistribute it and/or modify it under the terms of
 * the GNU General Public License as published by the Free Software Foundation, either
 * version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ArgumentParser.Helpers
{
    /// <summary>
    /// Provides static methods for type conversion using a <see cref="T:System.String"/>.
    /// </summary>
    public static class ValueConverter
    {
        /// <summary>
        /// Converts a value to a given type using a type converter and the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <typeparam name="T">The type of the returned value.</typeparam>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="typeConverter">The type converter to use to for conversion.</param>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        public static T GetValue<T>(CultureInfo culture, TypeConverter typeConverter, String value)
        {
            if (typeof (T) == typeof (String))
                return (T) (Object) value;

            if (typeof (T) == typeof (Char))
                return (T) (Object) value.SingleOrDefault();

            if (String.IsNullOrWhiteSpace(value)
                || typeConverter == null
                || !typeConverter.CanConvertFrom(typeof (String))
                || !typeConverter.CanConvertTo(typeof (T)))
                return default (T);

            return (T) typeConverter.ConvertFromString(null, culture, value);
        }

        /// <summary>
        /// Converts a value to a native equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type to convert the value to.</param>
        /// <returns>The converted value.</returns>
        public static Object ConvertValue(Object value, Type type)
        {
            return ConvertValue(value, type, null);
        }

        /// <summary>
        /// Converts a value to a native equivalent using the the specified <see cref="T:System.IFormatProvider"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type to convert the value to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <returns>The converted value.</returns>
        public static Object ConvertValue(Object value, Type type, IFormatProvider formatProvider)
        {
            if (value == null)
                return null;

            if (value.GetType().IsAssignableFrom(type))
                return value;

            if (type.IsEnum)
                return Enum.ToObject(type, value);

            if (value is IConvertible && type.GetInterfaces().Any(x => x == typeof (IConvertible)))
                return Convert.ChangeType(value, type, formatProvider);

            return value;
        }
    }
}
