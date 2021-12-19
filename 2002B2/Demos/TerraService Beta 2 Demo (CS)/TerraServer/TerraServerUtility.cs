// Copyright (C) Microsoft Corporation.  All Rights reserved.
// TerraServerUtility.cs
//

namespace TerraServer 
{

    using System;
	using System.Configuration;
    using System.Diagnostics;
	using GeoCoordinate;
	/// <summary>
	/// TerraServerUtility class.  Intended for internal use by the TerraServer and TerraConnection classes.
	/// </summary>
    public sealed class TerraServerUtility {

        private TerraServerUtility() {
        }
		/// <summary>
		/// Obtain the connection string of the Primary database for the specified/requested partition.
		/// </summary>
		/// <param name="partition">Partition identifier of the primary database to connect to.</param>
		/// <returns>Database connection string of the Primary partition.</returns>
        public static string PrimaryPartition(int partition) {
			string s;
			switch (partition) {
				case 0:
					s = ConfigurationSettings.AppSettings["PrimaryPartition0"];
					break;
				case 1:
					s = ConfigurationSettings.AppSettings["PrimaryPartition1"];
					break;
				case 2:
					s = ConfigurationSettings.AppSettings["PrimaryPartition2"];
					break;
				case 3:
					s = ConfigurationSettings.AppSettings["PrimaryPartition3"];
					break;
				default:
					s = ConfigurationSettings.AppSettings["PrimaryPartition0"];
					break;
			}
			return(s);
        }
		/// <summary>
		/// Obtains the connection string of the secondary database server for the specified partition id.
		/// </summary>
		/// <param name="partition">Partition identifier of the secondary database.</param>
		/// <returns>Database connection string.</returns>
        public static string SecondaryPartition(int partition) {
			string s;
			switch (partition) {
				case 0:
					s = ConfigurationSettings.AppSettings["SecondaryPartition0"];
					break;
				case 1:
					s = ConfigurationSettings.AppSettings["SecondaryPartition1"];
					break;
				case 2:
					s = ConfigurationSettings.AppSettings["SecondaryPartition2"];
					break;
				case 3:
					s = ConfigurationSettings.AppSettings["SecondaryPartition3"];
					break;
				default:
					s = ConfigurationSettings.AppSettings["SecondaryPartition0"];
					break;
			}
			return(s);
        }
		/// <summary>
		/// Verifies that the Theme enum value is correct.
		/// </summary>
		/// <param name="theme">Theme enum value to validate.</param>
		/// <exception cref="ArgumentException">Is thrown if the theme enum does not identify a valid theme in the TerraServer database.</exception>
        public static void ValidateTheme(Theme theme) {
			if(!Enum.IsDefined(typeof(Theme), theme))
				throw new ArgumentException(string.Format("Theme {0} out of range", theme));
        }
		/// <summary>
		/// Verifies that the scale exists in the TerraServer database for the specified theme.  Calls ValidateTheme() to verify the Theme.
		/// </summary>
		/// <param name="theme">Theme enum to validate.</param>
		/// <param name="scale">Scale enum to validate.</param>
		/// <exception cref="ArgumentException">Thrown if the specified Scale is not maintained for the specified Theme.</exception>
        public static void ValidateScale(Theme theme, Scale scale) {
			ValidateTheme(theme);

			if(!Enum.IsDefined(typeof(Scale), scale)) {
				throw new ArgumentException(string.Format("Scale {0} out of range", scale));
			}
			else {
				switch (theme) {
					case Theme.Photo:
						if (((int)scale < 10) || ((int)scale > 16))
							throw new ArgumentException(string.Format("Theme 1 (DOQ) Scale {0} invalid, valid values are 10 thru 16", scale));
						break;
					case Theme.Topo:
						if (((int)scale < 11) || ((int)scale > 21))
							throw new ArgumentException(string.Format("Theme 2 (DRG) Scene {0} invalid, valid values are 11 thru 21", scale));
						break;
					case Theme.Relief:
						if (((int)scale < 20) || ((int)scale > 24))
							throw new ArgumentException(string.Format("Theme 4 (Relief) Scene {0} invalid, valid value are 20 thru 24", scale));
						break;
				}
			}
        }
		/// <summary>
		/// Validates the scene for the specified theme.  First calls ValidateTheme() to verify the theme enum.
		/// </summary>
		/// <param name="theme"></param>
		/// <param name="scene"></param>
		/// <exception cref="ArgumentException">Is thrown if the Scene is not within range for the specified Theme.</exception>
        public static void ValidateScene(Theme theme, int scene) {
			ValidateTheme(theme);
			switch (theme) {
				case Theme.Photo:
					if ((scene < 1) || (scene > 60))
						throw new ArgumentException(string.Format("Theme 1 (DOQ) Scene {0} invalid, valid values are 5,6,10 thru 20",scene));
					break;
				case Theme.Topo:
					if ((scene < 1) || (scene > 60))
						throw new ArgumentException(string.Format("Theme 2 (DRG) Scene {0} invalid, valid values are 4,5,10 thru 19",scene));
					break;
				case Theme.Relief:
					if (scene != 0)
						throw new ArgumentException(string.Format("Theme 4 (Relief) Scene {0} invalid, valid value is 0",scene));
					break;
			}
        }
		/// <summary>
		/// Verifies that the specified Longitude and Latitude value is within range -180.0,-90.0 : 180.0,90.0
		/// </summary>
		/// <param name="point">Longitude/Latitude value to check.</param>
		/// <exception cref="ArgumentException">Thrown if longitude value is not between -180.0 and 180.0 and latitude is not between -90.0 and 90.0.</exception>
		public static void ValidateLonLatPt(LonLatPt point) {
			if((point.Lon < -180.0) || (point.Lon > 180.0)) {
				throw new ArgumentException(string.Format("Longitude {0} invalid, valid values range between -180.0 and 180.0", point.Lon));
			}
			if((point.Lat < -90.0) || (point.Lat > 90.0)) {
				throw new ArgumentException(string.Format("Latitude {0} invalid, valid values range between -90.0 and 90.0", point.Lat));
			}
		}
		/// <summary>
		/// Obtains the Primary Parition database connection string for the specified Theme and Scene value.
		/// </summary>
		/// <param name="theme">Data theme of the Partition to return</param>
		/// <param name="scene">Scene from the Theme of the Partition to return.</param>
		/// <returns>A Partition identifer</returns>
        public static string PrimaryConnection(Theme theme, int scene) {
			int partition;

			ValidateScene(theme, scene);
			switch (theme) {
				case Theme.Photo:
					switch (scene) {
						case 2:
						case 4:
						case 6:
						case 8:
						case 10:
						case 12:
						case 14:
						case 16:
						case 18:
						case 20:
							partition = 2;
							break;
						case 1:
						case 3:
						case 5:
						case 7:
						case 9:
						case 11:
						case 13:
						case 15:
						case 17:
						case 19:
							partition = 3;
							break;
						default:
							partition = 2;
							break;
					}
					break;
				default:
					partition = 1;
					break;
			}
			return(PrimaryPartition(partition));
        }
		/// <summary>
		/// Obtains the Secondary Parition database connection string for the specified Theme and Scene value.
		/// </summary>
		/// <param name="theme">The Data Theme to query.</param>
		/// <param name="scene">The Scene within the Theme to query.</param>
		/// <returns></returns>
        public static string SecondaryConnection(Theme theme, int scene) 
		{
			int partition;

			ValidateScene(theme, scene);
			switch (theme) {
				case Theme.Photo:
					switch (scene) {
						case 2:
						case 4:
						case 6:
						case 8:
						case 10:
						case 12:
						case 14:
						case 16:
						case 18:
						case 20:
						default:
							partition = 2;
							break;
						case 1:
						case 3:
						case 5:
						case 7:
						case 9:
						case 11:
						case 13:
						case 15:
						case 17:
						case 19:
							partition = 3;
							break;
					}
					break;
				default:
					partition = 1;
					break;
	        }
		    return(PrimaryPartition(partition));
        }
		/// <summary>
		/// Obtain the Primary Parition's database connection string using the Parition identifier value.
		/// </summary>
		/// <param name="partition">Parition identifier</param>
		/// <returns>Primary partition's database connection string</returns>
        public static string PrimaryConnection(int partition) {
			return(PrimaryPartition(partition));
        }
		/// <summary>
		/// Obtain the Secondary Partition's database connection string using the Parition identifier
		/// </summary>
		/// <param name="partition">Parition identifier</param>
		/// <returns>Secondary Parition's database connection string.</returns>
        public static string SecondaryConnection(int partition) {
			return(SecondaryPartition(partition));
        }
		/// <summary>
		/// Obtain the Primary Partition's database connection string using the Theme and Longitude only.
		/// </summary>
		/// <param name="theme">Data Theme to search for.</param>
		/// <param name="lon">The longitude value of the data to search for.</param>
		/// <returns></returns>
        public static string PrimaryConnection(Theme theme, Double lon) {
			Double	ZoneBoundary = -180.0;
			Int32	scene;

			for(scene = 1;scene < 61;scene++){
				ZoneBoundary += 6.0;
				if(lon <= ZoneBoundary)
					return(PrimaryConnection(theme, scene));
			}
			return(PrimaryConnection(theme, 1));
		}
		/// <summary>
		/// Obtain the Secondary Parition's database connection string given a theme and longitude value.
		/// </summary>
		/// <param name="theme">Data theme of the Partition</param>
		/// <param name="lon">Longitude value.</param>
		/// <returns>Database connection string of the Secondary Parition.</returns>
        public static string SecondaryConnection(Theme theme, Double lon) {
			Double	ZoneBoundary = -180.0;
			Int32	scene;

			for(scene = 1;scene < 61;scene++){
				ZoneBoundary += 6.0;
				if(lon <= ZoneBoundary)
					return(SecondaryConnection(theme, scene));
			}
			return(PrimaryConnection(theme, 1));
		}
		/// <summary>
		/// Obtain the Primary Partition's database connection string given a theme and longitude/latitude point.
		/// </summary>
		/// <param name="theme">Data theme of the Partition to return.</param>
		/// <param name="point">The longitude and latitude point.</param>
		/// <returns>Primary Partition's database connection string.</returns>
        public static string PrimaryConnection(Theme theme, LonLatPt point) {
			return(PrimaryConnection(theme, point.Lon));
		}
		/// <summary>
		/// Obtain the Secondary Partition's database connection string given a theme and longitude/latitude point.
		/// </summary>
		/// <param name="theme">Data theme of the Partition to return.</param>
		/// <param name="point">Longitude and latitude point.</param>
		/// <returns></returns>
        public static string SecondaryConnection(Theme theme, LonLatPt point) {
			return(SecondaryConnection(theme, point.Lon));
		}
	}
}
