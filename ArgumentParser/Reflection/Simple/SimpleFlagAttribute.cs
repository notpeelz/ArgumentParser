//-----------------------------------------------------------------------
// <copyright file="SimpleFlagAttribute.cs" company="LouisTakePILLz">
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
using ArgumentParser.Arguments.Simple;
using ArgumentParser.Helpers;

namespace ArgumentParser.Reflection.Simple
{
    /// <summary>
    /// Represents a minimalism-flavored flag option attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class SimpleFlagAttribute : SimpleOptionAttribute, IFlagOptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.Simple.SimpleFlagAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public SimpleFlagAttribute(String tag) : base(tag) { }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        public FlagOptions FlagOptions { get; set; }

        /// <summary>
        /// Gets an argument definition using the supplied specifications.
        /// </summary>
        /// <param name="valueType">The expected value type to convert and bind to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <returns>The newly created argument definition.</returns>
        public override IArgument CreateArgument(Type valueType, IFormatProvider formatProvider)
        {
            var defaultValue = ValueConverter.ConvertValue(valueType, formatProvider, this.DefaultValue);
            var type = typeof (SimpleFlag<>).MakeGenericType(valueType);

            return (IArgument) Activator.CreateInstance(type, this.Tag, this.Description, this.ValueOptions, this.FlagOptions, this.TypeConverter, this.Preprocessor, defaultValue);
        }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        TypeConverter IOptionAttribute.TypeConverter
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the delegate used for preprocessing.
        /// </summary>
        PreprocessorDelegate IOptionAttribute.Preprocessor
        {
            get { return null; }
        }
    }
}
