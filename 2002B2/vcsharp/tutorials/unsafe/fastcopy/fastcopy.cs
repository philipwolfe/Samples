// fastcopy.cs
// compile with: /unsafe
using System;

class Test
{
    // The unsafe keyword allows pointers to be used within
    // the following method:
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
        // The following fixed statement pins the location of
        // the src and dst objects in memory so that they will
        // not be moved by garbage collection.
        fixed (byte* pSrc = src, pDst = dst)
        {
            byte* ps = pSrc;
            byte* pd = pDst;
            // Loop over the count in blocks of 4 bytes, copying an
            // integer (4 bytes) at a time:
            for (int n = count >> 2; n != 0; n--)
            {
                *((int*)pd) = *((int*)ps);
                pd += 4;
                ps += 4;
            }
            // Complete the copy by moving any bytes that weren't
            // moved in blocks of 4:
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
           Console.Write(b[i] + "{0}", i < 9 ? " " : "");
        Console.WriteLine("\n");
    }
}
