//-----------------------------------------------------------------------
// <copyright file="ParameterPair.cs" company="LouisTakePILLz">
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
using System.Collections.Generic;
using System.Linq;
using ArgumentParser.Arguments;

namespace ArgumentParser
{
    /// <summary>
    /// Represents an argument-parameter match.
    /// </summary>
    public class ParameterPair : IPairable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ParameterPair"/> class.
        /// </summary>
        /// <param name="argument">The matched argument.</param>
        /// <param name="values">The values that were passed to the parameter.</param>
        internal ParameterPair(IArgument argument, IEnumerable<Object> values)
        {
            this.Argument = argument;
            this.Values = values;
        }

        /// <summary>
        /// Gets the key that defines the argument.
        /// </summary>
        public Key Key { get { return this.Argument.Key; } }

        /// <summary>
        /// Gets the matched argument.
        /// </summary>
        public IArgument Argument { get; private set; }

        /// <summary>
        /// Gets the input values.
        /// </summary>
        public IEnumerable<Object> Values { get; private set; }

        /// <summary>
        /// Gets a boolean value indicating whether the argument was matched.
        /// </summary>
        public virtual Boolean Matched { get { return this.Values != null && this.Values.Any(); } }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
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