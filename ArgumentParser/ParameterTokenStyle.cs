//-----------------------------------------------------------------------
// <copyright file="ParameterTokenStyle.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    /// <summary>
    /// Specifies the parameter syntax to be used by the parser.
    /// </summary>
    public enum ParameterTokenStyle
    {
        /// <summary>
        /// Parse POSIX-flavored input parameters.
        /// </summary>
        POSIX = 1,

        /// <summary>
        /// Parse Windows-flavored input parameters.
        /// </summary>
        Windows,

        /// <summary>
        /// Parse Windows-flavored input parameters, using the colon character as the attribution token.
        /// </summary>
        WindowsColon,

        /// <summary>
        /// Parse Windows-flavored input parameters, using the equal character as the attribution token.
        /// </summary>
        WindowsEqual,

        /// <summary>
        /// Parse minimalism-flavored input parameters.
        /// </summary>
        Simple
    }
}
