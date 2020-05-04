using System;
using System.Collections.Generic;
using System.Text;

namespace VSTSTest
{
    /// <summary>
    /// Class to demo a simple add and subtract method
    /// </summary>
    public class Simple
    {
        /// <summary>
        /// Add method
        /// </summary>
        /// <param name="intNum1">number 1</param>
        /// <param name="intNum2">number 2</param>
        /// <returns>added numbers</returns>
        public int Add(int intNum1, int intNum2)
        {
            return intNum1 + intNum2;
        }

        /// <summary>
        /// Subtract
        /// </summary>
        /// <param name="intNum1"></param>
        /// <param name="intNum2"></param>
        /// <returns></returns>
        public int Subtract(int intNum1, int intNum2)
        {
            return intNum1 - intNum2;
        }

    }

}
