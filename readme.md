# <img src="/src/icon.png" height="30px"> Verify.Xaml

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/o2iy3b7k9le0ntps?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-xaml)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Xaml.svg)](https://www.nuget.org/packages/Verify.Xaml/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of Xaml UIs.

**See [Milestones](../../milestones?state=closed) for release notes.**



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

[TheTests.WindowUsage.verified.xml](/src/Tests/TheTests.WindowUsage.verified.xml):

<!-- snippet: TheTests.WindowUsage.verified.xml -->
<a id='snippet-TheTests.WindowUsage.verified.xml'></a>
```xml
<MyWindow Title="MyWindow" Width="525" Height="350" xmlns="clr-namespace:Tests;assembly=Tests" xmlns:av="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
  <av:DockPanel Name="MyPanel">
    <av:Menu Height="26" av:DockPanel.Dock="Top">
      <av:MenuItem Header="File">
        <av:MenuItem Header="Exit" />
      </av:MenuItem>
      <av:MenuItem Header="View">
        <av:MenuItem IsCheckable="True" IsChecked="True" Header="Standard" Name="StandardMenu" />
      </av:MenuItem>
      <av:MenuItem Header="Help">
        <av:MenuItem Header="About" />
      </av:MenuItem>
    </av:Menu>
    <av:Grid ShowGridLines="False" Name="MyGrid">
      <av:Grid.ColumnDefinitions>
        <av:ColumnDefinition />
        <av:ColumnDefinition />
        <av:ColumnDefinition />
        <av:ColumnDefinition />
        <av:ColumnDefinition />
        <av:ColumnDefinition />
        <av:ColumnDefinition />
        <av:ColumnDefinition />
        <av:ColumnDefinition />
      </av:Grid.ColumnDefinitions>
      <av:Grid.RowDefinitions>
        <av:RowDefinition />
        <av:RowDefinition />
        <av:RowDefinition />
        <av:RowDefinition />
        <av:RowDefinition />
        <av:RowDefinition />
      </av:Grid.RowDefinitions>
      <av:Button Name="B7" av:Grid.Column="4" av:Grid.Row="2">7</av:Button>
      <av:Button Name="B8" av:Grid.Column="5" av:Grid.Row="2">8</av:Button>
      <av:Button Name="B9" av:Grid.Column="6" av:Grid.Row="2">9</av:Button>
      <av:Button Name="B4" av:Grid.Column="4" av:Grid.Row="3">4</av:Button>
      <av:Button Name="B5" av:Grid.Column="5" av:Grid.Row="3">5</av:Button>
      <av:Button Name="B6" av:Grid.Column="6" av:Grid.Row="3">6</av:Button>
      <av:Button Name="B1" av:Grid.Column="4" av:Grid.Row="4">1</av:Button>
      <av:Button Name="B2" av:Grid.Column="5" av:Grid.Row="4">2</av:Button>
      <av:Button Name="B3" av:Grid.Column="6" av:Grid.Row="4">3</av:Button>
      <av:Button Name="B0" av:Grid.Column="4" av:Grid.Row="5">0</av:Button>
      <av:Button Name="BPeriod" av:Grid.Column="5" av:Grid.Row="5">.</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BPM" av:Grid.Column="6" av:Grid.Row="5">+/-</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BDevide" av:Grid.Column="7" av:Grid.Row="2">/</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BMultiply" av:Grid.Column="7" av:Grid.Row="3">*</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BMinus" av:Grid.Column="7" av:Grid.Row="4">-</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BPlus" av:Grid.Column="7" av:Grid.Row="5">+</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BSqrt" ToolTip="Usage: 'A Sqrt'" av:Grid.Column="8" av:Grid.Row="2">Sqrt</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BPercent" ToolTip="Usage: 'A % B ='" av:Grid.Column="8" av:Grid.Row="3">%</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BOneOver" ToolTip="Usage: 'A 1/X'" av:Grid.Column="8" av:Grid.Row="4">1/X</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BEqual" av:Grid.Column="8" av:Grid.Row="5">=</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BC" ToolTip="Clear All" av:Grid.Column="8" av:Grid.Row="1">C</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BCE" ToolTip="Clear Current Entry" av:Grid.Column="7" av:Grid.Row="1">CE</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BMemClear" ToolTip="Clear Memory" av:Grid.Column="3" av:Grid.Row="2">MC</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BMemRecall" ToolTip="Recall Memory" av:Grid.Column="3" av:Grid.Row="3">MR</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BMemSave" ToolTip="Store in Memory" av:Grid.Column="3" av:Grid.Row="4">MS</av:Button>
      <av:Button Background="#FFA9A9A9" Name="BMemPlus" ToolTip="Add To Memory" av:Grid.Column="3" av:Grid.Row="5">M+</av:Button>
      <av:TextBlock Text="Memory: [empty]" Name="BMemBox" Margin="10,17,10,17" av:Grid.Column="3" av:Grid.Row="1" av:Grid.ColumnSpan="2" />
      <av:TextBox Name="DisplayBox" Height="30" Margin="5,5,5,5" av:Grid.ColumnSpan="9" xml:space="preserve" />
      <av:TextBox Name="PaperBox" Margin="5,5,5,5" av:Grid.Row="1" av:Grid.ColumnSpan="3" av:Grid.RowSpan="5" xml:space="preserve" />
    </av:Grid>
  </av:DockPanel>
</MyWindow>
```
<sup><a href='/src/Tests/TheTests.WindowUsage.verified.xml#L1-L65' title='Snippet source file'>snippet source</a> | <a href='#snippet-TheTests.WindowUsage.verified.xml' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

[TheTests.WindowUsage.verified.png](/src/Tests/TheTests.WindowUsage.verified.png):

<img src="/src/Tests/TheTests.WindowUsage.verified.png" width="200px">


## OS specific rendering

The rendering of XAML elements can very slightly between different OS versions. This can make verification on different machines (eg CI) problematic. There are several approaches to mitigate this:

 * [Forcing elements to use a specific theme](https://arbel.net/2006/11/03/forcing-wpf-to-use-a-specific-windows-theme/)
 * Using a [custom comparer](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md)



## Icon

[Gem](https://thenounproject.com/term/gem/2247823/) designed by [Adnen Kadri](https://thenounproject.com/adnen.kadri/) from [The Noun Project](https://thenounproject.com).
