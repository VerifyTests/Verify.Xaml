using System.Windows;

namespace VerifyTests
{
    public static class VerifyXaml
    {
        public static void Enable()
        {
            VerifierSettings.RegisterFileConverter<Window>(WindowToImage);
            VerifierSettings.RegisterFileConverter<FrameworkElement>(ElementToImage);
        }

        static ConversionResult ElementToImage(FrameworkElement element, VerifySettings settings)
        {
            var stream = WpfUtils.ScreenCapture(element);
            return new ConversionResult(null, "png", stream);
        }

        static ConversionResult WindowToImage(Window window, VerifySettings settings)
        {
            var stream = WpfUtils.ScreenCapture(window);
            return new ConversionResult(null, "png", stream);
        }
    }
}