public static class ModuleInit
{
    #region Enable

    [ModuleInitializer]
    public static void Init() =>
        VerifyXaml.Enable();

    #endregion

    [ModuleInitializer]
    public static void InitOther()
    {
        VerifyDiffPlex.Initialize();
        VerifyPhash.Initialize();
    }
}