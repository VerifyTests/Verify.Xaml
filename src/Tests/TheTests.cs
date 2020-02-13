using System.Drawing;
using System.Threading.Tasks;
using Shipwreck.Phash;
using Shipwreck.Phash.Bitmaps;
using Tests;
using Verify;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

public class TheTests :
    VerifyBase
{
    #region Window
    [StaFact]
    public Task WindowUsage()
    {
        return Verify(new MyWindow());
    }
    #endregion

    #region Page
    [StaFact]
    public Task Page()
    {
        return Verify(new MyPage());
    }
    #endregion

    #region UserControl
    [StaFact]
    public Task UserControl()
    {
        return Verify(new MyUserControl());
    }
    #endregion

    public TheTests(ITestOutputHelper output) :
        base(output)
    {
    }

    static TheTests()
    {
        SharedVerifySettings.RegisterComparer(
            "png",
            (stream1, stream2) =>
            {
                var bitmap1 = (Bitmap)Image.FromStream(stream1);
                var hash1 = ImagePhash.ComputeDigest(bitmap1.ToLuminanceImage());
                var bitmap2 = (Bitmap)Image.FromStream(stream2);
                var hash2 = ImagePhash.ComputeDigest(bitmap2.ToLuminanceImage());

                var score = ImagePhash.GetCrossCorrelation(hash1, hash2);

                return score > .999;
            });
    }
}