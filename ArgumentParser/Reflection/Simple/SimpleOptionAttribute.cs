//-----------------------------------------------------------------------
// <copyright file="SimpleOptionAttribute.cs" company="LouisTakePILLz">
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
using System.ComponentModel;
using ArgumentParser.Arguments;
using ArgumentParser.Arguments.Simple;
using ArgumentParser.Helpers;

namespace ArgumentParser.Reflection.Simple
{
    /// <summary>
    /// Represents a minimalism-flavored option attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class SimpleOptionAttribute : Attribute, ISimpleOptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.Simple.SimpleOptionAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public SimpleOptionAttribute(String tag)
        {
            this.Tag = tag;
        }

        /// <summary>
        /// Gets the tag that defines the argument.
        /// </summary>
        public String Tag { get; private set; }

        /// <summary>
        /// Gets or sets the description of the argument.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets a boolean value indicating whether the member is meant to be manually bound or not. (Only applies to methods)
        /// </summary>
        public Boolean ManualBinding { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:ArgumentParser.Arguments.ValueOptions"/> value(s) that define how values should be interpreted.
        /// </summary>
        public ValueOptions ValueOptions { get; set; }

        /// <summary>
        /// Gets or sets the default value of the argument.
        /// </summary>
        public Object DefaultValue { get; set; }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        public virtual TypeConverter TypeConverter { get; protected set; }

        /// <summary>
        /// Gets the delegate used for preprocessing.
        /// </summary>
        public virtual PreprocessorDelegate Preprocessor { get; protected set; }

        /// <summary>
        /// Gets an argument definition using the supplied specifications.
        /// </summary>
        /// <param name="valueType">The expected value type to convert and bind to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <returns>The newly created argument definition.</returns>
        public virtual IArgument CreateArgument(Type valueType, IFormatProvider formatProvider)
        {
            var defaultValue = ValueConverter.ConvertValue(valueType, formatProvider, this.DefaultValue);
            var type = typeof (SimpleArgument<>).MakeGenericType(valueType);

            return (IArgument) Activator.CreateInstance(type, this.Tag, this.Description, this.ValueOptions, this.TypeConverter, this.Preprocessor, defaultValue);
        }

        /// <summary>
        /// Gets the unique identifier for this option attribute.
        /// </summary>
        public override Object TypeId
        {
            get { return Guid.NewGuid(); }
        }
    }
}
