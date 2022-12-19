﻿using System.Windows;

namespace VerifyTests;

public static class VerifyXaml
{
    public static void Enable()
    {
        InnerVerifier.ThrowIfVerifyHasBeenRun();
        VerifierSettings.RegisterFileConverter<Window>(WindowToImage);
        VerifierSettings.RegisterFileConverter<FrameworkElement>(ElementToImage);
    }

    static ConversionResult ElementToImage(FrameworkElement element, IReadOnlyDictionary<string, object> context)
    {
        var pngStream = WpfUtils.ScreenCapture(element);
        return new(null,
            new List<Target>
            {
                new("xml", element.ToXamlString()),
                new("png", pngStream)
            });
    }

    static ConversionResult WindowToImage(Window window, IReadOnlyDictionary<string, object> context)
    {
        var pngStream = WpfUtils.ScreenCapture(window);
        return new(null,
            new List<Target>
            {
                new("xml", window.ToXamlString()),
                new("png", pngStream)
            });
    }
}