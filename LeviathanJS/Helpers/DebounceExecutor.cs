using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeviathanJS.Helpers;

public class DebounceExecutor
{
    private CancellationTokenSource _cancellationTokenSource;

    public void Execute(Action action, TimeSpan delaySpan)
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource = new CancellationTokenSource();
        var token = _cancellationTokenSource.Token;
         
        Task.Delay(delaySpan.Milliseconds, token)
            .ContinueWith( t =>
            {
                if (t.IsCanceled) return;

                if (Avalonia.Threading.Dispatcher.UIThread.CheckAccess())
                {
                    action();
                }
                else
                {
                    Avalonia.Threading.Dispatcher.UIThread.Post(action);
                }
            }, TaskScheduler.Default);
    }
}