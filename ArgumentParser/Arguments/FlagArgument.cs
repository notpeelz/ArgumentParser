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

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents an argument of a specific value type that supports special value handling.
    /// </summary>
    public abstract class FlagArgument : FlagArgument<Int32>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.FlagArgument"/> class.
        /// </summary>
        protected FlagArgument() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.FlagArgument"/> class.
        /// </summary>
        /// <param name="key">The unique identifier to use to represent the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="flagOptions">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected FlagArgument(Key key, String description = null, ValueOptions valueOptions = ValueOptions.Single, FlagOptions flagOptions = FlagOptions.None, TypeConverter typeConverter = null, Parser.PreprocessorDelegate preprocessor = null, Int32 defaultValue = default (Int32))
            : base(key, description, valueOptions, flagOptions, typeConverter, preprocessor, defaultValue) { }
    }
}
