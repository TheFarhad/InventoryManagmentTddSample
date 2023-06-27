namespace IM.E2E.Tests.HostApplication;

using System.Diagnostics;

public class HostNetCoreApp : IHostProcess
{
    private readonly HostOptions _options;
    public string BaseUrl => $"https://localhost:{_options.Port}";
    private readonly AutoResetEvent _resetEvent = new AutoResetEvent(false);

    public HostNetCoreApp(HostOptions options) =>
           _options = options;

    public void Start()
    {
        ShutDown();
        var startInfo = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            Arguments = $"run --project \"{_options.CsProjectPath}\"",
        };
        var process = Process.Start(startInfo);

        process.ErrorDataReceived += ProcessOnErrorDataReceived;
        process.OutputDataReceived += ProcessOnOutputDataReceived;

        process.BeginErrorReadLine();
        process.BeginOutputReadLine();

        _resetEvent.WaitOne();
    }

    public void ShutDown()
    {
        HostProcessManager.KillBy(_options.Port);
    }

    private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (e.Data != null && e.Data.Contains("Now listening on", StringComparison.OrdinalIgnoreCase))
            _resetEvent.Set();
    }

    private static void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data))
            throw new Exception(e.Data);
    }
}