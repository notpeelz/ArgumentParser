//-----------------------------------------------------------------------
// <copyright file="FlagOptions.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Specifies the value conversion behavior upon parsing a value for an <see cref="T:ArgumentParser.Arguments.IFlag"/>.
    /// </summary>
    [Flags]
    public enum FlagOptions
    {
        /// <summary>
        /// No special behavior.
        /// </summary>
        None = 0,

        /// <summary>
        /// Convert implicit values to bit-field entries.
        /// </summary>
        BitFieldImplicit = 1 << 0,

        /// <summary>
        /// Convert explicit values to bit-field entries.
        /// </summary>
        BitFieldExplicit = 1 << 1,

        /// <summary>
        /// Convert both implicit and explicit values to bit-field entries.
        /// </summary>
        BitFieldAll = BitFieldImplicit | BitFieldExplicit,

        /// <summary>
        /// Combine implicit values from multiple <see cref="T:ArgumentParser.RawParameter"/> entries of the same <see cref="T:ArgumentParser.Arguments.IFlag"/> type as a single value.
        /// </summary>
        AggregateImplicit = 1 << 2,

        /// <summary>
        /// Combine explicit values from multiple <see cref="T:ArgumentParser.RawParameter"/> entries of the same <see cref="T:ArgumentParser.Arguments.IFlag"/> type as a single value.
        /// </summary>
        AggregateExplicit = 1 << 3,

        /// <summary>
        /// Combine both implicit and explicit values from multiple <see cref="T:ArgumentParser.RawParameter"/> entries of the same <see cref="T:ArgumentParser.Arguments.IFlag"/> type as a single value.
        /// </summary>
        AggregateAll = AggregateImplicit | AggregateExplicit,

        /// <summary>
        /// Allow for explicit and implicit values to be aggregated in the same <see cref="T:ArgumentParser.FlagPair"/>.
        /// </summary>
        AggregateCombine = 1 << 4,

        /// <summary>
        /// Invert implicit values for arguments of the <see cref="T:System.Boolean"/> type.
        /// </summary>
        InvertBooleanImplicit = 1 << 5,

        /// <summary>
        /// Invert explicit values for arguments of the <see cref="T:System.Boolean"/> type.
        /// </summary>
        InvertBooleanExplicit = 1 << 6,

        /// <summary>
        /// Invert both implicit and explicit values for arguments of the <see cref="T:System.Boolean"/> type.
        /// </summary>
        InvertBoolean = InvertBooleanImplicit | InvertBooleanExplicit
    }
}
