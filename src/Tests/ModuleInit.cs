public static class ModuleInit
{
    #region Enable

    [ModuleInitializer]
    public static void Init() =>
        VerifyXaml.Initialize();

    #endregion

    [ModuleInitializer]
    public static void InitOther() =>
        VerifierSettings.InitializePlugins();
}