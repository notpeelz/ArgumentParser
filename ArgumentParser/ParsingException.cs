//-----------------------------------------------------------------------
// <copyright file="ParsingException.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    /// <summary>
    /// The exception that is thrown when a parsing operation fails.
    /// </summary>
    [Serializable]
    public class ParsingException : Exception
    {
        private const String EXCEPTION_MESSAGE = "An issue occured while parsing parameters.";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ParsingException"/> class.
        /// </summary>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ParsingException(Object member = null, Object context = null, ParameterPair pair = null)
            : base(EXCEPTION_MESSAGE)
        {
            this.Member = member;
            this.Context = context;
            this.Pair = pair;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ParsingException"/> class.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ParsingException(Exception innerException, Object member = null, Object context = null, ParameterPair pair = null)
            : base(EXCEPTION_MESSAGE, innerException)
        {
            this.Member = member;
            this.Context = context;
            this.Pair = pair;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ParsingException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ParsingException(String message, Object member = null, Object context = null, ParameterPair pair = null)
            : base(message)
        {
            this.Member = member;
            this.Context = context;
            this.Pair = pair;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArgumentParser.ParsingException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <param name="member">The member used upon failing.</param>
        /// <param name="context">The context throwing the exception (if applicable).</param>
        /// <param name="pair">The parameter pair being parsed upon failing.</param>
        public ParsingException(String message, Exception innerException, Object member = null, Object context = null, ParameterPair pair = null)
            : base(message, innerException)
        {
            this.Member = member;
            this.Context = context;
            this.Pair = pair;
        }

        /// <summary>
        /// Gets the member that was being used upon throwing an exception (if applicable).
        /// </summary>
        public Object Member { get; private set; }

        /// <summary>
        /// Gets the context instance being parsed (if applicable).
        /// </summary>
        public Object Context { get; private set; }

        /// <summary>
        /// Gets the parameter pair being parsed (if applicable).
        /// </summary>
        public ParameterPair Pair { get; private set; }
    }
}
