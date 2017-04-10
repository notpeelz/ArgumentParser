//-----------------------------------------------------------------------
// <copyright file="IArgument.cs" company="LouisTakePILLz">
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
    /// Represents an argument definition of an undefined value type.
    /// </summary>
    public interface IArgument : IPairable
    {
        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        Object DefaultValue { get; }

        /// <summary>
        /// Gets the value type of the argument.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets the description of the argument.
        /// </summary>
        String Description { get; }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        ValueOptions ValueOptions { get; }

        /// <summary>
        /// Gets the default value of the argument.
        /// </summary>
        /// <param name="value">The default value.</param>
        /// <returns>A boolean value indicating whether the conversion succeeded.</returns>
        Boolean TryGetDefaultValue(out Object value);

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified format.
        /// </summary>
        /// <param name="values">The input values to convert.</param>
        /// <param name="culture">The <see cref="T:System.FormatProvider"/> to use for format-sensitive operations.</param>
        /// <returns>The converted values.</returns>
        IEnumerable<Object> GetValues(IEnumerable<String> values, CultureInfo culture);

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="parameters">The source parameters.</param>
        /// <param name="preprocessor">The preprocessor to use to transform raw inputs.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="trailingValues">The values that are to be interpreted as trailing.</param>
        /// <returns>The converted values.</returns>
        ParameterPair GetPair(IEnumerable<RawParameter> parameters, PreprocessorDelegate preprocessor, CultureInfo culture, out IEnumerable<IEnumerable<String>> trailingValues);
    }
}
