//-----------------------------------------------------------------------
// <copyright file="Key.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    /// <summary>
    /// Represents a compound identifier constituted of a prefix and a tag.
    /// </summary>
    public class Key
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentParser.Key"/> class.
        /// </summary>
        internal Key() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Key"/> class.
        /// </summary>
        /// <param name="prefix">The identifier preceding the tag.</param>
        /// <param name="tag">The tag following the prefix.</param>
        public Key(String prefix, String tag)
        {
            this.Prefix = prefix;
            this.Tag = tag;
        }

        /// <summary>
        /// Gets the prefix of the key.
        /// </summary>
        public String Prefix { get; private set; }

        /// <summary>
        /// Gets the tag of the key.
        /// </summary>
        public String Tag { get; private set; }

        /// <summary>
        /// Gets the full name of the key.
        /// </summary>
        public String Value
        {
            get { return this.Prefix + this.Tag; }
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="key"/> parameter.Zero This object is equal to <paramref name="key"/>. Greater than zero This object is greater than <paramref name="key"/>.
        /// </returns>
        /// <param name="key">An object to compare with this object.</param>
        public Int32 CompareTo(Key key)
        {
            return String.Compare(this.Value, key.Value, StringComparison.Ordinal);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="key"/> parameter.Zero This object is equal to <paramref name="key"/>. Greater than zero This object is greater than <paramref name="key"/>.</returns>
        /// <param name="key">An object to compare with this object.</param>
        /// <param name="comparisonType">The comparison rule to use.</param>
        public Int32 CompareTo(Key key, StringComparison comparisonType)
        {
            return String.Compare(this.Value, key.Value, comparisonType);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
        {
            return this.Value;
        }
    }
}