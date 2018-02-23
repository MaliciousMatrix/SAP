using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public enum ActivityType
	{
		// Morning 
		BreakfastDishes,
        FlagRaising,
        BreakfastGrace,

		// Noon
		LunchDishes,
        LunchGrace,

		// Afternoon
		PowerUp,

		// Evening 
		DinnerDishes,
        FlagLowering,
        DinnerGrace,

		TradingPost,
		NightOff, 
		QuietCabin,
		CabinCoverage, 
		Campfire,
        Overnight
    }
}
