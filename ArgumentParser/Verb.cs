//-----------------------------------------------------------------------
// <copyright file="Verb.cs" company="LouisTakePILLz">
// Copyright © 2015 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/* This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace ArgumentParser
{
    /// <summary>
    /// Represents a verb definition.
    /// </summary>
    public class Verb : IComparable<Verb>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Verb"/> class.
        /// </summary>
        /// <param name="name">The name of the verb.</param>
        /// <param name="description">The description of the verb.</param>
        public Verb(String name, String description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets the name of the verb.
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Gets the description of the verb.
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
        public Int32 CompareTo(Verb other)
        {
            return String.Compare(this.Name, other.Name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        /// <param name="comparisonType">The comparison rule to use.</param>
        public Int32 CompareTo(Verb other, StringComparison comparisonType)
        {
            return String.Compare(this.Name, other.Name, comparisonType);
        }
    }
}
