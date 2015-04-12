//-----------------------------------------------------------------------
// <copyright file="POSIXFlagAttribute.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Factory
{
    /// <summary>
    /// Represents a POSIX-flavored flag option attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class POSIXFlagAttribute : Attribute, ICoupleableOptionAttribute, IFlagOptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Factory.POSIXFlagAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public POSIXFlagAttribute(String tag)
        {
            this.Tag = tag;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Factory.POSIXFlagAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public POSIXFlagAttribute(Char tag)
        {
            this.Tag = tag.ToString();
            this.IsShort = true;
        }

        /// <summary>
        /// Gets or sets the tag that defines the argument.
        /// </summary>
        public String Tag { get; set; }

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
        TypeConverter IOptionAttribute.TypeConverter
        {
            get { return null; }
        }

        /// <summary>
        /// Gets a boolean value indicating whether the argument is represented by a single <see cref="T:System.Char"/>.
        /// </summary>
        public Boolean IsShort { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="T:ArgumentParser.Arguments.FlagOptions"/> value(s) that define the behavior of the flag.
        /// </summary>
        public FlagOptions Options { get; set; }

        /// <summary>
        /// Gets the unique identifier for this <see cref="T:ArgumentParser.Factory.POSIXOptionAttribute"/>.
        /// </summary>
        public override Object TypeId
        {
            get { return Guid.NewGuid(); }
        }
    }
}
