namespace MiniTwitch.Common.Extensions;
public static class SpanExtensions
{
    public static bool SumsTo(this ReadOnlySpan<byte> source, int value)
    {
        int sum = 0;
        foreach (byte b in source)
        {
            sum += b;
        }

        return sum == value;
    }
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
