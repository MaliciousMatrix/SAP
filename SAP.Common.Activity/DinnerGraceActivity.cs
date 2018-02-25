using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class DinnerGraceActivity : ActivityBase
	{
		public DinnerGraceActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.DinnerGrace;
		protected override double StartTime => 18.00;
		protected override double EndTime => 18.25;

		public static DinnerGraceActivity Sunday = new DinnerGraceActivity(DayOfWeek.Sunday);
		public static DinnerGraceActivity Monday = new DinnerGraceActivity(DayOfWeek.Monday);
		public static DinnerGraceActivity Tuesday = new DinnerGraceActivity(DayOfWeek.Tuesday);
		public static DinnerGraceActivity Wednesday = new DinnerGraceActivity(DayOfWeek.Wednesday);
		public static DinnerGraceActivity Thursday = new DinnerGraceActivity(DayOfWeek.Thursday);
		public static DinnerGraceActivity Friday = new DinnerGraceActivity(DayOfWeek.Friday);
	}
}
