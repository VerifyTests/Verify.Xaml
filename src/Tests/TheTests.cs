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
        await Verify(window);
    }

    #endregion

    #region Page

    [Test]
    public async Task Page()
    {
        var page = new MyPage();
        await Verify(page);
    }

    #endregion

    #region UserControl

    [Test]
    public async Task UserControl()
    {
        var userControl = new MyUserControl();
        await Verify(userControl);
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