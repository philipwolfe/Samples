// Unsafe\fastcopy.cs
using System;

class Test
{
    static unsafe void Copy(byte[] src, int srcIndex,
                            byte[] dst, int dstIndex, int count)
    {
        if (src == null || srcIndex < 0 ||
            dst == null || dstIndex < 0 || count < 0)
        {
            throw new ArgumentException();
        }
        int srcLen = src.Length;
        int dstLen = dst.Length;
        if (srcLen - srcIndex < count ||
            dstLen - dstIndex < count)
        {
            throw new ArgumentException();
        }
        fixed (byte* pSrc = src, pDst = dst)
        {
            byte* ps = pSrc;
            byte* pd = pDst;
            for (int n = count >> 2; n != 0; n--)
            {
                *((int*)pd) = *((int*)ps);
                pd += 4;
                ps += 4;
            }
            for (count &= 3; count != 0; count--)
            {
                *pd = *ps;
                pd++;
                ps++;
            }
        }
    }

    static void Main(string[] args) 
    {
        byte[] a = new byte[100];
        byte[] b = new byte[100];
        for(int i=0; i<100; ++i) 
           a[i] = (byte)i;
        Copy(a, 0, b, 0, 100);
        Console.WriteLine("The first 10 elements are:");
        for(int i=0; i<10; ++i) 
           Console.Write(b[i]+" ");
    }
}
