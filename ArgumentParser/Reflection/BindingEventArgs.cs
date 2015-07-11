//-----------------------------------------------------------------------
// <copyright file="BindingEventArgs.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Reflection
{
    /// <summary>
    /// Provides data for manually bound members upon passing the input.
    /// </summary>
    public class BindingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.BindingEventArgs"/> class.
        /// </summary>
        public BindingEventArgs() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Reflection.BindingEventArgs"/> class.
        /// </summary>
        /// <param name="pair">The matched parameter pair.</param>
        /// <param name="attribute">The attribute adorning the member.</param>
        public BindingEventArgs(ParameterPair pair, IOptionAttribute attribute)
        {
            this.Pair = pair;
            this.Attribute = attribute;
        }

        /// <summary>
        /// Gets the corresponding <see cref="T:ArgumentParser.ParameterPair"/>.
        /// </summary>
        public ParameterPair Pair { get; private set; }

        /// <summary>
        /// Gets the attribute adorning the bound member.
        /// </summary>
        public IOptionAttribute Attribute { get; private set; }
    }
}
