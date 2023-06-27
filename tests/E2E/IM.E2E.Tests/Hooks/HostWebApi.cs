namespace IM.E2E.Tests.Hooks;

using HostApplication;
using TechTalk.SpecFlow;

[Binding]
public sealed class HostWebApi
{
    private static HostNetCoreApp _host;

    [BeforeFeature("InventoryManaement")]
    public static void StartApp()
    {
        _host = new HostNetCoreApp(new HostOptions
        {
            Port = InventoryHostOptions.Port,
            CsProjectPath = InventoryHostOptions.CsProjectPath
        });
        _host.Start();
    }

    [AfterFeature("InventoryManaement")]
    public static void ShutdownApp() =>
        _host.ShutDown();
}