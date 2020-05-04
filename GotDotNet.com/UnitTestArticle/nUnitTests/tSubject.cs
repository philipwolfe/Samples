using System;
using UnitTestArticle;
using NUnit.Framework;

namespace nUnitTests
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
		
		private Subject Subject{
			get{
				return this._Subject;
			}
			set{
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

		[Test]
		public void tAdd(){
			Int32 Sum;
			Sum = this.Subject.Add(1,2);
			Assert.AreEqual(3, Sum);
		}

		#endregion

	}
}
