//-----------------------------------------------------------------------
// <copyright file="BindingPolicyAttribute.cs" company="LouisTakePILLz">
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

namespace ArgumentParser.Factory
{
    /// <summary>
    /// Indicates how a member is meant to be be bound.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class BindingPolicyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.Factory.BindingPolicyAttribute"/> class.
        /// </summary>
        /// <param name="policy">The binding policy to use for the adorned member.</param>
        public BindingPolicyAttribute(BindingPolicy policy)
        {
            this.BindingPolicy = policy;
        }

        /// <summary>
        /// Gets the specified <see cref="T:ArgumentParser.Factory.BindingPolicy"/>.
        /// </summary>
        public BindingPolicy BindingPolicy { get; private set; }
    }
}
