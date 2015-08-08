# Contributing to ArgumentParser

:thumbsup: First off, big thumbs-up for contributing!

Please take a moment and read this document and ensure that you're not going against any guideline.

## Submitting Issues

1. **Use the GitHub issue search**&mdash;check if the issue has already been reported.
2. **Ensure that the issued hasn't already been fixed**&mdash;try to reproduce the issue using a freshly compiled build from the `master` branch.
2. Ensure that your issue report includes:
  * the framework (and version) used
  * the programming language used (C#, VB, F#, ...)
  * as many details as possible
  * screenshots/GIFs if deemed appropriate
3. If possible, isolate the problem and explain how to reproduce it.

## Git Commit Messages

* Use the present tense (`Add support for [...]` as opposed to `Added support for [...]`)
* Separate subject from body with a blank line (if applicable)
* Use sentence case in body and subject line
* Do not end the subject line with a period
* Limit the subject line to 72 characters
* Use the body to explain what and why vs. how
* Reference issues and pull requests liberally
* Consider prepending an *emoji-tag* when applicable:
  * :bug: `:bug:` when fixing a bug
  * :art: `:art:` when refactoring or altering the code structure w/o significant behavioral changes (e.g. renaming variables, splitting a class into multiple files)
  * :memo: `:memo:` when altering documentation, comments or anything of the like
  * :racehorse: `:racehorse:` when improving performance
  * :white_check_mark: `:white_check_mark:` when dealing with the test suite
  * :anger: `:anger:` when the committed changes stem from a mistake in a previous commit (i.e. when forgetting something)
  * :boom: `:boom:` when bringing significant changes and/or breaking the API backward-compatibility

## Coding Style

The coding style used in this project is slightly different than most; some of the more unintuitive rules are listed below.

### Indent style

* Always use 4-wide spaces indent with open braces.
* Empty constructor should be in-lined.
* Automatic properties (and smaller ones) are, however, always in-line (except when adorned with attributes).

```cs
namespace ArgumentParser.Something
{
    public class Blah
    {
        private static readonly Random randomNumberProvider = new Random();

        public Int32 Count { get; private set; }
        public String Empty { get { return String.Empty; }}
        public String Something
        {
            get { return String.Empty; }
            set
            {
                var count = value.Length + randomNumberProvider.Next();
                this.Count = count;
            }
        }

        public static void Main() { }
    }
}
```

### Naming

  * Use **camelCase** for **local** variables and `private` fields
  * Do **not** prefix your `private` fields with underscores
  * Use **PascalCase** for (non-private) `static readonly` fields:
    ```cs
    public static readonly PreprocessorDelegate DefaultPreprocessor = (x, c) => Regex.Unescape(x);
    ```
  * Use C-Style constant naming:
    ```cs
    internal const String INVALID_TOKEN_STYLE_EXCEPTION_MESSAGE = "The token style is not within the valid range of values.";
    internal const String PREFIX_GETOPT_LONG = "--";
    internal const String PREFIX_GETOPT_SHORT = "-";
    internal const String PREFIX_WINDOWS = "/";
    internal const String PREFIX_SIMPLE = "-";
    ```
  * Enumerated types (`enum`) always use **PascalCase**

### XML Documentation Comments

  * Favor in-line over wrapping (except for `<remarks>` sections and the like):
    ```xml
    <summary>The quick brown fox jumps over the lazy dog.</summary>
    ```
    as opposed to
    ```xml
    <summary>
      The quick brown fox jumps
      over the lazy dog.
    </summary>
    ```

### Type Usage

#### `var` Usage

Favor using the `var` keyword wherever the type is explicitly defined on the right-hand side of the equal sign (e.g. an explicit cast or an unambiguous data type):

```cs
var someString = "test"; // Unambiguous data
var charIdentifier = (UInt32) someString.FirstOrDefault(); // Explicit cast
```

#### CLR Types vs. C# Types

Granted, this one might strike you as odd, but the author prefers using CLR types over the C# specs-defined ones, but this is merely a matter of personal preference. There are, however, a few exceptions to this "rule":
  * types used in a local scope may use either the "short" form (e.g. `uint`) or the "long" form (`UInt32`)
  * the `String` type is always written as such, regardless of the context
  * explicit casts always use the "long" form

### Spacing

* `typeof` and explicit casts are always followed by a space (e.g. `typeof (String)`, `(Char) myVar`)
