using System.Threading;
using System.Threading.Tasks;
using Tests;
using VerifyNUnit;
using NUnit.Framework;
using VerifyTests;

[Apartment(ApartmentState.STA)]
[TestFixture]
public class TheTests
{
    #region Window

    [Test]
    public async Task WindowUsage()
    {
        MyWindow window = new();
        await Verifier.Verify(window);
    }

    #endregion

    #region Page

    [Test]
    public async Task Page()
    {
        MyPage page = new();
        await Verifier.Verify(page);
    }

    #endregion

    #region UserControl

    [Test]
    public async Task UserControl()
    {
        MyUserControl userControl = new();
        await Verifier.Verify(userControl);
    }

    #endregion

    static TheTests()
    {
        #region Enable

        VerifyXaml.Enable();

        #endregion

        VerifyPhash.Initialize();
    }
}