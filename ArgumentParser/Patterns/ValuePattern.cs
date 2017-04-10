//-----------------------------------------------------------------------
// <copyright file="ValuePattern.cs" company="LouisTakePILLz">
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

namespace ArgumentParser
{
    public static partial class Parser
    {
        #if DEBUG
        internal const String VALUE_PATTERN = @"
            (?<=^|\s)
            (?<!\\\s)
            (
                "" (?<value> (?> \\.  | [^""] )*) ""|
                '  (?<value> (?> \\.  | [^'] )*) '|
                   (?<value> (?> \\.  | [^\s""']  )+)
            )
            (?=$|\s)";
        #else
        internal const String VALUE_PATTERN = @"(?<=^|\s)(?<!\\\s)(""(?<value>(?>\\.|[^""])*)""|'(?<value>(?>\\.|[^'])*)'|(?<value>(?>\\.|[^\s""'])+))(?=$|\s)";
        #endif
    }
}
