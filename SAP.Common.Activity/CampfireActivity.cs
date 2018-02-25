using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class CampfireActivity : ActivityBase
	{
		private CampfireActivity(DayOfWeek day) : base(day)
		{	}

		public override ActivityType Type => ActivityType.Campfire;
		protected override double StartTime => 19.00;
		protected override double EndTime => 22.00;

		public static CampfireActivity Monday = new CampfireActivity(DayOfWeek.Monday);
		public static CampfireActivity Tuesday = new CampfireActivity(DayOfWeek.Tuesday);
		public static CampfireActivity Wednesday = new CampfireActivity(DayOfWeek.Wednesday);
		public static CampfireActivity Thursday = new CampfireActivity(DayOfWeek.Thursday);
	}
}
