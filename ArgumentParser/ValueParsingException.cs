//-----------------------------------------------------------------------
// <copyright file="ValueParsingException.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    /// <summary>
    /// The exception that is thrown when a parsing operation fails upon transforming a value.
    /// </summary>
    public class ValueParsingException : ParsingException
    {
        private const String EXCEPTION_MESSAGE = "An issue occured while parsing a value.";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ValueParsingException"/> class.
        /// </summary>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ValueParsingException(Object member = null, Object context = null, ParameterPair pair = null)
            : base(EXCEPTION_MESSAGE, member, context, pair) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ValueParsingException"/> class.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ValueParsingException(Exception innerException, Object member = null, Object context = null, ParameterPair pair = null)
            : base(EXCEPTION_MESSAGE, innerException, member, context, pair) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ValueParsingException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ValueParsingException(String message, Object member = null, Object context = null, ParameterPair pair = null)
            : base(message, member, context, pair) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ValueParsingException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ValueParsingException(String message, Exception innerException, Object member = null, Object context = null, ParameterPair pair = null)
            : base(message, innerException, member, context, pair) { }
    }
}
