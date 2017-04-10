//-----------------------------------------------------------------------
// <copyright file="WindowsCompositeListOptionAttribute.cs" company="LouisTakePILLz">
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
using ArgumentParser.Arguments;
using ArgumentParser.Helpers;

namespace ArgumentParser.Reflection.Windows
{
    /// <summary>
    /// Represents a Windows-flavored option attribute that supports splitting using spaces.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class WindowsCompositeListOptionAttribute : WindowsOptionAttribute
    {
        private static readonly StringArrayConverter typeConverter = new StringArrayConverter('\x20', StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.Windows.WindowsCompositeListOptionAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public WindowsCompositeListOptionAttribute(String tag) : base(tag)
        {
            this.ValueOptions = ValueOptions.Composite;
        }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        public override TypeConverter TypeConverter
        {
            get { return typeConverter; }
        }
    }
}
