#if  UNIT_TESTS

using System;
using System.IO;
using NUnit.Core;
using NUnit.Framework;

namespace TZ4Net
{
	/// <summary>
	/// Tests for ZoneInfoResGen class.
	/// </summary>
	[TestFixture]
	public class ZoneInfoResGenFixture
	{
		private static int addedCount;
		private static int generatedCount;

		[SetUp]
		public void Setup()
		{
			ZoneInfoResGen.Added += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Added);
			ZoneInfoResGen.Skipped += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Skipped);
			ZoneInfoResGen.Generated += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Generated);
		}

		[TearDown]
		public void Teardown() 
		{
			ZoneInfoResGen.Added -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Added);
			ZoneInfoResGen.Skipped -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Skipped);
			ZoneInfoResGen.Generated -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Generated);
		}
		
		[Test]
		public void GenerateResourceFile()
		{
			const string zoneinfoDir = ".\\..\\..\\..\\..\\etc\\zoneinfo";
			const string resourceDir = ".\\";
			addedCount = 0;
			generatedCount = 0;
			ZoneInfoResGen.Generate(zoneinfoDir, resourceDir);
			Assert.IsTrue(addedCount > 0, "No zoneinfo file added to resource file.");
			Assert.IsTrue(generatedCount == 1, "Resource file was not generated.");
		}

		private static void ZoneInfoResGen_Added(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			System.Console.WriteLine(string.Format("Added resource: {0} ({1} bytes).", args.FileName, new FileInfo(args.FileName).Length));
			addedCount++;
		}

		private static void ZoneInfoResGen_Skipped(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			System.Console.WriteLine("Skipped file: {0}. 'TZif' signature not found.", args.FileName);
		}

		private static void ZoneInfoResGen_Generated(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			System.Console.WriteLine("Generated resource file: {0}.", args.FileName);
			generatedCount++;
		}

	}
}
#endif