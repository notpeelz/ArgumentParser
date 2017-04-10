//-----------------------------------------------------------------------
// <copyright file="ParameterPair.cs" company="LouisTakePILLz">
// Copyright © 2017 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/*
 * Copyright 2017 LouisTakePILLz
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
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
