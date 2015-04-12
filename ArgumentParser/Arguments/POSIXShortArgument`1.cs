﻿//-----------------------------------------------------------------------
// <copyright file="POSIXShortArgument`1.cs" company="LouisTakePILLz">
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
    /// Represents a POSIX-flavored argument identified by a <see cref="T:System.Char"/> tag.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class POSIXShortArgument<T> : ShortArgument<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.POSIXShortArgument`1"/> class.
        /// </summary>
        /// <param name="tag">The character that defines the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for value conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public POSIXShortArgument(Char tag, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, T defaultValue = default (T))
            : base(Prefix, tag, valueOptions, typeConverter, defaultValue) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.POSIXShortArgument`1"/> class.
        /// </summary>
        /// <param name="tag">The character that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior  of the argument.</param>
        /// <param name="typeConverter">The type converter to use for value conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public POSIXShortArgument(Char tag, String description, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, T defaultValue = default (T))
            : base(Prefix, tag, description, valueOptions, typeConverter, defaultValue) { }

        /// <summary>
        /// Gets the prefix used for arguments of the <see cref="T:ArgumentParser.Arguments.POSIXShortArgument`1"/> type.
        /// </summary>
        public static String Prefix
        {
            get { return Parser.PREFIX_UNIX_SHORT; }
        }
    }
}
