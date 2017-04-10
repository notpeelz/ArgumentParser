//-----------------------------------------------------------------------
// <copyright file="BindingEventArgs.cs" company="LouisTakePILLz">
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
