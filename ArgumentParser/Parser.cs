//-----------------------------------------------------------------------
// <copyright file="Parser.cs" company="LouisTakePILLz">
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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using ArgumentParser.Arguments;
using ArgumentParser.Helpers;
using ArgumentParser.Reflection;

namespace ArgumentParser
{
    /// <summary>
    /// Provides core static functions for parsing.
    /// </summary>
    [ReflectionPermission(SecurityAction.Assert, MemberAccess = true)]
    public static partial class Parser
    {
        internal const String INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE = "The token style is not within the valid range of values.";
        internal const String INVALID_MEMBER_TYPE_EXCEPTION_MESSAGE = "The provided object is neither a PropertyInfo nor a MethodInfo.";
        internal const String UNWRITABLE_PROPERTY_EXCEPTION_MESSAGE = "The mapped property does not support writing.";
        internal const String PREFIX_POSIX_LONG = "--";
        internal const String PREFIX_POSIX_SHORT = "-";
        internal const String PREFIX_WINDOWS = "/";
        internal const String PREFIX_SIMPLE = "-";

        /// <summary>
        /// Represents the default value preprocessor delegate.
        /// </summary>
        public static readonly PreprocessorDelegate DefaultPreprocessor = (x, c) => Regex.Unescape(x);

        /// <summary>
        /// Represents the default <see cref="T:ArgumentParser.IPairable"/> equality comparer.
        /// </summary>
        public static readonly IEqualityComparer<IPairable> DefaultPairEqualityComparer = ProjectionEqualityComparer<IPairable>.Create(x => x.Key.Value);

        #region Main methods
        /// <summary>
        /// Parses and extracts parameters with little to no transformation.
        /// </summary>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="tokenStyle">The parameter syntax to use.</param>
        /// <param name="culture">The culture to use for preprocessing.</param>
        /// <returns>A sequence of raw parameters extracted from the original sequence.</returns>
        /// <remarks>
        /// Flags couples aren't dissociated; they are passed verbatim, as a single tag.
        /// </remarks>
        public static IEnumerable<RawParameter> GetRawParameters(String[] input, ParameterTokenStyle tokenStyle, CultureInfo culture = null)
        {
            return GetRawParameters(String.Join("\x20", input), tokenStyle, culture);
        }

        /// <summary>
        /// Parses and extracts parameters with little to no transformation.
        /// </summary>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="tokenStyle">The parameter syntax to use.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="culture">The culture to use for preprocessing.</param>
        /// <returns>A sequence of raw parameters extracted from the original sequence.</returns>
        /// <remarks>
        /// Flag couples aren't dissociated; they are passed verbatim, as a single tag.
        /// </remarks>
        public static IEnumerable<RawParameter> GetRawParameters(String[] input, ParameterTokenStyle tokenStyle, PreprocessorDelegate preprocessor, CultureInfo culture = null)
        {
            return GetRawParameters(String.Join("\x20", input), tokenStyle, preprocessor, culture);
        }

        /// <summary>
        /// Parses and extracts parameters with little to no transformation.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <param name="tokenStyle">The parameter syntax to use.</param>
        /// <param name="culture">The culture to use for preprocessing.</param>
        /// <returns>A sequence of raw parameters extracted from the original sequence.</returns>
        /// <remarks>
        /// Flag couples aren't dissociated; they are passed verbatim, as a single tag.
        /// </remarks>
        public static IEnumerable<RawParameter> GetRawParameters(String input, ParameterTokenStyle tokenStyle, CultureInfo culture = null)
        {
            return GetRawParameters(input, tokenStyle, DefaultPreprocessor, culture);
        }

        /// <summary>
        /// Parses and extracts parameters with little to no transformation.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <param name="tokenStyle">The parameter syntax to use.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="culture">The culture to use for preprocessing.</param>
        /// <returns>A sequence of raw parameters extracted from the original sequence.</returns>
        /// <remarks>
        /// Flag couples aren't dissociated; they are passed verbatim, as a single tag.
        /// </remarks>
        public static IEnumerable<RawParameter> GetRawParameters(String input, ParameterTokenStyle tokenStyle, PreprocessorDelegate preprocessor, CultureInfo culture)
        {
            MatchCollection matches = Regex.Matches(
                input: input,
                pattern: GetParameterPattern(tokenStyle),
                options: RegexOptions.ExplicitCapture |
                         RegexOptions.IgnorePatternWhitespace |
                         RegexOptions.CultureInvariant |
                         RegexOptions.Singleline);

            return matches.OfType<Match>().Select(x =>
                new RawParameter(
                    x.Groups["prefix"].Value,
                    x.Groups["tag"].Value,
                    preprocessor == null ? x.Groups["value"].Value : preprocessor(x.Groups["value"].Value, culture)));
        }

        /// <summary>
        /// Extracts the verbs and the parameters out of an input string.
        /// </summary>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="verbs">The extracted verb tags.</param>
        /// <param name="parameters">The remainder of the input string.</param>
        public static void GetParts(ParserOptions options, String[] input, out String[] verbs, out String parameters)
        {
            GetParts(options, String.Join("\x20", input), out verbs, out parameters);
        }

        /// <summary>
        /// Extracts the verbs and the parameters out of an input string.
        /// </summary>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="verbs">The extracted verb tags.</param>
        /// <param name="parameters">The remainder of the input string.</param>
        public static void GetParts(ParserOptions options, String input, out String[] verbs, out String parameters)
        {
            GetParts(input, out verbs, out parameters, options.Preprocessor, options.Culture);
        }

        /// <summary>
        /// Extracts the verbs and the parameters out of an input string.
        /// </summary>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="verbs">The extracted verb tags.</param>
        /// <param name="parameters">The remainder of the input string.</param>
        /// <param name="preprocessor">The delegate to use for preprocessing.</param>
        /// <param name="culture">The culture to use for preprocessing.</param>
        public static void GetParts(String input, out String[] verbs, out String parameters, PreprocessorDelegate preprocessor, CultureInfo culture = null)
        {
            var matches = Regex.Matches(
                input: input,
                pattern: VERB_PATTERN,
                options: RegexOptions.ExplicitCapture |
                         RegexOptions.IgnorePatternWhitespace |
                         RegexOptions.CultureInvariant |
                         RegexOptions.Singleline).OfType<Match>().ToArray();

            if (preprocessor == null)
            {
                verbs = matches
                    .Where(x => x.Groups["verb"].Success)
                    .Select(x => x.Groups["verb"].Value).ToArray();
            }
            else
            {
                verbs = matches
                    .Where(x => x.Groups["verb"].Success)
                    .Select(x => ValueConverter.PreprocessValue(x.Groups["verb"].Value, preprocessor, culture)).ToArray();
            }

            parameters = matches
                .Where(x => x.Groups["args"].Success)
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        /// <summary>
        /// Parses and binds the input parameters and verbs to members within a context using reflection.
        /// </summary>
        /// <param name="context">The context use for binding.</param>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <exception cref="T:ArgumentParser.ValueBindingException">An issue occured while binding parsing results.</exception>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static void Parse(this IVerbContext context, String[] input, ParserOptions options)
        {
            Parse(context, String.Join("\x20", input), options);
        }

        /// <summary>
        /// Parses and binds the input parameters and verbs to members within a context using reflection.
        /// </summary>
        /// <param name="context">The context use for binding.</param>
        /// <param name="input">The input string array to parse.</param>
        /// <exception cref="T:ArgumentParser.ValueBindingException">An issue occured while binding parsing results.</exception>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static void Parse(this IParserContext context, String[] input)
        {
            Parse(context, String.Join("\x20", input));
        }

        /// <summary>
        /// Parses and binds the input parameters and verbs to members within a context using reflection.
        /// </summary>
        /// <param name="context">The context use for binding.</param>
        /// <param name="input">The input string to parse.</param>
        /// <exception cref="T:ArgumentParser.ValueBindingException">An issue occured while binding parsing results.</exception>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static void Parse(this IParserContext context, String input)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (context.Options == null)
                throw new InvalidOperationException("The provided context does not hold a valid options provider.");

            Parse(context, input, context.Options);
        }

        /// <summary>
        /// Parses and binds the input parameters and verbs to members within a context using reflection.
        /// </summary>
        /// <param name="context">The context use for binding.</param>
        /// <param name="input">The input string to parse.</param>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <exception cref="T:ArgumentParser.ValueBindingException">An issue occured while binding parsing results.</exception>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static void Parse(this IVerbContext context, String input, ParserOptions options)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (options == null)
                throw new ArgumentNullException("options");

            String[] verbNames;
            String args;
            GetParts(options, input, out verbNames, out args);

            List<String> unmatchedVerbs = verbNames.ToList();
            KeyValuePair<PropertyInfo, Verb>? pair;
            Object parent = context;
            var enumerator = verbNames.GetEnumerator();

            Object value = parent;

            while (enumerator.MoveNext()
                && (pair = GetVerb(parent = value, (String) enumerator.Current)).HasValue
                && unmatchedVerbs.Remove((String) enumerator.Current))
            {
                value = pair.Value.Key.GetValue(parent);
                if (value == null)
                    pair.Value.Key.SetValue(parent, value = Activator.CreateInstance(pair.Value.Key.PropertyType));
            }

            ((IVerbContext) value).Init(unmatchedVerbs.ToArray());

            ParseArguments((IVerbContext) value, input, options);
        }

        /// <summary>
        /// Parses and binds the input parameters to members within a subcontext using reflection.
        /// </summary>
        /// <param name="context">The context to use for binding.</param>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <exception cref="T:ArgumentParser.ValueBindingException">An issue occured while binding parsing results.</exception>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static void ParseArguments(this IVerbContext context, String[] input, ParserOptions options)
        {
            ParseArguments(context, String.Join("\x20", input), options);
        }

        /// <summary>
        /// Parses and binds the input parameters to members within a subcontext using reflection.
        /// </summary>
        /// <param name="context">The context to use for binding.</param>
        /// <param name="input">The input string to parse.</param>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <exception cref="T:System.ArgumentNullException">The value of 'context' cannot be null.-or-The value of 'options' cannot be null.</exception>
        /// <exception cref="T:ArgumentParser.ValueBindingException">An issue occured while binding parsing results.</exception>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static void ParseArguments(this IVerbContext context, String input, ParserOptions options)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (options == null)
                throw new ArgumentNullException("options");

            var properties = context.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var methods = context.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            var members = methods.Concat<Object>(properties);
            var arguments = GetArgumentMap(options, members);

            var pairs = GetParameters(input, options, arguments.Select(x => x.Key)).ToArray();
            var matches = pairs.OfType<ParameterPair>()
                .GroupJoin(
                    arguments,
                    x => x,
                    x => x.Key,
                    (pair, kv) => new { MemberBinding = kv.First().Value, ParameterPair = pair },
                    options.PairEqualityComparer)
                .ToLookup(x => x.MemberBinding, x => x.ParameterPair);

            context.HandleParameters(pairs.OfType<RawParameter>());
            context.HandleValues(pairs.OfType<UnboundValue>());

            BindValues(options, context, matches);
        }

        /// <summary>
        /// Parses and returns parameters using a given configuration and argument definitions.
        /// </summary>
        /// <param name="input">The input string array to parse.</param>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <param name="arguments">The known argument definitions to match.</param>
        /// <returns>The paired results of the parsing operation.</returns>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static IEnumerable<IPairable> GetParameters(String[] input, ParserOptions options, params IArgument[] arguments)
        {
            return GetParameters(String.Join("\x20", input), options, arguments);
        }

        /// <summary>
        /// Parses and returns parameters using a given configuration and argument definitions.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <param name="arguments">The known argument definitions to match.</param>
        /// <returns>The paired results of the parsing operation.</returns>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static IEnumerable<IPairable> GetParameters(String input, ParserOptions options, params IArgument[] arguments)
        {
            return GetParameters(input, options, (IEnumerable<IArgument>) arguments);
        }

        /// <summary>
        /// Parses and returns parameters using a given configuration and argument definitions.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <param name="options">The configuration to use for parsing.</param>
        /// <param name="arguments">The known argument definitions to match.</param>
        /// <returns>The paired results of the parsing operation.</returns>
        /// <exception cref="T:ArgumentParser.ValueParsingException">An issue occured while parsing a value.</exception>
        /// <exception cref="T:ArgumentParser.ParsingException">An issue occured while parsing parameters.</exception>
        public static IEnumerable<IPairable> GetParameters(String input, ParserOptions options, IEnumerable<IArgument> arguments)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            if (options == null)
                throw new ArgumentNullException("options");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            MatchCollection matches = Regex.Matches(
                input: input,
                pattern: GetParameterPattern(options.TokenStyle),
                options: RegexOptions.ExplicitCapture |
                         RegexOptions.IgnorePatternWhitespace |
                         RegexOptions.CultureInvariant |
                         RegexOptions.Singleline);

            var matchElements =
                matches.OfType<Match>().SelectMany(x =>
                {
                    var captures = x.Groups["tag"].Captures.OfType<Capture>().ToArray();

                    return captures
                        .GroupBy(c => c.Value, (c, e) => new RawParameter(
                            prefix: x.Groups["prefix"].Value,
                            tag: c,
                            value: x.Groups["value"].Success
                                ? x.Groups["value"].Value
                                : null,
                            count: e.Count(),
                            coupleCount: captures.Length));
                }).ToArray();

            List<UnboundValue> unboundValues = new List<UnboundValue>();
            var preprocessor = options.Preprocessor;

            var pairs = arguments
                .GroupJoin(
                    matchElements,
                    a => a,
                    p => p,
                    (a, p) =>
                    {
                        IEnumerable<IEnumerable<String>> values;
                        var pair = a.GetPair(p, preprocessor, options.Culture, out values);

                        unboundValues.AddRange(values
                            .Where(x => x != null && x.Any())
                            .SelectMany(x => x.Select(v => new UnboundValue(pair, v))));

                        return pair;
                    },
                    options.PairEqualityComparer);

            pairs = pairs.ToArray();

            // Caveat: Except() conflates duplicate (unrecognized) parameters.
            return pairs
                .Concat(matchElements.Except(pairs, options.PairEqualityComparer))
                .Concat(unboundValues);
        }
        #endregion

        #region Ancillary methods
        private static KeyValuePair<PropertyInfo, Verb>? GetVerb(Object instance, String name)
        {
            var entry = instance.GetType().GetProperties()
                .Select(x => new
                {
                    Attribute = x.GetCustomAttributes()
                        .OfType<VerbAttribute>()
                        .SingleOrDefault(a => a.Tag == name),
                    Property = x
                })
                .SingleOrDefault(x => x.Attribute != null
                    // Verb properties must be of a type implementing 'IVerbContext'
                    && x.Property.PropertyType.GetInterfaces().Any(i => i == typeof (IVerbContext)));

            if (entry == null)
                return null;

            return new KeyValuePair<PropertyInfo, Verb>(entry.Property, new Verb(entry.Attribute.Tag, entry.Attribute.Description));
        }

        private static String GetParameterPattern(ParameterTokenStyle tokenStyle)
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.Windows:
                    return WINDOWS_PARAMETER_PATTERN;
                case ParameterTokenStyle.WindowsColon:
                    return WINDOWS_COLON_PARAMETER_PATTERN;
                case ParameterTokenStyle.WindowsEqual:
                    return WINDOWS_EQUAL_PARAMETER_PATTERN;
                case ParameterTokenStyle.POSIX:
                    return POSIX_PARAMETER_PATTERN;
                case ParameterTokenStyle.Simple:
                    return SIMPLE_PARAMETER_PATTERN;
                default:
                    throw new InvalidEnumArgumentException(INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }

        private static IDictionary<IArgument, MemberBinding> GetArgumentMap(ParserOptions options, IEnumerable<Object> members)
        {
            var filter = options.GetAttributeFilter();

            var bindingMap =
                from member in members
                    let isProperty = member is PropertyInfo
                    let attributes = (isProperty ? ((PropertyInfo) member).GetCustomAttributes() : ((MethodInfo) member).GetCustomAttributes())
                    let bpAttribute = attributes.OfType<BindingPolicyAttribute>().SingleOrDefault()
                    from attribute in attributes
                        where attribute is IOptionAttribute
                        where filter((IOptionAttribute) attribute)
                        select new MemberBinding(member, (IOptionAttribute) attribute, bpAttribute != null
                            ? bpAttribute.BindingPolicy
                            : BindingPolicy.Default);

            return bindingMap.ToDictionary(x => CreateArgument(options.Culture, x.Attribute, x.Member));
        }

        private static IArgument CreateArgument(IFormatProvider formatProvider, IOptionAttribute attribute, Object member)
        {
            var descriptor = member as PropertyInfo;
            var returnType = descriptor != null
                ? descriptor.PropertyType
                : ((MethodInfo) member).GetParameters().First().ParameterType;

            return attribute.CreateArgument(returnType, formatProvider);
        }
        #endregion

        #region Binding
        private static void BindValues(ParserOptions options, Object instance, ILookup<MemberBinding, ParameterPair> matches)
        {
            List<Object> boundMembers = new List<Object>();

            foreach (var binding in matches.OrderByDescending(x => x.Any(p => p.Matched)))
            {
                var attribute = binding.Key.Attribute;
                var member = binding.Key.Member;

                var bindingPolicy = binding.Key.BindingPolicy == BindingPolicy.Default && (member is PropertyInfo)
                        ? BindingPolicy.Once
                        : binding.Key.BindingPolicy;

                bool bindOnce = bindingPolicy == BindingPolicy.Once;

                foreach (var pair in binding)
                {
                    bool isBound = boundMembers.Contains(member);

                    if (isBound && bindOnce)
                        break;

                    bool shouldBlock = false;
                    var flagPair = pair as FlagPair;
                    try
                    {
                        if (pair.Matched)
                        {
                            if (flagPair != null) BindFlag(options, instance, flagPair, member, (IFlagOptionAttribute) attribute);
                            else BindArgument(options, instance, pair, member, attribute);

                            shouldBlock = true;
                        }
                        else if (pair.Argument.DefaultValue != null)
                        {
                            BindDefaultValue(options, instance, pair, member, attribute);
                        }
                    }
                    catch (ParsingException ex)
                    {
                        if (options.ExceptionHandler == null || !options.ExceptionHandler.Invoke(ex))
                            throw;
                    }
                    catch (Exception ex)
                    {
                        var parsingException = new ParsingException(ex, member: member, context: instance, pair: pair);

                        if (options.ExceptionHandler == null || !options.ExceptionHandler.Invoke(parsingException))
                            throw parsingException;
                    }

                    if (bindOnce && !isBound && shouldBlock)
                        boundMembers.Add(member);
                }
            }
        }

        private static void BindDefaultValue(ParserOptions options, Object instance, ParameterPair pair, Object member, IOptionAttribute attribute)
        {
            var property = member as PropertyInfo;
            var methodInfo = member as MethodInfo;

            Object defaultValue;
            pair.Argument.TryGetDefaultValue(out defaultValue);

            if (property != null)
                BindValue(instance, property, pair, defaultValue, options.Culture);
            else if (methodInfo != null)
                BindValue(instance, methodInfo, pair, attribute, attribute.ManualBinding, defaultValue, options.Culture);
            else throw new ArgumentException(INVALID_MEMBER_TYPE_EXCEPTION_MESSAGE, "member");
        }

        private static void BindArgument(ParserOptions options, Object instance, ParameterPair pair, Object member, IOptionAttribute attribute)
        {
            var property = member as PropertyInfo;
            var methodInfo = member as MethodInfo;

            if (property != null)
            {
                foreach (var value in pair.Values)
                    BindValue(instance, property, pair, value, options.Culture);
            }
            else if (methodInfo != null)
            {
                if (attribute.ManualBinding)
                    BindValue(instance, methodInfo, pair, attribute, true, null, options.Culture);
                else foreach (var value in pair.Values)
                    BindValue(instance, methodInfo, pair, attribute, false, value, options.Culture);
            }
            else throw new ArgumentException(INVALID_MEMBER_TYPE_EXCEPTION_MESSAGE, "member");
        }

        private static void BindFlag(ParserOptions options, Object instance, FlagPair flagPair, Object member, IFlagOptionAttribute attribute)
        {
            var property = member as PropertyInfo;
            var methodInfo = member as MethodInfo;

            // We're binding a property
            if (property != null)
            {
                if (property.PropertyType == typeof (Boolean))
                    BindValue(instance, property, flagPair, flagPair.Count > 0, options.Culture);
                else if (flagPair.Count > 0)
                    BindValue(instance, property, flagPair, flagPair.Count, options.Culture);
                else foreach (var value in flagPair.Values)
                    BindValue(instance, property, flagPair, value, options.Culture);
            }
            else if (methodInfo != null) // ...or invoking a method
            {
                if (flagPair.Argument.Type == typeof (Boolean))
                    BindValue(instance, methodInfo, flagPair, attribute, attribute.ManualBinding, flagPair.Count > 0, options.Culture);
                else if (attribute.ManualBinding || flagPair.Count > 0)
                    BindValue(instance, methodInfo, flagPair, attribute, attribute.ManualBinding, flagPair.Count, options.Culture);
                else foreach (var value in flagPair.Values)
                    BindValue(instance, methodInfo, flagPair, attribute, false, value, options.Culture);
            }
            else throw new ArgumentException(INVALID_MEMBER_TYPE_EXCEPTION_MESSAGE, "member");
        }

        private static void BindValue(Object instance, PropertyInfo property, ParameterPair pair, Object value, CultureInfo culture)
        {
            var convertedValue = ValueConverter.ConvertValue(pair.Argument.Type, culture, value);

            if (!property.CanWrite)
                throw new ParserBindingException(UNWRITABLE_PROPERTY_EXCEPTION_MESSAGE, pair: pair, member: property, context: instance);

            property.SetValue(instance, convertedValue);
        }

        private static void BindValue(Object instance, MethodInfo method, ParameterPair pair, IOptionAttribute attribute, Boolean manualBinding, Object value, CultureInfo culture)
        {
            var convertedValue = ValueConverter.ConvertValue(pair.Argument.Type, culture, value);
            method.Invoke(instance, manualBinding
                ? new[] { convertedValue, new BindingEventArgs(pair, attribute) }
                : new[] { convertedValue });
        }
        #endregion
    }
}
