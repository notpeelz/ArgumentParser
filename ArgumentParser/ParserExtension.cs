//-----------------------------------------------------------------------
// <copyright file="ParserExtension.cs" company="LouisTakePILLz">
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
        /// Gets the values from the parameters matching the provided arguments.
        /// </summary>
        /// <typeparam name="T">The type of the returned</typeparam>
        /// <param name="source"></param>
        /// <param name="argument"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>(this IEnumerable<IPairable> source, IArgument argument)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (argument == null)
                throw new ArgumentNullException("argument");

            var groups = source.OfType<ParameterPair>().ToArray();

            if (!groups.Any())
                return new T[0];

            var group = groups.SingleOrDefault(x => x.CompareTo(argument) == 0);

            if (group == null)
                throw new ParsingException("The supplied argument did not match any of the results.");

            return group.Values.Cast<T>();
        }

        public static IEnumerable<T> GetValues<T>(this IEnumerable<IPairable> source, params IArgument[] arguments)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            return arguments.SelectMany(argument => GetValues<T>(source, argument));
        }

        public static T GetValue<T>(this IEnumerable<IPairable> source, params IArgument[] arguments)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            try
            {
                return arguments.SelectMany(verb => GetValues<T>(source, verb)).SingleOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw new ParsingException("Could not disambiguate the match results; several values were found for the supplied arguments.", ex);
            }
        }

        public static T GetValue<T>(this IEnumerable<ParameterPair> source, IArgument verb)
        {
            return GetValues<T>(source, verb).SingleOrDefault();
        }

        public static IEnumerable<RawParameter> GetArguments(this IEnumerable<IPairable> source, Key key)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.OfType<RawParameter>().Where(x => x.Key.CompareTo(key) == 0);
        }

        public static RawParameter GetUnboundParameter(this IEnumerable<IPairable> source, Key key)
        {
            return GetArguments(source, key).SingleOrDefault();
        }

        public static Boolean HasFlag(this IEnumerable<IPairable> pairs, IFlag flag)
        {
            return GetValue<UInt32>(pairs, flag) > 0;
        }

        public static UInt64 GetFlagLevel(this IEnumerable<IPairable> pairs, IFlag flag)
        {
            return GetValue<UInt32>(pairs, flag);
        }
    }
}
