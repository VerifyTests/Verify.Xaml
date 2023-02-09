# <img src="/src/icon.png" height="30px"> Verify.Xaml

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/o2iy3b7k9le0ntps?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-xaml)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Xaml.svg)](https://www.nuget.org/packages/Verify.Xaml/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of Xaml UIs.



## NuGet package

https://nuget.org/packages/Verify.Xaml/


## Usage

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Init() =>
    VerifyXaml.Initialize();
```
<sup><a href='/src/Tests/ModuleInit.cs#L3-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

A visual element (Window/Page/Control etc) can then be verified as follows:

<!-- snippet: Window -->
<a id='snippet-window'></a>
```cs
[Test]
public async Task WindowUsage()
{
    var window = new MyWindow();
    await Verify(window);
}
```
<sup><a href='/src/Tests/TheTests.cs#L7-L16' title='Snippet source file'>snippet source</a> | <a href='#snippet-window' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

With the state of the element being rendered as a verified files:

[TheTests.WindowUsage.00.verified.xml](/src/Tests/TheTests.WindowUsage.00.verified.xml):

[TheTests.WindowUsage.01.verified.png](/src/Tests/TheTests.WindowUsage.01.verified.png):

<img src="/src/Tests/TheTests.WindowUsage.01.verified.png" width="200px">


## OS specific rendering

The rendering of XAML elements can very slightly between different OS versions. This can make verification on different machines (eg CI) problematic. There are several approaches to mitigate this:

 * [Forcing elements to use a specific theme](https://arbel.net/2006/11/03/forcing-wpf-to-use-a-specific-windows-theme/)
 * Using a [custom comparer](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md)



## Icon

[Gem](https://thenounproject.com/term/gem/2247823/) designed by [Adnen Kadri](https://thenounproject.com/adnen.kadri/) from [The Noun Project](https://thenounproject.com).
