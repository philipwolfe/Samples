#if  UNIT_TESTS

using System;
using NUnit.Core;
using NUnit.Framework;

namespace TZ4Net
{
	/// <summary>
	/// Summary description for UtilsFixture.
	/// </summary>
	[TestFixture]
	public class ZoneInfoFixture
	{
		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void Teardown() 
		{
		}
		

		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void NameNull()
		{
			ZoneInfo zi = new ZoneInfo(null as string);
		}


		[Test, ExpectedException(typeof(ArgumentException))]
		public void NameEmpty()
		{
			Assert.IsNotNull(this);
			ZoneInfo zi = new ZoneInfo(string.Empty);
		}


		[Test, ExpectedException(typeof(ArgumentException))]
		public void NameUnknown()
		{
			ZoneInfo zi = new ZoneInfo("{0CC2C22D-0368-49b2-AF7E-4C261D336B01}");
		}


		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// "At 01:58:31 UTC on March 18, 2005, the Unix time number reached 1111111111. A large celebration was held
		// on IRC in the Freenode channel #1111111111. At its peak the channel held over 200 people and averaged up 
		// to 24 messages in a single second".
		[Test]
		public void LocalTime1111111111ToUtc()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(1111111111);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(2005, 03, 18, 01, 58, 31)) == 0);
		}

		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// At 23:31:30 UTC on February 13, 2009, a celebration is expected as the Unix time 
		// number reaches 1234567890 seconds.
		[Test]
		public void LocalTime1234567890ToUtc()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(1234567890);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(2009, 02, 13, 23, 31, 30)) == 0);
		}


		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// At 03:14:08 UTC on January 19, 2038 (+2^31), a 32-bit signed integer representation of Unix time 
		// will overflow. Systems using a 32-bit signed integer Unix time_t will therefore be unable to 
		// represent that time, or any later [...]
		[Test]
		public void LocalTimeIntMaxToUtc()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(int.MaxValue);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(2038, 01, 19, 03, 14, 07)) == 0);
		}


		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// [...] and will likely wrap around to 20:45:52 UTC on December 13, 1901, 
		// with integer value -2^31. This is known as the year 2038 problem.
		[Test]
		public void LocalTimeIntMinToUtc()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(int.MinValue);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(1901, 12, 13, 20, 45, 52)) == 0);
		}


		// From http://slashdot.org/articles/01/04/17/1915221.shtml
        // "If my calculations are correct, on Thursday, April 19, 2001, at 04:25:21 UTC (00:25:21 EDT and 
		// late Wednesday at 21:25:21 PDT), the UNIX clock will read 987654321, which is pretty cool. 
		// This will be the first of two such "significant" events in 2001,  
		[Test]
		public void LocalTime987654321ToUtc()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(987654321);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(2001, 04, 19, 04, 25, 21)) == 0);
		}


        // From http://slashdot.org/articles/01/04/17/1915221.shtml
		// [...] the second being 01:46:39 UTC on 2001-09-09, when the clock will read 999999999 
		// (and then of course "roll over" to 1000000000 one second later). Use the Time Zone 
		// Converter to help you figure out when this will occur in your area, or read up on other 
		// critical dates (such as when the 32-bit signed UNIX clock overflows in 2038)."
		[Test]
		public void LocalTime999999999ToUtc()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(999999999);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(2001, 09, 09, 01, 46, 39)) == 0);
		}


		// According to www.timezoneconverter.com :
		//04:25:11 Thursday April 19, 2001 in UCT converts to
		//06:25:11 Thursday April 19, 2001 in Europe/Amsterdam 
		[Test]
		public void LocalTime987654321ToEuropeAmsterdam()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Amsterdam");
			ZoneInfo.Time t = zi.GetLocalTime(987654321);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(2001, 04, 19, 06, 25, 21)) == 0);
		}


		// According to www.timezoneconverter.com :
		// 01:46:39 Sunday September 9, 2001 in UCT converts to
		// 03:46:39 Sunday September 9, 2001 in Europe/Amsterdam  
		[Test]
		public void LocalTime999999999ToEuropeAmsterdam()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Amsterdam");
			ZoneInfo.Time t = zi.GetLocalTime(999999999);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.Create(2001, 09, 09, 03, 46, 39)) == 0);
		}

		[Test]
		public void AvailableNames() 
		{
			string[] names = ZoneInfo.AvailableNames;
			Assert.IsTrue(Array.IndexOf(names, "Europe/Amsterdam") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Warsaw") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Sofia") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "America/Chicago") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "America/New_York") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "{0CC2C22D-0368-49b2-AF7E-4C261D336B01}") < 0);
		}


		// According to www.timezoneconverter.com :
		// 14:11:48 Friday August 5, 2005 in UCT converts to
		// 16:11:48 Friday August 5, 2005 in Europe/Amsterdam  
		[Test]
		public void UTC20050805141148ToEuropeAmsterdam()
		{
			Assert.IsTrue(ZoneInfo.Convert("UCT", new DateTime(2005, 08, 05, 14, 11, 48), "Europe/Amsterdam") == new DateTime(2005, 08, 05, 16, 11, 48));
		}

		 
		// According to www.timezoneconverter.com :
		// 15:15:15 Thursday March 17, 2005 in UCT converts to
		// 16:15:15 Thursday March 17, 2005 in Europe/Amsterdam 
		[Test]
		public void UTC20050317151515ToEuropeAmsterdam()
		{
			Assert.IsTrue(ZoneInfo.Convert("UCT", new DateTime(2005, 03, 17, 15, 15, 15), "Europe/Amsterdam") == new DateTime(2005, 03, 17, 16, 15, 15));
		}


		/// According to www.timezoneconverter.com :
		/// 11:15:00 Saturday October 24, 1992 in Europe/Warsaw converts to
		/// 05:15:00 Saturday October 24, 1992 in America/Chicago
		/// DST is not in effect on this date/time in Europe/Warsaw 
		/// DST is in effect on this date/time in America/Chicago
		[Test]
		public void EuropeWarsaw19921024111500ToAmericaChicago()
		{
			Assert.IsTrue(ZoneInfo.Convert("Europe/Warsaw", new DateTime(1992, 10, 24, 11, 15, 00), "America/Chicago") == new DateTime(1992, 10, 24, 05, 15, 00));
			Assert.IsFalse(new ZoneInfo("Europe/Warsaw").InDaylightTime(new DateTime(1992, 10, 24, 11, 15, 00)));
			Assert.IsTrue(new ZoneInfo("America/Chicago").InDaylightTime(new DateTime(1992, 10, 24, 05, 15, 00)));
		}


		// From http://www.infoplease.com/spot/daylight1.html :
		// "But just months after Indiana got in step with the rest of the country, the federal government announced 
		// a major change in Daylight Saving Time. In Aug. 2005, Congress passed an energy bill that included 
		// extending Daylight Saving Time by about a month. Beginning in 2007, DST will start the second Sunday 
		// of March and end on the first Sunday of November."
		// So, March 17 should NOT be in DST in 2006, but should be in DST in 2007 in New York....

		// According to www.timezoneconverter.com :
		// 13:13:13 Friday March 17, 2006 in UCT converts to
		// 08:13:13 Friday March 17, 2006 in America/New_York  
		// DST* is not in effect on this date/time in UCT 
		// DST* is not in effect on this date/time in America/New_York
		[Test]
		public void UTC20060317131313ToAmericaNewYork()
		{
			Assert.IsTrue(ZoneInfo.Convert("UTC", new DateTime(2006, 03, 17, 13, 13, 13), "America/New_York") == new DateTime(2006, 03, 17, 08, 13, 13));
			Assert.IsFalse(new ZoneInfo("UTC").InDaylightTime(new DateTime(2006, 03, 17, 13, 13, 13)));
			Assert.IsFalse(new ZoneInfo("America/New_York").InDaylightTime(new DateTime(2006, 03, 17, 08, 13, 13)));
		}

		// According to www.timezoneconverter.com :
		// 13:13:13 Saturday March 17, 2007 in UCT converts to
		// 09:13:13 Saturday March 17, 2007 in America/New_York  
		// DST* is not in effect on this date/time in UCT 
		// DST* is in effect on this date/time in America/New_York  
		[Test]
		public void UTC20070317131313ToAmericaNewYork()
		{
			Assert.IsTrue(ZoneInfo.Convert("UTC", new DateTime(2007, 03, 17, 13, 13, 13), "America/New_York") == new DateTime(2007, 03, 17, 09, 13, 13));
			Assert.IsFalse(new ZoneInfo("UTC").InDaylightTime(new DateTime(2007, 03, 17, 13, 13, 13)));
			Assert.IsTrue(new ZoneInfo("America/New_York").InDaylightTime(new DateTime(2007, 03, 17, 09, 13, 13)));
		}

	}
}
#endif