//-----------------------------------------------------------------------
// <copyright file="ParameterDisambiguationTestUnit.cs" company="LouisTakePILLz">
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
using System.Globalization;
using System.Linq;
using System.Threading;
using ArgumentParser;
using ArgumentParser.Arguments;
using ArgumentParser.Arguments.Getopt;
using ArgumentParser.Arguments.Windows;
using ArgumentParser.Helpers;
using NUnit.Framework;

namespace ArgumentParserTest
{
    [TestFixture]
    public class ParameterDisambiguationTestUnit
    {
        private static readonly IArgument interfaceLongVerb = new GetoptLongArgument("interface", description: "The network interface(s) to use.");
        private static readonly IArgument interfaceShortVerb = new GetoptShortArgument<String[]>('i', "The network interface(s) to use.", typeConverter: new StringArrayConverter());
        private static readonly IArgument getoptPortShortVerb = new GetoptShortArgument<UInt16>('p', "The port to listen to.");
        private static readonly IArgument getoptPortLongVerb = new GetoptLongArgument<UInt16>("port", "The port to listen to.");
        private static readonly IArgument windowsPortShortVerb = new WindowsArgument<UInt16>("p");
        private static readonly IArgument windowsPortLongVerb = new WindowsArgument<UInt16>("port");
        private static readonly IArgument getoptCADirVerb = new GetoptLongArgument("CAdir", description: "The directory to retrieve the certificates authorities from.");
        private static readonly IArgument getoptVerboseShortVerb = new GetoptShortFlag('v', "The verbosity level.");
        private static readonly IArgument getoptVerboseLongVerb = new GetoptLongArgument<Byte>("verbose", "The verbosity level.");

        private static readonly IArgument[] arguments =
        {
            interfaceShortVerb,
            interfaceLongVerb,
            getoptPortShortVerb,
            getoptPortLongVerb,
            getoptCADirVerb,
            getoptVerboseShortVerb,
            getoptVerboseLongVerb,
            windowsPortLongVerb,
            windowsPortShortVerb
        };

        private static readonly ParserOptions getoptOptions = new ParserOptions(ParameterTokenStyle.Getopt)
        {
            Culture = CultureInfo.GetCultureInfoByIetfLanguageTag("sv-SE")
        };

        private static readonly ParserOptions windowsOptions = new ParserOptions(ParameterTokenStyle.Windows)
        {
            Culture = CultureInfo.GetCultureInfoByIetfLanguageTag("sv-SE")
        };

        [Test]
        public void TestCollisionDetection()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("sv-SE");
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var args = Parser.GetParameters("--CAdir ..\\ca -i eth0,lo -h 127.0.0.1 -p 20327 -p 15 --port 3030 -1111 -vvv 5342642 -vvvvvv 5", getoptOptions, arguments).ToArray();
            var matchedParameters = args.OfType<ParameterPair>();
            var unmatchedParameters = args.OfType<RawParameter>();

            try
            {
                var port = matchedParameters.GetValue<UInt16>(getoptPortShortVerb, getoptPortLongVerb);
            }
            catch (ParsingException)
            {
                return;
            }
            Assert.Fail();
        }

        [Test]
        public void TestWindowsParameters()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var args = Parser.GetParameters(@"/test /h /q /foo bar\ baz\ blah /t ""e\""s\""t\"" /1 234 /p 5 /port 32", windowsOptions, arguments).ToArray();
            var matchedParameters = args.OfType<ParameterPair>();
            var unmatchedParameters = args.OfType<RawParameter>();

            try
            {
                var port = matchedParameters.GetValue<UInt16>(windowsPortShortVerb, windowsPortLongVerb);
            }
            catch (ParsingException)
            {
                return;
            }
            Assert.Fail();
        }
    }
}
