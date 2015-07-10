//-----------------------------------------------------------------------
// <copyright file="ICoupleableOptionAttribute.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Reflection
{
    /// <summary>
    /// Represents a coupleable argument definition attribute.
    /// </summary>
    public interface ICoupleableOptionAttribute : IOptionAttribute
    {
        /// <summary>
        /// Gets a boolean value indicating whether the argument is represented by a single <see cref="T:System.Char"/>.
        /// </summary>
        Boolean IsShort { get; }
    }
}
