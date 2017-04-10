//-----------------------------------------------------------------------
// <copyright file="FlagTestUnit.cs" company="LouisTakePILLz">
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
using System.Collections.Generic;
using System.Linq;
using ArgumentParser;
using ArgumentParser.Arguments;
using ArgumentParser.Reflection.POSIX;
using Xunit;

namespace ArgumentParserTest
{
    public class FlagTestUnit
    {
        [Fact]
        public void TestFlag()
        {
            var a = Parser.GetRawParameters("--test t es t 123 456", ParameterTokenStyle.POSIX);
            //Main.Instance.Parse(@"--foobar 20 --foobar 19 --foobar 20 -bbbb -b -b 2");
            Main.Instance.Parse(@"-ttt -t 39 -tt -t");
            //Assert.AreEqual("blahssetest", Main.Instance.Test);
            Assert.Equal(6, Main.Instance.T);
            //Assert.AreEqual(7, (int) Main.Instance.B);
        }

        public sealed class Main : IParserContext
        {
            #region Singleton Declaration
            private static readonly Main instance = new Main();
            public static Main Instance { get { return instance; } }
            #endregion

            #region IParserContext Members
            private static readonly ParserOptions options = new ParserOptions(ParameterTokenStyle.POSIX);

            ParserOptions IParserContext.Options
            {
                get { return options; }
            }

            public void Init(IEnumerable<String> verbs)
            {

            }

            public void HandleParameters(IEnumerable<RawParameter> parameters)
            {
                this.Test = parameters.Aggregate(String.Empty, (a, x) => String.Join(String.Empty, Enumerable.Repeat(x.Key.Tag, x.Count)) + Environment.NewLine);
            }

            public void HandleValues(IEnumerable<UnboundValue> values)
            {

            }
            #endregion

            public String Test { get; private set; }

            [POSIXFlag('t', FlagOptions = FlagOptions.AggregateExplicit | FlagOptions.AggregateImplicit)]
            //[POSIXFlag("foobar", Options = FlagOptions.Aggregate | FlagOptions.AggregateExplicit)]
            //[POSIXFlag("foobar", Description = "Magic!", Options = FlagOptions.Aggregate | FlagOptions.AggregateExplicit)]
            public Int32 T { get; private set; }

            [POSIXFlag('b')]
            public TestEnum B { get; private set; }

            public enum TestEnum
            {
                A = 1,
                B,
                C
            }
        }
    }
}
