//-----------------------------------------------------------------------
// <copyright file="FlagTestUnit.cs" company="LouisTakePILLz">
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
using System.Collections.Generic;
using System.Linq;
using ArgumentParser;
using ArgumentParser.Arguments;
using ArgumentParser.Factory.POSIX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgumentParserTest
{
    [TestClass]
    public class FlagTestUnit
    {
        [TestMethod]
        public void TestFlag()
        {
            var a = Parser.GetRawParameters("--test t es t 123 456", ParameterTokenStyle.POSIX);
            //Main.Instance.Parse(@"--foobar 20 --foobar 19 --foobar 20 -bbbb -b -b 2");
            Main.Instance.Parse(@"-ttt -t 39 -tt -t");
            //Assert.AreEqual("blahssetest", Main.Instance.Test);
            Assert.AreEqual(6, Main.Instance.T);
            //Assert.AreEqual(7, (int) Main.Instance.B);
        }

        public sealed class Main : IParserContext
        {
            #region Singleton Declaration
            private static readonly Main instance = new Main();
            public static Main Instance { get { return instance; } }
            #endregion

            #region IParserContext Members
            private static readonly ParserOptions options = new ParserOptions(ParameterTokenStyle.POSIX)
            {
                Detokenize = true
            };

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
