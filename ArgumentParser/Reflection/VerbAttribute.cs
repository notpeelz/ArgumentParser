//-----------------------------------------------------------------------
// <copyright file="VerbAttribute.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Reflection
{
    /// <summary>
    /// Represents a verb definition attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class VerbAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.VerbAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the verb.</param>
        public VerbAttribute(String tag)
        {
            this.Tag = tag;
        }

        /// <summary>
        /// Gets the tag that defines the verb.
        /// </summary>
        public String Tag { get; private set; }

        /// <summary>
        /// Gets or sets the description of the verb.
        /// </summary>
        public String Description { get; set; }

#if NETFRAMEWORK
        /// <summary>
        /// Gets the unique identifier for this attribute.
        /// </summary>
        public override Object TypeId
        {
            get { return this.Tag.GetHashCode(); }
        }
#endif
    }
}
