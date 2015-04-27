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
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

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
        /// Converts a value using flag conversion rules.
        /// </summary>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="convertBoolean">A boolean value indicating whether implicit boolean equivalents should be converted.</param>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static Int32 GetFlagValue(CultureInfo culture, Boolean convertBoolean, String value)
        {
            int intValue;
            bool booleanValue;

            if (convertBoolean && Boolean.TryParse(value ?? String.Empty, out booleanValue))
                return booleanValue ? 1 : 0;

            Int32.TryParse(value ?? String.Empty, NumberStyles.Integer, culture, out intValue);

            return intValue;
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

        /// <summary>
        /// Converts a value to a native equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type to convert the value to.</param>
        /// <param name="convertedValue">The converted value.</param>
        /// <returns>A boolean value indicating whether the conversion succeeded.</returns>
        public static Boolean TryConvertValue(Object value, Type type, out Object convertedValue)
        {
            return TryConvertValue(value, type, null, out convertedValue);
        }

        /// <summary>
        /// Converts a value to a native equivalent.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type to convert the value to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <param name="convertedValue">The converted value.</param>
        /// <returns>A boolean value indicating whether the conversion succeeded.</returns>
        public static Boolean TryConvertValue(Object value, Type type, IFormatProvider formatProvider, out Object convertedValue)
        {
            if (value == null)
            {
                convertedValue = null;
                return false;
            }

            if (value.GetType().IsAssignableFrom(type))
            {
                convertedValue = value;
                return true;
            }

            if (type.IsEnum)
            {
                convertedValue = Enum.ToObject(type, value);
                return true;
            }

            if (value is IConvertible && type.GetInterfaces().Any(x => x == typeof (IConvertible)))
            {
                convertedValue = Convert.ChangeType(value, type, formatProvider);
                return true;
            }

            convertedValue = null;
            return false;
        }

        /// <summary>
        /// Determines the appropriate type-safe default value for a given type.
        /// </summary>
        /// <param name="type">The type to use for conversion.</param>
        /// <param name="typeConverter">The type converter to use.</param>
        /// <param name="defaultValue">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static Object GetDefaultValue(Type type, TypeConverter typeConverter, Object defaultValue)
        {
            Object value = defaultValue;
            if (value != null && !value.GetType().IsAssignableFrom(type))
            {
                value = typeConverter != null && typeConverter.CanConvertFrom(value.GetType())
                    ? typeConverter.ConvertFrom(defaultValue)
                    : null;
            }

            return value;
        }

        /// <summary>
        /// Determines whether a given type supports implicit value conversion.
        /// </summary>
        /// <param name="type">The type to test.</param>
        /// <returns>A boolean value indicating whether the provided value is implicitly convertible.</returns>
        public static Boolean IsConvertible(Type type)
        {
            return type.IsEnum || type.GetInterfaces().Any(x => x == typeof (IConvertible));
        }

        /// <summary>
        /// Extracts the parts out of a value compound from a parameter, representing individual value entries.
        /// </summary>
        /// <param name="parameter">The source parameter to extract from.</param>
        /// <param name="detokenizer">The delegate to use for detokenization.</param>
        /// <param name="culture">The culture to supply the detokenizer delegate.</param>
        /// <returns>The value sub-entries.</returns>
        public static IEnumerable<String> GetCompositeValueParts(RawParameter parameter, Parser.DetokenizerDelegate detokenizer = null, CultureInfo culture = null)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            return parameter.Value == null || parameter.CoupleCount > 1
                ? null
                : Regex.Matches(
                    input: parameter.Value,
                    pattern: Parser.VALUE_PATTERN,
                    options: RegexOptions.ExplicitCapture |
                                RegexOptions.IgnorePatternWhitespace |
                                RegexOptions.CultureInvariant |
                                RegexOptions.Singleline)
                    .OfType<Match>()
                    .Select(m => DetokenizeValue(m.Groups["value"].Value, detokenizer, culture));
        }

        /// <summary>
        /// Detokenizes a given value using a supplied delegate and culture.
        /// </summary>
        /// <param name="value">The input value to detokenize.</param>
        /// <param name="detokenizer">The delegate to use for detokenization.</param>
        /// <param name="culture">The culture to supply the delegate.</param>
        /// <returns>The detokenized value.</returns>
        public static String DetokenizeValue(String value, Parser.DetokenizerDelegate detokenizer = null, CultureInfo culture = null)
        {
            try
            {
                return detokenizer == null
                    ? Parser.DefaultDetokenizer(value, culture)
                    : detokenizer(value, culture);
            }
            catch (Exception ex)
            {
                throw new ValueParsingException(ex);
            }
        }

        /// <summary>
        /// Transforms a supplied value into its bit-field equivalent.
        /// </summary>
        /// <param name="value">The value to use as level.</param>
        /// <returns>The bit-field equivalent of the supplied value.</returns>
        public static Int32 GetBitFieldValue(Int32 value)
        {
            if (value <= 0)
                return 0;

            return 1 << (value - 1);
        }
    }
}
