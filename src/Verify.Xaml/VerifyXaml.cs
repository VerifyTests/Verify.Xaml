using System.Windows;

namespace Verify.Xaml
{
    public static class VerifyXaml
    {
        public static void Enable()
        {
            SharedVerifySettings.RegisterFileConverter<Window>("png", WindowToImage);
            SharedVerifySettings.RegisterFileConverter<FrameworkElement>("png", ElementToImage);
        }

        static ConversionResult ElementToImage(FrameworkElement element, VerifySettings settings)
        {
            var stream = WpfUtils.ScreenCapture(element);
            return new ConversionResult(null, new[] {stream});
        }

        static ConversionResult WindowToImage(Window window, VerifySettings settings)
        {
            var stream = WpfUtils.ScreenCapture(window);
            return new ConversionResult(null, new[] {stream});
        }
    }
}