//-----------------------------------------------------------------------
// <copyright file="POSIXListOptionAttribute.cs" company="LouisTakePILLz">
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
using System.ComponentModel;
using ArgumentParser.Helpers;

namespace ArgumentParser.Reflection.POSIX
{
    /// <summary>
    /// Represents a POSIX-flavored option attribute that supports splitting using a culture-dependent separator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class POSIXListOptionAttribute : POSIXOptionAttribute
    {
        private static readonly StringArrayConverter typeConverter = new StringArrayConverter();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.POSIX.POSIXListOptionAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public POSIXListOptionAttribute(String tag) : base(tag) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.POSIX.POSIXListOptionAttribute"/> class.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        public POSIXListOptionAttribute(Char tag) : base(tag) { }

        /// <summary>
        /// Gets the type converter used for value conversion.
        /// </summary>
        public override TypeConverter TypeConverter
        {
            get { return typeConverter; }
        }
    }
}
