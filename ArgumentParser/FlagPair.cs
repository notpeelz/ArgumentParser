//-----------------------------------------------------------------------
// <copyright file="FlagPair.cs" company="LouisTakePILLz">
// Copyright © 2015 LouisTakePILLz
// <author>LouisTakePILLz</author>
// </copyright>
//-----------------------------------------------------------------------

/* This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using ArgumentParser.Arguments;

namespace ArgumentParser
{
    /// <summary>
    /// Represents a flag-parameter match.
    /// </summary>
    public class FlagPair : ParameterPair
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.FlagPair"/> class.
        /// </summary>
        /// <param name="argument">The matched argument.</param>
        /// <param name="values">The values that were passed to the parameter.</param>
        /// <param name="count">The flag level.</param>
        internal FlagPair(IFlag argument, IEnumerable<Object> values, Int32 count)
            : base(argument, values)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");

            this.Count = count;
        }

        /// <summary>
        /// Gets the flag level.
        /// </summary>
        public Int32 Count { get; private set; }
    }
}
