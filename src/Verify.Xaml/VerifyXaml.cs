using System.Windows;

using VerifyTests.Xaml;

namespace VerifyTests;

public static class VerifyXaml
{
    public static bool Initialized { get; private set; }

    public static void Initialize()
    {
        if (Initialized)
        {
            throw new("Already Initialized");
        }

        Initialized = true;

        InnerVerifier.ThrowIfVerifyHasBeenRun();
        VerifierSettings.RegisterFileConverter<Window>(WindowToImage);
        VerifierSettings.RegisterFileConverter<FrameworkElement>(ElementToImage);
    }

    static ConversionResult ElementToImage(FrameworkElement element, IReadOnlyDictionary<string, object> context)
    {
        var pngStream = WpfUtils.ScreenCapture(element);
        var xaml = element.ToXamlString();
        var targets = new List<Target> { new("png", pngStream) };
        if (xaml != null)
        {
            targets.Insert(0, new("xml", xaml));
        }

        return new(null, targets);
    }

    static ConversionResult WindowToImage(Window window, IReadOnlyDictionary<string, object> context)
    {
        var pngStream = WpfUtils.ScreenCapture(window);
        var xaml = window.ToXamlString();
        var targets = new List<Target> { new("png", pngStream) };
        if (xaml != null)
        {
            targets.Insert(0, new("xml", xaml));
        }

        return new(null, targets);
    }
}
