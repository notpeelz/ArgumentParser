//-----------------------------------------------------------------------
// <copyright file="Key.cs" company="LouisTakePILLz">
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
        /// <param name="key">An object to compare with this object.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="key"/> parameter.Zero This object is equal to <paramref name="key"/>. Greater than zero This object is greater than <paramref name="key"/>.
        /// </returns>
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
