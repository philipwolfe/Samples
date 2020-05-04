#region Copyright MarketXS B.V. 2005

/* This code is distributed under the GNU Library General Public License.

http://www.gnu.org/copyleft/lgpl.html

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Library General Public
License as published by the Free Software Foundation; either
version 2 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Library General Public License for more details.

You should have received a copy of the GNU Library General Public
License along with this library; if not, write to the
Free Software Foundation, Inc., 59 Temple Place - Suite 330,
Boston, MA  02111-1307, USA.

Written by Zbigniew Babiej, zbabiej@yahoo.com.

*/

#endregion

#region Using directives

using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;

#endregion

namespace TZ4Net
{
	/// <summary>
	/// A TimeZone Implementation with Historical Changes and Leapseconds.
	/// Implementation of the local time zone conversion based on Olson database.
	/// This public-domain time zone database contains code and data that represent the history of local time 
	/// for many representative locations around the globe. It is updated periodically to reflect changes made 
	/// by political bodies to UTC offsets and daylight-saving rules. This database (often called tz or zoneinfo) 
	/// is used by several implementations, including the GNU C Library used in GNU/Linux, FreeBSD, NetBSD, 
	/// OpenBSD, Cygwin, DJGPP, HP-UX, IRIX, Mac OS X, OpenVMS, Solaris, Tru64, and UnixWare.
	/// As opposite to Win32/.NET API, it allows to perform convertion in arbitrary time zone
	///
	/// This is a C# translation of the Stuart D. Gathman's Java translation of the  
	/// Unix "tz" package (formerly known as "localtime"). tn provides reading /etc/zoneinfo files stored 
	/// as a resources and unix like functions such as localtime() - here GetLocalTime) and mktime() - here GetTime();
	/// See http://www.twinsun.com/tz/tz-link.htm and http://www.bmsi.com/java/#TZ for more details.
	/// It uses Jon Skeet's EndianBitConverter. See http://www.yoda.arachsys.com/csharp/miscutil/ for more details.
	/// </summary>
	public class ZoneInfo
	{
		#region Nested types

		/// <summary>
		/// Container for time local variables.
		/// </summary>
		internal class Time
		{
			/// <summary>
			/// Hour of day, 0 - 23.
			/// </summary>
			private int hour;
		
			/// <summary>
			/// Minute of hour, 0 - 59.
			/// </summary>
			private int min;
		
			/// <summary>
			/// Second of minute, 0 - 60.
			/// Note: that value may be 60 on a leap second. 
			/// </summary>
			private int sec;
		
			/// <summary>
			/// Day of week, 0 - 6, 0 = Sunday
			/// </summary>
			private int wday;
		
			/// <summary>
			/// Years since 1900.
			/// </summary>
			private int year;

			/// <summary>
			/// Day of year, 1 - 366.
			/// </summary>
			private int yday;

			/// <summary>
			/// Month of year, 0 - 11.
			/// </summary>
			private int mon;
		
			/// <summary>
			/// Day of month, 1 - 31.
			/// </summary>
			private int mday;

			/// <summary>
			/// True if time is DST.
			/// </summary>
			private bool isDst;

			/// <summary>
			/// Timezone name.
			/// </summary>
			private string zone;

			private const int SECSPERMIN	= 60;
			private const int MINSPERHOUR	= 60;
			private const int HOURSPERDAY	= 24;
			private const int DAYSPERWEEK	= 7;
			private const int SECSPERHOUR	= SECSPERMIN * MINSPERHOUR;
			private const int SECSPERDAY	= SECSPERHOUR * HOURSPERDAY;
			private const int SUNDAY	= 0;
			private const int MONDAY	= 1;
			private const int TUESDAY	= 2;
			private const int WEDNESDAY	= 3;
			private const int THURSDAY	= 4;
			private const int FRIDAY	= 5;
			private const int SATURDAY	= 6;
			private const int EPOCH_WDAY	= THURSDAY;
			private const int EPOCH_YEAR	= 1970;
			private const int DAYSADJ = 25203;	// days between 1900 & 1970
			private const int CENT_WDAY = EPOCH_WDAY - DAYSADJ % 7;

			#region Constructors

			/// <summary>
			/// Default constructor
			/// </summary>
			internal Time()
			{
			}

			/// <summary>
			/// Initialize a new tm object to calendar day and time offset.
			/// </summary>
			/// <param name="year">Years since 1900.</param>
			/// <param name="mon">Month 0-11</param>
			/// <param name="day">Day of month 1-31.</param>
			/// <param name="secs">Seconds in day.</param>
			internal Time(int year, int mon, int day, int secs) 
			{
				this.year = year;
				this.mon = mon;
				this.mday = day;
				SetSecs(secs);
			}

			/// <summary>
			/// Creates the "normalized" instance by making all the necessary calculations.
			/// </summary>
			/// <param name="year">Year.</param>
			/// <param name="mon">Month of year 1-12.</param>
			/// <param name="day">Day of month 1-31.</param>
			/// <param name="hour">Hour 0-23.</param>
			/// <param name="min">Minute 0-59.</param>
			/// <param name="sec">Second 0-60.</param>
			/// <returns></returns>
			public static Time Create(int year, int mon, int day, int hour, int min, int sec) 
			{
				if (year < 1901 || year > 2038) 
				{
					throw new System.ArgumentOutOfRangeException("year", year, "Value must be in range 1901-2038");
				}
				if (mon < 1 || mon > 12) 
				{
					throw new System.ArgumentOutOfRangeException("mon", mon, "Value must be in range 1-12");
				}
				if (day < 1 || day > 31) 
				{
					throw new System.ArgumentOutOfRangeException("day", day, "Value must be in range 1-31");
				}
				if (hour < 0 || hour > 23) 
				{
					throw new System.ArgumentOutOfRangeException("hour", hour, "Value must be in range 0-23");
				}
				if (min < 0 || min > 59) 
				{
					throw new System.ArgumentOutOfRangeException("min", min, "Value must be in range 0-59");
				}
				if (sec < 0 || sec > 60) 
				{
					throw new System.ArgumentOutOfRangeException("sec", sec, "Value must be in range 0-60");
				}

				Time t	= new Time();
				t.Year	= checked(year - 1900);
				t.Mon	= checked(mon - 1);
				t.MDay	= day;
				t.Hour	= hour;
				t.Min	= min;
				t.Sec	= sec;

				return t;
			}

			#endregion

			/// <summary>
			/// String representation of the object.
			/// </summary>
			/// <returns><see cref="string"></see> representation of the object.</returns>
			public override string ToString()
			{
				return string.Format("{0}/{1}/{2} {3}:{4}:{5} {6}", mon + 1, mday, year + 1900, hour, min, sec, zone == null ? "null" : zone);
			}

			/// <summary>
			/// Determines whether the specified object is equal to the current object.
			/// </summary>
			/// <param name="obj">Object instance to compare to.</param>
			/// <returns><see cref="bool"></see> value indicating if both objects are equal.</returns>
			public override bool Equals(object obj) 
			{
				if (obj == null || !obj.GetType().IsSubclassOf(this.GetType())) 
				{ 
					return false;
				}
				return CompareTo((Time)obj) == 0;
			}

			/// <summary>
			/// Types that override Equals must also override GetHashCode.
			/// </summary>
			/// <returns>Hashcode of the instance.</returns>
			public override int GetHashCode() 
			{
				return (year << 24) + (mon << 20) + (mday << 15) + (hour << 10) + (min << 5) + sec;
			}

			/// <summary>
			/// Set the local time fields from a clock and GMT offset.
			/// </summary>
			/// <param name="clock">Seconds since 1970</param>
			/// <param name="offset">Offset from UT in seconds</param>
			public void SetClock(long clock, int offset) 
			{
				int days = (int)(clock / SECSPERDAY);
				int secs = (int)(clock % SECSPERDAY);
				secs += offset;
				while (secs < 0) 
				{
					secs += SECSPERDAY;
					days--;
				}
				while (secs >= SECSPERDAY) 
				{
					secs -= SECSPERDAY;
					days++;
				}
      
				SetSecs(secs);
      
				int doc = days + DAYSADJ;
				wday = (CENT_WDAY + doc) % DAYSPERWEEK;

				// now compute date from days since EPOCH
				int leapyear = 2;								// not leapyear adj = 2 
				// 1461 days in 4 years 
				year = (doc - doc/1461 + 364) / 365;			// calculate year 
				yday = doc - ((year - 1) * 1461) / 4;			// day of year conversion 
				if (year % 4 == 0)								// is this a leapyear? 
				{							
					leapyear = 1;								// yes - reset adj to 1 
				}
				if (yday > 59 && (yday > 60 || leapyear == 2)) 
				{
					yday += leapyear;							// correct for leapyear 
				}

				mon = (269 + yday * 9) / 275;					// calculate month 
				mday = yday + 30 - 275 * mon / 9;				// calc day of month 
				mon--;											// unix convention
			}


			/// <summary>
			/// Hour of day, 0 - 23.
			/// </summary>
			public int Hour 
			{
				get 
				{
					return hour;
				}
				set 
				{
					hour = value;
				}
			}
		
			/// <summary>
			/// Minute of hour, 0 - 59.
			/// </summary>
			public int Min 
			{
				get 
				{
					return min;
				}
				set 
				{
					min = value;
				}
			}

			/// <summary>
			/// Second of minute, 0 - 60.
			/// Note: that value may be 60 on a leap second. 
			/// </summary>
			public int Sec 
			{
				get 
				{
					return sec;
				}
				set 
				{
					sec = value;
				}
			}
		
			/// <summary>
			/// Day of week, 0 - 6, 0 = Sunday
			/// </summary>
			public int WDay 
			{
				get 
				{
					return wday;
				}
				set 
				{
					wday = value;
				}
			}
	
			/// <summary>
			/// Years since 1900.
			/// </summary>
			public int Year 
			{
				get 
				{
					return year;
				}
				set 
				{
					year = value;
				}
			}

			/// <summary>
			/// Day of year, 1 - 366.
			/// </summary>
			public int YDay 
			{
				get 
				{
					return yday;
				}
				set 
				{
					yday = value;
				}
			}

			/// <summary>
			/// Month of year, 0 - 11.
			/// </summary>
			public int Mon 
			{
				get 
				{
					return mon;
				}
				set 
				{
					mon = value;
				}
			}
		
			/// <summary>
			/// Day of month, 1 - 31.
			/// </summary>
			public int MDay 
			{
				get 
				{
					return mday;
				}
				set 
				{
					mday = value;
				}
			}

			/// <summary>
			/// True if time is DST.
			/// </summary>
			public bool IsDst
			{
				get 
				{
					return isDst;
				}
				set 
				{
					isDst = value;
				}
			}

			/// <summary>
			/// Timezone name.
			/// </summary>
			public string Zone 
			{
				get 
				{
					return zone;
				}
				set 
				{
					zone = value;
				}
			}

			/// <summary>
			/// Compares to other instance of <see cref="LocalTime"></see> object.
			/// </summary>
			/// <param name="t">Instance to compare current object to.</param>
			/// <returns>-1, 0 or 1 indicating the comparison result.</returns>
			public int CompareTo(Time time) 
			{
				if (year != time.year) 
				{
					return year - time.year;
				}
				if (mon != time.mon) 
				{
					return mon - time.mon;
				}
				if (mday != time.mday) 
				{
					return mday - time.mday;
				}
				if (hour != time.hour) 
				{
					return hour - time.hour;
				}
				if (min != time.min) 
				{
					return min - time.min;
				}
				return sec - time.sec;
			}

			#region Implementation

			/// <summary>
			/// Calculates time values from the number of seconds.
			/// </summary>
			/// <param name="secs">Number of seconds.</param>
			private void SetSecs(int secs) 
			{
				hour = secs / SECSPERHOUR;
				int rem = secs % SECSPERHOUR;
				min =  rem / SECSPERMIN;
				sec = rem % SECSPERMIN;
			}

			#endregion
		}

		/// <summary>
		/// Summary description for TimeZoneType.
		/// </summary>
		internal class TimeZoneType
		{
			#region Fields

			/// <summary>
			/// Offset from GMT in seconds. 
			/// </summary>
			private readonly int offset;

			/// <summary>
			/// Name of type. 
			/// </summary>
			private readonly string name;

			/// <summary>
			/// True if daylight savings time. 
			/// </summary>
			private readonly bool isDst;

			#endregion

			#region Constructors

			/// <summary>
			/// Creates the instance from name, offset and the DST flag.
			/// </summary>
			/// <param name="name">Name of the zone.</param>
			/// <param name="offset">Offset of the zone.</param>
			/// <param name="isDST">Flag indicating if this is DST zone.</param>
			internal TimeZoneType(string name, int offset, bool isDst) 
			{
				this.name = name;
				this.offset = offset;
				this.isDst = isDst;
			}

			#endregion

			#region Public interface

			/// <summary>
			/// Gets the offset of the zone.
			/// </summary>
			public int Offset 
			{
				get 
				{
					return offset;
				}
			}

			/// <summary>
			/// Gets the name of type. 
			/// </summary>
			public string Name 
			{
				get 
				{
					return name;
				}
			}

			/// <summary>
			/// Gets the True if daylight savings time. 
			/// </summary>
			public bool IsDST 
			{
				get 
				{
					return isDst;
				}
			}

			/// <summary>
			/// Converts the instance to a string.
			/// </summary>
			/// <returns>String representation of the instance.</returns>
			public override string ToString() 
			{
				return string.Format("Type: {0} Offset: {1} DST: {2}", name, offset, isDst);
			}

			#endregion
		}

		#endregion

		#region Fields

		/// <summary>
		/// Transition times.
		/// </summary>
		private int[] transTimes;

		/// <summary>
		/// Timezone description for each transition.
		/// </summary>
		private byte[] transTypes;

		/// <summary>
		/// Timezone descriptions.
		/// </summary>
		private TimeZoneType[] tz;
		
		/// <summary>
		/// Leapseconds.
		/// </summary>
		private int[] leapSecs;

		/// <summary>
		/// Raw offset.
		/// </summary>
		private int rawOff;

		/// <summary>
		/// Normal timezone.
		/// </summary>
		private TimeZoneType normalTz;

		/// <summary>
		/// Constants denoting number of seconds per 3 months.
		/// </summary>
		private const long secsPerThreeMonths = 60*60*24*30*3;

		/// <summary>
		/// Caches the id of this time zone.
		/// </summary>
		private string id;

		/// <summary>
		/// Caches the name of this time zone passed in constructor.
		/// </summary>
		private string name;

		/// <summary>
		/// Caches the base name of the TZ database resource.
		/// </summary>
		private const string baseName = "zoneinfo";

		/// <summary>
		/// Caches the resource file name of the TZ database resource, like MyResource.resources.
		/// </summary>
		private static readonly string resFileName = string.Format("{0}.resources", baseName);

		/// <summary>
		/// Root name of the TZ database resource, like MyAssembly.MyResource.
		/// </summary>
		private static readonly string resRootName = string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Name, baseName);

		/// <summary>
		/// Manifest name of the TZ database resource, like MyAssembly.MyResource.resources
		/// </summary>
		private static readonly string resManifestName = string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Name, resFileName);

		#endregion

		#region Constructors

		/// <summary>
		/// Constructs the instance of the time zone from the given name.
		/// </summary>
		/// <param name="ID">TZ name of time zone.</param>
		public ZoneInfo(string name)
		{
			if (name == null) 
			{
				throw new System.ArgumentNullException("name", "Value can not be null.");
			}
			if (name.Length == 0) 
			{
				throw new System.ArgumentException("Value can not be empty.", "name");
			}

			ResourceManager resourceManager = new ResourceManager(resRootName, Assembly.GetExecutingAssembly());
			byte[] resource = (byte[])resourceManager.GetObject(name);
			if (resource == null) 
			{
				throw new System.ArgumentException("Zone name {0} not found in the database.", name);			
			}

			EndianBinaryReader reader = new EndianBinaryReader(EndianBitConverter.Big, new BufferedStream(new MemoryStream(resource, false)));

			try 
			{
				// read header
				reader.Seek(28, SeekOrigin.Begin);
				int leapCnt = reader.ReadInt32();
				int timeCnt = reader.ReadInt32();
				int typeCnt = reader.ReadInt32();
				int charCnt = reader.ReadInt32();

				// load DST transition data
				transTimes = new int[timeCnt];
				for (int i = 0; i < timeCnt; i++) 
				{
					transTimes[i] = reader.ReadInt32();
				}
				transTypes = new byte[timeCnt];
				reader.Read(transTypes, 0, timeCnt);

				// load TZ type data
				int[] offset = new int[typeCnt];
				byte[] dst = new byte[typeCnt];
				byte[] idx = new byte[typeCnt];
				for (int i = 0; i < typeCnt; i++) 
				{
					offset[i] = reader.ReadInt32();
					dst[i] = reader.ReadByte();
					idx[i] = reader.ReadByte();
				}
				byte[] str = new byte[charCnt];
				reader.Read(str, 0, charCnt);

				// convert type data
				tz = new TimeZoneType[typeCnt];
				for (int i = 0; i < typeCnt; i++) 
				{
					// find string
					int pos = idx[i];
					int end = pos;
					while (str[end] != 0) end++;
					char[] chars = new char[end - pos];
					int decodedChars = Encoding.ASCII.GetDecoder().GetChars(str, pos, end - pos, chars, 0);
					System.Diagnostics.Debug.Assert(decodedChars == end - pos, "Unexpected number of decoded characters.");
					tz[i] = new TimeZoneType(new string(chars), offset[i], dst[i] != 0);
				}

				// load leap seconds table
				leapSecs = new int[leapCnt * 2];
				for (int i = 0; leapCnt > 0; leapCnt--) 
				{
					leapSecs[i++] = reader.ReadInt32();
					leapSecs[i++] = reader.ReadInt32();
				}
			} 
			finally 
			{
				reader.Close();
			}

			// Set default timezone (normaltz).
			// First, set default to first non-DST rule.
			int n = 0;
			while (tz[n].IsDST && n < tz.Length) 
			{
				n++;
			}
			normalTz = tz[n];

			// When setting "normaltz" (the default timezone) in the constructor,
			// we originally took the first non-DST rule for the current TZ.
			// But this produces nonsensical results for areas where historical
			// non-integer time zones were used, e.g. if GMT-2:33 was used until 1918.

			// This loop, based on a suggestion by Ophir Bleibergh, tries to find a
			// non-DST rule close to the current time. This is somewhat of a hack, but
			// much better than the previous behavior in this case.

			// Tricky: we need to get either the next or previous non-dst TZ
			// We shall take the future non-dst value, by trying to add 3 months at a
			// time to the current date and searching.
			long ts = (long)System.DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
			for (int i = 0; i < 9; i++) 
			{
				TimeZoneType currTz = GetTimeZoneType(ts + secsPerThreeMonths * i);
				if (!currTz.IsDST) 
				{
					normalTz = currTz;
					break;
				}
			}
			id = normalTz.Name;
			this.name = name;
		}

		#endregion

		#region Implementation

		/// <summary>
		/// Gets the base name of the zoneinfo database.
		/// </summary>
		internal static string BaseName
		{
			get 
			{
				return baseName;
			}
		}

		/// <summary>
		/// Gets the resource file name of the zoneinfo database.
		/// </summary>
		internal static string ResourceFileName
		{
			get 
			{
				return resFileName;
			}
		}

		/// <summary>
		/// Lookup which timezone a given instant should use.
		/// </summary>
		/// <param name="clock">
		/// Unix time clock i.e number of seconds since epoch.
		/// </param>
		/// <returns>
		/// Instance of <see cref="TimeZoneType"></see> object representing the time zone
		/// to be used for a given time clock;
		/// </returns>
		internal TimeZoneType GetTimeZoneType(long clock) 
		{
			// FIXME: use binary search
			if (transTimes.Length > 0 && clock >= transTimes[0]) 
			{
				int i = 1;
				for (; i < transTimes.Length; i++) 
				{
					if (clock < transTimes[i]) 
					{
						break;
					}
				}
				return this.tz[transTypes[i - 1]];
			}
			return normalTz;
		}

		/// <summary>
		/// Computes <see cref="Time"/> properties from clock with leapsecond correction.
		/// </summary>
		/// <param name="clock">Seconds since 1970.</param>
		/// <param name="tz">Time zone.</param>
		/// <param name="t">Local time properties to set.</param>
		/// <returns>The offset from GMT including timezone, DST, and leap seconds.</returns>
		internal int TimeSub(long clock, TimeZoneType tz, Time t) 
		{
			bool hit = false;
			int offset = (tz == null) ? 0 : tz.Offset;

			for (int y = leapSecs.Length; (y -= 2) >= 0; ) 
			{
				int lsTrans = leapSecs[y];
				int lsCorr = leapSecs[y + 1];
				if (clock >= lsTrans) 
				{
					if (clock == lsTrans) 
					{
						hit = ((y == 0 && lsCorr > 0) || lsCorr > leapSecs[ y - 1]);
					}
					offset -= lsCorr;
					break;
				}
			}

			t.SetClock(clock, offset);

			// A positive leap second requires a special
			// representation.  This uses "... ??:59:60".
			if (hit) 
			{
				t.Sec += 1;
			}

			if (tz != null) 
			{
				t.IsDst = tz.IsDST;
				t.Zone = tz.Name;
			}
			else 
			{
				t.IsDst = false;
				t.Zone = "UTC";
			}

			return offset;
		}


		/// <summary>
		/// Compute local time from seconds since the epoch, storing into an existing Time object.
		/// </summary>
		/// <param name="clock">Seconds since 1970.</param>
		/// <param name="t">Time instance to store the computed time fields.</param>
		/// <returns>Offset of the local time from UT.</returns>
		internal int GetLocalTime(long clock, Time t) 
		{
			return TimeSub(clock, GetTimeZoneType(clock), t);
		}


		/// <summary>
		/// Calculates local time from seconds since the epoch.
		/// </summary>
		/// <param name="clock">seconds since 1970.</param>
		/// <returns>Local time instance.</returns>
		internal Time GetLocalTime(long clock) 
		{
			Time t = new Time();
			GetLocalTime(clock, t);
			return t;
		}


		/// <summary>
		/// Compute UT from clock.  This does not include leap second corrections.
		/// </summary>
		/// <param name="clock">Seconds since 1970.</param>
		/// <returns>New <see cref="Time"/> object with all time fields computed.</returns>
		internal static Time GetGMTime(long clock) 
		{
			Time t = new Time();
			t.SetClock(clock, 0);
			t.Zone = "GMT";
			return t;
		}


		/// <summary>
		/// Compute UTC from clock.  This includes leap second corrections if
		/// compiled into the current timezone file.
		/// </summary>
		/// <param name="clock">Clock seconds since 1970.</param>
		/// <returns>New <see cref="Time"/> object with all time fields computed.</returns>
		internal Time GetUtcTime(long clock) 
		{
			Time t = new Time();
			TimeSub(clock, null, t);
			return t;
		}


		/// <summary>
		/// Calculates seconds since the epoch, the reverse of GetLocalTime(). 
		/// Unused fields are computed and stored in yourTime.
		/// </summary>
		/// <param name="yourtm"> The Year, Mon, MDay, Hour, Min, Sec fields are used and validated. Other fields are computed.</param>
		/// <returns>Seconds since the epoch.</returns>
		internal long GetTime(Time yourTime) 
		{
			return GetTime(yourTime, false);
		}


		/// <summary>
		/// Calculates seconds since the epoch, the reverse of GetLocalTime().
		/// Unused fields are computed and stored in yourTime.
		/// </summary>
		/// <param name="yourtm"> The Year, Mon, MDay, Hour, Min, Sec fields are used and validated. 
		/// Other fields are computed.</param>
		/// <param name="raw">Flag indicating wether the offset is unmodified i.e not modified in 
		/// case of daylight savings.</param>
		/// <returns>Seconds since the epoch.</returns>
		internal long GetTime(Time yourTime, bool raw) 
		{
			int t = 0;
			int bits = 31;
			int offset = RawOffset / 1000;
			Time myTime = new Time();
			// use binary search
			// FIXME: make smarter initial guess?
			for (;;) 
			{
				if (raw) 
				{
					//TimeSub(t, tz, myTime);
					myTime.SetClock(t, offset);
				}
				else 
				{
					GetLocalTime(t, myTime);
				}

				int direction = myTime.CompareTo(yourTime);
				if (direction == 0) 
				{
					yourTime.WDay	= myTime.WDay;
					yourTime.YDay	= myTime.YDay;
					yourTime.IsDst	= myTime.IsDst;
					yourTime.Zone	= myTime.Zone;

					return t;
				}
				//System.Console.WriteLine(myTime.ToString() + ", " + t + ", " + direction);
				if (bits-- < 0) 
				{
					throw new ArgumentException(string.Format("Bad time: {0}", yourTime));
				}
				if (bits < 0) 
				{
					t--;
				}
				else if (direction > 0) 
				{
					t -=  1 << bits;
				}
				else 
				{
					t +=  1 << bits;
				}
			}
		}


		/// <summary>
		/// Return the offset of this time zone from UTC for a calendar date and time.
		/// The calendar time we are passed is always computed using <see cref="RawOffset"></see>.
		/// </summary>
		/// <param name="era">The era of the given date.</param>
		/// <param name="year">The year in the given date.</param>
		/// <param name="month"> the month in the given date. Month is 0-based. e.g., 0 for January.</param>
		/// <param name="day">The day-in-month of the given date.</param>
		/// <param name="dow">The day-of-week of the given date.</param>
		/// <param name="millis">The milliseconds in day in standard local time.</param>
		/// <returns>The offset in milliseconds to add to UTC to get local time.</returns>
		internal int GetOffset(int era, int year, int month, int day, int dow, int millis) 
		{
			if (era != GregorianCalendar.ADEra)  
			{
				return RawOffset;
			}
			int secs = millis / 1000;
			Time then = new Time(checked(year - 1900), month, day, secs);
			long ts;

			try 
			{
				ts = GetTime(then, true);
			}
			catch (ArgumentException) 
			{
				// outside the range of GetTime()
				return RawOffset;
			}

			int offset = GetTimeZoneType(ts).Offset;

			for (int y = leapSecs.Length; (y -= 2) >= 0; ) 
			{
				int lsTrans = leapSecs[y];
				int lsCorr = leapSecs[y + 1];
				if (ts >= lsTrans) 
				{
					offset -= lsCorr;
					break;
				}
			}

			return offset * 1000 + rawOff;
		}


		/// <summary>
		/// Converts <see cref="ZoneInfo.tm"></see> value to <see cref="DateTime"></see> value.
		/// </summary>
		/// <param name="tm">
		/// <see cref="ZoneInfo.tm"></see> value;
		/// </param>
		/// <returns>
		/// Corresponding <see cref="DateTime"></see> value;
		/// </returns>
		internal static DateTime TimeToDateTime(Time t) 
		{
			return new DateTime(t.Year + 1900, t.Mon + 1, t.MDay, t.Hour, t.Min, t.Sec);
		}


		/// <summary>
		/// Converts <see cref="DateTime"></see> value to <see cref="ZoneInfo.tm"></see> value.
		/// </summary>
		/// <param name="dt">
		/// <see cref="DateTime"></see> value;
		/// </param>
		/// <returns>
		/// Corresponding <see cref="ZoneInfo.tm"></see> value;
		/// </returns>
		internal static Time DateTimeToTime(DateTime dt) 
		{
			Time t = new Time();
			t.Year	= dt.Year - 1900;
			t.Mon	= dt.Month - 1;
			t.MDay	= dt.Day;
			t.Hour	= dt.Hour;
			t.Min	= dt.Minute;
			t.Sec	= dt.Second;

			return t;
		}

		#endregion

		#region Public interface

		/// <summary>
		/// Gets the name of this time zone.
		/// </summary>
		public string Name 
		{
			get 
			{
				return name;
			}
		}

		/// <summary>
		/// Gets the ID of this time zone. 
		/// </summary>
		public string ID
		{
			get 
			{
				return id;
			}
		}
		

		/// <summary>
		/// Gets/sets the amount of time in milliseconds to add to UTC to get standard time in this time zone.
		/// </summary>
		public int RawOffset 
		{
			get 
			{
				return normalTz.Offset * 1000 + rawOff;
			}
			set 
			{
				rawOff = value - normalTz.Offset * 1000;
			}
		}


		/// <summary>
		/// Converts the UTC time to the local time of time zone.
		/// </summary>
		/// <param name="utcTime">UTC time./// </param>
		/// <returns>
		/// Local time of converter's time zone corresponding to UTC time.
		/// </returns>
		public DateTime ToLocal(DateTime utcTime) 
		{
			Time localTime = GetLocalTime((long)((TimeSpan)utcTime.Subtract(new DateTime(1970,1,1,0,0,0))).TotalSeconds);
			return TimeToDateTime(localTime);
		}


		/// <summary>
		/// Converts the local time of converter's time zone to the UTC time.
		/// </summary>
		/// <param name="localTime">
		/// Local time of the given time zone. Note: It is not a local time of the machine !!!
		/// </param>
		/// <returns>
		/// UTC time corresponding to the local time of converter's time zone.
		/// </returns>
		public DateTime ToUtc(DateTime localTime) 
		{
			Time time = DateTimeToTime(localTime);
			Time utcTime = GetUtcTime(GetTime(time));

			return TimeToDateTime(utcTime);
		}


		/// <summary>
		/// Returns true if a particular date is considered part of daylight time in this timezone.
		/// </summary>
		/// <param name="d">Date to test.</param>
		/// <returns>true if a particular date is considered part of daylight time in this timezone.</returns>
		public bool InDaylightTime(DateTime time) 
		{
			TimeZoneType tz = GetTimeZoneType((long)time.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
			return tz.IsDST;
		}


		/// <summary>
		/// Returns true if this timezone has transitions between various offsets
		/// from UT, such as standard time and daylight time.
		/// </summary>
		public bool UsesDaylightTime 
		{ 
			get 
			{
				return tz.Length > 1;
			}
		}

		/// <summary>
		/// Gets all the available TZ names.
		/// </summary>
		public static string[] AvailableNames
		{
			get 
			{
				ResourceReader reader = new ResourceReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resManifestName));
				ArrayList names = new ArrayList();
				foreach (DictionaryEntry entry in reader)
				{
					names.Add((string)entry.Key);
				}
				reader.Close();
				return (string[])names.ToArray(typeof(string));
			}
		}


		/// <summary>
		/// Helper method which allows to convertion between arbitrary time zones.
		/// </summary>
		/// <param name="fromZoneName">Name of the source time zone.</param>
		/// <param name="fromTime">Time to convert.</param>
		/// <param name="toZoneName">Name of the destintation time zone.</param>
		/// <returns></returns>
		public static DateTime Convert(string fromZoneName, DateTime fromTime, string toZoneName) 
		{
			return new ZoneInfo(toZoneName).ToLocal(new ZoneInfo(fromZoneName).ToUtc(fromTime));
		}


		#endregion
	}
}
