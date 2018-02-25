using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class FlagLoweringActivity : ActivityBase
	{
		public FlagLoweringActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.FlagLowering;
		protected override double StartTime => 17.75;
		protected override double EndTime => 18.00;

		public static FlagLoweringActivity Sunday = new FlagLoweringActivity(DayOfWeek.Sunday);
		public static FlagLoweringActivity Monday = new FlagLoweringActivity(DayOfWeek.Monday);
		public static FlagLoweringActivity Tuesday = new FlagLoweringActivity(DayOfWeek.Tuesday);
		public static FlagLoweringActivity Wednesday = new FlagLoweringActivity(DayOfWeek.Wednesday);
		public static FlagLoweringActivity Thursday = new FlagLoweringActivity(DayOfWeek.Thursday);
		public static FlagLoweringActivity Friday = new FlagLoweringActivity(DayOfWeek.Friday);
	}
}
