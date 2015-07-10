//-----------------------------------------------------------------------
// <copyright file="PreprocessorDelegate.cs" company="LouisTakePILLz">
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
using System.Globalization;

namespace ArgumentParser
{
    /// <summary>
    /// Preprocesses and perform various operations on an input string, such as escaped token substitution.
    /// </summary>
    /// <param name="input">The input string to format.</param>
    /// <param name="culture">The culture to use for preprocessing.</param>
    /// <returns>The preprocessed input string.</returns>
    public delegate String PreprocessorDelegate(String input, CultureInfo culture);
}
