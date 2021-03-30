using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Verify.Xaml;

static class WpfUtils
{
    public static string ToXamlString(this FrameworkElement element)
    {
        var builder = new StringBuilder();
        using var stringWriter = new StringWriter(builder);
        using var xmlWriter = new XmlTextWriter(stringWriter)
        {
            Formatting = Formatting.Indented
        };
        XamlWriter.Save(element, xmlWriter);

        return builder.ToString();
    }

    public static Stream ScreenCapture(FrameworkElement element)
    {
        var window = new HostWindow
        {
            Content = element
        };
        return ScreenCapture(window);
    }

    public static Stream ScreenCapture(Window window)
    {
        try
        {
            var height = window.Height;
            var width = window.Width;
            // make sure it is ready for rendering
            window.Show();
            window.Height = height;
            window.Width = width;
            // The BitmapSource that is rendered with a Visual.
            var rtb = new RenderTargetBitmap((int) window.ActualWidth, (int) window.ActualHeight, 96, 96,
                PixelFormats.Pbgra32);
            rtb.Render((Visual) window.Content);

            // Encoding the RenderBitmapTarget as a PNG file.
            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            var stream = new MemoryStream();
            png.Save(stream);
            return stream;
        }
        finally
        {
            window.Close();
        }
    }
}