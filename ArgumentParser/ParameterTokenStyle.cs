//-----------------------------------------------------------------------
// <copyright file="ParameterTokenStyle.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    /// <summary>
    /// Specifies the parameter syntax to be used by the parser.
    /// </summary>
    public enum ParameterTokenStyle
    {
        /// <summary>
        /// Parse POSIX-flavored input parameters.
        /// </summary>
        POSIX = 1,

        /// <summary>
        /// Parse Windows-flavored input parameters.
        /// </summary>
        Windows,

        /// <summary>
        /// Parse Windows-flavored input parameters, using the colon character as the attribution token.
        /// </summary>
        WindowsColon,

        /// <summary>
        /// Parse Windows-flavored input parameters, using the equal character as the attribution token.
        /// </summary>
        WindowsEqual,

        /// <summary>
        /// Parse minimalism-flavored input parameters.
        /// </summary>
        Simple
    }
}
