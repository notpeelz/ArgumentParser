//-----------------------------------------------------------------------
// <copyright file="Verb.cs" company="LouisTakePILLz">
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
