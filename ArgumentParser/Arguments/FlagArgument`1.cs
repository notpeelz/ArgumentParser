//-----------------------------------------------------------------------
// <copyright file="FlagArgument.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents an argument of a specific value type that supports special value handling.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public abstract class FlagArgument<T> : Argument<T>, IFlag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.FlagArgument`1"/> class.
        /// </summary>
        protected FlagArgument() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.Argument`1"/> class.
        /// </summary>
        /// <param name="key">The unique identifier to use to represent the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="flagOptions">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected FlagArgument(Key key, String description = null, ValueOptions valueOptions = ValueOptions.Single, FlagOptions flagOptions = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default(T))
            : base(key, description, valueOptions, typeConverter, defaultValue)
        {
            this.FlagOptions = flagOptions;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        public FlagOptions FlagOptions { get; private set; }

        /// <summary>
        /// Converts a value to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        public override T GetValue(CultureInfo culture, String value)
        {
            return base.GetValue(culture, value);
        }

        /// <summary>
        /// Converts a value to the type of the argument.
        /// </summary>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        public override T GetValue(String value)
        {
            return base.GetValue(value);
        }

        /// <summary>
        /// Converts a value to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        Object IArgument.GetValue(CultureInfo culture, String value)
        {
            return base.GetValue(culture, value);
        }

        /// <summary>
        /// Converts a value to the type of the argument.
        /// </summary>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        Object IArgument.GetValue(String value)
        {
            return base.GetValue(value);
        }
    }
}
