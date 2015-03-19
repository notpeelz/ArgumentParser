//-----------------------------------------------------------------------
// <copyright file="RawParameter.cs" company="LouisTakePILLz">
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
    /// Represents a raw, untransformed, parameter.
    /// </summary>
    public class RawParameter : IPairable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.RawParameter"/> class.
        /// </summary>
        /// <param name="prefix">The prefix of the parameter.</param>
        /// <param name="tag">The tag that defines the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public RawParameter(String prefix, String tag, Object value)
        {
            this.Value = value;
            this.Key = new Key(prefix, tag);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.RawParameter"/> class.
        /// </summary>
        /// <param name="prefix">The prefix of the parameter.</param>
        /// <param name="tag">The tag that defines the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <param name="count">The tag couple count.</param>
        public RawParameter(String prefix, String tag, Object value, Int32 count)
            : this(prefix, tag, value)
        {
            this.Count = count;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Key"/> representing the argument.
        /// </summary>
        public Key Key { get; private set; }
        
        /// <summary>
        /// Gets the tag couple count.
        /// </summary>
        public Int32 Count { get; private set; }

        /// <summary>
        /// Gets the value of the parameter.
        /// </summary>
        public Object Value { get; private set; }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public Int32 CompareTo(IPairable other)
        {
            return this.Key.CompareTo(other.Key);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        /// <param name="comparisonType">The comparison rule to use.</param>
        public Int32 CompareTo(IPairable other, StringComparison comparisonType)
        {
            return this.Key.CompareTo(other.Key, comparisonType);
        }
    }
}