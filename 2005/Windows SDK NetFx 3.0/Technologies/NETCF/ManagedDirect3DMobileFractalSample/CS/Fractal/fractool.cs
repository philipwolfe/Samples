//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;


namespace Microsoft.Samples.MD3DM
{
    /// <summary>
    /// This class generates a 2D array of elevation points using
    /// midpoint displacement and random additions in two dimensions.
    /// </summary>
    public class ElevationPoints
    {
        // fractal terrain goes here. It is (2^maxlevel+1)^2 in bufferSize.
        private double[,] heights;

        // These values govern the topology of the fractal mesh
        private int maxlevel;
        private bool addition;
        private double sigma;
        private double shape;

        // Gausian number generator.
        private GaussGen Gauss;

        private double f3(double delta, double x0, double x1, double x2)
        {
            return ((x0 + x1 + x2) / 3 + delta * Gauss.GaussianNumber);
        }

        private double f4(double delta, double x0, double x1, double x2,
            double x3)
        {
            return ((x0 + x1 + x2 + x3) / 4 + delta * Gauss.GaussianNumber);
        }

        public double[,] GetHeights()
        {
            return heights;
        }

        /// <summary>
        /// Constrcutor. Pass in parameters
        /// </summary>
        /// <param name="maxLevel"> Maxlevel : determines the bufferSize of
        /// the fractal mesh</param>
        /// <param name="add"> Use random additions?</param>
        /// <param name="sd"> sigma : initial standard deviation</param>
        /// <param name="fractalDimension">
        /// Determines general shape of mesh</param>
        public ElevationPoints(int maxLevel, bool add, double sd,
            double fractalDimension)
        {
            maxlevel = maxLevel;
            addition = add;
            sigma = sd;
            shape = fractalDimension;
        }

        /// <summary>
        /// Constructor : uses arbitrary defualts
        /// </summary>
        public ElevationPoints()
        {
            maxlevel = 5;
            addition = true;
            sigma = .5;
            shape = .5;
        }

        /// <summary>
        /// Generates a fractal mesh 2^maxelvel+1 in bufferSize
        /// cribbed from "The Science of Fractal Images"
        /// </summary>
        public void CalcMidpointFM2D()
        {
            // tracks standard deviation
            double delta;
            // Integers
            int N, stage;
            // Array indices
            int x, y, D, d;

            // Initialize gaussian number widget
            Gauss = new GaussGen();
            N = (int)Math.Pow(2, maxlevel);
            delta = sigma;

            // Allocate dump for data
            heights = new double[N + 1, N + 1];
            // Init starting corner points in grid
            heights[0, 0] = delta * Gauss.GaussianNumber;
            heights[0, N] = delta * Gauss.GaussianNumber;
            heights[N, 0] = delta * Gauss.GaussianNumber;
            heights[N, N] = delta * Gauss.GaussianNumber;
            D = N;
            d = N / 2;
            stage = 1;

            while (stage <= maxlevel)
            {
                delta = delta * Math.Pow(0.5, 0.5 * shape);
                for (x = d; x <= N - d; x += D)
                    for (y = d; y <= N - d; y += D)
                        heights[x, y] = f4(delta, 
                            heights[x + d, y + d], 
                            heights[x + d, y - d],
                            heights[x - d, y + d], 
                            heights[x - d, y - d]);

                if (addition)
                    for (x = 0; x <= N; x += D)
                        for (y = 0; y <= N; y += D)
                            heights[x, y] = heights[x, y] +
                                delta * Gauss.GaussianNumber;


                delta = delta * Math.Pow(0.5, 0.5 * shape);

                for (x = d; x <= N - d; x += D)
                {
                    heights[x, 0] = f3(delta, heights[x + d, 0],
                        heights[x - d, 0], heights[x, d]);
                    heights[x, N] = f3(delta, heights[x + d, N],
                        heights[x - d, N], heights[x, N - d]);
                    heights[0, x] = f3(delta, heights[0, x + d],
                        heights[0, x - d], heights[d, x]);
                    heights[N, x] = f3(delta, heights[N, x + d],
                        heights[N, x - d], heights[N - d, x]);
                }

                for (x = d; x <= N - d; x += D)
                    for (y = D; y <= N - d; y += D)
                        heights[x, y] = f4(delta, 
                            heights[x, y + d], heights[x, y - d],
                            heights[x + d, y], heights[x - d, y]);

                for (x = D; x <= N - d; x += D)
                    for (y = d; y <= N - d; y += D)
                        heights[x, y] = f4(delta, 
                            heights[x, y + d], heights[x, y - d],
                            heights[x + d, y], heights[x - d, y]);


                if (addition)
                {
                    for (x = 0; x <= N; x += D)
                        for (y = 0; y <= N; y += D)
                            heights[x, y] = heights[x, y] + delta * Gauss.GaussianNumber;


                    for (x = d; x <= N - d; x += D)
                        for (y = d; y <= N - d; y += D)
                            heights[x, y] = heights[x, y] + delta * Gauss.GaussianNumber;
                }

                D = D / 2;
                d = d / 2;
                stage++;
            }
        }
    }

    class GaussGen
    {
        private int Arand;
        private double GaussAdd, numer, denom;
        private Random rand;

        /// <summary>
        /// Constructor; Initialize the Gausian number system
        /// </summary>
        /// <param name="seed"></param>
        public GaussGen()
        {
            rand = new Random(unchecked((int)DateTime.Now.Ticks));
            Arand = (int)Math.Pow(2, 31) - 1;
            GaussAdd = Math.Sqrt(12);
            numer = GaussAdd + GaussAdd;
            denom = (double)4 * Arand;
        }

        /// <summary>
        /// Return a Gaussian number
        /// </summary>
        /// <returns></returns>
        public double GaussianNumber
        {
            get
            {
                int i;
                double sum = 0;
                for (i = 1; i <= 4; i++)
                    sum += rand.Next(Arand);
                return ((sum * numer / denom) - GaussAdd);
            }
        }
    }
}
