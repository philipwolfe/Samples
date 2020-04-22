/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * LifeModel.cs
 * 
 * Implements the AvalonLife simulation model class
 * 
 * Written by Mark Betz - http://www.markbetz.net
 * 
 * This application and related source code is released to the public domain.
 * If you modify and redistribute this source or executable please indicate
 * the version in the application window title, and include a readme file
 * listing the changes you have made.
 * 
*/

using System;
using System.IO;
using System.Windows.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.Serialization;

namespace AvalonLife
{
    /// <summary>
    /// GridType
    /// 
    /// This enumeration is used to specify the type of grid bounding that
    /// the model will use:
    /// 
    /// Torus - the cells on all edges of the grid wrap to the opposite edge.
    /// XCylinder - the cells on the x axis edges wrap, the y-axis is finite.
    /// YCylinder - the cells on the y axis edges wrap, the x-axis is finite.
    /// Finite - all four edges of the grid are finite.
    /// 
    /// </summary>
    enum GridType
    {
        Torus,
        XCylinder,
        YCylinder,
        Finite
    };
    
    /// <summary>
    /// I just wanted a simple rectangle class with four numbers in it, to use in
    /// resizing the model grid (I use it as return type from a function that
    /// calculates the extent of the current model).
    /// </summary>
    struct ALRectangle
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    
    /// <summary>
    /// The LifeCell class represents a single cell and its live/dead state
    /// </summary>
    class LifeCell : INotifyPropertyChanged
    {
        #region LifeCell public properties
        
        
        private bool _isAlive = false;
        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
            set
            {
                _isAlive = value;
                if ( PropertyChanged != null )
                    PropertyChanged( this, new PropertyChangedEventArgs("IsAlive") );
            }
        }
        #endregion
        
        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 
    }
    
    /// <summary>
    /// The LifeModel class represents a grid of life cells
    /// </summary>
    [Serializable]
    class LifeModel : ISerializable, INotifyPropertyChanged
    {
        #region LifeModel public interface
        
        /// <summary>
        /// LifeModel()
        /// 
        /// Initializes the LifeCell array with the default bounds
        /// </summary>
        public LifeModel()
        {
            InitArrays( ALSettings.Default.GridHeight, ALSettings.Default.GridWidth );
        }

        /// <summary>
        /// LifeModel(int, int)
        /// 
        /// Initializes the LifeCell array with the passed in bounds
        /// </summary>
        /// <param name="columns">int, width of the life grid</param>
        /// <param name="rows">int, height of the life grid</param>
        public LifeModel( int rows, int columns )
        {
            InitArrays( rows, columns ); 
        }

        /// <summary>
        /// LifeModel(Stream)
        /// 
        /// Constructs a LifeModel from a stream of .cells data compatible with the
        /// Life Lexicon website.
        /// </summary>
        /// <param name="str"></param>
        public LifeModel( Stream str )
        {
            int copyRow = 0;
            int copyCol = 0;
            
            StreamReader reader = new StreamReader(str);
            string input = reader.ReadToEnd();
            char[] sep = { '\n' };
            string[] inputs = input.Split(sep);
            if ( inputs.Length < 2 )
                throw( new System.Exception("Bad cell data format") );
                
            _modelName = inputs[0].Substring(6, inputs[0].Length - 6);
            
            int newRows = inputs.Length - 3;
            int newCols = inputs[2].Length;
            int defRows = ALSettings.Default.GridHeight;
            int defCols = ALSettings.Default.GridWidth;
            
            if ( !ALSettings.Default.ShrinkGridToModel )
            {
                if (newRows < defRows)
                    copyRow = (defRows - newRows) / 2;
                else
                    defRows = newRows;
                    
                if (newCols < defCols)
                    copyCol = (defCols - newCols) / 2;
                else
                    defCols = newCols;
            }
            else
            {
                defRows = newRows;
                defCols = newCols;
            }

            _evaluated = false;
            PeakPopulation = 0;
            Population = 0;
            _gridType = ALSettings.Default.DefaultGridType;
            
            InitArrays(defRows, defCols);
            
            BuildWorkGrid();
            
            for ( int row = 0; row < newRows; row++ )
            {
                for ( int col = 0; col < newCols; col++ )
                {
                    bool set = false;
                    if ( inputs[row + 2][col] == '\x4f' )
                    {    
                        set = true;
                    }
                    else if ( inputs[row + 2][col] != '\x2e' )
                        throw( new System.Exception("Invalid character in cell data: " + inputs[row + 2][col].ToString()) );
                    
                    _cellGrid[row + copyRow, col + copyCol].IsAlive = 
                        _lastGrid[row + copyRow, col + copyCol] = 
                        _startingGrid[row + copyRow, col + copyCol] = set;
                }
            }
        }
        
        #region ISerializable methods
        
        /// <summary>
        /// LifeModel(SerializationInfo, StreamingContext)
        /// 
        /// Called by the BinaryFormatter to construct a LifeModel instance from a stream. Expects
        /// _lastGrid to contain the most recent grid array, and copies it into a newly constructed
        /// array of LifeCells.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public LifeModel( SerializationInfo info, StreamingContext ctxt )
        {
            _rows = (int)info.GetValue( "_rows", typeof(int) );
            _columns = (int)info.GetValue( "_columns", typeof(int) );
            _startingGrid = (bool[,])info.GetValue( "_startingGrid", typeof(bool[,]) );
            _lastGrid = (bool[,])info.GetValue("_lastGrid", typeof(bool[,]) );
            _evaluated = (bool)info.GetValue( "_evaluated", typeof(bool) );
            _peakPopulation = (int)info.GetValue( "_peakPopulation", typeof(int) );
            _gridType = (GridType)info.GetValue( "_gridType", typeof(GridType) );
            _modelName = (string)info.GetValue( "_modelName", typeof(string) );
            _cellGrid = new LifeCell[_rows, _columns];
            
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                {    
                    _cellGrid[row, col] = new LifeCell();
                    _cellGrid[row, col].IsAlive = _lastGrid[row, col];
                }
            }
            BuildWorkGrid();
        }
        
        /// <summary>
        /// GetObjectData(SerializationInfo, StreamingContext)
        /// 
        /// Called by the BinaryFormatter to serialize the data for a LifeModel
        /// into a stream. If the model has never been evaluated (i.e. edits have been
        /// made to the grid but the sim hasn't been run, the contents of the grid array
        /// are copied into _lastGrid first, and then serialization occurs.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public void GetObjectData( SerializationInfo info, StreamingContext ctxt )
        {
            if ( !_evaluated )
            {
                for ( int row = 0; row < _rows; row++ )
                {
                    for ( int col = 0; col < _columns; col++ )
                        _lastGrid[row, col] = _cellGrid[row, col].IsAlive;
                }
            }
            info.AddValue( "_rows", _rows );
            info.AddValue( "_columns", _columns );
            info.AddValue( "_startingGrid", _startingGrid );
            info.AddValue( "_lastGrid", _lastGrid );
            info.AddValue( "_evaluated", _evaluated );
            info.AddValue( "_gridType", _gridType );
            info.AddValue( "_modelName", _modelName );
            info.AddValue( "_peakPopulation", _peakPopulation );
        }
        
        /// <summary>
        /// StreamCells(Stream)
        /// 
        /// Writes out the current model grid to the passed in Stream in .cells
        /// format compatible with the format on the Life Lexicon website. Note
        /// that this format doesn't store any of the additional information, such
        /// as grid type and starting state, that the .avl format saves.
        /// </summary>
        /// <param name="str"></param>
        public void StreamCells( Stream str )
        {
            str.WriteByte( 0x21 );

            byte[] bytes;
            if ( _modelName != null && _modelName.Length > 0 )
                bytes = Encoding.UTF8.GetBytes( "Name: " + _modelName );
            else
                bytes = Encoding.UTF8.GetBytes( "Name: untitled" );
            
            str.Write( bytes, 0, bytes.Length );
            str.WriteByte( 0x0a );
            
            str.WriteByte( 0x21 );
            str.WriteByte( 0x0a );
            
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                {
                    if ( _cellGrid[row, col].IsAlive )
                        str.WriteByte( 0x4f );
                    else
                        str.WriteByte( 0x2e );
                }
                str.WriteByte( 0x0a );
            }
        }
        
        /// <summary>
        /// ResizeModel(int, int)
        /// 
        /// This function performs a resizing of the grid according to the specified
        /// dimensions. It does not resize the model, i.e. the current set of live cells
        /// but will center the model in the new grid if it is larger. If this function
        /// is passed 0 for the rows and columns it will shrink the grid to the size
        /// of the current model. The function will return false if the specific requested
        /// grid size is too small to contain the current set of live cells.
        /// </summary>
        /// <param name="newRows"></param>
        /// <param name="newCols"></param>
        /// <returns></returns>
        public bool ResizeModel( int newRows, int newCols )
        {
            int copyRow = 0;
            int copyCol = 0;
            int currRows = 0;
            int currCols = 0;
            
            // if the dimensions haven't changed bail
            if ( newRows == _rows && newCols == _columns )
                return true;
                
            // if the requested dimensions are larger we can just expand and center
            // the model on the grid
            if ( newRows > _rows && newCols > _columns )
            {
                copyRow = (newRows - _rows) / 2;
                copyCol = (newCols - _columns) / 2;
                
                bool[,] tempLifeGrid = new bool[_rows, _columns];
                bool[,] tempStartGrid = _lastGrid;
                
                for ( int row = 0; row < _rows; row++ )
                {
                    for ( int col = 0; col < _columns; col++ )
                    {    
                        tempLifeGrid[row, col] = _cellGrid[row, col].IsAlive;
                        tempStartGrid[row, col] = _startingGrid[row, col];
                    }
                }
                currRows = _rows;
                currCols = _columns;
                
                InitArrays(newRows, newCols);
                BuildWorkGrid();
                
                for ( int row = 0; row < currRows; row++ )
                {
                    for ( int col = 0; col < currCols; col++ )
                    {    
                        _cellGrid[row + copyRow, col + copyCol].IsAlive = tempLifeGrid[row, col];
                        _startingGrid[row + copyRow, col + copyCol] = tempStartGrid[row, col];
                    }
                }
                return true;
            }
            
            // if we get here either the requested grid is smaller than the current
            // one, or the user has asked for the grid to be shrunk to the model. In
            // either case we first need to know the extent of the current set of live
            // cells.
            ALRectangle rect = GetModelExtent();
            currRows = (rect.Bottom - rect.Top) + 1;
            currCols = (rect.Right - rect.Left) + 1;
            
            if ( newRows == 0 ) newRows = currRows;
            if ( newCols == 0 ) newCols = currCols;
            
            if ( newRows >= currRows && newCols >= currCols )
            {
                copyRow = (newRows - currRows) / 2;
                copyCol = (newCols - currCols) / 2;

                bool[,] tempLifeGrid = new bool[_rows, _columns];
                bool[,] tempStartGrid = _lastGrid;

                for (int row = 0; row < _rows; row++)
                {
                    for (int col = 0; col < _columns; col++)
                    {
                        tempLifeGrid[row, col] = _cellGrid[row, col].IsAlive;
                        tempStartGrid[row, col] = _startingGrid[row, col];
                    }
                }
                InitArrays(newRows, newCols);
                BuildWorkGrid();
                for (int row = 0; row < currRows; row++)
                {
                    for (int col = 0; col < currCols; col++)
                    {
                        _cellGrid[row + copyRow, col + copyCol].IsAlive = tempLifeGrid[row + rect.Top, col + rect.Left];
                        _startingGrid[row + copyRow, col + copyCol] = tempStartGrid[row + rect.Top, col + rect.Left];
                    }
                }
                return true;
            }
            return false;
        }
        
        #endregion
        
        /// <summary>
        /// IsEmpty()
        /// 
        /// Returns false if at least one cell in the grid is alive
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            bool empty = true;
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                {
                    if ( _cellGrid[row, col].IsAlive )
                    {
                        empty = false;
                        break;
                    }
                }
            } 
            return empty;
        }
        
        /// <summary>
        /// Called by the LifeSim class to iterate through the array and apply the game
        /// rules once.
        /// </summary>
        public void Evaluate()
        {
            bool[,] temp = new bool[_rows, _columns];
            
            int population = 0;
            
            if ( !_evaluated )
            {
                _evaluated = true;
                for ( int row = 0; row < _rows; row++ )
                {
                    for ( int col = 0; col < _columns; col++ )
                    {    
                        _startingGrid[row, col] = _lastGrid[row, col] = _cellGrid[row, col].IsAlive;
                        if ( _startingGrid[row, col] )
                            _peakPopulation++;
                    }
                }
                PeakPopulation = _peakPopulation;
            } 
            
            for( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                {
                    _lastGrid[row, col] = _cellGrid[row, col].IsAlive;
                    int adj = CountAdjacent( row, col );
                    if ( _cellGrid[row, col].IsAlive )
                    {
                        if ( adj == 2 || adj == 3 )
                            temp[row, col] = true;
                        else
                            CellDeaths++;
                    }
                    else
                    {
                        if ( adj == 3 )
                        {
                            temp[row, col] = true;
                            CellBirths++;
                        }
                    }
                }
            }
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                {
                    if ( temp[row, col] == true )
                    {    
                        _cellGrid[row, col].IsAlive = true;
                        population++;
                    }
                    else
                        _cellGrid[row, col].IsAlive = false;   
                }
            }
            Population = population;
            if ( _peakPopulation < population )
                PeakPopulation = population;
            if ( AreEqualGrids(_cellGrid, _lastGrid) )
                _evoHalted = true;
        }

        /// <summary>
        /// ResetModel()
        /// 
        /// Resets the life model to the starting state by restoring the values in
        /// _startingGrid to the cell array.
        /// </summary>
        public void ResetModel()
        {
            _evaluated = false;
            CellBirths = 0;
            CellDeaths = 0;
            _evoHalted = false;
            Population = 0;
            PeakPopulation = 0;
            
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                    _cellGrid[row, col].IsAlive = _startingGrid[row, col];
            }
        }
        #endregion

        #region LifeModel private methods

        /// <summary>
        /// GetModelExtent()
        /// 
        /// Returns an ALRectangle structure with the extent of the current
        /// set of life cells.
        /// </summary>
        /// <returns></returns>
        private ALRectangle GetModelExtent()
        {
            ALRectangle rect;
            rect.Left = _columns / 2;
            rect.Top = _rows / 2;
            rect.Right = rect.Left + 1;
            rect.Bottom = rect.Top + 1;
            
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                {
                    if ( _cellGrid[row, col].IsAlive )
                    {
                        if (row < rect.Top ) rect.Top = row;
                        if (row > rect.Bottom ) rect.Bottom = row;
                        if (col < rect.Left) rect.Left = col;
                        if (col > rect.Right) rect.Right = col;
                    }
                }
            }
            return rect;
        }
        
        /// <summary>
        /// AreEqualGrids(LifeCell[,], bool[,])
        /// 
        /// Called from Evaluate() to determine if evolution has ceased or the sim
        /// has fallen into an  oscillating pattern. Compares an array of LifeCells
        /// to a backup array of booleans and returns true if they are the same
        /// </summary>
        /// <param name="lc"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool AreEqualGrids( LifeCell[,] lc, bool[,] b )
        {
            bool result = true;
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                {
                    if ( lc[row, col].IsAlive != b[row, col] )
                    {
                        result = false;
                        break;
                    }
                }
            }
            
            return result;
        }
        
        /// <summary>
        /// CountAdjacent(int, int)
        /// 
        /// This function counts neighbors using the work grid, which returns
        /// the correct values for edge cells depending on the grid type. The work
        /// grid is two cells larger in both dimensions, with the outer cells used
        /// for correct wrapping of neighbor checks, as set up in BuildWorkGrid().
        /// The incoming coordinates are in the _cellGrid space, so this function
        /// shifts them down and right 1 cell to get to _workGrid space.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private int CountAdjacent(int row, int column)
        {
            int count = 0;
            
            row++;
            column++;
            
            // upper left
            if ( _workGrid[row - 1, column - 1].IsAlive )
                count++;
            
            if ( _workGrid[row - 1, column].IsAlive )
                count++;
            
            // upper right
            if ( _workGrid[row - 1, column + 1].IsAlive )
                count++;
            
            // left
            if ( _workGrid[row, column - 1].IsAlive )
                count++;
            
            // right
            if ( _workGrid[row, column + 1].IsAlive )
                count++;
        
            // lower left
            if ( _workGrid[row + 1, column - 1].IsAlive )
                count++;
            
            // lower middle
            if ( _workGrid[row + 1, column].IsAlive )
                count++;
         
            // lower right
            if ( _workGrid[row + 1, column + 1].IsAlive )
                count++;
            
            return count;
        }
        
        /// <summary>
        /// BuildWorkGrid()
        /// 
        /// The work grid is two cells larger in each dimension, with the edge cells being
        /// used for controlling how the model wraps. This method builds the work grid off
        /// of the _cellGrid taking the GridType into account.
        /// </summary>
        private void BuildWorkGrid()
        {
            _workGrid = new LifeCell[_rows + 2, _columns + 2];
            for ( int row = 0; row < _rows + 2; row++ )
            {
                for ( int col = 0; col < _columns + 2; col++ )
                {
                   // Handle the corner conditions. A corner cell can only be
                   // alive in the case of a torus. In all other grid types it
                   // will be dead by one of the other edges. In the case of a
                   // torus it wraps to the opposite corner.
                   if ( row == 0 && col == 0 )
                   {
                       switch (_gridType)
                       {
                           case GridType.Torus:
                               _workGrid[row, col] = _cellGrid[_rows - 1, _columns - 1];
                               break;
                           default:    
                               _workGrid[row, col] = new LifeCell();
                               break;
                       }
                   }
                   else if ( row == 0 && col == _columns + 1 )
                   {
                       switch (_gridType)
                       {
                           case GridType.Torus:
                               _workGrid[row, col] = _cellGrid[_rows - 1, 0];
                               break;
                           default:
                               _workGrid[row, col] = new LifeCell();
                               break;
                       }
                   }
                   else if (row == _rows + 1 && col == _columns + 1)
                   {
                       switch (_gridType)
                       {
                           case GridType.Torus:
                               _workGrid[row, col] = _cellGrid[0, 0];
                               break;
                           default:
                               _workGrid[row, col] = new LifeCell();
                               break;
                       }
                   }
                   else if (row == _rows + 1 && col == 0)
                   {
                       switch (_gridType)
                       {
                           case GridType.Torus:
                               _workGrid[row, col] = _cellGrid[0, _columns - 1];
                               break;
                           default:
                               _workGrid[row, col] = new LifeCell();
                               break;
                       }
                   }
                   // Handle the non-corner edges. They are dead in the
                   // finite case, or the case where they lie along the top/bottom
                   // in an x cylinder grid, or the left/right in a y cylinder grid.
                   // Otherwise they wrap to the cell on the opposite side.
                   else if (row == 0)
                   {
                       switch( _gridType )
                       {
                           case GridType.Finite:
                           case GridType.XCylinder:
                               _workGrid[row, col] = new LifeCell();
                               break;
                           case GridType.Torus:
                           case GridType.YCylinder:
                               _workGrid[row, col] = _cellGrid[_rows - 1, col - 1];
                               break;
                       }
                   }
                   else if ( row == _rows + 1 )
                   {
                       switch( _gridType )
                       {
                           case GridType.Finite:
                           case GridType.XCylinder:
                               _workGrid[row, col] = new LifeCell();
                               break;
                           case GridType.Torus:
                           case GridType.YCylinder:
                               _workGrid[row, col] = _cellGrid[0, col - 1];
                               break;
                       }
                   }
                   else if ( col == 0 )
                   {
                       switch (_gridType)
                       {
                           case GridType.Finite:
                           case GridType.YCylinder:
                               _workGrid[row, col] = new LifeCell();
                               break;
                           case GridType.Torus:
                           case GridType.XCylinder:
                               _workGrid[row, col] = _cellGrid[row - 1, _columns - 1];
                               break;
                       }
                   }
                   else if ( col == _columns + 1 )
                   {
                       switch (_gridType)
                       {
                           case GridType.Finite:
                           case GridType.YCylinder:
                               _workGrid[row, col] = new LifeCell();
                               break;
                           case GridType.Torus:
                           case GridType.XCylinder:
                               _workGrid[row, col] = _cellGrid[row - 1, 0];
                               break;
                       }
                   }
                   else
                       _workGrid[row, col] = _cellGrid[row - 1, col - 1];
                }
            }          
        }
        
        /// <summary>
        /// InitArrays(int, int)
        /// 
        /// Called from the LifeModel constructors to create the LifeCell array and assign
        /// values to related private members
        /// </summary>
        /// <param name="columns">int, the width (columns) of the grid to be created</param>
        /// <param name="rows">int, the height (rows) of the grid to be created</param>
        private void InitArrays(int rows, int columns )
        {
            if ( columns <= 0 || rows <= 0 )
                throw( new System.ArgumentOutOfRangeException("InitArrays") );
                 
            _columns = columns;
            _rows = rows;
            
            _cellGrid = new LifeCell[_rows, _columns];
            
            for ( int row = 0; row < _rows; row++ )
            {
                for ( int col = 0; col < _columns; col++ )
                    _cellGrid[row, col] = new LifeCell();
            }
            
            BuildWorkGrid();
            
            _startingGrid = new bool[_rows, _columns];
            _lastGrid = new bool[_rows, _columns];
        }
        #endregion
        
        #region LifeModel Properties
        
        /// <summary>
        /// The number of columns across the life grid
        /// </summary>
        private int _columns = 0;
        public int Columns
        {
            get
            {
                return _columns;
            }
        }
        
        /// <summary>
        /// The number of rows down the life grid
        /// </summary>
        private int _rows = 0;
        public int Rows
        {
            get
            {
                return _rows;
            }
        }
        
        /// <summary>
        /// LifeCell
        /// 
        /// This property gives access to the array of LifeCell objects so that they can be used
        /// as data context in binding to the UI. Not sure I like this design.
        /// </summary>
        private LifeCell[,] _cellGrid = null;
        public LifeCell[,] CellGrid
        {
            get
            {
                if ( _cellGrid != null )
                    return _cellGrid;    
                else
                    throw( new System.InvalidOperationException("LifeCell_get") );
            }
        }

        /// <summary>
        /// Evaluated
        /// 
        /// True if the model has been evaluated at least once, meaning that the data
        /// in _startingGrid is valid
        /// </summary>
        bool _evaluated = false;
        public bool Evaluated
        {
            get
            {
                return _evaluated;
            }
        }

        /// <summary>
        /// CellBirths
        /// 
        /// Counts the number of cell births. Fires change notification.
        /// </summary>
        private int _cellBirths = 0;
        public int CellBirths
        {
            get
            {
                return _cellBirths;
            }
            protected set
            {
                _cellBirths = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellBirths"));
            }
        }
        
        /// <summary>
        /// CellDeaths
        /// 
        /// Counts the number of cell deaths. Fires change notification.
        /// </summary>
        private int _cellDeaths = 0;
        public int CellDeaths
        {
            get
            {
                return _cellDeaths;
            }
            protected set
            {
                _cellDeaths = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellDeaths"));
            }
        }
        
        /// <summary>
        /// EvolutionHalted
        /// 
        /// True if the model evolution has halted
        /// </summary>
        private bool _evoHalted = false;
        public bool EvolutionHalted
        {
            get
            {
                return _evoHalted;
            }
        }
        
        /// <summary>
        /// PeakPopulation
        /// 
        /// Tracks the maximum population of cells on the grid. Fires
        /// change notification.
        /// </summary>
        private int _peakPopulation = 0;
        public int PeakPopulation
        {
            get
            {
                return _peakPopulation;
            }
            protected set
            {
                _peakPopulation = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PeakPopulation"));
            }
        }
        
        /// <summary>
        /// Population
        /// 
        /// Tracks the current population of the grid at the close of each tick.
        /// Fires change notification.
        /// </summary>
        private int _population = 0;
        public int Population
        {
            get
            {
                return _population;
            }
            protected set
            {
                _population = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Population"));
            }
        }
        
        /// <summary>
        /// GridType
        /// 
        /// Used to set the bounding behavior of the cell grid according to the
        /// GridType enumeration. 
        /// </summary>
        private GridType _gridType = ALSettings.Default.DefaultGridType;
        public GridType LifeGridType
        {
            get
            {
                return _gridType;
            }
            set
            {
                _gridType = value;
                BuildWorkGrid();
            }
        }
        
        /// <summary>
        /// Contains the name (title) of the current model
        /// </summary>
        private string _modelName = null;
        public string ModelName
        {
            get
            {
                return _modelName;
            }
            set
            {
                _modelName = value;
            }
        }
        
        #endregion

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        
        #region LifeModel private data
        
        // holds the starting grid state so we can revert on demand
        private bool[,] _startingGrid = null;
        
        // holds the state of the last calculate grid, used to 
        // detect a halt
        private bool[,] _lastGrid = null;
        
        // holds the working grid, which is two cells larger than
        // the cell grid on each dimension, with the edge cells
        // being set up to wrap correctly according to the 
        // grid type. See BuildWorkGrid()
        private LifeCell[,] _workGrid = null;
        
        #endregion
    }
}
