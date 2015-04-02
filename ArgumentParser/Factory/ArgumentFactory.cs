//-----------------------------------------------------------------------
// <copyright file="ArgumentFactory.cs" company="LouisTakePILLz">
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
using System.ComponentModel;
using ArgumentParser.Arguments;

namespace ArgumentParser.Factory
{
    /// <summary>
    /// Provides static methods for POSIX-flavored argument creation.
    /// </summary>
    public static class POSIXArgumentFactory
    {
        #region LongArgument methods
        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXLongArgument`1"/> of a dynamically-resolved type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IArgument CreateArgument(String tag, String description, Type returnType, TypeConverter typeConverter = null, Object defaultValue = null, Boolean allowComposite = false)
        {
            var type = typeof (POSIXLongArgument<>).MakeGenericType(returnType);
            var value = ArgumentFactory.GetDefaultValue(returnType, typeConverter, defaultValue);
            return (IArgument) Activator.CreateInstance(type, tag, description, typeConverter, value, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXLongArgument`1"/> of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument<T>(String tag, String description, TypeConverter typeConverter = null, T defaultValue = default (T), Boolean allowComposite = false)
        {
            return new POSIXLongArgument<T>(tag, description, typeConverter, defaultValue, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXLongArgument"/> of an undefined type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument(String tag, String description, String defaultValue = null, Boolean allowComposite = false)
        {
            return new POSIXLongArgument(tag, description, defaultValue, allowComposite);
        }
        #endregion

        #region ShortArgument methods
        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXShortArgument`1"/> of a dynamically-resolved type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IArgument CreateArgument(Char tag, String description, Type returnType, TypeConverter typeConverter = null, Object defaultValue = null, Boolean allowComposite = false)
        {
            var type = typeof (POSIXShortArgument<>).MakeGenericType(returnType);
            var value = ArgumentFactory.GetDefaultValue(returnType, typeConverter, defaultValue);

            return (IArgument) Activator.CreateInstance(type, tag, description, typeConverter, value, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXShortArgument`1"/> of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument<T>(Char tag, String description, TypeConverter typeConverter = null, T defaultValue = default (T), Boolean allowComposite = false)
        {
            return new POSIXShortArgument<T>(tag, description, typeConverter, defaultValue, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXShortArgument"/> of an undefined type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument(Char tag, String description, String defaultValue = null, Boolean allowComposite = false)
        {
            return new POSIXShortArgument(tag, description, defaultValue, allowComposite);
        }
        #endregion

        #region Flag methods
        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXLongFlag`1"/> of a dynamically-resolved type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IFlag CreateFlag(String tag, String description, Type returnType, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, Object defaultValue = null, Boolean allowComposite = false)
        {
            var type = typeof (POSIXLongFlag<>).MakeGenericType(returnType);
            var value = ArgumentFactory.GetDefaultValue(returnType, typeConverter, defaultValue);

            return (IFlag) Activator.CreateInstance(type, tag, description, options, typeConverter, value, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXFlag`1"/> of a dynamically-resolved type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IFlag CreateFlag(Char tag, String description, Type returnType, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, Object defaultValue = null, Boolean allowComposite = false)
        {
            var type = typeof (POSIXFlag<>).MakeGenericType(returnType);
            var value = ArgumentFactory.GetDefaultValue(returnType, typeConverter, defaultValue);

            return (IFlag) Activator.CreateInstance(type, tag, description, options, typeConverter, value, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXLongFlag`1"/> of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag<T>(String tag, String description, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default (T), Boolean allowComposite = false)
        {
            return new POSIXLongFlag<T>(tag, description, options, typeConverter, defaultValue, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXLongFlag"/> of an undefined type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag(String tag, String description, FlagOptions options = FlagOptions.None, String defaultValue = null, Boolean allowComposite = false)
        {
            return new POSIXLongFlag(tag, description, options, defaultValue, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXFlag`1"/> of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag<T>(Char tag, String description, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default (T), Boolean allowComposite = false)
        {
            return new POSIXFlag<T>(tag, description, options, typeConverter, defaultValue, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.POSIXFlag"/> of an undefined type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag(Char tag, String description, FlagOptions options = FlagOptions.None, String defaultValue = null, Boolean allowComposite = false)
        {
            return new POSIXFlag(tag, description, options, defaultValue, allowComposite);
        }
        #endregion
    }

    /// <summary>
    /// Provides static methods for Windows-flavored argument creation.
    /// </summary>
    public static class WindowsArgumentFactory
    {
        #region Argument methods
        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.WindowsArgument`1"/> of a dynamically-resolved type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IArgument CreateArgument(String tag, String description, Type returnType, TypeConverter typeConverter = null, Object defaultValue = null, Boolean allowComposite = false)
        {
            var type = typeof (WindowsArgument<>).MakeGenericType(returnType);
            var value = ArgumentFactory.GetDefaultValue(returnType, typeConverter, defaultValue);
            return (IArgument) Activator.CreateInstance(type, tag, description, typeConverter, value, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.WindowsArgument`1"/> of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument<T>(String tag, String description, TypeConverter typeConverter = null, T defaultValue = default (T), Boolean allowComposite = false)
        {
            return new WindowsArgument<T>(tag, description, typeConverter, defaultValue, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.WindowsArgument"/> of an undefined type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument(String tag, String description, String defaultValue = null, Boolean allowComposite = false)
        {
            return new WindowsArgument(tag, description, defaultValue, allowComposite);
        }
        #endregion

        #region Flag methods
        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.WindowsFlag`1"/> of a dynamically-resolved type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IFlag CreateFlag(String tag, String description, Type returnType, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, Object defaultValue = null, Boolean allowComposite = false)
        {
            var type = typeof (WindowsFlag<>).MakeGenericType(returnType);
            var value = ArgumentFactory.GetDefaultValue(returnType, typeConverter, defaultValue);

            return (IFlag) Activator.CreateInstance(type, tag, description, options, typeConverter, value, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.WindowsFlag`1"/> of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag<T>(String tag, String description, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default (T), Boolean allowComposite = false)
        {
            return new WindowsFlag<T>(tag, description, options, typeConverter, defaultValue, allowComposite);
        }

        /// <summary>
        /// Creates a <see cref="T:ArgumentParser.Arguments.WindowsFlag"/> of an undefined type.
        /// </summary>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <param name="allowComposite">A boolean value indicating whether trailing values should be interpreted.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag(String tag, String description, FlagOptions options = FlagOptions.None, String defaultValue = null, Boolean allowComposite = false)
        {
            return new WindowsFlag(tag, description, options, defaultValue, allowComposite);
        }
        #endregion
    }

    internal static class ArgumentFactory
    {
        public static Object GetDefaultValue(Type returnType, TypeConverter typeConverter, Object defaultValue)
        {
            Object value = defaultValue;
            if (value != null && !value.GetType().IsAssignableFrom(returnType))
            {
                value = typeConverter != null && typeConverter.CanConvertFrom(value.GetType())
                    ? typeConverter.ConvertFrom(defaultValue)
                    : null;
            }

            return value;
        }
    }
}
