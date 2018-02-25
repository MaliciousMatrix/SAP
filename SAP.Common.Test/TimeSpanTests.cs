using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Test
{
	[TestFixture]
	public class TimeSpanTests
	{
		[Test]
		public void TestCreation()
		{
			Time startTime = new Time(DayOfWeek.Monday, 14.5);
			Time endTime = new Time(DayOfWeek.Monday, 15.5);

			TimeSpan ts = new TimeSpan(startTime, endTime);
			Assert.AreEqual(startTime, ts.StartTime);
			Assert.AreEqual(endTime, ts.EndTime);

			endTime = new Time(DayOfWeek.Tuesday, 14.5);
			ts = new TimeSpan(startTime, endTime);
			Assert.AreEqual(startTime, ts.StartTime);
			Assert.AreEqual(endTime, ts.EndTime);

			endTime = new Time(DayOfWeek.Tuesday, 15.5);
			ts = new TimeSpan(startTime, endTime);
			Assert.AreEqual(startTime, ts.StartTime);
			Assert.AreEqual(endTime, ts.EndTime);
		} 

		public void TestErroneousCreation()
		{
			bool caught = false;
			Time startTime = new Time(DayOfWeek.Monday, 14.5);
			Time endTime = new Time(DayOfWeek.Sunday, 15.5);
			try
			{
				TimeSpan ts = new TimeSpan(startTime, endTime);
			}
			catch (ArgumentOutOfRangeException)
			{
				caught = true;
			}

			if (!caught)
				Assert.Fail();

			caught = false;
			endTime = new Time(DayOfWeek.Monday, 13);
			try
			{
				TimeSpan ts = new TimeSpan(startTime, endTime);
			}
			catch (ArgumentOutOfRangeException)
			{
				Assert.Pass();
			}
			Assert.Fail();

		}

		[Test]
		public void TestConflictingTimeSpans()
		{
			Time t1 = new Time(DayOfWeek.Tuesday, 10);
			Time t2 = new Time(DayOfWeek.Tuesday, 11);
			Time t3 = new Time(DayOfWeek.Tuesday, 12);
			Time t4 = new Time(DayOfWeek.Tuesday, 13);

			// X-----------------X
			//           X----------------X
			TimeSpan ts1 = new TimeSpan(t1, t3);
			TimeSpan ts2 = new TimeSpan(t2, t4);
			Assert.IsTrue(ts1.ConfilctsWith(ts2));
			Assert.IsTrue(ts2.ConfilctsWith(ts1));

			// X-----------------------------X
			//        X-------------X
			ts1 = new TimeSpan(t1, t4);
			ts2 = new TimeSpan(t2, t3);
			Assert.IsTrue(ts2.ConfilctsWith(ts1));
			Assert.IsTrue(ts1.ConfilctsWith(ts2));

			// X----------------X
			// X--------X
			ts2 = new TimeSpan(t1, t3);
			Assert.IsTrue(ts1.ConfilctsWith(ts2));
			Assert.IsTrue(ts2.ConfilctsWith(ts1));

			// X--------------X
			//          X-----X
			ts2 = new TimeSpan(t3, t4);
			Assert.IsTrue(ts1.ConfilctsWith(ts2));
			Assert.IsTrue(ts2.ConfilctsWith(ts1));

			// X----------X
			// X----------X
			ts2 = new TimeSpan(t1, t4);
			Assert.IsTrue(ts1.ConfilctsWith(ts2));
			Assert.IsTrue(ts2.ConfilctsWith(ts1));

			// X------------X
			//              X----------X
			ts1 = new TimeSpan(t1, t2);
			ts2 = new TimeSpan(t2, t3);
			Assert.IsTrue(ts1.ConfilctsWith(ts2, true));
			Assert.IsTrue(ts2.ConfilctsWith(ts1, true));

			Assert.IsFalse(ts1.ConfilctsWith(ts2));
			Assert.IsFalse(ts2.ConfilctsWith(ts1));

			// X-------X
			//                 X-------X
			ts2 = new TimeSpan(t3, t4);
			Assert.IsFalse(ts1.ConfilctsWith(ts2));
			Assert.IsFalse(ts2.ConfilctsWith(ts1));
		}
	}
}
