using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class BreakfastGraceActivity : ActivityBase
	{
		public BreakfastGraceActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.BreakfastGrace;
		protected override double StartTime => 8.00;
		protected override double EndTime => 8.25;

		public static BreakfastGraceActivity Monday = new BreakfastGraceActivity(DayOfWeek.Monday);
		public static BreakfastGraceActivity Tuesday = new BreakfastGraceActivity(DayOfWeek.Tuesday);
		public static BreakfastGraceActivity Wednesday = new BreakfastGraceActivity(DayOfWeek.Wednesday);
		public static BreakfastGraceActivity Thursday = new BreakfastGraceActivity(DayOfWeek.Thursday);
		public static BreakfastGraceActivity Friday = new BreakfastGraceActivity(DayOfWeek.Friday);
	}
}
