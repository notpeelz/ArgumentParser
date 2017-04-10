//-----------------------------------------------------------------------
// <copyright file="SimpleListOptionAttribute.cs" company="LouisTakePILLz">
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
using System.ComponentModel;
using ArgumentParser.Helpers;

namespace ArgumentParser.Reflection.Simple
{
    /// <summary>
    /// Represents a minimalism-flavored option attribute that supports splitting using a culture-dependent separator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class SimpleListOptionAttribute : SimpleOptionAttribute
    {
        private static readonly StringArrayConverter typeConverter = new StringArrayConverter();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.Simple.SimpleListOptionAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public SimpleListOptionAttribute(String tag) : base(tag) { }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        public override TypeConverter TypeConverter
        {
            get { return typeConverter; }
        }
    }
}
