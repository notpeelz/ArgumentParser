//-----------------------------------------------------------------------
// <copyright file="StringArrayConverter.cs" company="LouisTakePILLz">
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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArgumentParser.Helpers
{
    /// <summary>
    /// Provides a type converter to convert a string of character-separated values to and from an array of strings.
    /// </summary>
    public class StringArrayConverter : TypeConverter
    {
        private readonly String separator;
        private readonly StringSplitOptions splitOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Helpers.StringArrayConverter"/> class.
        /// </summary>
        /// <param name="options">The <see cref="T:System.StringSplitOptions"/> policy to use for splitting strings.</param>
        public StringArrayConverter(StringSplitOptions options = StringSplitOptions.None)
        {
            this.splitOptions = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Helpers.StringArrayConverter"/> class.
        /// </summary>
        /// <param name="separator">The separator <see cref="T:System.String"/> used to override the one provided by the culture.</param>
        /// <param name="options">The <see cref="T:System.StringSplitOptions"/> policy to use for splitting strings.</param>
        public StringArrayConverter(String separator, StringSplitOptions options = StringSplitOptions.None)
        {
            this.separator = separator;
            this.splitOptions = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Helpers.StringArrayConverter"/> class.
        /// </summary>
        /// <param name="separator">The separator <see cref="T:System.Char"/> used to override the one provided by the culture.</param>
        /// <param name="options">The <see cref="T:System.StringSplitOptions"/> policy to use for splitting strings.</param>
        public StringArrayConverter(Char separator, StringSplitOptions options = StringSplitOptions.None)
        {
            this.separator = separator.ToString();
            this.splitOptions = options;
        }

        /// <summary>
        /// Determines whether this converter can convert a given source type to the native type of the converter.
        /// </summary>
        /// <returns>A boolean value indicating whether this type can be converted to a <see cref="T:System.String"/> array.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> object that provides a format context.</param>
        /// <param name="sourceType">The source <see cref="T:System.Type"/> to test.</param>
        public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof (String);
        }

        /// <summary>
        /// Determines whether this converter can convert a given destination type from the native type of the converter.
        /// </summary>
        /// <returns>A boolean value indicating whether a <see cref="T:System.String"/> can be converted to this type.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> object that provides a format context.</param>
        /// <param name="destinationType">The destination <see cref="T:System.Type"/> to test.</param>
        public override Boolean CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof (String[]);
        }

        /// <summary>
        /// Converts the specified object to a <see cref="T:System.String"/> array, using the specified context and culture information.
        /// </summary>
        /// <returns>An <see cref="T:System.Object"/> that represents the converted value.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed.</exception>
        public override Object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value)
        {
            String source = value as String;
            if (source == null)
                throw this.GetConvertFromException(value);

            if (source.Length == 0)
                return new String[0];

            String separator = Regex.Escape(this.separator ?? Regex.Escape((culture ?? CultureInfo.InvariantCulture).TextInfo.ListSeparator));
            String[] names = Regex.Split(source, @"(?<!\\)" + separator, RegexOptions.Singleline | RegexOptions.CultureInvariant);

            return this.splitOptions == StringSplitOptions.RemoveEmptyEntries
                ? names.Where(x => !String.IsNullOrEmpty(x)).ToArray()
                : names;
        }

        /// <summary>
        /// Converts the specified object to the specified <see cref="T:System.Type"/>, using the specified context and culture information.
        /// </summary>
        /// <returns>An <see cref="T:System.Object"/> that represents the converted value.</returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> object that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the object to.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null.</exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed.</exception>
        public override Object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, Object value, Type destinationType)
        {
            if (destinationType != typeof (String))
                throw this.GetConvertToException(value, destinationType);

            String separator = this.separator ?? (culture ?? CultureInfo.InvariantCulture).TextInfo.ListSeparator;

            return value == null
                ? String.Empty
                : String.Join(separator, ((String[]) value).Select(x => x.Replace(separator, @"\" + separator)));
        }
    }
}
