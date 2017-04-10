//-----------------------------------------------------------------------
// <copyright file="WindowsTestUnit.cs" company="LouisTakePILLz">
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
using ArgumentParser;
using ArgumentParser.Reflection.Windows;
using Xunit;

namespace ArgumentParserTest
{
    public class WindowsTestUnit
    {
        [Fact]
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
            private static readonly ParserOptions options = new ParserOptions(ParameterTokenStyle.Windows);

            ParserOptions IParserContext.Options
            {
                get { return options; }
            }

            public void Init(IEnumerable<String> verbs)
            {

            }

            public void HandleParameters(IEnumerable<RawParameter> parameters)
            {

            }

            public void HandleValues(IEnumerable<UnboundValue> values)
            {

            }
            #endregion

            [WindowsFlag("test", DefaultValue = true)]
            public Boolean Test { get; private set; }
        }
    }
}
