//-----------------------------------------------------------------------
// <copyright file="UnboundValue.cs" company="LouisTakePILLz">
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
    /// Represents an unbound, trailing value.
    /// </summary>
    public class UnboundValue : IPairable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.UnboundValue"/> class.
        /// </summary>
        /// <param name="value">The raw unbound value.</param>
        public UnboundValue(String value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.UnboundValue"/> class.
        /// </summary>
        /// <param name="parent">The parameter preceding the trailing value.</param>
        /// <param name="value">The raw unbound value.</param>
        public UnboundValue(ParameterPair parent, String value)
        {
            this.Parent = parent;
            this.Value = value;
        }

        /// <summary>
        /// Gets the parameter preceding the value.
        /// </summary>
        public ParameterPair Parent { get; private set; }

        /// <summary>
        /// Gets the unbound, trailing value.
        /// </summary>
        public String Value { get; private set; }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Key"/> representing this object.
        /// </summary>
        public Key Key { get { return this.Parent == null ? null : this.Parent.Key; } }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public Int32 CompareTo(IPairable other)
        {
            var value = other as UnboundValue;
            if (value != null)
                return String.Compare(this.Value, value.Value, StringComparison.Ordinal);

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
            var value = other as UnboundValue;
            if (value != null)
                return String.Compare(this.Value, value.Value, comparisonType);

            return this.Key.CompareTo(other.Key);
        }
    }
}
