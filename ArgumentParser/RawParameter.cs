//-----------------------------------------------------------------------
// <copyright file="RawParameter.cs" company="LouisTakePILLz">
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
        public RawParameter(String prefix, String tag, String value)
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
        /// <param name="coupleCount">The total tag couple count.</param>
        /// <param name="count">The count of identical tags.</param>
        public RawParameter(String prefix, String tag, String value, Int32 coupleCount, Int32 count)
            : this(prefix, tag, value)
        {
            this.CoupleCount = coupleCount;
            this.Count = count;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Key"/> representing the argument.
        /// </summary>
        public Key Key { get; private set; }

        /// <summary>
        /// Gets the count of identical tags within the same couple.
        /// </summary>
        public Int32 Count { get; private set; }

        /// <summary>
        /// Gets the total tag couple count.
        /// </summary>
        public Int32 CoupleCount { get; private set; }

        /// <summary>
        /// Gets the value of the parameter.
        /// </summary>
        public String Value { get; private set; }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
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
