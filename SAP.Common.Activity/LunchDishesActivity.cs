using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class LunchDishesActivity : DishesActivity
	{
		public LunchDishesActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.LunchDishes;

		protected override double StartTime => 12.25;

		protected override double EndTime => 13.75;

		public static LunchDishesActivity Monday = new LunchDishesActivity(DayOfWeek.Monday);
		public static LunchDishesActivity Tuesday = new LunchDishesActivity(DayOfWeek.Tuesday);
		public static LunchDishesActivity Wednesday = new LunchDishesActivity(DayOfWeek.Wednesday);
		public static LunchDishesActivity Thursday = new LunchDishesActivity(DayOfWeek.Thursday);
		public static LunchDishesActivity Friday = new LunchDishesActivity(DayOfWeek.Friday);
	}
}
