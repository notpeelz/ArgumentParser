//-----------------------------------------------------------------------
// <copyright file="ProjectionEqualityComparer.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Helpers
{
    /// <summary>
    /// Compares two objects for equivalence through a projected key.
    /// </summary>
    public static class ProjectionEqualityComparer
    {
        /// <summary>
        /// Creates an instance of <see cref="T:ArgumentParser.Helpers.ProjectionEqualityComparer`2"/> using the specified projection.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements to be compared.</typeparam>
        /// <typeparam name="TKey">The type of the keys to be compared.</typeparam>
        /// <param name="projection">The projection to use for extracting the compared key.</param>
        /// <returns>A comparer that compares elements using a projected key.</returns>
        public static ProjectionEqualityComparer<TSource, TKey> Create<TSource, TKey>(Func<TSource, TKey> projection)
        {
            return new ProjectionEqualityComparer<TSource, TKey>(projection);
        }
    }
}
