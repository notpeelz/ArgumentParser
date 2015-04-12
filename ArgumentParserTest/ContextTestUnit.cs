//-----------------------------------------------------------------------
// <copyright file="ContextTestUnit.cs" company="LouisTakePILLz">
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
using System.Diagnostics;
using System.Linq;
using ArgumentParser;
using ArgumentParser.Arguments;
using ArgumentParser.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArgumentParserTest
{
    [TestClass]
    public class ContextTestUnit
    {
        [TestInitialize]
        public void Init()
        {
            //Main.Instance.Parse("install global - test-app atom \"test --test --blah \" --test -f -b");
            Main.Instance.Parse("-u Test1,Test2 --test -t -a 'short' --ambiguous \"long\" -vvvv -eeee -hhhh -hhh -hh -h -i 15 -i 1 -i 0 -i");
        }

        [TestMethod]
        public void TestPropertyAttribute()
        {
            Assert.IsTrue(Main.Instance.AmbiguousValue == "short" || Main.Instance.AmbiguousValue == "long");
        }

        [TestMethod]
        public void TestListSeparation()
        {
            Assert.AreEqual(2, Main.Instance.Usernames.Length);
            Assert.AreEqual("Test1", Main.Instance.Usernames.First());
            Assert.AreEqual("Test2", Main.Instance.Usernames.Last());
        }

        [TestMethod]
        public void TestUnboundFlagDefault()
        {
            Assert.IsTrue(Main.Instance.UnaffectedDefault);
        }

        [TestMethod]
        public void TestFlagInversion()
        {
            Assert.AreEqual(1, Main.Instance.InvertedValue);
        }

        [TestMethod]
        public void TestImplicitConversion()
        {
            Assert.IsTrue(!Main.Instance.ImplicitlyConvertedValue);
        }

        [TestMethod]
        public void TestValuedFlagAggregation()
        {
            Assert.AreEqual(4, Main.Instance.VerbosityLevel);
        }

        [TestMethod]
        public void TestFlagAggregation()
        {
            Assert.AreEqual(4, Main.Instance.SecondVerbosityLevel);
        }

        [TestMethod]
        public void TestEnumFlag()
        {
            Assert.AreEqual((VerbosityLevel) (1 << 4) - 1, Main.Instance.ThirdVerbosityLevel);
        }

        private class Main : IParserContext
        {
            #region Singleton declaration
            private static readonly Main instance = new Main();

            public static Main Instance { get { return instance; } }

            private Main() { }
            #endregion

            #region IParserContext members
            private readonly ParserOptions options = new ParserOptions(ParameterTokenStyle.POSIX)
            {
                Detokenize = true,
                IgnoreUnmatchedParameters = false,
                ExceptionHandler = ExceptionHandler
            };

            public ParserOptions Options
            {
                get { return this.options; }
            }

            public void Init(String[] verbs)
            {

            }

            public void HandleParameter(RawParameter parameter)
            {
                Debug.WriteLine("{0} #{1}: \"{2}\" (Compound: {3})", parameter.Key, parameter.Count, parameter.Value, parameter.CoupleCount > 1);
            }

            public void HandleValue(UnboundValue value)
            {
                Debug.WriteLine("Parent: {0}, Value: {1}", value.Key, value.Value);
            }

            private static Boolean ExceptionHandler(ParsingException exception)
            {
                if (exception.InnerException is FormatException)
                    return true;

                return false;
            }
            #endregion

            #region Main options
            [POSIXFlag('f', DefaultValue = true)]
            public Boolean UnaffectedDefault { get; set; }

            [POSIXFlag('i', DefaultValue = true, Options = FlagOptions.InvertBoolean)]
            public Boolean ImplicitlyConvertedValue { get; set; }

            [POSIXFlag('t', DefaultValue = 1)]
            public Int32 InvertedValue { get; set; }

            [POSIXListOption('u', ManualBinding = true, DefaultValue = "anonymous", Description = "The username used to authenticate against the server.")]
            private void AddUsernames(String[] usernames, BindingEventArgs eventArgs)
            {
                this.Usernames = (String[]) (usernames ?? eventArgs.Pair.Values.First());
            }

            public String[] Usernames { get; private set; }

            [POSIXOption('a')]
            [POSIXOption("ambiguous")]
            public String AmbiguousValue { get; set; }

            [POSIXFlag('v')]
            public Int32 VerbosityLevel { get; set; }

            [POSIXFlag('e')]
            public Int32 SecondVerbosityLevel { get; set; }

            /*[POSIXFlag('h', ManualBinding = true)]
            public void SetVerbosityLevel(VerbosityLevel level, BindingEventArgs eventArgs)
            {
                var values = eventArgs.Pair.Values.ToArray();
                this.ThirdVerbosityLevel = values.Length > 0 && values.All(x => x == null)
                    ? (VerbosityLevel) (1 << (values.Length - 1))
                    : level;
            }*/

            [POSIXFlag('h', ManualBinding = true, Options = FlagOptions.BitFieldImplicit | FlagOptions.AggregateImplicit | FlagOptions.AggregateCombine)]
            public VerbosityLevel ThirdVerbosityLevel { get; set; }
            #endregion

            #region Verbs
            [Verb("install")]
            public Install InstallVerb { get; set; }
            #endregion

            #region Nested verb classes
            public class Install : IVerbContext
            {
                public Install() { }

                public void Init(String[] verbs)
                {
                    if (!verbs.Any())
                        throw new NotSupportedException();

                    this.InstallLocal = new Local();
                    this.InstallLocal.Init(verbs);
                }

                public void HandleParameter(RawParameter parameter)
                {

                }

                public void HandleValue(UnboundValue value)
                {

                }

                #region Verbs
                [Verb("local")]
                public Local InstallLocal { get; set; }

                [Verb("global")]
                [Verb("g")]
                public Global InstallGlobal { get; set; }
                #endregion

                #region Nested verb classes
                public class Local : IVerbContext
                {
                    public void Init(String[] verbs)
                    {
                        if (!verbs.Any())
                            throw new NotSupportedException();

                        this.Names = verbs;
                    }

                    public void HandleParameter(RawParameter parameter)
                    {
                        throw new NotImplementedException();
                    }

                    public void HandleValue(UnboundValue value)
                    {
                        throw new NotImplementedException();
                    }

                    [POSIXFlag('f')]
                    public Boolean ForceInstall { get; set; }

                    public String[] Names { get; set; }
                }

                public class Global : IVerbContext
                {
                    public void Init(String[] verbs)
                    {
                        if (!verbs.Any())
                            throw new NotSupportedException();

                        this.Names = verbs;
                    }

                    public void HandleParameter(RawParameter parameter)
                    {
                        throw new NotImplementedException();
                    }

                    public void HandleValue(UnboundValue value)
                    {
                        throw new NotImplementedException();
                    }

                    [POSIXFlag('f')]
                    public Boolean ForceInstall { get; set; }

                    public String[] Names { get; set; }
                }
                #endregion
            }
            #endregion
        }

        [Flags]
        public enum VerbosityLevel
        {
            None = 0,
            Info = 1,
            Warning = 1 << 1,
            Error = 1 << 2,
            Debug = 1 << 3
        }
    }
}
