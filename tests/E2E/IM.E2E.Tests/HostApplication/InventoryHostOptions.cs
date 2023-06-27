namespace IM.E2E.Tests.HostApplication;

public static class InventoryHostOptions
{
    public static int Port = 7245;
    public static readonly string BaseUrl = $"https://localhost:{Port}";
    public const string CsProjectPath = @"G:\Tutorial\Programming\8 - Projects\InventoryManagement\src\Endpoint\IM.Endpoint\IM.Endpoint.csproj";
}
