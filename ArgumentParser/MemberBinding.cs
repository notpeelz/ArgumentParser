//-----------------------------------------------------------------------
// <copyright file="MemberBinding.cs" company="LouisTakePILLz">
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
using ArgumentParser.Reflection;

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
