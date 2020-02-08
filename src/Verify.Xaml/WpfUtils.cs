using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

static class WpfUtils
{
    public static Stream ScreenCapture(Window window)
    {
        try
        {
            // make sure it is ready for rendering
            window.Show();

            // The BitmapSource that is rendered with a Visual.
            var rtb = new RenderTargetBitmap((int) window.ActualWidth, (int) window.ActualHeight, 96, 96,
                PixelFormats.Pbgra32);
            rtb.Render(window);

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