using System.Threading.Tasks;
using Tests;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

public class TheTests :
    VerifyBase
{
    #region Window
    [StaFact]
    public async Task WindowUsage()
    {
        await Verify(new MyWindow())
            .ConfigureAwait(true);
    }
    #endregion

    #region Page
    [StaFact]
    public async Task Page()
    {
        await Verify(new MyPage())
            .ConfigureAwait(true);
    }
    #endregion

    #region UserControl
    [StaFact]
    public async Task UserControl()
    {
        await Verify(new MyUserControl())
            .ConfigureAwait(true);
    }
    #endregion

    public TheTests(ITestOutputHelper output) :
        base(output)
    {
    }

    static TheTests()
    {
        VerifyPhash.Initialize();
    }
}