//-----------------------------------------------------------------------
// <copyright file="WindowsTestUnit.cs" company="LouisTakePILLz">
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
using ArgumentParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArgumentParser.Factory;

namespace ArgumentParserTest
{
    [TestClass]
    public class WindowsTestUnit
    {
        [TestMethod]
        public void TestFlag()
        {
            Main.Instance.Parse("/test");
        }

        public sealed class Main : IParserContext
        {
            #region Singleton Declaration

            private static readonly Main instance = new Main();

            public static Main Instance
            {
                get { return instance; }
            }

            #endregion

            #region IParserContext Members

            private static readonly ParserOptions options = new ParserOptions(ParameterTokenStyle.Windows)
            {
                Detokenize = true
            };

            ParserOptions IParserContext.Options
            {
                get { return options; }
            }

            public void Init(String[] verbs)
            {
                throw new NotImplementedException();
            }

            public void HandleParameter(RawParameter parameter)
            {
                
            }
            #endregion

            [WindowsFlag("test", DefaultValue = true)]
            public Boolean Test { get; private set; }
        }
    }
}
