using System.Threading.Tasks;
using CoenM.ImageHash;
using CoenM.ImageHash.HashAlgorithms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
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
                var algorithm = new DifferenceHash();
                using var image1 = Image.Load<Rgba32>(stream1);
                var hash1 = algorithm.Hash(image1);
                using var image2 = Image.Load<Rgba32>(stream2);
                var hash2 = algorithm.Hash(image2);
                var percentage = CompareHash.Similarity(hash1, hash2);
                return percentage > 90;
            });
    }
}