//-----------------------------------------------------------------------
// <copyright file="UnboundValue.cs" company="LouisTakePILLz">
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
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.</returns>
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
