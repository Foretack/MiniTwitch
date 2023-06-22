using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

namespace MiniTwitch.Common.Extensions;
public static class SpanExtensions
{
    public static int Sum(this ReadOnlySpan<byte> source)
    {
        int sum = 0;
        if (Avx2.IsSupported && source.Length > Vector256<byte>.Count)
        {
            var vecResult = Vector256<byte>.Zero;
            int inc = Vector256<byte>.Count;
            unsafe
            {
                fixed (byte* bRef = source)
                {
                    for (int i = 0; i < source.Length; i += inc)
                    {
                        Vector256<byte> vec = Avx.LoadVector256(bRef + i);
                        vecResult = Avx2.Add(vecResult, vec);
                    }
                }
            }

            for (int i = 0; i < inc; i++)
            {
                sum += vecResult.GetElement(i);
            }
        }
        else
        {
            foreach (byte b in source)
            {
                sum += b;
            }
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
