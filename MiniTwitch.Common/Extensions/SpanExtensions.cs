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

    public static int CopyUnescaped(this ReadOnlySpan<byte> source, Span<byte> destination)
    {
        const byte backSlash = (byte)'\\';
        const byte quotation = (byte)'"';

        const byte s = (byte)'s';
        const byte colon = (byte)':';
        const byte r = (byte)'r';
        const byte n = (byte)'n';

        const byte space = (byte)' ';
        const byte semicolon = (byte)';';
        const byte cr = (byte)'\r';
        const byte lf = (byte)'\n';

        const byte terminate = 0;

        int moveLeft = 0;
        int atIndex = 0;
        int slashIndex;
        while ((slashIndex = source[atIndex..].IndexOf(backSlash)) != -1)
        {
            destination[atIndex + slashIndex - moveLeft] = source[atIndex + slashIndex + 1] switch
            {
                backSlash => backSlash,
                quotation => quotation,
                s => space,
                colon => semicolon,
                r => cr,
                n => lf,
                _ => source[atIndex + slashIndex + 1]
            };

            source[atIndex..(atIndex + slashIndex)].CopyTo(destination[(atIndex - moveLeft)..(atIndex + slashIndex - moveLeft)]);
            moveLeft++;
            atIndex += slashIndex + 2;
        }

        source[atIndex..].CopyTo(destination[(atIndex - moveLeft)..]);
        int stop = destination.IndexOf(terminate);
        return stop == -1 ? destination.Length : stop;
    }
}
