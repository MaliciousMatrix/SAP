using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public abstract class DishesActivity : ActivityBase
	{
		// for future functionality so that Dishes. 
		protected DishesActivity(DayOfWeek day) : base(day)
		{
		}
	}
}
