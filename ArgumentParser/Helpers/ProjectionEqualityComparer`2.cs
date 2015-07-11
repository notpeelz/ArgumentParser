//-----------------------------------------------------------------------
// <copyright file="ProjectionEqualityComparer`2.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Helpers
{
    /// <summary>
    /// Compares two objects for equivalence through a projected key.
    /// </summary>
    /// <typeparam name="TSource">The type of the source objects to compare.</typeparam>
    /// <typeparam name="TKey">The type of the projected key.</typeparam>
    public class ProjectionEqualityComparer<TSource, TKey> : IEqualityComparer<TSource>
    {
        private readonly Func<TSource, TKey> projection;
        private readonly IEqualityComparer<TKey> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Helpers.ProjectionEqualityComparer"/> class using the default comparer.
        /// </summary>
        /// <param name="projection">The projection to use for extracting the compared key.</param>
        public ProjectionEqualityComparer(Func<TSource, TKey> projection)
            : this(projection, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Helpers.ProjectionEqualityComparer"/> class using the specified comparer.
        /// </summary>
        /// <param name="projection">The projection to use for extracting the compared key</param>
        /// <param name="comparer">The comparer to use on the keys. May be null, in which case the default comparer will be used.</param>
        public ProjectionEqualityComparer(Func<TSource, TKey> projection, IEqualityComparer<TKey> comparer)
        {
            if (projection == null)
                throw new ArgumentNullException("projection");

            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
            this.projection = projection;
        }

        /// <summary>
        /// Creates an instance of <see cref="T:ArgumentParser.Helpers.ProjectionEqualityComparer`2"/> using the specified projection.
        /// </summary>
        /// <param name="projection">The projection to use for extracting the compared key</param>
        /// <returns>A comparer that compares elements using a projected key.</returns>
        public static ProjectionEqualityComparer<TSource, TKey> Create(Func<TSource, TKey> projection)
        {
            return new ProjectionEqualityComparer<TSource, TKey>(projection);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>A boolean value indicating whether the two objects are equal.</returns>
        public Boolean Equals(TSource x, TSource y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return this.comparer.Equals(this.projection(x), this.projection(y));
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>A hash code for the specified object.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param>
        /// <exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(TSource obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            return this.comparer.GetHashCode(this.projection(obj));
        }
    }
}
