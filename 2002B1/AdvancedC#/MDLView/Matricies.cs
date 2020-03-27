namespace MdlView
{
	using System;

	/// <summary>
	/// 4x4 Matrix Data Structure 
	/// </summary>
	struct Matrix
	{
		private float[,] Grid;
		internal bool AllOnes;
		
		/// <summary>
		/// Constructor for the Matrix struct
		/// </summary>
		public Matrix(bool ones)
		{
			this.Grid = new float[4, 4];
			AllOnes = ones;
		}

		/// <summary>
		/// Basic * Operator 
		/// </summary>
		/// <param name="A"> The left hand side of the operator </param>
		/// <param name="B"> The right hand side of the operator </param>
		public static Matrix operator* (Matrix A, Matrix B)
		{
			Matrix ResultMtrx = new Matrix(false);

			ResultMtrx[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0] + A[0, 2] * B[2, 0];
			ResultMtrx[0, 1] = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1] + A[0, 2] * B[2, 1];
			ResultMtrx[0, 2] = A[0, 0] * B[0, 2] + A[0, 1] * B[1, 2] + A[0, 2] * B[2, 2];
			ResultMtrx[0, 3] = 0;

			ResultMtrx[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0] + A[1, 2] * B[2, 0];
			ResultMtrx[1, 1] = A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1] + A[1, 2] * B[2, 1];
			ResultMtrx[1, 2] = A[1, 0] * B[0, 2] + A[1, 1] * B[1, 2] + A[1, 2] * B[2, 2];
			ResultMtrx[1, 3] = 0;

			ResultMtrx[2, 0] = A[2, 0] * B[0, 0] + A[2, 1] * B[1, 0] + A[2, 2] * B[2, 0];
			ResultMtrx[2, 1] = A[2, 0] * B[0, 1] + A[2, 1] * B[1, 1] + A[2, 2] * B[2, 1];
			ResultMtrx[2, 2] = A[2, 0] * B[0, 2] + A[2, 1] * B[1, 2] + A[2, 2] * B[2, 2];
			ResultMtrx[2, 3] = 0;

			ResultMtrx[3, 0] = A[3, 0] * B[0, 0] + A[3, 1] * B[1, 0] + A[3, 2] * B[2, 0];
			ResultMtrx[3, 1] = A[3, 0] * B[0, 1] + A[3, 1] * B[1, 1] + A[3, 2] * B[2, 1];
			ResultMtrx[3, 2] = A[3, 0] * B[0, 2] + A[3, 1] * B[1, 2] + A[3, 2] * B[2, 2];
			ResultMtrx[3, 3] = 0;			

			return ResultMtrx;
		}

		/// <summary>
		/// Indexer that allows easy access to the internal grid
		/// </summary>
		internal float this[int offsetX, int offsetY]
		{
			// Could do range checking here, but would rather speed for the moment			
			set
			{
				this.Grid[offsetX, offsetY] = value;
			}
			get
			{ 
				return this.Grid[offsetX, offsetY];
			}
		}

		/// <summary>
		/// Copies one matrix to another
		/// </summary>
		/// <param name="Source">The source matrix</param>
		/// <param name="Dest">The destination matrix</param>
		internal static void copy(Matrix Source, ref Matrix Dest)
		{
			int x;
			int y;
			for (y = 0; y < 4; y++)
				for (x = 0; x < 4; x++)
					Dest[x, y] = Source[x, y];
		}

		/// <summary>
		/// Set a matrix to the identity matrix
		/// </summary>
		/// <param name="A">The matrix to be set</param>
		internal static void identity(ref Matrix A)
		{
			int x;
			int y;
			for (y = 0; y < 4; y++)
				for (x = 0; x < 4; x++)
					A[x, y] = 0;			
			A[0, 0] = 1;
			A[1, 1] = 1;
			A[2, 2] = 1;
			A[3, 3] = 1;
		}
	}
}
