using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class QuietCabinActivity : ActivityBase
	{
		private QuietCabinActivity(DayOfWeek day) : base(day)
		{}

		public override ActivityType Type => ActivityType.QuietCabin;
		protected override double StartTime => 22.00;
		protected override double EndTime => 23.00;

		public static QuietCabinActivity Sunday = new QuietCabinActivity(DayOfWeek.Sunday);
		public static QuietCabinActivity Monday = new QuietCabinActivity(DayOfWeek.Monday);
		public static QuietCabinActivity Tuesday = new QuietCabinActivity(DayOfWeek.Tuesday);
		public static QuietCabinActivity Wednesday = new QuietCabinActivity(DayOfWeek.Wednesday);
		public static QuietCabinActivity Thursday = new QuietCabinActivity(DayOfWeek.Thursday);
		public static QuietCabinActivity Friday = new QuietCabinActivity(DayOfWeek.Friday);
	}
}
