using System.Windows;

namespace Verify.Xaml
{
    public static class VerifyXaml
    {
        public static void Enable()
        {
            SharedVerifySettings.RegisterFileConverter<Window>("png", WindowToImage);
        }

        static ConversionResult WindowToImage(Window window, VerifySettings settings)
        {
            var stream = WpfUtils.ScreenCapture(window);
            return new ConversionResult(null, new[] {stream});
        }
    }
}