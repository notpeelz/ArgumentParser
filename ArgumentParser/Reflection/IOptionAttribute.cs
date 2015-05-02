//-----------------------------------------------------------------------
// <copyright file="IOptionAttribute.cs" company="LouisTakePILLz">
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
using ArgumentParser.Arguments;

namespace ArgumentParser.Reflection
{
    /// <summary>
    /// Represents an argument definition attribute.
    /// </summary>
    public interface IOptionAttribute
    {
        /// <summary>
        /// Gets the tag that defines the argument.
        /// </summary>
        String Tag { get; }

        /// <summary>
        /// Gets the description of the argument.
        /// </summary>
        String Description { get; }

        /// <summary>
        /// Gets a boolean value indicating whether the member is meant to be manually bound or not. (Only applies to methods)
        /// </summary>
        Boolean ManualBinding { get; }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        ValueOptions ValueOptions { get; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        Object DefaultValue { get; }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        TypeConverter TypeConverter { get; }

        /// <summary>
        /// Gets the delegate used for detokenization.
        /// </summary>
        Parser.DetokenizerDelegate Detokenizer { get; }

        /// <summary>
        /// Gets an argument definition using the supplied specifications.
        /// </summary>
        /// <param name="valueType">The expected value type to convert and bind to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <returns>The newly created argument definition.</returns>
        IArgument CreateArgument(Type valueType, IFormatProvider formatProvider);
    }
}
