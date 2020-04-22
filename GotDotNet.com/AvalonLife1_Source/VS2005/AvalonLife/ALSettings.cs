/* ****************************************************************************
 * AvalonLife 1.0
 * 
 * ALSettings.cs
 * 
 * Implements the ALSettings class, which provides strongly-typed access to
 * persistent application settings stored in an XML file. As to why I bothered
 * to write this rather than use ApplicationSettings, it was mostly a matter of
 * being in a hurry to get through this part, and running into some issues
 * with persisting settings that I didn't want to take the time to figure out.
 * Implementing a simple settings class that reads/writes to the app
 * directory was a snap, so I just did that.
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
using System.Windows;
using System.Windows.Media;
using System.IO;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace AvalonLife
{
    class ALSettings: INotifyPropertyChanged
    {
        protected ALSettings()
        {
            Stream str = null;
            SoapFormatter formatter = new SoapFormatter();
            try
            {
                str = File.OpenRead(Properties.Resources.Sys_DefConfigFileName);
                _settings = formatter.Deserialize(str) as OrderedDictionary;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Properties.Resources.UI_MB_SettingsLoadFailedMsg + ex.Message,
                     Properties.Resources.UI_MB_SettingsLoadFailedCaption,
                     MessageBoxButton.OK, MessageBoxImage.Information);
                SetDefaults();
            }
            finally
            {
                if ( str != null )
                    str.Close();
            }
        }
        
        public void Save()
        {
            Stream str = null;
            SoapFormatter formatter = new SoapFormatter();
            try
            {
                str = File.OpenWrite(Properties.Resources.Sys_DefConfigFileName);
                formatter.Serialize(str, _settings);
                _changed = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(Properties.Resources.UI_MB_SettingsFailedMsg + " " + ex.Message,
                     Properties.Resources.UI_MB_SettingsFailedCaption,
                     MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if ( str != null )
                    str.Close();
            }
        }
        
        public void SetDefaults()
        {
            _settings = new OrderedDictionary();
            
            _settings.Add("GridH", "50");
            _settings.Add("GridW", "50");
            _settings.Add("TimerInterval", "1000");
            _settings.Add("ReticleOn", "true");
            _settings.Add("GridOn", "false");
            _settings.Add("GridBackground", "White");
            _settings.Add("CellBrushType", "linear");
            _settings.Add("CellBrushC1", "#FF86C7EE");
            _settings.Add("CellBrushC1Off", "0.2");
            _settings.Add("CellBrushC2", "#FF5E9FE8");
            _settings.Add("CellBrushC2Off", "0.4");
            _settings.Add("CellBrushC3", "#FF1E70AC");
            _settings.Add("CellBrushC3Off", "0.9");
            _settings.Add("ReticleColor", "Gray");
            _settings.Add("ShrinkGridToModel", "false");
            _settings.Add("DefaultGridType", "Finite");
            _settings.Add("HaltOnStability", "true");
            
            _changed = true;
        }
        
        public int GridHeight
        {
            get
            {
                return Convert.ToInt32(_settings["GridH"]);
            }
            set
            {
                _settings["GridH"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GridHeight"));
                _changed = true;
            }
        }

        public int GridWidth
        {
            get
            {
                return Convert.ToInt32(_settings["GridW"]);
            }
            set
            {
                _settings["GridW"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GridWidth"));
                _changed = true;
            }
        }

        public int TimerInterval
        {
            get
            {
                return Convert.ToInt32(_settings["TimerInterval"]);
            }
            set
            {
                _settings["TimerInterval"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TimerInterval"));
                _changed = true;
            }
        }

        public bool ReticleOn
        {
            get
            {
                return Convert.ToBoolean(_settings["ReticleOn"]);
            }
            set
            {
                _settings["ReticleOn"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ReticleOn"));
                _changed = true;
            }
        }

        public bool GridOn
        {
            get
            {
                return Convert.ToBoolean(_settings["GridOn"]);
            }
            set
            {
                _settings["GridOn"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GridOn"));
                _changed = true;
            }
        }

        public Color GridBackground
        {
            get
            {
                return (Color)ColorConverter.ConvertFromString(_settings["GridBackground"].ToString());
            }
            set
            {
                _settings["GridBackground"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GridBackground"));
                _changed = true;
            }
        }

        public CellBrushType LifeCellBrushType
        {
            get
            {
                string bt = _settings["CellBrushType"].ToString() ;
                if ( string.Compare(bt, "radial", true) == 0 )
                    return CellBrushType.Radial;
                else if (string.Compare(bt, "linear", true) == 0)
                    return CellBrushType.Linear;
                else if (string.Compare(bt, "solid", true) == 0)
                    return CellBrushType.Solid;
                else
                    return CellBrushType.Solid;
            }
            set
            {
                switch( value )
                {
                    case CellBrushType.Radial:
                        _settings["CellBrushType"] = "radial";
                        break;
                    case CellBrushType.Linear:
                        _settings["CellBrushType"] = "linear";
                        break;
                    case CellBrushType.Solid:
                        _settings["CellBrushType"] = "solid";
                        break;
                }
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LifeCellBrushType"));
                _changed = true;
            }
        }

        public Color CellBrushC1
        {
            get
            {
                return (Color)ColorConverter.ConvertFromString(_settings["CellBrushC1"].ToString());
            }
            set
            {
                _settings["CellBrushC1"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellBrushC1"));
                _changed = true;
            }
        }

        public double CellBrushC1Off
        {
            get
            {
                return Convert.ToDouble(_settings["CellBrushC1Off"]);
            }
            set
            {
                _settings["CellBrushC1Off"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellBrushC1Off"));
                _changed = true;
            }
        }

        public Color CellBrushC2
        {
            get
            {
                return (Color)ColorConverter.ConvertFromString(_settings["CellBrushC2"].ToString());
            }
            set
            {
                _settings["CellBrushC2"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellBrushC2"));
                _changed = true;
            }
        }

        public double CellBrushC2Off
        {
            get
            {
                return Convert.ToDouble(_settings["CellBrushC2Off"]);
            }
            set
            {
                _settings["CellBrushC2Off"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellBrushC2Off"));
                _changed = true;
            }
        }

        public Color CellBrushC3
        {
            get
            {
                return (Color)ColorConverter.ConvertFromString(_settings["CellBrushC3"].ToString());
            }
            set
            {
                _settings["CellBrushC3"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellBrushC3"));
                _changed = true;
            }
        }

        public double CellBrushC3Off
        {
            get
            {
                return Convert.ToDouble(_settings["CellBrushC3Off"]);
            }
            set
            {
                _settings["CellBrushC3Off"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CellBrushC3Off"));
                _changed = true;
            }
        }

        public Color ReticleColor
        {
            get
            {
                return (Color)ColorConverter.ConvertFromString(_settings["ReticleColor"].ToString());
            }
            set
            {
                _settings["ReticleColor"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ReticleColor"));
                _changed = true;
            }
        }

        public bool ShrinkGridToModel
        {
            get
            {
                return Convert.ToBoolean(_settings["ShrinkGridToModel"]);
            }
            set
            {
                _settings["ShrinkGridToModel"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ShrinkGridToModel"));
                _changed = true;
            }
        }

        public GridType DefaultGridType
        {
            get
            {
                string strGridType = _settings["DefaultGridType"].ToString();
                GridType gt = GridType.Finite;
                
                if (string.Compare(strGridType, "Torus", true) == 0)
                    gt = GridType.Torus;
                else if (string.Compare(strGridType, "XCylinder", true) == 0)
                    gt = GridType.XCylinder;
                else if (string.Compare(strGridType, "YCylinder", true) == 0)
                    gt = GridType.YCylinder;

                return gt; 
            }
            set
            {
                if ( value == GridType.Finite )
                    _settings["DefaultGridType"] = "Finite";
                else if (value == GridType.Torus)
                    _settings["DefaultGridType"] = "Torus";
                else if (value == GridType.XCylinder)
                    _settings["DefaultGridType"] = "XCylinder";
                else if (value == GridType.YCylinder)
                    _settings["DefaultGridType"] = "YCylinder";

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DefaultGridType"));
                _changed = true;
            }
        }

        public bool HaltOnStability
        {
            get
            {
                return Convert.ToBoolean(_settings["HaltOnStability"]);
            }
            set
            {
                _settings["HaltOnStability"] = value.ToString();
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HaltOnStability"));
                _changed = true;
            }
        }

        private bool _changed = false;
        public bool Changed
        {
            get
            {
                return _changed;
            }
        }
        
        private static ALSettings _default = null; 
        public static ALSettings Default
        {
            get
            {
                if ( _default == null )
                    _default = new ALSettings();
                return _default;
            }
        
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 
        
        private OrderedDictionary _settings = null;
    }
}
