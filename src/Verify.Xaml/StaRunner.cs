using System;
using System.Threading;
using System.Threading.Tasks;

static class StaRunner
{
    public static Task<T> Start<T>(Func<T> func)
    {
        var completionSource = new TaskCompletionSource<T>();
        var thread = new Thread(() =>
        {
            try
            {
                var result = func();
                completionSource.SetResult(result);
            }
            catch (Exception exception)
            {
                completionSource.SetException(exception);
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        return completionSource.Task;
    }
}