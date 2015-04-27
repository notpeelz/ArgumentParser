//-----------------------------------------------------------------------
// <copyright file="VerbAttribute.cs" company="LouisTakePILLz">
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
    /// Represents a verb definition attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class VerbAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.VerbAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the verb.</param>
        public VerbAttribute(String tag)
        {
            this.Tag = tag;
        }

        /// <summary>
        /// Gets the tag that defines the verb.
        /// </summary>
        public String Tag { get; private set; }

        /// <summary>
        /// Gets or sets the description of the verb.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Gets a unique identifier for this <see cref="T:ArgumentParser.Reflection.VerbAttribute"/>.
        /// </summary>
        public override Object TypeId
        {
            get { return this.Tag.GetHashCode(); }
        }
    }
}
