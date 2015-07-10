//-----------------------------------------------------------------------
// <copyright file="ProjectionEqualityComparer`1.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Helpers
{
    /// <summary>
    /// Compares two objects for equivalence through a projected key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements to be compared.</typeparam>
    public static class ProjectionEqualityComparer<TSource>
    {
        /// <summary>
        /// Creates an instance of <see cref="T:ArgumentParser.Helpers.ProjectionEqualityComparer`2"/> using the specified projection.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys to be compared.</typeparam>
        /// <param name="projection">The projection to use for extracting the compared key.</param>
        /// <returns>A comparer that compares elements using a projected key.</returns>
        public static ProjectionEqualityComparer<TSource, TKey> Create<TKey>(Func<TSource, TKey> projection)
        {
            return new ProjectionEqualityComparer<TSource, TKey>(projection);
        }
    }
}
