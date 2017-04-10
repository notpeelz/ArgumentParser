//-----------------------------------------------------------------------
// <copyright file="POSIXParameterPattern.cs" company="LouisTakePILLz">
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
        private const String POSIX_PARAMETER_PATTERN = @"
            (?<=^|\s)
            (
                (?<prefix>-)
                (?<tag>[\w-[\d]]){2,}
                (
                    $|(?=\s+)
                    (?<value>
                        (
                            ("" (?> \\. | [^""])* "")|
                            ('  (?> \\. | [^'])* ')|
                            ( \\.-? | [^\-] | (?<!\s) \- | \-{3,} | \-{1,2} (?=\d|[^\-\w]|$) )
                        )+
                    )?
                )|
                (
                    (?<prefix>--)
                    (?<tag>(?!-)[\w\-]+(?<!\-))|
                    (?<prefix>-)
                    (?<tag>[\w-[\d]])
                )
                (
                    (\s*|=)
                    (?<value>
                        (
                            ("" (?> \\. | [^""])* "")|
                            ('  (?> \\. | [^'])* ')
                        )+
                    )|
                    (\s+|=)
                    (?<value>
                        ( \\.-? | [^\-] | (?<!\s) \- | \-{3,} | \-{1,2} (?=\d|[^\-\w]|$) )*
                    )
                )?
            )
            (?=\s|$)";
        #else
        private const String POSIX_PARAMETER_PATTERN = @"(?<=^|\s)((?<prefix>-)(?<tag>[\w-[\d]]){2,}($|(?=\s+)(?<value>((""(?>\\.|[^""])*"")|('(?>\\.|[^'])*')|(\\.-?|[^\-]|(?<!\s)\-|\-{3,}|\-{1,2}(?=\d|[^\-\w]|$)))+)?)|((?<prefix>--)(?<tag>(?!-)[\w\-]+(?<!\-))|(?<prefix>-)(?<tag>[\w-[\d]]))((\s*|=)(?<value>((""(?>\\.|[^""])*"")|('(?>\\.|[^'])*'))+)|(\s+|=)(?<value>(\\.-?|[^\-]|(?<!\s)\-|\-{3,}|\-{1,2}(?=\d|[^\-\w]|$))*))?)(?=\s|$)";
        #endif
    }
}
