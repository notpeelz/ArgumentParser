//-----------------------------------------------------------------------
// <copyright file="ParserExtension.cs" company="LouisTakePILLz">
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
using System.Linq;
using ArgumentParser.Arguments;

namespace ArgumentParser
{
    /// <summary>
    /// Provides static extension methods for parameter handling.
    /// </summary>
    public static class ParserExtension
    {
        /// <summary>
        /// Gets the values from the parameters matching the provided argument.
        /// </summary>
        /// <typeparam name="T">The type of the returned values.</typeparam>
        /// <returns>The values matching the supplied argument.</returns>
        /// <param name="source">A sequence to extract match results from.</param>
        /// <param name="argument">The argument to match.</param>
        public static IEnumerable<T> GetValues<T>(this IEnumerable<IPairable> source, IArgument argument)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (argument == null)
                throw new ArgumentNullException("argument");

            var groups = source.OfType<ParameterPair>().ToArray();

            if (!groups.Any())
                return new T[0];

            var group = groups.Where(x => x.CompareTo(argument) == 0);

            if (group == null)
                throw new ParsingException("The supplied argument did not match any of the results.");

            return group.SelectMany(x => x.Values.Select(v => (T) v));
        }

        /// <summary>
        /// Gets the values from the parameters matching the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type of the returned values.</typeparam>
        /// <param name="source">A sequence to extract match results from.</param>
        /// <param name="arguments">The arguments to match.</param>
        /// <returns>The values matching one of the supplied arguments.</returns>
        public static IEnumerable<T> GetValues<T>(this IEnumerable<IPairable> source, params IArgument[] arguments)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            return arguments.SelectMany(argument => GetValues<T>(source, argument));
        }

        /// <summary>
        /// Gets a single value from the parameters matching the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type of the returned value.</typeparam>
        /// <param name="source">A sequence to extract match results from.</param>
        /// <param name="arguments">The arguments to match.</param>
        /// <returns>The value matching one of the supplied arguments.</returns>
        public static T GetValue<T>(this IEnumerable<IPairable> source, params IArgument[] arguments)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            try
            {
                return GetValues<T>(source, arguments).SingleOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw new ParsingException("Could not disambiguate the match results; several values were found for the supplied arguments.", ex);
            }
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.RawParameter"/> objects from a sequence matching the provided key.
        /// </summary>
        /// <param name="source">A sequence to extract match results from.</param>
        /// <param name="key">The key to match parameters to.</param>
        /// <returns>The entries matching the supplied key.</returns>
        public static IEnumerable<RawParameter> GetUnboundParameters(this IEnumerable<IPairable> source, Key key)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source
                .OfType<RawParameter>()
                .Where(x => x.Key != null && x.Key.CompareTo(key) == 0);
        }

        /// <summary>
        /// Gets a <see cref="T:ArgumentParser.RawParameter"/> object from a sequence matching the provided key.
        /// </summary>
        /// <param name="source">A sequence to extract match results from.</param>
        /// <param name="key">The key to match parameters to.</param>
        /// <returns>The entries matching the supplied key.</returns>
        /// <exception cref="T:ArgumentParser.ParsingException">Could not disambiguate the match results; several matches were found for the supplied key.</exception>
        public static RawParameter GetUnboundParameter(this IEnumerable<IPairable> source, Key key)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            try
            {
                return GetUnboundParameters(source, key).SingleOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw new ParsingException("Could not disambiguate the match results; several matches were found for the supplied key.", ex);
            }
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.UnboundValue"/> objects from a sequence matching the provided key, if supplied.
        /// </summary>
        /// <param name="source">A sequence to extract match results from.</param>
        /// <param name="key">The key to match parameters to.</param>
        /// <returns>The entries matching the supplied key.</returns>
        public static IEnumerable<UnboundValue> GetUnboundValues(this IEnumerable<IPairable> source, Key key = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (key == null)
                return source.OfType<UnboundValue>();

            return source
                .OfType<UnboundValue>()
                .Where(x => x.Key != null && x.Key.CompareTo(key) == 0);
        }

        /// <summary>
        /// Determines whether a supplied flag is present within a sequence.
        /// </summary>
        /// <param name="pairs">A sequence to extract match results from.</param>
        /// <param name="flag">The flag to match parameters to.</param>
        /// <returns>A boolean value indicating whether the flag was matched.</returns>
        public static Boolean HasFlag(this IEnumerable<IPairable> pairs, IFlag flag)
        {
            return GetValue<UInt32>(pairs, flag) > 0;
        }

        /// <summary>
        /// Gets the flag level of the supplied flag from a sequence.
        /// </summary>
        /// <param name="pairs">A sequence to extract match results from.</param>
        /// <param name="flag">The flag to match parameters to.</param>
        /// <returns>The flag level value.</returns>
        public static UInt64 GetFlagLevel(this IEnumerable<IPairable> pairs, IFlag flag)
        {
            return GetValue<UInt64>(pairs, flag);
        }
    }
}
