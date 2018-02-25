using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class LunchGraceActivity : ActivityBase
	{
		public LunchGraceActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.LunchGrace;
		protected override double StartTime => 12.25;
		protected override double EndTime => 12.50;

		public static LunchGraceActivity Monday = new LunchGraceActivity(DayOfWeek.Monday);
		public static LunchGraceActivity Tuesday = new LunchGraceActivity(DayOfWeek.Tuesday);
		public static LunchGraceActivity Wednesday = new LunchGraceActivity(DayOfWeek.Wednesday);
		public static LunchGraceActivity Thursday = new LunchGraceActivity(DayOfWeek.Thursday);
		public static LunchGraceActivity Friday = new LunchGraceActivity(DayOfWeek.Friday);
	}
}
