using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class DinnerDishesActivity : DishesActivity
	{
		public DinnerDishesActivity(DayOfWeek day) : base(day)
		{
		}

		public override ActivityType Type => ActivityType.DinnerDishes;
		protected override double StartTime => 18.00;
		protected override double EndTime => 19.50;

		public static DinnerDishesActivity Sunday = new DinnerDishesActivity(DayOfWeek.Sunday);
		public static DinnerDishesActivity Monday = new DinnerDishesActivity(DayOfWeek.Monday);
		public static DinnerDishesActivity Tuesday = new DinnerDishesActivity(DayOfWeek.Tuesday);
		public static DinnerDishesActivity Wednesday = new DinnerDishesActivity(DayOfWeek.Wednesday);
		public static DinnerDishesActivity Thursday = new DinnerDishesActivity(DayOfWeek.Thursday);
		public static DinnerDishesActivity Friday = new DinnerDishesActivity(DayOfWeek.Friday);
	}
}
