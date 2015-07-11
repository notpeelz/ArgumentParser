//-----------------------------------------------------------------------
// <copyright file="CompositeParameterValueTestUnit.cs" company="LouisTakePILLz">
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
using ArgumentParser;
using ArgumentParser.Arguments;
using ArgumentParser.Arguments.POSIX;
using ArgumentParser.Helpers;
using NUnit.Framework;

namespace ArgumentParserTest
{
    [TestFixture]
    public class CompositeParameterValueTestUnit
    {
        private static readonly IArgument<String[]> pushShortArgument = new POSIXShortArgument<String[]>(
            tag: 'p',
            valueOptions: ValueOptions.Composite,
            typeConverter: new StringArrayConverter('\x20', StringSplitOptions.RemoveEmptyEntries));

        private static readonly ParserOptions options = new ParserOptions(ParameterTokenStyle.POSIX);

        [Test]
        public void TestCompositeValues()
        {
            var args = Parser.GetParameters("-p origin    master  ", options, pushShortArgument);
            Assert.AreEqual(args.GetValue<String[]>(pushShortArgument).Length, 2);
        }
    }
}
