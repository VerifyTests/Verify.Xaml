public static class ModuleInit
{
    #region Enable

    [ModuleInitializer]
    public static void Init()
    {
        VerifyXaml.Enable();

        #endregion

        VerifyDiffPlex.Initialize();
        VerifyPhash.Initialize();
    }
}