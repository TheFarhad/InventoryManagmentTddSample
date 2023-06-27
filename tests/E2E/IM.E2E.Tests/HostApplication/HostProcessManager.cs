namespace IM.E2E.Tests.HostApplication;

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class HostProcessManager
{
    private class WindowsProcess
    {
        public int ProcessId { get; set; }
        public int Port { get; set; }
        public string Protocol { get; set; }
    }

    public static void KillBy(int port)
    {
        var process = GetAllProcesses().FirstOrDefault(_ => _.Port == port);
        if (process != null)
        {
            Process.
                GetProcessById(process.ProcessId)
              .Kill();
        }
        //var processess = GetAllProcesses();
        //if (processes.Any(_ => _.Port == port))
        //    Process.
        //        GetProcessById(processes.First(_ => _.Port == port).ProcessId)
        //        .Kill();
    }

    public static int? FindProcessIdBy(int port) =>
        GetAllProcesses()
        .FirstOrDefault(a => a.Port == port)?
        .ProcessId;

    private static List<WindowsProcess> GetAllProcesses()
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "netstat.exe",
            Arguments = "-a -n -o",
            WindowStyle = ProcessWindowStyle.Maximized,
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        var process = Process.Start(processInfo);
        var soStream = process.StandardOutput;

        var output = soStream.ReadToEnd();
        if (process.ExitCode != 0)
            throw new Exception("something broken");

        var lines = Regex.Split(output, "\r\n");
        var result = CreateProcessFromOutput(lines);
        return result;
    }

    private static List<WindowsProcess> CreateProcessFromOutput(string[] lines)
    {
        var result = new List<WindowsProcess>();

        foreach (var line in lines)
        {
            if (line.Trim().StartsWith("Proto"))
                continue;

            var parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var len = parts.Length;
            if (len > 2)
                result.Add(new WindowsProcess
                {
                    Protocol = parts[0],
                    Port = int.Parse(parts[1].Split(':').Last()),
                    ProcessId = int.Parse(parts[len - 1])
                });
        }

        return result;
    }
}
