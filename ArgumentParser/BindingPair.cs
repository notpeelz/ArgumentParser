//-----------------------------------------------------------------------
// <copyright file="BindingPair.cs" company="LouisTakePILLz">
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
using ArgumentParser.Factory;

namespace ArgumentParser
{
    /// <summary>
    /// Represents a member-attribute binding.
    /// </summary>
    internal class MemberBinding
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.MemberBinding"/> class.
        /// </summary>
        /// <param name="member">The member being paired.</param>
        /// <param name="attribute">The attribute adorning the member.</param>
        /// <param name="bindingPolicy">The policy defining the binding behavior.</param>
        public MemberBinding(Object member, IOptionAttribute attribute, BindingPolicy bindingPolicy)
        {
            this.Member = member;
            this.Attribute = attribute;
            this.BindingPolicy = bindingPolicy;
        }

        /// <summary>
        /// Gets the adorned member.
        /// </summary>
        public Object Member { get; private set; }
        
        /// <summary>
        /// Gets the attribute adorning the member.
        /// </summary>
        public IOptionAttribute Attribute { get; private set; }
        
        /// <summary>
        /// Gets the binding policy.
        /// </summary>
        public BindingPolicy BindingPolicy { get; private set; }
    }
}
