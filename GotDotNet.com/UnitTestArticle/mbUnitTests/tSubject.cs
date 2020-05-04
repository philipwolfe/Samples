using System;
using UnitTestArticle;
using MbUnit.Core.Framework;
using MbUnit.Framework;

namespace mbUnitTests
{
	[TestFixture]
	public class tSubject
	{
		#region " Constructors "

		public tSubject()
		{
		}
		
		#endregion

		#region " fields "

		private Subject _Subject;

		#endregion

		#region " Properties "
		
		private Subject Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				this._Subject = value;
			}
		}

		#endregion

		#region " Setup/Teardown "

		[SetUp]
		public void Setup()
		{
			this.Subject = new Subject();
		}

		[TearDown]
		public void Teardown()
		{
			
		}

		#endregion

		#region " Tests "

		[RowTest()]
		[Row(1,2,3)]
		[Row(2,3,5)]
		[Row(3,4,8)]
		[Row(4,5,9)]
		public void tAdd(Int32 x, Int32 y, Int32 expectedSum)
		{
			Int32 Sum;
			Sum = this.Subject.Add(x,y);
			Assert.AreEqual(expectedSum, Sum);
		}

		#endregion

	}
}
