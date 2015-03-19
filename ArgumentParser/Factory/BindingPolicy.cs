//-----------------------------------------------------------------------
// <copyright file="BindingPolicy.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Factory
{
    /// <summary>
    /// Specifies the binding behavior upon multiple matches.
    /// </summary>
    public enum BindingPolicy
    {
        /// <summary>
        /// Infer the appropriate policy based on the member type.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Disable filtering upon binding, thus binding all matches.
        /// </summary>
        None = 1,
        
        /// <summary>
        /// Restrict binding to once, resulting in other matches being discarded.
        /// </summary>
        Once = 2
    }
}