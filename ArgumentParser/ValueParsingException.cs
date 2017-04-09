//-----------------------------------------------------------------------
// <copyright file="ValueParsingException.cs" company="LouisTakePILLz">
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
