//-----------------------------------------------------------------------
// <copyright file="POSIXOptionAttribute.cs" company="LouisTakePILLz">
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
using System.Linq;
using ArgumentParser.Arguments;
using ArgumentParser.Arguments.POSIX;
using ArgumentParser.Helpers;

namespace ArgumentParser.Reflection.POSIX
{
    /// <summary>
    /// Represents a POSIX-flavored option attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class POSIXOptionAttribute : Attribute, IPOSIXOptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.POSIX.POSIXOptionAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public POSIXOptionAttribute(String tag)
        {
            this.Tag = tag;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.POSIX.POSIXOptionAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public POSIXOptionAttribute(Char tag)
        {
            this.Tag = tag.ToString();
            this.IsShort = true;
        }

        /// <summary>
        /// Gets the tag that defines the argument.
        /// </summary>
        public String Tag { get; private set; }

        /// <summary>
        /// Gets or sets the description of the argument.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets a boolean value indicating whether the member is meant to be manually bound or not. (Only applies to methods)
        /// </summary>
        public Boolean ManualBinding { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        public ValueOptions ValueOptions { get; set; }

        /// <summary>
        /// Gets or sets the default value of the argument.
        /// </summary>
        public Object DefaultValue { get; set; }

        /// <summary>
        /// Gets a boolean value indicating whether the argument is represented by a single <see cref="T:System.Char"/>.
        /// </summary>
        public Boolean IsShort { get; private set; }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        public virtual TypeConverter TypeConverter { get; protected set; }

        /// <summary>
        /// Gets the delegate used for preprocessing.
        /// </summary>
        public virtual PreprocessorDelegate Preprocessor { get; protected set; }

        /// <summary>
        /// Gets an argument definition using the supplied specifications.
        /// </summary>
        /// <param name="valueType">The expected value type to convert and bind to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <returns>The newly created argument definition.</returns>
        public virtual IArgument CreateArgument(Type valueType, IFormatProvider formatProvider)
        {
            var defaultValue = ValueConverter.ConvertValue(valueType, formatProvider, this.DefaultValue);

            if (this.IsShort)
                return (IArgument) Activator.CreateInstance(typeof (POSIXShortArgument<>)
                    .MakeGenericType(valueType), this.Tag.First(), this.Description, this.ValueOptions, this.TypeConverter, this.Preprocessor, defaultValue);

            return (IArgument) Activator.CreateInstance(typeof (POSIXLongArgument<>)
                .MakeGenericType(valueType), this.Tag, this.Description, this.ValueOptions, this.TypeConverter, this.Preprocessor, defaultValue);
        }

#if NETFRAMEWORK
        /// <summary>
        /// Gets the unique identifier for this attribute.
        /// </summary>
        public override Object TypeId
        {
            get { return Guid.NewGuid(); }
        }
#endif
    }
}
