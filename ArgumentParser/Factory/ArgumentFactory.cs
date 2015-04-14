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
    /// Provides static methods for coupleable argument creation.
    /// </summary>
    public static class ArgumentFactory
    {
        #region LongArgument methods
        /// <summary>
        /// Creates an argument definition of a dynamically-resolved type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IArgument CreateArgument(ParameterTokenStyle tokenStyle, String tag, String description, Type returnType, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, Object defaultValue = null)
        {
            Type type;
            Object value = GetDefaultValue(returnType, typeConverter, defaultValue);

            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    type = typeof (POSIXLongArgument<>).MakeGenericType(returnType);
                    break;
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    type = typeof (WindowsArgument<>).MakeGenericType(returnType);
                    break;
                case ParameterTokenStyle.PowerShell:
                    type = typeof (PowerShellArgument<>).MakeGenericType(returnType);
                    break;
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }

            return (IArgument) Activator.CreateInstance(type, tag, description, valueOptions, typeConverter, value);
        }

        /// <summary>
        /// Creates an argument definition of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument<T>(ParameterTokenStyle tokenStyle, String tag, String description, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, T defaultValue = default (T))
        {
            switch(tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXLongArgument<T>(tag, description, valueOptions, typeConverter, defaultValue);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsArgument<T>(tag, description, valueOptions, typeConverter, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellArgument<T>(tag, description, valueOptions, typeConverter, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }

        /// <summary>
        /// Creates an argument definition of an undefined type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument(ParameterTokenStyle tokenStyle, String tag, String description, ValueOptions valueOptions = ValueOptions.Single, String defaultValue = null)
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXLongArgument(tag, description, valueOptions, defaultValue);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsArgument(tag, description, valueOptions, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellArgument(tag, description, valueOptions, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }
        #endregion

        #region ShortArgument methods
        /// <summary>
        /// Creates an argument definition of a dynamically-resolved type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IArgument CreateArgument(ParameterTokenStyle tokenStyle, Char tag, String description, Type returnType, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, Object defaultValue = null)
        {
            Type type;
            Object value = GetDefaultValue(returnType, typeConverter, defaultValue);

            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    type = typeof (POSIXShortArgument<>).MakeGenericType(returnType);
                    return (IArgument) Activator.CreateInstance(type, tag, description, valueOptions, typeConverter, value);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    type = typeof (WindowsArgument<>).MakeGenericType(returnType);
                    break;
                case ParameterTokenStyle.PowerShell:
                    type = typeof (PowerShellArgument<>).MakeGenericType(returnType);
                    break;
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }

            return (IArgument) Activator.CreateInstance(type, tag.ToString(), description, valueOptions, typeConverter, value);
        }

        /// <summary>
        /// Creates an argument definition of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument<T>(ParameterTokenStyle tokenStyle, Char tag, String description, ValueOptions valueOptions = ValueOptions.Single, TypeConverter typeConverter = null, T defaultValue = default (T))
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXShortArgument<T>(tag, description, valueOptions, typeConverter, defaultValue);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsArgument<T>(tag.ToString(), description, valueOptions, typeConverter, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellArgument<T>(tag.ToString(), description, valueOptions, typeConverter, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }

        /// <summary>
        /// Creates an argument definition of an undefined type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IArgument CreateArgument(ParameterTokenStyle tokenStyle, Char tag, String description, ValueOptions valueOptions = ValueOptions.Single, String defaultValue = null)
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXShortArgument(tag, description, valueOptions, defaultValue);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsArgument(tag.ToString(), description, valueOptions, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellArgument(tag.ToString(), description, valueOptions, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }
        #endregion

        #region Flag methods
        /// <summary>
        /// Creates a flag argument definition of a dynamically-resolved type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IFlag CreateFlag(ParameterTokenStyle tokenStyle, String tag, String description, Type returnType, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, Object defaultValue = null)
        {
            Type type;
            Object value = GetDefaultValue(returnType, typeConverter, defaultValue);

            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    type = typeof (POSIXLongFlag<>).MakeGenericType(returnType);
                    break;
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    type = typeof (WindowsFlag<>).MakeGenericType(returnType);
                    break;
                case ParameterTokenStyle.PowerShell:
                    type = typeof (PowerShellFlag<>).MakeGenericType(returnType);
                    break;
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }

            return (IFlag) Activator.CreateInstance(type, tag, description, valueOptions, options, typeConverter, value);
        }

        /// <summary>
        /// Creates a flag argument definition of a dynamically-resolved type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="returnType">The value type of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created dynamically-resolved argument.</returns>
        public static IFlag CreateFlag(ParameterTokenStyle tokenStyle, Char tag, String description, Type returnType, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, Object defaultValue = null)
        {
            Type type;
            Object value = GetDefaultValue(returnType, typeConverter, defaultValue);

            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    type = typeof (POSIXFlag<>).MakeGenericType(returnType);
                    return (IFlag) Activator.CreateInstance(type, tag, description, valueOptions, options, typeConverter, value);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    type = typeof (WindowsFlag<>).MakeGenericType(returnType);
                    break;
                case ParameterTokenStyle.PowerShell:
                    type = typeof (PowerShellFlag<>).MakeGenericType(returnType);
                    break;
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }

            return (IFlag) Activator.CreateInstance(type, tag.ToString(), description, valueOptions, options, typeConverter, value);
        }

        /// <summary>
        /// Creates a flag argument definition of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag<T>(ParameterTokenStyle tokenStyle, String tag, String description, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default (T))
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXLongFlag<T>(tag, description, valueOptions, options, typeConverter, defaultValue);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsFlag<T>(tag, description, valueOptions, options, typeConverter, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellFlag<T>(tag, description, valueOptions, options, typeConverter, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }

        /// <summary>
        /// Creates a flag argument definition of an undefined type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag(ParameterTokenStyle tokenStyle, String tag, String description, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, String defaultValue = null)
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXLongFlag(tag, description, valueOptions, options, defaultValue);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsFlag(tag, description, valueOptions, options, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellFlag(tag, description, valueOptions, options, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }

        /// <summary>
        /// Creates a flag argument definition of a generic type.
        /// </summary>
        /// <typeparam name="T">The value type of the argument.</typeparam>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="typeConverter">The type converter to use for conversion.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag<T>(ParameterTokenStyle tokenStyle, Char tag, String description, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, TypeConverter typeConverter = null, T defaultValue = default (T))
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXFlag<T>(tag, description, valueOptions, options, typeConverter, defaultValue);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsFlag<T>(tag.ToString(), description, valueOptions, options, typeConverter, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellFlag<T>(tag.ToString(), description, valueOptions, options, typeConverter, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }

        /// <summary>
        /// Creates a flag argument definition of an undefined type.
        /// </summary>
        /// <param name="tokenStyle">The token style to use to help determine the appropriate argument definition type.</param>
        /// <param name="tag">The tag that defines the argument.</param>
        /// <param name="description">The description of the argument.</param>
        /// <param name="valueOptions">The value parsing behavior of the argument.</param>
        /// <param name="options">The value conversion behavior.</param>
        /// <param name="defaultValue">The default value of the argument.</param>
        /// <returns>The newly created argument.</returns>
        public static IFlag CreateFlag(ParameterTokenStyle tokenStyle, Char tag, String description, ValueOptions valueOptions = ValueOptions.Single, FlagOptions options = FlagOptions.None, String defaultValue = null)
        {
            switch (tokenStyle)
            {
                case ParameterTokenStyle.POSIX:
                    return new POSIXFlag(tag, description, valueOptions, options, description);
                case ParameterTokenStyle.WindowsEqual:
                case ParameterTokenStyle.WindowsColon:
                case ParameterTokenStyle.Windows:
                    return new WindowsFlag(tag.ToString(), description, valueOptions, options, defaultValue);
                case ParameterTokenStyle.PowerShell:
                    return new PowerShellFlag(tag.ToString(), description, valueOptions, options, defaultValue);
                default:
                    throw new InvalidEnumArgumentException(Parser.INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE);
            }
        }
        #endregion

        #region Internal methods
        internal static Object GetDefaultValue(Type returnType, TypeConverter typeConverter, Object defaultValue)
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
        #endregion
    }
}
