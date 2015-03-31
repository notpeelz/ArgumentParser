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

namespace ArgumentParser.Factory
{
    /// <summary>
    /// Represents an argument definition (or option) attribute.
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
        /// Gets a boolean value indicating whether trailing values should be interpreted.
        /// </summary>
        Boolean AllowCompositeValue { get; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        Object DefaultValue { get; }
    }
}