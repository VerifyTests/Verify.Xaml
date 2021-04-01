using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using Verify.Xaml;

static class WpfUtils
{
    public static string ToXamlString(this FrameworkElement element)
    {
        StringBuilder builder = new();
        using StringWriter stringWriter = new(builder);
        using XmlTextWriter xmlWriter = new(stringWriter)
        {
            Formatting = Formatting.Indented
        };
        XamlWriter.Save(element, xmlWriter);
        var document = XDocument.Load(new StringReader(builder.ToString()));
        var root = document.Root!;
        foreach (var attribute in root.Attributes().ToList())
        {
            var name = attribute.Name.ToString();
            if (name == "AllowsTransparency" ||
                name == "ShowInTaskbar" ||
                name == "WindowStyle"  ||
                name == "Opacity" ||
                name == "Visibility" )
            {
                attribute.Remove();
            }
        }
        return document.ToString();
    }

    public static Stream ScreenCapture(FrameworkElement element)
    {
        HostWindow window = new()
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
            RenderTargetBitmap renderTargetBitmap = new(
                (int) window.ActualWidth,
                (int) window.ActualHeight,
                96,
                96,
                PixelFormats.Pbgra32);
            renderTargetBitmap.Render((Visual) window.Content);

            // Encoding the RenderBitmapTarget as a PNG file.
            PngBitmapEncoder png = new();
            png.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            MemoryStream stream = new();
            png.Save(stream);
            return stream;
        }
        finally
        {
            window.Close();
        }
    }
}