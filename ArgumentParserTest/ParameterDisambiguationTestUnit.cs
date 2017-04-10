//-----------------------------------------------------------------------
// <copyright file="ParameterDisambiguationTestUnit.cs" company="LouisTakePILLz">
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
using System.Globalization;
using System.Linq;
using ArgumentParser;
using ArgumentParser.Arguments;
using ArgumentParser.Arguments.POSIX;
using ArgumentParser.Arguments.Windows;
using ArgumentParser.Helpers;
using Xunit;

#if NETFRAMEWORK
using System.Threading;
#endif

namespace ArgumentParserTest
{
    public class ParameterDisambiguationTestUnit
    {
        private static readonly IArgument interfaceLongVerb = new POSIXLongArgument("interface", description: "The network interface(s) to use.");
        private static readonly IArgument interfaceShortVerb = new POSIXShortArgument<String[]>('i', "The network interface(s) to use.", typeConverter: new StringArrayConverter());
        private static readonly IArgument posixPortShortVerb = new POSIXShortArgument<UInt16>('p', "The port to listen to.");
        private static readonly IArgument posixPortLongVerb = new POSIXLongArgument<UInt16>("port", "The port to listen to.");
        private static readonly IArgument windowsPortShortVerb = new WindowsArgument<UInt16>("p");
        private static readonly IArgument windowsPortLongVerb = new WindowsArgument<UInt16>("port");
        private static readonly IArgument posixCADirVerb = new POSIXLongArgument("CAdir", description: "The directory to retrieve the certificates authorities from.");
        private static readonly IArgument posixVerboseShortVerb = new POSIXShortFlag('v', "The verbosity level.");
        private static readonly IArgument posixVerboseLongVerb = new POSIXLongArgument<Byte>("verbose", "The verbosity level.");

        private static readonly IArgument[] arguments =
        {
            interfaceShortVerb,
            interfaceLongVerb,
            posixPortShortVerb,
            posixPortLongVerb,
            posixCADirVerb,
            posixVerboseShortVerb,
            posixVerboseLongVerb,
            windowsPortLongVerb,
            windowsPortShortVerb
        };

        private static readonly ParserOptions posixOptions = new ParserOptions(ParameterTokenStyle.POSIX)
        {
            Culture = new CultureInfo("sv-SE")
        };

        private static readonly ParserOptions windowsOptions = new ParserOptions(ParameterTokenStyle.Windows)
        {
            Culture = new CultureInfo("sv-SE")
        };

        [Fact]
        public void TestCollisionDetection()
        {
            //CultureInfo.CurrentCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("sv-SE");
#if NETSTANDARD
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
#else
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
#endif

            var args = Parser.GetParameters("--CAdir ..\\ca -i eth0,lo -h 127.0.0.1 -p 20327 -p 15 --port 3030 -1111 -vvv 5342642 -vvvvvv 5", posixOptions, arguments).ToArray();
            var matchedParameters = args.OfType<ParameterPair>();
            var unmatchedParameters = args.OfType<RawParameter>();

            Assert.Throws<ParsingException>(() =>
            {
                var port = matchedParameters.GetValue<UInt16>(posixPortShortVerb, posixPortLongVerb);
            });
        }

        [Fact]
        public void TestWindowsParameters()
        {
#if NETSTANDARD
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
#else
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
#endif

            var args = Parser.GetParameters(@"/test /h /q /foo bar\ baz\ blah /t ""e\""s\""t\"" /1 234 /p 5 /port 32", windowsOptions, arguments).ToArray();
            var matchedParameters = args.OfType<ParameterPair>();
            var unmatchedParameters = args.OfType<RawParameter>();

            Assert.Throws<ParsingException>(() =>
            {
                var port = matchedParameters.GetValue<UInt16>(windowsPortShortVerb, windowsPortLongVerb);
            });
        }
    }
}
