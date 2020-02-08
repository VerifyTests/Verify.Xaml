using Verify.Xaml;
using Xunit;

[GlobalSetUp]
public static class GlobalSetup
{
    public static void Setup()
    {
        #region Enable
        VerifyXaml.Enable();
        #endregion
    }
}