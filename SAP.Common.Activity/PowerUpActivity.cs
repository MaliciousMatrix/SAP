using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class PowerUpActivity : ActivityBase
	{
		public PowerUpActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.PowerUp;
		protected override double StartTime => 15.50;
		protected override double EndTime => 16.00;

		public static PowerUpActivity Monday = new PowerUpActivity(DayOfWeek.Monday);
		public static PowerUpActivity Tuesday = new PowerUpActivity(DayOfWeek.Tuesday);
		public static PowerUpActivity Wednesday = new PowerUpActivity(DayOfWeek.Wednesday);
		public static PowerUpActivity Thursday = new PowerUpActivity(DayOfWeek.Thursday);
		public static PowerUpActivity Friday = new PowerUpActivity(DayOfWeek.Friday);
	}
}
