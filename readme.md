<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /readme.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# <img src="/src/icon.png" height="30px"> Verify.Xaml

[![Build status](https://ci.appveyor.com/api/projects/status/o2iy3b7k9le0ntps?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-xaml)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Xaml.svg)](https://www.nuget.org/packages/Verify.Xaml/)

Extends [Verify](https://github.com/SimonCropp/Verify) to allow verification of Xaml UIs.


<!-- toc -->
## Contents

  * [Usage](#usage)
  * [Notes](#notes)
  * [Security contact information](#security-contact-information)<!-- endtoc -->


## NuGet package

https://nuget.org/packages/Verify.Xaml/


## Usage

Enable VerifyXaml once at assembly load time:

<!-- snippet: Enable -->
<a id='snippet-enable'/></a>
```cs
VerifyXaml.Enable();
```
<sup><a href='/src/Tests/GlobalSetup.cs#L9-L11' title='File snippet `enable` was extracted from'>snippet source</a> | <a href='#snippet-enable' title='Navigate to start of snippet `enable`'>anchor</a></sup>
<!-- endsnippet -->

A visual element (Window/Page/Control etc) can then be verified as follows:

<!-- snippet: Window -->
<a id='snippet-window'/></a>
```cs
[StaFact]
public Task WindowUsage()
{
    return Verify(new MyWindow());
}
```
<sup><a href='/src/Tests/TheTests.cs#L15-L21' title='File snippet `window` was extracted from'>snippet source</a> | <a href='#snippet-window' title='Navigate to start of snippet `window`'>anchor</a></sup>
<!-- endsnippet -->

With the state of the element being rendered as a verified file:

[TheTests.WindowUsage.verified.png](/src/Tests/TheTests.WindowUsage.verified.png):

<img src="/src/Tests/TheTests.WindowUsage.verified.png" width="200px">



## Notes

 * [Forcing WPF to use a specific Windows theme](https://arbel.net/2006/11/03/forcing-wpf-to-use-a-specific-windows-theme/)
 

## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Gem](https://thenounproject.com/term/gem/2247823/) designed by [Adnen Kadri](https://thenounproject.com/adnen.kadri/) from [The Noun Project](https://thenounproject.com/creativepriyanka).
