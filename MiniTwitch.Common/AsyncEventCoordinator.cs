namespace MiniTwitch.Common;

/// <summary>
/// Provides mechanisms to asynchronously wait for an event to occur
/// </summary>
/// <typeparam name="TEnum">The enum type to operate on</typeparam>
public class AsyncEventCoordinator<TEnum> : IDisposable
    where TEnum : struct
{
    private readonly Dictionary<int, SemaphoreSlim> _locks;

    /// <summary>
    /// Initializes a new instance of AsyncEventCoordinator
    /// </summary>
    /// <param name="initialCount">The initial semaphore request count</param>
    /// <exception cref="NotSupportedException"></exception>
    public AsyncEventCoordinator(int initialCount = 0)
    {
        if (!typeof(TEnum).IsEnum)
            throw new NotSupportedException($"The type {typeof(TEnum)} is not an enum");

        TEnum[] values = (TEnum[])Enum.GetValues(typeof(TEnum));
        _locks = new(values.Length);
        for (int i = 0; i < values.Length; i++)
        {
            _locks[(int)(object)values[i]] = new SemaphoreSlim(initialCount);
        }
    }

    /// <summary>
    /// Asynchronously wait for the <see cref="TEnum"/> value to be released
    /// </summary>
    /// <param name="value">The value to wait on</param>
    /// <param name="timeout">The wait timeout, after which <see langword="false"/> is returned</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns><see langword="true"/> if the wait was successful, otherwise <see langword="false"/></returns>
    public Task<bool> WaitFor(TEnum value, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        int key = (int)(object)value;
        return _locks[key].WaitAsync(timeout, cancellationToken);
    }

    /// <summary>
    /// Asynchronously wait for any of the <see cref="TEnum"/> values to be released
    /// </summary>
    /// <param name="values">The values to wait on</param>
    /// <param name="timeout">The wait timeout, after which <see langword="default"/> is returned</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The <see cref="TEnum"/> value that was released, otherwise <see cref="TimeoutException"/> is thrown</returns>
    /// <exception cref="TimeoutException"></exception>
    public async Task<TEnum> WaitForAny(IEnumerable<TEnum> values, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        TEnum[] valuesArr = values.ToArray();
        var tasks = new Task<bool>[valuesArr.Length];
        CancellationToken token = new(false);
        CancellationTokenSource tokenSource = CancellationTokenSource.CreateLinkedTokenSource(new[] { token, cancellationToken });
        for (int i = 0; i < valuesArr.Length; i++)
        {
            tasks[i] = WaitFor(valuesArr[i], timeout, tokenSource.Token);
        }

        _ = await Task.WhenAny(tasks);
        tokenSource.Cancel();
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].IsCompleted && tasks[i].Result == true)
                return valuesArr[i];
        }

        throw new TimeoutException("Timeout: No reference to a completed task was found");
    }

    /// <summary>
    /// Asynchronously wait for all the <see cref="TEnum"/> values to be released
    /// </summary>
    /// <param name="values">the values to wait on</param>
    /// <param name="timeout">The wait timeout, after which <see langword="false"/> is returned</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns><see langword="true"/> if the wait was successful, otherwise <see langword="false"/></returns>
    public async Task<bool> WaitForAll(IEnumerable<TEnum> values, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        TEnum[] valuesArr = values.ToArray();
        var tasks = new Task<bool>[valuesArr.Length];
        for (int i = 0; i < valuesArr.Length; i++)
        {
            tasks[i] = WaitFor(valuesArr[i], timeout, cancellationToken);
        }

        if ((await Task.WhenAll(tasks)).Contains(false))
            return false;

        return true;
    }

    /// <summary>
    /// Whether the semaphore for the <see cref="TEnum"/> value can grant a request
    /// </summary>
    /// <param name="value">The <see cref="TEnum"/> value to check</param>
    /// <returns><see langword="true"/> if <see cref="SemaphoreSlim.CurrentCount"/> > 0, otherwise <see langword="false"/></returns>
    public bool IsReleased(TEnum value)
    {
        int key = (int)(object)value;
        return _locks[key].CurrentCount > 0;
    }

    /// <summary>
    /// Release the lock for a <see cref="TEnum"/> value
    /// </summary>
    /// <param name="value">The <see cref="TEnum"/> value to release</param>
    public void Release(TEnum value)
    {
        int key = (int)(object)value;
        _ = _locks[key].Release();
    }

    /// <summary>
    /// Release the lock for a <see cref="TEnum"/> value only if <see cref="SemaphoreSlim.CurrentCount"/> == 0
    /// </summary>
    /// <param name="value">The <see cref="TEnum"/> value to release</param>
    public void ReleaseIfLocked(TEnum value)
    {
        int key = (int)(object)value;
        if (_locks[key].CurrentCount == 0)
            _ = _locks[key].Release();
    }

    public void Dispose()
    {
        foreach (SemaphoreSlim s in _locks.Values)
        {
            s.Dispose();
        }

        _locks.Clear();
        GC.SuppressFinalize(this);
    }
}
