//-----------------------------------------------------------------------
// <copyright file="ValueConverter.cs" company="LouisTakePILLz">
// Copyright © 2017 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/*
 * Copyright 2017 LouisTakePILLz
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
        /// <param name="type">The type to convert the value to.</param>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static Object ConvertValue(Type type, Object value)
        {
            return ConvertValue(type, null, value);
        }

        /// <summary>
        /// Converts a value to a native equivalent using the the specified <see cref="T:System.IFormatProvider"/>.
        /// </summary>
        /// <param name="type">The type to convert the value to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static Object ConvertValue(Type type, IFormatProvider formatProvider, Object value)
        {
            if (value == null)
                return null;

            if (value.GetType().GetTypeInfo().IsAssignableFrom(type))
                return value;

            if (type.GetTypeInfo().IsEnum)
                return Enum.ToObject(type, value);

            if (value is IConvertible && type.GetTypeInfo().GetInterface(nameof(IConvertible)) != null)
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

            if (value.GetType().GetTypeInfo().IsAssignableFrom(type))
            {
                convertedValue = value;
                return true;
            }

            if (type.GetTypeInfo().IsEnum)
            {
                convertedValue = Enum.ToObject(type, value);
                return true;
            }

            if (value is IConvertible && type.GetTypeInfo().GetInterface(nameof(IConvertible)) != null)
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
            if (value != null && !value.GetType().GetTypeInfo().IsAssignableFrom(type))
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
            return type.GetTypeInfo().IsEnum || type.GetTypeInfo().GetInterface(nameof(IConvertible)) != null;
        }

        /// <summary>
        /// Extracts the parts out of a value compound from a parameter, representing individual value entries.
        /// </summary>
        /// <param name="parameter">The source parameter to extract from.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="culture">The culture to supply the preprocessor delegate.</param>
        /// <returns>The value sub-entries.</returns>
        public static IEnumerable<String> GetCompositeValueParts(RawParameter parameter, PreprocessorDelegate preprocessor = null, CultureInfo culture = null)
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
                    .Select(m => PreprocessValue(m.Groups["value"].Value, preprocessor, culture));
        }

        /// <summary>
        /// Preprocesses a given value using a supplied delegate and culture.
        /// </summary>
        /// <param name="value">The input value to preprocess.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="culture">The culture to supply the delegate.</param>
        /// <returns>The preprocessed value.</returns>
        public static String PreprocessValue(String value, PreprocessorDelegate preprocessor = null, CultureInfo culture = null)
        {
            try
            {
                return preprocessor == null
                    ? Parser.DefaultPreprocessor(value, culture)
                    : preprocessor(value, culture);
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
