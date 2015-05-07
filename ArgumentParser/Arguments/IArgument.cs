//-----------------------------------------------------------------------
// <copyright file="IArgument.cs" company="LouisTakePILLz">
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
using System.Globalization;

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents an argument definition of an undefined value type.
    /// </summary>
    public interface IArgument : IPairable
    {
        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        Object DefaultValue { get; }

        /// <summary>
        /// Gets the value type of the argument.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets the description of the argument.
        /// </summary>
        String Description { get; }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        ValueOptions ValueOptions { get; }

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified format.
        /// </summary>
        /// <param name="values">The input values to convert.</param>
        /// <param name="culture">The <see cref="T:System.FormatProvider"/> to use for format-sensitive operations.</param>
        /// <returns>The converted values.</returns>
        IEnumerable<Object> GetValues(IEnumerable<String> values, CultureInfo culture);

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="parameters">The source parameters.</param>
        /// <param name="preprocessor">The preprocessor to use to transform raw inputs.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="trailingValues">The values that are to be interpreted as trailing.</param>
        /// <returns>The converted values.</returns>
        ParameterPair GetPair(IEnumerable<RawParameter> parameters, PreprocessorDelegate preprocessor, CultureInfo culture, out IEnumerable<IEnumerable<String>> trailingValues);
    }
}
