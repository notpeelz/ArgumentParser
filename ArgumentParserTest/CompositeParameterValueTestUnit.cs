//-----------------------------------------------------------------------
// <copyright file="CompositeParameterValueTestUnit.cs" company="LouisTakePILLz">
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
using ArgumentParser;
using ArgumentParser.Arguments;
using ArgumentParser.Arguments.POSIX;
using ArgumentParser.Helpers;
using Xunit;

namespace ArgumentParserTest
{
    public class CompositeParameterValueTestUnit
    {
        private static readonly IArgument<String[]> pushShortArgument = new POSIXShortArgument<String[]>(
            tag: 'p',
            valueOptions: ValueOptions.Composite,
            typeConverter: new StringArrayConverter('\x20', StringSplitOptions.RemoveEmptyEntries));

        private static readonly ParserOptions options = new ParserOptions(ParameterTokenStyle.POSIX);

        [Fact]
        public void TestCompositeValues()
        {
            var args = Parser.GetParameters("-p origin    master  ", options, pushShortArgument);
            Assert.Equal(args.GetValue<String[]>(pushShortArgument).Length, 2);
        }
    }
}
