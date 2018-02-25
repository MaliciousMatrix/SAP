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
        [TestCaseSource(nameof(GetInvalidNameList))]
		public void TestInvalidName(string name)
		{
			try
			{
                Cabin cabin = new Cabin(0, name, "Loop", 1, false);
			}
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass();
            }
            Assert.Fail();
		}

        private List<string> GetInvalidNameList()
        {
            return new List<string>()
            {
                "  ",
                null,
                String.Empty,
                "\n",
                "                        ",
                " "
            };
        }

        public void TestEquals()
        {
            Cabin c1 = new Cabin(1, "Hennepin", "Lower", 1, false);
            Cabin c2 = new Cabin(1, "Hennepin", "Lower", 1, true);
            Cabin c3 = new Cabin(1, "Jolliet", "Lower", 1, false);
            Cabin c4 = new Cabin(4, "Hennepin", "Lower", 1, false);
            Cabin c5 = new Cabin(1, "Hennepin", "Upper", 1, false);
            Cabin c6 = new Cabin(3, "Jolliet", "Timerframe", 1, false);

            Assert.AreEqual(c1, c1);
            Assert.AreEqual(c1, c2);
            Assert.AreEqual(c2, c2);
            Assert.AreEqual(c3, c3);
            Assert.AreEqual(c4, c4);
            Assert.AreEqual(c5, c5);
            Assert.AreEqual(c6, c6);

            Assert.AreNotEqual(c1, c3);
            Assert.AreNotEqual(c1, c4);
            Assert.AreNotEqual(c1, c5);
            Assert.AreNotEqual(c1, c6);

        }
    }
}
