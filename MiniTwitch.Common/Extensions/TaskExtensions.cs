namespace MiniTwitch.Common.Extensions;
public static class TaskExtensions
{
    public static async void StepOver(this ValueTask valueTask, Action<Exception>? @catch = null)
    {
        try
        {
            await valueTask;
        }
        catch (Exception ex) when (@catch is not null)
        {
            @catch.Invoke(ex);
        }
    }
    public static async void StepOver(this Task task, Action<Exception>? @catch = null)
    {
        try
        {
            await task;
        }
        catch (Exception ex) when (@catch is not null)
        {
            @catch.Invoke(ex);
        }
    }
}
