namespace LeviathanJS.Services.Interface;

public interface IConsoleHost
{
    public void Log(params object[] args);
    
    public string GetLog();
}