using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class NightOffActivity : ActivityBase
	{
		private NightOffActivity(DayOfWeek day) : base(day)
		{	}

		public override ActivityType Type => ActivityType.NightOff;
		protected override double StartTime => 18.00;
		protected override double EndTime => 23.99;

		public static NightOffActivity Monday = new NightOffActivity(DayOfWeek.Monday);
		public static NightOffActivity Tuesday = new NightOffActivity(DayOfWeek.Tuesday);
		public static NightOffActivity Wednesday = new NightOffActivity(DayOfWeek.Wednesday);
		public static NightOffActivity Thursday = new NightOffActivity(DayOfWeek.Thursday);		
	}
}
