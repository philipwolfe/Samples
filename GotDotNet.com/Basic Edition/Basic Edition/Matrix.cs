using System;
using System.Diagnostics;

namespace General
{


	/// <summary>
	/// Summary description for matrix.
	/// </summary>
	public class Matrix 
	{

		public Matrix()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void   Multiplication(double val, ref double[] product) 
		{

			for (byte m = 0; m < product.GetLength(0); m++) 

					product[m] *= val;
						
		}

		public static void   Multiplication(double val, ref double[,] product) 
		{

			for (byte m = 0; m < product.GetLength(0); m++) 
		
				for (byte n = 0; n < product.GetLength(1); n++) 
				
					product[m, n] *= val;
						
		}


		public static void   Multiplication(double[,]  first, double[]  second, out double[]  product) 
		{

			product = new double[first.GetLength(0)];
			
			for (byte m = 0; m < first.GetLength(0); m++) 
		
				for (byte i = 0; i < first.GetLength(1); i++) 

					product[m] += first[m, i] * second[i];
		
		}

		public static void   Multiplication(double[,] first, double[,] second, out double[,] product) 
		{

			product = new double[first.GetLength(0), second.GetLength(1)];
			
			for (byte m = 0; m < first.GetLength(0); m++) 
		
				for (byte n = 0; n < second.GetLength(1); n++) 
				{
	
					for (byte i = 0; i < first.GetLength(1); i++) 

						product[m, n] += first[m, i] * second[i, n];

				}

		
		}

		public static void   Multiplication(float[,]  first, float[,]  second, out float[,]  product) 
		{

			product = new float[first.GetLength(0), second.GetLength(1)];
			
			for (byte m = 0; m < first.GetLength(0); m++) 
		
				for (byte n = 0; n < second.GetLength(1); n++) 
				{

					for (byte i = 0; i < first.GetLength(1); i++) 

						product[m, n] += first[m, i] * second[i, n];

				}

		
		}


		public static void   Add(double[,] toAdd, ref double[,] original)
		{
	
			Debug.WriteLineIf(
				(toAdd.GetLength(0) != original.GetLength(0)) || 
				(toAdd.GetLength(1) != original.GetLength(1)),
				"Matrix.Add: different rank.");

			for (byte m = 0; m < original.GetLength(0); m++)

				for (byte n = 0; n < original.GetLength(1); n++) 
		
					original[m,n] += toAdd[m,n];

		}
		public static void   Add(double[] toAdd, ref double[] original)
		{
	
			Debug.WriteLineIf(
				(toAdd.GetLength(0) != original.GetLength(0)),
				"Matrix.Add: different rank.");

			for (byte m = 0; m < original.GetLength(0); m++)

					original[m] += toAdd[m];

		}

		public static void	 MakeSymmetric(ref double[,] matrix) 
		{

			for (byte m = 0; m < matrix.GetLength(0); m++)
				
				for (byte n = (byte)(m+1); n < matrix.GetLength(1); n++) 
		
					matrix[n,m] = matrix[m,n];

		}
		public static double Determinant(double[,] matrix) 
		{

			double det = 0;
		
			switch(matrix.GetLength(0)) 
			{

				case 2:

					det += matrix[0,0] * matrix[1,1];
					det -= matrix[0,1] * matrix[1,0];

					break;

				case 3:

					det += matrix[0,0] * matrix[1,1] * matrix[2,2];
					det += matrix[0,1] * matrix[1,2] * matrix[2,0];
					det += matrix[0,2] * matrix[1,0] * matrix[2,1];
					det -= matrix[0,2] * matrix[1,1] * matrix[2,0];
					det -= matrix[0,0] * matrix[1,2] * matrix[2,1];
					det -= matrix[0,1] * matrix[1,0] * matrix[2,2];

					break;

				default:

					Debug.WriteLine("Matrix.Determinant: Unable to calculate the determinant for this dimension");

					break;
			}

			return det;
		}
	
		public static void   Transpose(double[,] matrix, out double[,] transpose) 
		{

			transpose = new double[matrix.GetLength(1), matrix.GetLength(0)];

			for (byte m = 0; m < matrix.GetLength(0); m++)

				for (byte n = 0; n < matrix.GetLength(1); n++) 
		
					transpose[n,m] = matrix[m,n];

		}
	
		public static void   Inverse(double[,] matrix, out double[,] inverse) 
		{

			Debug.WriteLineIf(
				matrix.GetLength(0) != 3 ||
				matrix.GetLength(1) != 3, 
				"Matrix.Inverse: available only for 3x3 matrices.");

			double det = Determinant(matrix);

			Debug.WriteLineIf(det == 0, 
				"Matrix.Inverse: the inverse does not exists.");

			double[,] tmp;
			inverse = new double[3,3];

			tmp = new double[,] 
				{{matrix[1,1], matrix[1,2]},
				 {matrix[2,1], matrix[2,2]}};

			inverse[0,0] = +Determinant(tmp);

			tmp = new double[,] 
				{{matrix[1,0], matrix[1,2]},
				 {matrix[2,0], matrix[2,2]}};

			inverse[1,0] = -Determinant(tmp);

			tmp = new double[,] 
				{{matrix[1,0], matrix[1,1]},
				 {matrix[2,0], matrix[2,1]}};

			inverse[2,0] = +Determinant(tmp);

			tmp = new double[,] 
				{{matrix[0,1], matrix[0,2]},
				 {matrix[2,1], matrix[2,2]}};

			inverse[0,1] = -Determinant(tmp);

			tmp = new double[,] 
				{{matrix[0,0], matrix[0,2]},
				 {matrix[2,0], matrix[2,2]}};

			inverse[1,1] = +Determinant(tmp);

			tmp = new double[,] 
				{{matrix[0,0], matrix[0,1]},
				 {matrix[2,0], matrix[2,1]}};
			
			inverse[2,1] = -Determinant(tmp);			
			
			tmp = new double[,] 
				{{matrix[0,1], matrix[0,2]},
				 {matrix[1,1], matrix[1,2]}};
			
			inverse[0,2] = +Determinant(tmp);	
			
			tmp = new double[,] 
				{{matrix[0,0], matrix[0,2]},
				 {matrix[1,0], matrix[1,2]}};
			
			inverse[1,2] = -Determinant(tmp);	

			tmp = new double[,] 
				{{matrix[0,0], matrix[0,1]},
				 {matrix[1,0], matrix[1,1]}};
			
			inverse[2,2] = +Determinant(tmp);	

			Multiplication(1/det, ref inverse);

		}

		public static void AbsMinMax(double[,] matrix, out double minVal, out double maxVal) 
		{

			minVal = double.MaxValue;
			maxVal = double.MinValue;

			for (int m = 0; m < matrix.GetLength(0); m++)

				for (byte n = 0; n < matrix.GetLength(1); n++) 
				{

					double val = Math.Abs(matrix[m,n]);
		
					if (val > maxVal)

						maxVal = val;

					if (val < minVal)

						minVal = val;


				}

		}

		public static void AbsMax(float[,]  matrix, ref float maxVal) 
		{

			maxVal = float.MinValue;

			for (int m = 0; m < matrix.GetLength(0); m++)

				for (byte n = 0; n < matrix.GetLength(1); n++) 
				{

					float val = Math.Abs(matrix[m,n]);
		
					if (val > maxVal)

						maxVal = val;

				}

		}

		public static void AbsMax(double[,] matrix, out double maxVal) 
		{

			maxVal = double.MinValue;

			for (int m = 0; m < matrix.GetLength(0); m++)

				for (byte n = 0; n < matrix.GetLength(1); n++) 
				{

					double val = Math.Abs(matrix[m,n]);
		
					if (val > maxVal)

						maxVal = val;

				}

		}

		public static double Norm(double[,] matrix) 
		{

			double sum = 0;

			for (int m = 0; m < matrix.GetLength(0); m++)

				for (byte n = 0; n < matrix.GetLength(1); n++) 

					sum += matrix[m,n];

			return sum;

		}

		public static float Norm(float[,] matrix) 
		{

			float sum = 0;

			for (int m = 0; m < matrix.GetLength(0); m++)

				for (int n = 0; n < matrix.GetLength(1); n++) 

					sum += matrix[m,n];

			return sum;

		}



		public static float Norm1(float[] vector) 
		{

			float sum = 0;

			for (int m = 0; m < vector.Length; m++)

					sum += vector[m];

			return sum;

		}

		public static double Norm1(double[] vector) 
		{

			double sum = 0;

			for (int m = 0; m < vector.Length; m++)

				sum += vector[m];

			return sum;

		}

		public static float Norm2(float[,,] matrix) 
		{

					float sum = 0;

			for (int m = 0; m < matrix.GetLength(0); m++)

				for (int n = 0; n < matrix.GetLength(1); n++) 
				
					for (int i = 0; i < matrix.GetLength(2); i++) 
			
						sum += matrix[m,n,i];

		return sum;

		}





	}



}
