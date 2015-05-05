//-----------------------------------------------------------------------
// <copyright file="FlagArgument`1.cs" company="LouisTakePILLz">
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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using ArgumentParser.Helpers;

namespace ArgumentParser.Arguments
{
    /// <summary>
    /// Represents an argument of a specific value type that supports special value handling.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public abstract class FlagArgument<T> : Argument<T>, IFlag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.FlagArgument`1"/> class.
        /// </summary>
        protected FlagArgument() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Arguments.FlagArgument`1"/> class.
        /// </summary>
        /// <param name="key">The unique identifier to use to represent the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="flagOptions">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        protected FlagArgument(Key key, String description = null, ValueOptions valueOptions = ValueOptions.Single, FlagOptions flagOptions = FlagOptions.None, TypeConverter typeConverter = null, Parser.PreprocessorDelegate preprocessor = null, T defaultValue = default(T))
            : base(key, description, valueOptions, typeConverter, preprocessor, defaultValue)
        {
            this.FlagOptions = flagOptions;
        }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        public FlagOptions FlagOptions { get; set; }

        /// <summary>
        /// Converts a sequence of values to the type of the argument using the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// <param name="parameters">The source parameters.</param>
        /// <param name="preprocessor">The preprocessor to use to transform raw inputs.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use for culture-sensitive operations.</param>
        /// <param name="trailingValues">The values that are to be interpreted as trailing.</param>
        /// <returns>The converted values.</returns>
        public override ParameterPair GetPair(IEnumerable<RawParameter> parameters, Parser.PreprocessorDelegate preprocessor, CultureInfo culture, out IEnumerable<IEnumerable<String>> trailingValues)
        {
            var rawParameters = parameters as RawParameter[] ?? parameters.ToArray();

            if (!rawParameters.Any())
            {
                trailingValues = new String[0][];
                return new FlagPair(this, new Object[0], 0);
            }

            bool isBoolean = this.Type == typeof (Boolean);
            bool invertImplicit = (this.FlagOptions & FlagOptions.InvertBooleanImplicit) != 0;
            bool invertExplicit = (this.FlagOptions & FlagOptions.InvertBooleanExplicit) != 0;

            var canonicalValues = rawParameters.ToDictionary(x => x, x => ValueConverter.GetCompositeValueParts(x, preprocessor, culture));

            var flagValues = canonicalValues.Select(x =>
            {
                int value;
                var values = default (IEnumerable<String>);

                // Determine whether the flag level should be implicitly computed (doesn't accept values, has no value or is coupled)
                if (this.ValueOptions == ValueOptions.None || x.Key.Value == null || x.Key.CoupleCount > 1)
                {
                    value = invertImplicit ? 0 : 1;
                    values = x.Value;
                }
                else if (this.ValueOptions == ValueOptions.Composite)
                    value = ValueConverter.GetFlagValue(culture, isBoolean, String.Join("\x20", x.Value)) == 0 ^ invertExplicit ? 0 : 1;
                else // flag.ValueOptions == ValueOptions.Single
                {
                    var rawValue = ValueConverter.GetFlagValue(culture, isBoolean, x.Value.FirstOrDefault());
                    value = rawValue == 0 ^ invertExplicit ? 0 : 1;
                    values = x.Value.Skip(1);
                }

                return new
                {
                    Parameter = x.Key,
                    Value = value,
                    TrailingValues = values
                };
            }).ToArray();

            trailingValues = flagValues.Select(x => x.TrailingValues);

            // Skip special flag logic for booleans, as such operations can not be done on single bits.
            if (isBoolean)
            {
                var flagPair = new FlagPair(
                    argument: this,
                    values: flagValues.Select(x => (Object) x.Value),
                    count: flagValues.Last().Value);

                return flagPair;
            }

            bool aggregateImplicit = (this.FlagOptions & FlagOptions.AggregateImplicit) != 0,
                 aggregateExplicit = (this.FlagOptions & FlagOptions.AggregateExplicit) != 0,
                 aggregateCombine = (this.FlagOptions & FlagOptions.AggregateCombine) != 0,
                 bitFieldImplicit = (this.FlagOptions & FlagOptions.BitFieldImplicit) != 0,
                 bitFieldExplicit = (this.FlagOptions & FlagOptions.BitFieldExplicit) != 0;

            int implicitCount = 0,
                explicitCount = 0;

            if (aggregateImplicit && !aggregateExplicit) // Implicit not explicit
            {
                implicitCount = bitFieldImplicit
                    ? rawParameters.Aggregate(0, (c, x) => c + ValueConverter.GetBitFieldValue(x.Count))
                    : rawParameters.Aggregate(0, (c, x) => c + x.Count);
            }
            else if (aggregateExplicit && !aggregateImplicit) // Explicit not implicit
            {
                explicitCount = bitFieldExplicit
                    ? flagValues.Aggregate(0, (c, x) => c + ValueConverter.GetBitFieldValue(x.Value))
                    : flagValues.Aggregate(0, (c, x) => c + x.Value);
            }
            else if (aggregateImplicit) // Explicit and implicit (both)
            {
                implicitCount = bitFieldImplicit // Count only value-less parameters
                    ? rawParameters.Aggregate(0, (c, x) => c + (x.Value == null ? ValueConverter.GetBitFieldValue(x.Count) : 0))
                    : rawParameters.Aggregate(0, (c, x) => c + (x.Value == null ? x.Count : 0));

                if (aggregateCombine || implicitCount == 0)
                    explicitCount = bitFieldExplicit
                        ? flagValues.Aggregate(0, (c, x) => c + (x.Parameter.Value == null ? 0 : ValueConverter.GetBitFieldValue(x.Value)))
                        : flagValues.Aggregate(0, (c, x) => c + (x.Parameter.Value == null ? 0 : x.Value));
            }
            else // None
            {
                var implicitParameter = flagValues.FirstOrDefault(x => x.Parameter.Value == null);
                var explicitParameter = flagValues.FirstOrDefault(x => x.Parameter.Value != null);
                implicitCount = implicitParameter != null
                    ? (bitFieldImplicit ? ValueConverter.GetBitFieldValue(implicitParameter.Parameter.Count) : implicitParameter.Parameter.Count)
                    : 0;

                if (aggregateCombine && explicitParameter != null)
                    explicitCount = bitFieldExplicit ? ValueConverter.GetBitFieldValue(explicitParameter.Parameter.Count) : explicitParameter.Parameter.Count;
            }

            {
                var flagPair = new FlagPair(this, flagValues.Select(x => (Object) x.Value), implicitCount + explicitCount);
                return flagPair;
            }
        }
    }
}
