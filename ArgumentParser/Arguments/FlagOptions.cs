//-----------------------------------------------------------------------
// <copyright file="FlagOptions.cs" company="LouisTakePILLz">
// Copyright © 2015 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/*
 * This program is free software: you can redistribute it and/or modify it under the terms of
 * the GNU General Public License as published by the Free Software Foundation, either
 * version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
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
