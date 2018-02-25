using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Test
{
	[TestFixture]
	public class CabinTests
	{
		[Test]
		public void TestCreation()
		{
			int id = 10;
			string name = "Duluth";
			string loop = "Lower";
			int cabinScheduleId = 5;
			bool defaultSelected = false;

			Cabin cabin = new Cabin(id, name, loop, cabinScheduleId, defaultSelected);

			Assert.AreEqual(id, cabin.IdNumber);
			Assert.AreEqual(name, cabin.Name);
			Assert.AreEqual(loop, cabin.Loop);
			Assert.AreEqual(cabinScheduleId, cabin.CabinScheduleId);
			Assert.AreEqual(defaultSelected, cabin.DefaultSelected);
		}

		[Test]
		public void TestInvalidIdNumber()
		{
			try
			{
				Cabin cabin = new Cabin(-1, "Duluth", "Lower", 1, false);
			}
			catch(ArgumentOutOfRangeException)
			{
				Assert.Pass();
			}
			Assert.Fail();
		}

		[Test]
		public void TestInvalidIdNumber()
		{
			try
			{
				Cabin cabin = new Cabi
			}
		}
	}
}
