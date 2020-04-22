/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * LifeSim.cs
 * 
 * Implements the AvalonLife simulation controller class.
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
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AvalonLife
{
    [Serializable]
    class LifeSim : INotifyPropertyChanged, ISerializable
    {
        #region LifeSim public interface
        /// <summary>
        /// LifeSim()
        /// 
        /// Constructs an instance of the sim controller and creates an empty model
        /// for it to run. LifeSim is in the paused state after construction, but the
        /// timer is running.
        /// </summary>
        /// <param name="lm"></param>
        public LifeSim()
        {
            _lm = new LifeModel();
            _timerInterval = ALSettings.Default.TimerInterval;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = _timerInterval;
            _timer.Tick += new EventHandler(TimerEvent);
            _timer.Tag = this;
            _timer.Start();
        }

        /// <summary>
        /// LifeSim(int, int)
        /// 
        /// Constructs an instance of the sim controller and creates an empty model
        /// for it to run, using the specified dimensions. LifeSim is in the paused
        /// state after construction, but the timer is running.
        /// </summary>
        /// <param name="rows">Height of the requested model grid</param>
        /// <param name="columns">Width of the requested model grid</param>
        public LifeSim(int rows, int columns)
        {
            _lm = new LifeModel(rows, columns);
            _timerInterval = ALSettings.Default.TimerInterval;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = _timerInterval;
            _timer.Tick += new EventHandler(TimerEvent);
            _timer.Tag = this;
            _timer.Start();
        }

        #region ISerializable methods
        
        /// <summary>
        /// LifeSim(SerializationInfo, StreamingContext)
        /// 
        /// Called by the BinaryFormatter to construct an instance of LifeSim from a
        /// stream. Deserializes the private members, then the LifeModel deserialization
        /// is called, and finally the timer is created and started. The sim is constructed
        /// in a paused state. The UI is responsible for wiring up events.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public LifeSim( SerializationInfo info, StreamingContext ctxt )
        {
            _generation = (int)info.GetValue( "_generation", typeof(int) );
            _timerInterval = (int)info.GetValue( "_timerInterval", typeof(int) );
            
            _lm = new LifeModel( info, ctxt );
            
            _isPaused = true;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = _timerInterval;
            _timer.Tick += new EventHandler(TimerEvent);
            _timer.Tag = this;
            _timer.Start();
        }
        
        /// <summary>
        /// GetObjectData(SerializationInfo, StreamingContext)
        /// 
        /// Called by the BinaryFormatter to serialize an instance of LifeSim. Serializes
        /// the private members and then calls the LifeModel serialization method directly.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public void GetObjectData( SerializationInfo info, StreamingContext ctxt )
        {
            info.AddValue( "_generation", _generation );
            info.AddValue( "_timerInterval", _timerInterval );
            
            _lm.GetObjectData( info, ctxt );
        }
        
        #endregion
        
        /// <summary>
        /// ~LifeSim()
        /// 
        /// I haven't verified it, but this is almost certainly unnecessary. The timer
        /// class dispose() should kill the timer and clean up. Anyway no harm done.
        /// </summary>
        ~LifeSim()
        {
            if ( _timer != null )
                _timer.Stop();
        }
        
        /// <summary>
        /// TimerEvent(Object, EventArgs)
        /// 
        /// This function handles the timer tick. If the game is in the unpaused state it calls
        /// the LifeModel.Evaluate() method to iterate the model. It then increments the
        /// generation count. It's a static method so we pass in the 'this' pointer for the
        /// LifeSim instance that owns the timer in its Tag property. Useful little things, Tags.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TimerEvent( Object sender, EventArgs e )
        {
            LifeSim ls = ((System.Windows.Forms.Timer)sender).Tag as LifeSim;
            if ( ls != null && !ls.IsPaused )
            {
               if ( !ls._lm.EvolutionHalted || ALSettings.Default.HaltOnStability == false )
               {
                   ls._lm.Evaluate();
                   ls.Generation++;
               }
               else 
               {
                   ls.IsPaused = true;
                   if (ls._uiCallback != null)
                   {    
                      ls._uiCallback();
                   }
               } 
            }
            else if ( ls == null )
                throw( new System.InvalidOperationException("TimerEvent") );
        }
        
        /// <summary>
        /// ResetSim()
        /// 
        /// Called from the UI to reset the simulation to its starting condition. On
        /// exit the simulation is paused.
        /// </summary>
        public void ResetSim()
        {
            if ( !_isPaused )
                IsPaused = true;
                
            Generation = 0;
            
            _lm.ResetModel();
        }
        
        /// <summary>
        /// NewModel()
        /// 
        /// Called from the UI during handling of a click on Game | New.
        /// </summary>
        public void NewModel()
        {
            if ( !_isPaused )
                _isPaused = true;

            _lm = new LifeModel();
            Generation = 0;
        }

        /// <summary>
        /// NewModel(int, int)
        /// 
        /// Called from the UI during handling of a click on Game | New. Creates a
        /// new model using the passed in dimensions.
        /// </summary>
        public void NewModel(int rows, int columns)
        {
            if (!_isPaused)
                _isPaused = true;

            _lm = new LifeModel(rows, columns);
            Generation = 0;
        }

        /// <summary>
        /// NewModel(Stream)
        /// 
        /// Called to decode a stream of .cells format data into a LifeModel. The bulk
        /// of the work is done in the LifeModel.LifeModel(Stream) constructor. If
        /// construction fails we will already have warned the user in the constructor,
        /// so all we do here is restore the paused state we had on entry.
        /// </summary>
        /// <param name="str">Stream containing the .cells formated data</param>
        /// <returns></returns>
        public bool NewModel( Stream str )
        {
            bool result = false;
            bool paused = _isPaused;

            _isPaused = true;
            
            try
            {
                LifeModel lm = new LifeModel( str );
                _lm = lm;
                Generation = 0;
                result = true;
            }
            catch( System.Exception )
            {
                _isPaused = paused;
            }    
            return result;
        }
                
        #endregion

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region LifeSim public properties
        /// <summary>
        /// Counts the generations that the current model has run
        /// </summary>
        private int _generation = 0;
        public int Generation
        {
            get
            {
                return _generation;
            }
            protected set
            {
                _generation = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Generation"));
            }
        }
        
        /// <summary>
        /// Holds a reference to the simulation model
        /// </summary>
        private LifeModel _lm = null;
        public LifeModel Model
        {
            get
            {
                return _lm;
            }
        }
        
        /// <summary>
        /// Holds the timer interval, set to default on start
        /// </summary>
        private int _timerInterval = 0;
        public int TimerInterval
        {
            get
            {
                return _timerInterval;
            }
            set
            {
                _timerInterval = value;
                _timer.Interval = _timerInterval;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TimerInterval"));
            }
        }
        
        /// <summary>
        /// Holds the simulation run state: false if running, true if paused. 
        /// </summary>
        private bool _isPaused = true;
        public bool IsPaused
        {
            get
            {
                return _isPaused;
            }
            set
            {
                _isPaused = value;
            }
        }

        /// <summary>
        /// The timer handler may detect that the model has ceased evolving,
        /// i.e. entered a stable state. In that case it will make a call to
        /// the function in this delegate to inform the UI. The UI is responsible
        /// for setting a function-typed value to this delegate member if it
        /// wants to receive this callback.
        /// </summary>
        public delegate void UISimStatusCallback();

        private UISimStatusCallback _uiCallback = null;
        public UISimStatusCallback UICallback
        {
            get
            {
                return _uiCallback;
            }
            set
            {
                _uiCallback = value;
            }
        }
        
        #endregion
        
        #region LifeSim private data
        
        private System.Windows.Forms.Timer _timer = null;
        
        #endregion
    }
}
