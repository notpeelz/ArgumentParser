//-----------------------------------------------------------------------
// <copyright file="IArgument`1.cs" company="LouisTakePILLz">
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
using System.Collections.Generic;
using System.Globalization;

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents an argument definition of a defined value type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public interface IArgument<T> : IArgument
    {
        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        new T DefaultValue { get; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        /// <param name="value">The default value.</param>
        /// <returns>A boolean value indicating whether the conversion succeeded.</returns>
        Boolean TryGetDefaultValue(out T value);

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="values">The input values to convert.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <returns>The converted values.</returns>
        new IEnumerable<T> GetValues(IEnumerable<String> values, CultureInfo culture);
    }
}
