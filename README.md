![Logo](./img/logo.png)

This library was made in an attempt to simplify the handling and parsing of parameters, be it in the \*nix, Windows style or any of their variants.

Please see our [contributing guidelines](./CONTRIBUTING.md) before reporting an issue.

[![License](https://img.shields.io/badge/license-GPLv3-blue.svg)](./LICENSE)
[![Release](https://img.shields.io/github/release/louistakepillz/argumentparser.svg)](../../releases)
[![Tag](https://img.shields.io/github/tag/louistakepillz/argumentparser.svg)](../../tags)

[![Issues](https://img.shields.io/github/issues/louistakepillz/argumentparser.svg)](../../issues)
[![Forks](https://img.shields.io/github/forks/louistakepillz/argumentparser.svg)](../../network)
[![Downloads](https://img.shields.io/nuget/dt/ArgumentParser.svg)](https://www.nuget.org/packages/ArgumentParser)

## Operative modes

### Plain ("raw") mode

  This mode is the underlying substrate of it all; it simply returns match results using a RegEx sequence with very little transformation&mdash;it doesn't get much more straightforward than that.

### Standard mode

  You might find the latter mode a bit too blunt; should you have more refined needs, you probably want the dirty work hidden away. The gist of the library lies right here: just pass your *argument definitions* for the parser to match the input to.
  Oh, and value parsing/conversion is also done for you, isn't that great? You can even provide your own type converters!

### Reflective mode

  This one is just an extra programmatical sugar, yet so much more than that. Instead of manually supplying your *argument definitions*, you can adorn class members (either properties or methods) with an `IOptionAttribute`, which both serves as a binding descriptor and information container to generate your argument definitions at run-time. In other words, the parsing, solving and binding (i.e. data population) without ever having to touch the nitty-gritty of the parsing!

## How to use

See the [wiki pages](../../wiki).

## Contributing

See [Contributing](./CONTRIBUTING.md).
