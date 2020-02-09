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
    public Task WindowUsage()
    {
        return Verify(new MyWindow());
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
}