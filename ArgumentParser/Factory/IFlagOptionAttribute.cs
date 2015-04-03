﻿//-----------------------------------------------------------------------
// <copyright file="IFlagOptionAttribute.cs" company="LouisTakePILLz">
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

using ArgumentParser.Arguments;

namespace ArgumentParser.Factory
{
    /// <summary>
    /// Represents a flag definition attribute.
    /// </summary>
    public interface IFlagOptionAttribute : IOptionAttribute
    {
        /// <summary>
        /// Gets or sets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        FlagOptions Options { get; }
    }
}
