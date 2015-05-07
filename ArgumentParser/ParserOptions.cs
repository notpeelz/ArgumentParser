//-----------------------------------------------------------------------
// <copyright file="ParserOptions.cs" company="LouisTakePILLz">
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
using System.Globalization;
using ArgumentParser.Reflection;
using ArgumentParser.Reflection.PowerShell;
using ArgumentParser.Reflection.POSIX;
using ArgumentParser.Reflection.Windows;

namespace ArgumentParser
{
    /// <summary>
    /// Represents the configuration to use by the parser.
    /// </summary>
    [Serializable]
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
        private static readonly AttributeFilterDelegate powerShellAttributeFilter = a => a is IPSOptionAttribute;
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
                case ParameterTokenStyle.PowerShell:
                    return powerShellAttributeFilter;
                default:
                    throw new ArgumentOutOfRangeException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }
    }
}
