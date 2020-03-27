Notes:

    * MdlView reads and displays Quake(TM) I & Quake(TM) II models

Files:

    * GrLib16.cs - contains definition for 16-bit color graphic functions
    * IDirectDrawSurface7.cs - contains defintion for DirectDrawSurface interface
    * Matricies.cs - contains defintion for 4x4 matrix functions
    * MdlFile.cs - contains defintions for classes to read in .mdl and .md2 files
    * MdlForm.cs - contains the defintion for the Win Form used to host the viewer
    * Mesh.cs - contains the definition for 'meshs' (basic unit for representation of frames)
    * Model.cs - contains the definition of the model object
    * RenderList.cs - contains the definition of the 'world' triangle list
    * Stucts.cs - contains the definitions for most of the structs used for model info
    * SurfacePanel.cs - contains the re-definition of the panel to support a directDraw surface
    * VectorObject.cs - contains the abstract defintion of a vector object
    * .bmps - used for the buttons (note: actually compiled into the file... stored in the resX file)

Thanks to:
    * Michael Abarash for writing various 3d programming books and columns!  
    * Andre Lamothe for writing Black Art of 3d Game Programming (used in optimizations for matricies)


Issues:

    * Only loads skins that are named the same as the .md2 files for Quake II (tris.md2 will try to load tris.pcx)
    * Only runs in 16-bit color modes
    * Try http://www.planetquake.com for models