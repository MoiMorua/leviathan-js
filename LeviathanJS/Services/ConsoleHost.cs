using System.Text;
using LeviathanJS.Services.Interface;

namespace LeviathanJS.Services;

public class ConsoleHost : IConsoleHost
{
    private StringBuilder _logBuilder = new();

    public void Log(params object[] args)
    {
        string message = string.Join(" ", args);
        _logBuilder.AppendLine(message);
    }

    public string GetLog() => _logBuilder.ToString();
    
}