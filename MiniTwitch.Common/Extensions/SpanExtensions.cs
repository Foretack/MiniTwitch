namespace MiniTwitch.Common.Extensions;
public static class SpanExtensions
{
    public static int Sum(this ReadOnlySpan<byte> source)
    {
        int sum = 0;
        foreach (byte b in source)
        {
            sum += b;
        }

        return sum;
    }
}
