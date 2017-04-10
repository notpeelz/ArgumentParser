//-----------------------------------------------------------------------
// <copyright file="IOptionAttribute.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Reflection
{
    /// <summary>
    /// Represents an argument definition attribute.
    /// </summary>
    public interface IOptionAttribute
    {
        /// <summary>
        /// Gets the tag that defines the argument.
        /// </summary>
        String Tag { get; }

        /// <summary>
        /// Gets the description of the argument.
        /// </summary>
        String Description { get; }

        /// <summary>
        /// Gets a boolean value indicating whether the member is meant to be manually bound or not. (Only applies to methods)
        /// </summary>
        Boolean ManualBinding { get; }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        ValueOptions ValueOptions { get; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        Object DefaultValue { get; }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        TypeConverter TypeConverter { get; }

        /// <summary>
        /// Gets the delegate used for preprocessing.
        /// </summary>
        PreprocessorDelegate Preprocessor { get; }

        /// <summary>
        /// Gets an argument definition using the supplied specifications.
        /// </summary>
        /// <param name="valueType">The expected value type to convert and bind to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <returns>The newly created argument definition.</returns>
        IArgument CreateArgument(Type valueType, IFormatProvider formatProvider);
    }
}
