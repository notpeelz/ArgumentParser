//-----------------------------------------------------------------------
// <copyright file="IArgument`1.cs" company="LouisTakePILLz">
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
    /// Represents an argument definition of a defined value type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public interface IArgument<out T> : IArgument
    {
        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        new T DefaultValue { get; }

        /// <summary>
        /// Converts a value to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        new T GetValue(CultureInfo culture, String value);

        /// <summary>
        /// Converts a value to the type of the argument.
        /// </summary>
        /// <param name="value">The input value to convert from.</param>
        /// <returns>The converted value.</returns>
        new T GetValue(String value);
    }
}
