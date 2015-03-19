//-----------------------------------------------------------------------
// <copyright file="Argument.cs" company="LouisTakePILLz">
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
using System.Globalization;

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents an argument of an undefined value type.
    /// </summary>
    public abstract class Argument : IArgument<String>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Argument"/> class.
        /// </summary>
        /// <param name="key">The unique identifier to use to represent the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected Argument(Key key, String defaultValue)
        {
            this.Key = key;
            this.DefaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Argument"/> class.
        /// </summary>
        /// <param name="key">The unique identifier to use to represent the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected Argument(Key key, String description, String defaultValue)
            : this(key, defaultValue)
        {
            this.Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Argument"/> class.
        /// </summary>
        /// <param name="prefix">The prefix to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="tag">The tag to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected Argument(String prefix, String tag, String defaultValue)
            : this(new Key(prefix, tag), defaultValue) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Argument"/> class.
        /// </summary>
        /// <param name="prefix">The prefix to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="tag">The tag to use as a part of the <see cref="T:ArgumentParser.Key"/>.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected Argument(String prefix, String tag, String description, String defaultValue)
            : this(new Key(prefix, tag), description, defaultValue) { }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Key"/> representing the argument.
        /// </summary>
        public Key Key { get; private set; }

        /// <summary>
        /// Gets the description of the argument.
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        public String DefaultValue { get; private set; }

        /// <summary>
        /// Gets the value type of the argument.
        /// </summary>
        public Type Type { get { return typeof (String); } }

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
        public String GetValue(CultureInfo culture, String value)
        {
            return value;
        }

        /// <summary>
        /// Converts a value to the type of the argument.
        /// </summary>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        public String GetValue(String value)
        {
            return value;
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
