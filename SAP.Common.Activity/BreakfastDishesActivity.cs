using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class BreakfastDishesActivity : DishesActivity
	{
		private BreakfastDishesActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.BreakfastDishes;
		protected override double StartTime => 8.00;
		protected override double EndTime => 9.50;

		public static BreakfastDishesActivity Monday = new BreakfastDishesActivity(DayOfWeek.Monday);
		public static BreakfastDishesActivity Tuesday = new BreakfastDishesActivity(DayOfWeek.Tuesday);
		public static BreakfastDishesActivity Wednesday = new BreakfastDishesActivity(DayOfWeek.Wednesday);
		public static BreakfastDishesActivity Thursday = new BreakfastDishesActivity(DayOfWeek.Thursday);
		public static BreakfastDishesActivity Friday = new BreakfastDishesActivity(DayOfWeek.Friday);
		public static BreakfastDishesActivity Sunday = new BreakfastDishesActivity(DayOfWeek.Sunday);
	}
}
