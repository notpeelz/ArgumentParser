//-----------------------------------------------------------------------
// <copyright file="PSFlagAttribute.cs" company="LouisTakePILLz">
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
using ArgumentParser.Arguments.PowerShell;
using ArgumentParser.Helpers;

namespace ArgumentParser.Reflection.PowerShell
{
    /// <summary>
    /// Represents a PowerShell-like flag option attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class PSFlagAttribute : PSOptionAttribute, IFlagOptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.PowerShell.PSFlagAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public PSFlagAttribute(String tag) : base(tag) { }

        /// <summary>
        /// Gets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        public FlagOptions FlagOptions { get; private set; }

        /// <summary>
        /// Gets an argument definition using the supplied specifications.
        /// </summary>
        /// <param name="valueType">The expected value type to convert and bind to.</param>
        /// <param name="formatProvider">The format provider to use.</param>
        /// <returns>The newly created argument definition.</returns>
        public override IArgument CreateArgument(Type valueType, IFormatProvider formatProvider)
        {
            var value = ValueConverter.ConvertValue(this.DefaultValue, valueType, formatProvider);
            var type = typeof (PowerShellFlag<>).MakeGenericType(valueType);

            return (IArgument) Activator.CreateInstance(type, this.Tag, this.Description, this.ValueOptions, this.FlagOptions, this.TypeConverter, value);
        }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        TypeConverter IOptionAttribute.TypeConverter
        {
            get { return null; }
        }
    }
}
