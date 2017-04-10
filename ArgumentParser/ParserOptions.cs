//-----------------------------------------------------------------------
// <copyright file="ParserOptions.cs" company="LouisTakePILLz">
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
using System.Globalization;
using ArgumentParser.Reflection;
using ArgumentParser.Reflection.Simple;
using ArgumentParser.Reflection.POSIX;
using ArgumentParser.Reflection.Windows;

namespace ArgumentParser
{
    /// <summary>
    /// Represents the configuration to use by the parser.
    /// </summary>
    public sealed class ParserOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ParserOptions"/> class.
        /// </summary>
        public ParserOptions()
        {
            this.PairEqualityComparer = Parser.DefaultPairEqualityComparer;
            this.Preprocessor = Parser.DefaultPreprocessor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ParserOptions"/> class.
        /// </summary>
        /// <param name="tokenStyle">The parser syntax to use.</param>
        public ParserOptions(ParameterTokenStyle tokenStyle) : this()
        {
            this.TokenStyle = tokenStyle;
        }

        /// <summary>
        /// Gets or sets the culture to use for parsing and converting.
        /// </summary>
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// Gets or sets the parser syntax to use.
        /// </summary>
        public ParameterTokenStyle TokenStyle { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:ArgumentParser.IPairable"/> equality comparer.
        /// </summary>
        public IEqualityComparer<IPairable> PairEqualityComparer { get; set; }

        /// <summary>
        /// Gets or sets the preprocessor delegate to use upon parsing values.
        /// </summary>
        public PreprocessorDelegate Preprocessor { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:ArgumentParser.Reflection.IOptionAttribute"/> predicate that is used to filter mapped arguments given a specific token style.
        /// </summary>
        public AttributeFilterDelegate OptionAttributeFilter { get; set; }

        /// <summary>
        /// Gets or sets the exception handler delegate to use upon throwing an exception.
        /// </summary>
        public Func<ParsingException, Boolean> ExceptionHandler { get; set; }

        private static readonly AttributeFilterDelegate posixAttributeFilter = a => a is IPOSIXOptionAttribute;
        private static readonly AttributeFilterDelegate simpleAttributeFilter = a => a is ISimpleOptionAttribute;
        private static readonly AttributeFilterDelegate windowsAttributeFilter = a => a is IWindowsOptionAttribute;

        internal AttributeFilterDelegate GetAttributeFilter()
        {
            if (this.OptionAttributeFilter != null)
                return this.OptionAttributeFilter;

            switch (this.TokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return posixAttributeFilter;
                case ParameterTokenStyle.Windows:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.WindowsEqual:
                    return windowsAttributeFilter;
                case ParameterTokenStyle.Simple:
                    return simpleAttributeFilter;
                default:
                    throw new ArgumentOutOfRangeException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }
    }
}
