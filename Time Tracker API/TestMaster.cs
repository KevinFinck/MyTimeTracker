using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TimeTrackerAPI
{
	[TestFixture]
	public class TestMaster
	{
		#region SetUp / TearDown

		[SetUp]
		public void Init()
		{ }

		[TearDown]
		public void Dispose()
		{ }

		#endregion

		#region Tests

		[Test]
		public void Test()
		{
		}

		[Test]
		public void SumOfTwoNumbers()
		{
			Assert.AreEqual(10, 5 + 5);
		}

		[Test]
		public void AreTheValuesTheSame()
		{
			Assert.AreSame(10, 5 + 6);
		}

		#endregion
	}
}
