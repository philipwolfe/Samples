namespace MdlView
{
	using System;

	/// <summary>
	/// The class that encapsulates the 'model', derives from VectorObject
	/// </summary>
	internal class Model: VectorObject
	{
		// An array of .mdl files that make up the model (for quake 2 models, that's two files)
		private MdlFile[] modelList;
		private AnimationFrame[] animationSequences;
		private int modelVersion;
		private int maxMdlsLoadable;
		private int mdlsLoaded;
		private int currentFrameSequence;
		private int fCurrentFrameInSequence;

		/// <summary>
		/// Constructor
		/// </summary>
		public Model()
		{
			RotateMatrix = new Matrix(false);
			GlobalView = new Matrix(false);
			// Create the ability to load 10 separate .MDL files, ! Shouldn't ever need anywhere near that many
			modelList = new MdlFile[10];
			worldPos.X = 0;
			worldPos.Y = 0;
			worldPos.Z = 0;
			modelVersion = 0;
			// Assume only one for the moment
			maxMdlsLoadable = 1;
			// No mdls loaded yet!
			mdlsLoaded = 0;

			// Move this out of the constructor if you want to load more then one model at a time
			// That would also require rethinking how multiple palettes are handled
			MainFrm.graphicsObject.paletteCount = 0;
			MainFrm.graphicsObject.paletteIndex = 0;
			
			fCurrentFrameInSequence = 0;
			currentFrameSequence = 0;
		}

		/// <summary>
		/// Property that returns a string array of the animation sequence names
		/// </summary>
		public string[] sequenceList
		{
			get
			{
				int count;
				string[] returnList = new string[animationSequences.Length];
				for (count = 0; count < animationSequences.Length; count++)
					returnList[count] = animationSequences[count].AnimationName;

				return returnList;
			}
		}

		/// <summary>
		/// Property that gets and sets the current frame in a given sequence (the sequence is set through FrameSequencePlaying)
		/// </summary>
		public int currentFrameInSequence
		{
			get
			{
				return fCurrentFrameInSequence;
			}
			set
			{
				int count;
				if (value < animationSequences[currentFrameSequence].NumFrames)
				{
					fCurrentFrameInSequence = value;
				}
				else
					fCurrentFrameInSequence = 0;
				// Notice that the animation sequences are the same for all .mdls.  However, that is not always
				// true, in fact, it's almost never true for Quake II models.  Changing this to be based on the mesh
				// would probably be a good update.
				for (count = 0; count < mdlsLoaded; count++)
					modelList[count].CurrentFrameInMdl = animationSequences[currentFrameSequence].FirstFrame +
						fCurrentFrameInSequence;
			}
		}

		/// <summary>
		/// Returns the number of times to loop through a single sequence
		/// </summary>
		public int loopCount
		{
			get
			{
				return animationSequences[currentFrameSequence].LoopFrames;
			}
		}

		/// <summary>
		/// Gets and sets the frames per second for a given sequence.  
		/// </summary>
		public int FramesPerSecond
		{
			get
			{
				return animationSequences[currentFrameSequence].FramesPerSecond;
			}
			set
			{
				animationSequences[currentFrameSequence].FramesPerSecond = value;
			}
		}

		/// <summary>
		/// Gets and sets the current sequence that frame is an offset into
		/// </summary>
		public int FrameSequencePlaying
		{
			get
			{
				return currentFrameSequence;
			}
			set
			{
				int count;
				if (value < animationSequences.Length)
					currentFrameSequence = value;
				else
					currentFrameSequence = 0;
				fCurrentFrameInSequence = 0;
				for (count = 0; count < mdlsLoaded; count++)
					modelList[count].CurrentFrameInMdl = animationSequences[currentFrameSequence].FirstFrame;
			}
		}

		/// <summary>
		/// Overriden method (from VectorObject) that rotates the model
		/// </summary>
		protected internal override void RotateObject()
		{
			int Product;
			Matrix RotateX = new Matrix(false);
			Matrix RotateY = new Matrix(false);
			Matrix RotateZ = new Matrix(false);
			Matrix Temp = new Matrix(false);

			if ((angleX == 0) && (angleY == 0) && (angleZ == 0))
			{
				RotateMatrix.AllOnes = true;
				return;
			}
			else
				RotateMatrix.AllOnes = false;

			Product = 0;

			Matrix.identity(ref RotateMatrix);

			if (angleX > 0) 
			{
				Matrix.identity(ref RotateX);

				RotateX[1, 1] = Cos_Look[angleX];
				RotateX[1, 2] = Sin_Look[angleX];
				RotateX[2, 1] = -(Sin_Look[angleX]);
				RotateX[2, 2] = Cos_Look[angleX];

				Product |= 4;
			}

			if (angleY > 0)
			{
				Matrix.identity(ref RotateY);

				RotateY[0, 0] = Cos_Look[angleY];
				RotateY[0, 2] = -(Sin_Look[angleY]);
				RotateY[2, 0] = Sin_Look[angleY];
				RotateY[2, 2] = Cos_Look[angleY];

				Product |= 2;
			}

			if (angleZ > 0)
			{
				Matrix.identity(ref RotateZ);

				RotateZ[0, 0] = Cos_Look[angleZ];
				RotateZ[0, 1] = Sin_Look[angleZ];
				RotateZ[1, 0] = -(Sin_Look[angleZ]);
				RotateZ[1, 1] = Cos_Look[angleZ];

				Product |= 1;
			}

			switch(Product)
			{
				case 1:
					Matrix.copy(RotateZ, ref RotateMatrix);
					break;
				case 2:
					Matrix.copy(RotateY, ref RotateMatrix);
					break;
				case 3:
					RotateMatrix = RotateZ * RotateY;
					break;
				case 4:
					Matrix.copy(RotateX, ref RotateMatrix);
					break;
				case 5:
					RotateMatrix = RotateZ * RotateX;
					break;
				case 6:
					RotateMatrix = RotateX * RotateY;
					break;
				case 7:
					Temp = RotateZ * RotateY;
					RotateMatrix = Temp * RotateZ;

					break;
			}
		}

		/// <summary>
		/// Gets the version of the current model
		/// </summary>
		public int Version
		{
			get
			{
				return modelVersion;
			}
		}

		/// <summary>
		/// Loads an .mdl into the current model (can be called multiple times)
		/// </summary>
		/// <param name="Filename">The file and path to the .mdl</param>
		public bool LoadFromFile(string Filename)
		{
			bool ReturnValue = false;
			if (mdlsLoaded < maxMdlsLoadable)
			{
				modelList[mdlsLoaded] = new MdlFile();
				ReturnValue = modelList[mdlsLoaded].LoadFromFile(Filename);
				if (ReturnValue)
				{
					if (modelVersion == 0)
					{
						modelVersion = modelList[mdlsLoaded].Version;
						switch(modelVersion)
						{
							case 6:
								// Version 6 had all defintions in *one* .mdl file (the good old days!)
								maxMdlsLoadable = 1;
								animationSequences = modelList[mdlsLoaded].Sequences;
								break;
							case 8:
								// Version 8 has separate definitions for the 'tris' and the 'weapon' (two .MD2s)
								maxMdlsLoadable = 2;
								animationSequences = modelList[mdlsLoaded].Sequences;
								break;
						}
					}
					mdlsLoaded++;
				}
			}
			
			return ReturnValue;
		}

		protected internal override void AddToList(ref RenderList WorldList, enumRenderingMode renderType, int TransX, int TransY)
		{
			int count;
			Vector objectViewer; 

			RotateObject();

			// Unitized object viewer (y is the same as -512 not unitized)
			objectViewer.x = 0;
			objectViewer.y = -0.001953125f;
			objectViewer.z = 0;

			// Rotate the objectViewer in the oppisite direction of the model to make backface culling work
			// That is, we'll rotate a single vector the oppisite direction, instead of every vertex.
			objectViewer = Model.SingleRotate(objectViewer, (511 - angleX), (511 - angleY), (511 - angleZ));

			// Creates the global view
			CreateWorldToCamera(WorldList.ViewerPos.X, WorldList.ViewerPos.Y, WorldList.ViewerPos.Z,
				WorldList.ViewerAngle.X, WorldList.ViewerAngle.Y, WorldList.ViewerAngle.Z);

			for (count = 0; count < mdlsLoaded; count++)
			{
				modelList[count].setRotateMdl(RotateMatrix, scaleFactor, worldPos);
				// Add the model to the list!
				modelList[count].AddModelToList(ref WorldList, renderType, TransX, TransY, GlobalView, objectViewer);
			}
		}
	}
}
