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
        await Verifier.Verify(new MyWindow())
            .ConfigureAwait(true);
    }
    #endregion

    #region Page
    [Test]
    public async Task Page()
    {
        await Verifier.Verify(new MyPage())
            .ConfigureAwait(true);
    }
    #endregion

    #region UserControl
    [Test]
    public async Task UserControl()
    {
        await Verifier.Verify(new MyUserControl())
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