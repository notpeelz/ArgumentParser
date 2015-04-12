//-----------------------------------------------------------------------
// <copyright file="POSIXFlag`1.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents a POSIX-flavored flag that supports special value handling and decoupling.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class POSIXFlag<T> : POSIXShortArgument<T>, IFlag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.POSIXFlag`1"/> class.
        /// </summary>
        /// <param name="tag">The character that defines the flag.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for value conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public POSIXFlag(Char tag, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default (T))
            : base(tag, valueOptions, typeConverter, defaultValue)
        {
            this.Options = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.POSIXFlag`1"/> class.
        /// </summary>
        /// <param name="tag">The character that defines the flag.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for value conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public POSIXFlag(Char tag, String description, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default (T))
            : base(tag, description, valueOptions, typeConverter, defaultValue)
        {
            this.Options = options;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        public FlagOptions Options { get; private set; }
    }
}
