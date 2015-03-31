//-----------------------------------------------------------------------
// <copyright file="IVerbContext.cs" company="LouisTakePILLz">
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
        /// <param name="verbs">An array of the remaining unmatched verb tags.</param>
        void Init(String[] verbs);

        /// <summary>
        /// Handles undefined parameter entries upon parsing.
        /// </summary>
        /// <param name="parameter">A raw parameter representing an unmatched input.</param>
        void HandleParameter(RawParameter parameter);

        /// <summary>
        /// Handles trailing values upon parsing.
        /// </summary>
        /// <param name="value">An object representing an unbound, trailing value.</param>
        void HandleValue(UnboundValue value);
    }
}