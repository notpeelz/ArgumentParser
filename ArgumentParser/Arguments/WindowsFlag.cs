//-----------------------------------------------------------------------
// <copyright file="WindowsFlag.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents a Windows-flavored flag that supports special value handling.
    /// </summary>
    public class WindowsFlag : WindowsArgument, IFlag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.WindowsFlag"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the flag.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public WindowsFlag(String tag, FlagOptions options = FlagOptions.None, String defaultValue = null)
            : base(tag, defaultValue)
        {
            this.Options = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.WindowsFlag"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the flag.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        public WindowsFlag(String tag, String description, FlagOptions options = FlagOptions.None, String defaultValue = null)
            : base(tag, description, defaultValue)
        {
            this.Options = options;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        public FlagOptions Options { get; private set; }
    }
}
