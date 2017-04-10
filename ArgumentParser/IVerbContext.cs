//-----------------------------------------------------------------------
// <copyright file="IVerbContext.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    /// <summary>
    /// Represents a verb (i.e. a parser subcontext).
    /// </summary>
    public interface IVerbContext
    {
        /// <summary>
        /// Handles unmatched verb entries upon parsing.
        /// </summary>
        /// <param name="verbs">A sequence of strings representing the unmatched verb tags.</param>
        void Init(IEnumerable<String> verbs);

        /// <summary>
        /// Handles undefined parameter entries upon parsing.
        /// </summary>
        /// <param name="parameters">A sequence of raw, unmatched parameters representing unpaired entries.</param>
        void HandleParameters(IEnumerable<RawParameter> parameters);

        /// <summary>
        /// Handles trailing values upon parsing.
        /// </summary>
        /// <param name="values">A sequence of objects representing unbound, trailing values.</param>
        void HandleValues(IEnumerable<UnboundValue> values);
    }
}
