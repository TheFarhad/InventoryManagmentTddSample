namespace IM.E2E.Tests.HostApplication;

public interface IHost
{
    string BaseUrl { get; }
}

public interface IHostProcess : IHost
{
    void Start();
    void ShutDown();
}