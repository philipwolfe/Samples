using System;
using System.Collections.Generic;
using System.Text;


namespace SharedLib1
{
    public class Numbers
    {
        public long CalculateMean(long start, long count, long step)
        {
            long total = start;
            long mean = 0;

            try
            {
                for (long i = start; i < count; i += step)
                {
                    total += i;
                }

                mean = total / count;
            }
            catch (Exception)
            {
                mean = -1;
            }

            return mean;
        }
    }
}
