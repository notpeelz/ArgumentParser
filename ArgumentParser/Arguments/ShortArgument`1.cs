//-----------------------------------------------------------------------
// <copyright file="ShortArgument`1.cs" company="LouisTakePILLz">
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
using ArgumentParser.Helpers;

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents a short argument (argument with a single-character tag) of a defined value type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public abstract class ShortArgument<T> : IArgument<T>
    {
        private ShortArgument(TypeConverter typeConverter, T defaultValue, ValueOptions valueOptions)
        {
            this.TypeConverter = typeConverter ?? TypeDescriptor.GetConverter(typeof (T));
            this.DefaultValue = defaultValue;
            this.ValueOptions = valueOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.ShortArgument`1"/> class.
        /// </summary>
        /// <param name="prefix">The prefix to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="tag">The tag to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected ShortArgument(String prefix, Char tag, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, T defaultValue = default (T))
            : this(typeConverter, defaultValue, valueOptions)
        {
            this.Key = new Key(prefix, tag.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.ShortArgument`1"/> class.
        /// </summary>
        /// <param name="prefix">The prefix to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="tag">The tag to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected ShortArgument(String prefix, Char tag, String description, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, T defaultValue = default (T))
            : this(prefix, tag, valueOptions, typeConverter, defaultValue)
        {
            this.Description = description;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Key"/> representing the argument.
        /// </summary>
        public Key Key { get; private set; }

        /// <summary>
        /// Gets the description of the argument.
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        public ValueOptions ValueOptions { get; private set; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        public T DefaultValue { get; private set; }

        /// <summary>
        /// Gets the value type of the argument.
        /// </summary>
        public Type Type { get { return typeof (T); } }

        /// <summary>
        /// Gets the <see cref="T:System.ComponentModel.TypeConverter"/> to use for conversion.
        /// </summary>
        protected TypeConverter TypeConverter { get; private set; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        Object IArgument.DefaultValue
        {
            get { return this.DefaultValue; }
        }

        /// <summary>
        /// Converts a value to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        public virtual T GetValue(CultureInfo culture, String value)
        {
            return ValueConverter.GetValue<T>(culture, this.TypeConverter, value);
        }

        /// <summary>
        /// Converts a value to the type of the argument.
        /// </summary>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        public virtual T GetValue(String value)
        {
            return this.GetValue(null, value);
        }

        /// <summary>
        /// Converts a value to the type of the argument.
        /// </summary>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        Object IArgument.GetValue(String value)
        {
            return this.GetValue(value);
        }

        /// <summary>
        /// Converts a value to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        Object IArgument.GetValue(CultureInfo culture, String value)
        {
            return this.GetValue(culture, value);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual Int32 CompareTo(IPairable other)
        {
            return this.Key.CompareTo(other.Key);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        /// <param name="comparisonType">The comparison rule to use.</param>
        public virtual Int32 CompareTo(IPairable other, StringComparison comparisonType)
        {
            return this.Key.CompareTo(other.Key, comparisonType);
        }
    }
}
