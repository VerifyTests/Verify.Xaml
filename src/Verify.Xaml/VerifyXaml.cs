using System.Windows;
using System.Windows.Controls;

namespace Verify.Xaml
{
    public static class VerifyXaml
    {
        public static void Enable()
        {
            SharedVerifySettings.RegisterFileConverter<Window>("png", WindowToImage);
            SharedVerifySettings.RegisterFileConverter<UserControl>("png", UserControlToImage);
        }

        static ConversionResult UserControlToImage(UserControl userControl, VerifySettings settings)
        {
            var stream = WpfUtils.ScreenCapture(userControl);
            return new ConversionResult(null, new[] {stream});
        }

        static ConversionResult WindowToImage(Window window, VerifySettings settings)
        {
            var stream = WpfUtils.ScreenCapture(window);
            return new ConversionResult(null, new[] {stream});
        }
    }
}