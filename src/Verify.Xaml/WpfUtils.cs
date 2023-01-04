using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using VerifyTests.Xaml;

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
        var document = XDocument.Load(new StringReader(builder.ToString()));
        var root = document.Root!;
        foreach (var attribute in root.Attributes().ToList())
        {
            var name = attribute.Name.ToString();
            if (name is
                "AllowsTransparency" or
                "ShowInTaskbar" or
                "WindowStyle" or
                "Opacity" or
                "Visibility")
            {
                attribute.Remove();
            }
        }

        return document.ToString();
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
            window.ShowInTaskbar = false;
            window.WindowStyle = WindowStyle.None;
            window.AllowsTransparency = true;
            window.Opacity = 0.0;
            window.Show();
            window.Height = height;
            window.Width = width;
            // The BitmapSource that is rendered with a Visual.
            var renderTargetBitmap = new RenderTargetBitmap(
                (int) window.ActualWidth,
                (int) window.ActualHeight,
                96,
                96,
                PixelFormats.Pbgra32);
            renderTargetBitmap.Render((Visual) window.Content);

            // Encoding the RenderBitmapTarget as a PNG file.
            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
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