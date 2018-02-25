using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class FlagRaisingActivity : ActivityBase
	{
		public FlagRaisingActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.FlagRaising;
		protected override double StartTime => 7.50;
		protected override double EndTime => 8.00;

		public static FlagRaisingActivity Monday = new FlagRaisingActivity(DayOfWeek.Monday);
		public static FlagRaisingActivity Tuesday = new FlagRaisingActivity(DayOfWeek.Tuesday);
		public static FlagRaisingActivity Wednesday = new FlagRaisingActivity(DayOfWeek.Wednesday);
		public static FlagRaisingActivity Thursday = new FlagRaisingActivity(DayOfWeek.Thursday);
		public static FlagRaisingActivity Friday = new FlagRaisingActivity(DayOfWeek.Friday);
		public static FlagRaisingActivity Saturday = new FlagRaisingActivity(DayOfWeek.Saturday);
	}
}
