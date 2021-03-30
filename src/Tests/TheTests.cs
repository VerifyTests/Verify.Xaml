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
        var window = new MyWindow();
        await Verifier.Verify(window)
            .ConfigureAwait(true);
    }
    #endregion

    #region Page
    [Test]
    public async Task Page()
    {
        var page = new MyPage();
        await Verifier.Verify(page)
            .ConfigureAwait(true);
    }
    #endregion

    #region UserControl
    [Test]
    public async Task UserControl()
    {
        var userControl = new MyUserControl();
        await Verifier.Verify(userControl)
            .ConfigureAwait(true);
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