using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class Activity
	{
		protected internal Activity(DayOfWeek day, TimeOfDay time, ActivityType type)
		{
			Day = day;
			Time = time;
			Type = type;
		}

		public DayOfWeek Day { get; set; }
		public TimeOfDay Time { get; set; }
		public ActivityType Type { get; set; }

		public bool ConflictsWith(Activity activity)
		{
			// TODO: Deal with bitwise problem of overnight  
			return activity.Time == this.Time;
		}

		public bool Equals(Activity activity)
		{
			return activity.Type == this.Type && activity.Day == this.Day && activity.Time == this.Time;
		}

        public override string ToString()
        {
            return $"{Day} {Type}";
        }

        #region Static Nights Off

        public static Activity MondayNightOff = new Activity(DayOfWeek.Monday, TimeOfDay.Evening, ActivityType.NightOff);
        public static Activity TuesdayNightOff = new Activity(DayOfWeek.Tuesday, TimeOfDay.Evening, ActivityType.NightOff);
        public static Activity WednesdayNightOff = new Activity(DayOfWeek.Wednesday, TimeOfDay.Evening, ActivityType.NightOff);
        public static Activity ThursdayNightOff = new Activity(DayOfWeek.Thursday, TimeOfDay.Evening, ActivityType.NightOff);

        public static Activity[] NightsOff
        {
            get => new Activity[7]
            {
                // No sunday or friday night off. Add eventually for family camp?
                null,
                MondayNightOff,
                TuesdayNightOff,
                WednesdayNightOff,
                ThursdayNightOff,
                null,
                null
            };
        }

        #endregion Static Nights Off

        #region Campfires

        public static Activity SundayCampfire = new Activity(DayOfWeek.Sunday, TimeOfDay.Evening, ActivityType.Campfire);
		public static Activity MondayCampfire = new Activity(DayOfWeek.Monday, TimeOfDay.Evening, ActivityType.Campfire);
		public static Activity TuesdayCampfire = new Activity(DayOfWeek.Tuesday, TimeOfDay.Evening, ActivityType.Campfire);
		public static Activity WednesdayCampfire = new Activity(DayOfWeek.Wednesday, TimeOfDay.Evening, ActivityType.Campfire);
		public static Activity ThursdayCampfire = new Activity(DayOfWeek.Thursday, TimeOfDay.Evening, ActivityType.Campfire);
		public static Activity FridayCampfire = new Activity(DayOfWeek.Friday, TimeOfDay.Evening, ActivityType.Campfire);

        public static Activity[] Campfires
        {
            get => new Activity[7]
            {
                SundayCampfire,
                MondayCampfire,
                TuesdayCampfire,
                WednesdayCampfire,
                ThursdayCampfire,
                FridayCampfire,
                null
            };
        }

        #endregion Campfires

        #region Quiet Cabins

        public static Activity SundayQuietCabin = new Activity(DayOfWeek.Sunday, TimeOfDay.Evening, ActivityType.QuietCabin);
        public static Activity MondayQuietCabin = new Activity(DayOfWeek.Monday, TimeOfDay.Evening, ActivityType.QuietCabin);
        public static Activity TuesdayQuietCabin = new Activity(DayOfWeek.Tuesday, TimeOfDay.Evening, ActivityType.QuietCabin);
        public static Activity WednesdayQuietCabin = new Activity(DayOfWeek.Wednesday, TimeOfDay.Evening, ActivityType.QuietCabin);
        public static Activity ThursdayQuietCabin = new Activity(DayOfWeek.Thursday, TimeOfDay.Evening, ActivityType.QuietCabin);
        public static Activity FridayQuietCabin = new Activity(DayOfWeek.Friday, TimeOfDay.Evening, ActivityType.QuietCabin);

        public static Activity[] QuietCabins
        {
            get =>
                new Activity[7]
                {
                    SundayQuietCabin,
                    MondayQuietCabin,
                    TuesdayQuietCabin,
                    WednesdayQuietCabin,
                    ThursdayQuietCabin,
                    FridayQuietCabin,
                    null,
                };
        }

        #endregion QuietCabins

        #region Overnights

        public static Activity MondayOvernight = new Activity(DayOfWeek.Monday, (TimeOfDay.Evening | TimeOfDay.Afternoon), ActivityType.Overnight);
        public static Activity TuesdayOvernight = new Activity(DayOfWeek.Tuesday, (TimeOfDay.Evening | TimeOfDay.Afternoon), ActivityType.Overnight);
        public static Activity WednesdayOvernight = new Activity(DayOfWeek.Wednesday, (TimeOfDay.Evening | TimeOfDay.Afternoon), ActivityType.Overnight);
        public static Activity ThursdayOvernight = new Activity(DayOfWeek.Thursday, (TimeOfDay.Evening | TimeOfDay.Afternoon), ActivityType.Overnight);

        public static Activity[] Overnights
        {
            get => new Activity[7]
            {
                null,
                MondayOvernight,
                TuesdayOvernight,
                WednesdayOvernight,
                ThursdayOvernight,
                null,
                null,
            };
        }

        #endregion Overnights

        #region Trading Post

        public static Activity MondayTradingPost = new Activity(DayOfWeek.Monday, TimeOfDay.Evening, ActivityType.TradingPost);
        public static Activity TuesdayTradingPost = new Activity(DayOfWeek.Tuesday, TimeOfDay.Evening, ActivityType.TradingPost);
        public static Activity WednesdayTradingPost = new Activity(DayOfWeek.Wednesday, TimeOfDay.Evening, ActivityType.TradingPost);
        public static Activity ThursdayTradingPost = new Activity(DayOfWeek.Thursday, TimeOfDay.Evening, ActivityType.TradingPost);
        public static Activity FridayTradingPost = new Activity(DayOfWeek.Friday, TimeOfDay.Evening, ActivityType.TradingPost);

        public static Activity[] TradingPosts
        {
            get => new Activity[7]
            {
                null,
                MondayTradingPost,
                TuesdayTradingPost,
                WednesdayTradingPost,
                ThursdayTradingPost,
                FridayTradingPost,
                null,
            };
        }

        #endregion Trading Post

        #region Power Ups

        public static Activity MondayPowerUp = new Activity(DayOfWeek.Monday, TimeOfDay.Afternoon, ActivityType.PowerUp);
        public static Activity TuesdayPowerUp = new Activity(DayOfWeek.Tuesday, TimeOfDay.Afternoon, ActivityType.PowerUp);
        public static Activity WednesdayPowerUp = new Activity(DayOfWeek.Wednesday, TimeOfDay.Afternoon, ActivityType.PowerUp);
        public static Activity ThursdayPowerUp = new Activity(DayOfWeek.Thursday, TimeOfDay.Afternoon, ActivityType.PowerUp);

        public static Activity[] PowerUps
        {
            get => new Activity[7]
            {
                null,
                MondayPowerUp,
                TuesdayPowerUp,
                WednesdayPowerUp,
                ThursdayPowerUp,
                null,
                null,
            };
        }

        #endregion Power Ups 

        #region Dishes

        public static Activity SundayDinnerDishes = new Activity(DayOfWeek.Sunday, TimeOfDay.Evening, ActivityType.DinnerDishes);

        public static Activity MondayBreakfastDishes = new Activity(DayOfWeek.Monday, TimeOfDay.Morning, ActivityType.BreakfastDishes);
        public static Activity MondayLunchDishes = new Activity(DayOfWeek.Monday, TimeOfDay.Noon, ActivityType.LunchDishes);
        public static Activity MondayDinnerDishes = new Activity(DayOfWeek.Monday, TimeOfDay.Evening, ActivityType.DinnerDishes);

        public static Activity TuesdayBreakfastDishes = new Activity(DayOfWeek.Tuesday, TimeOfDay.Morning, ActivityType.BreakfastDishes);
        public static Activity TuesdayLunchDishes = new Activity(DayOfWeek.Tuesday, TimeOfDay.Noon, ActivityType.LunchDishes);
        public static Activity TuesdayDinnerDishes = new Activity(DayOfWeek.Tuesday, TimeOfDay.Evening, ActivityType.DinnerDishes);

        public static Activity WednesdayBreakfastDishes = new Activity(DayOfWeek.Wednesday, TimeOfDay.Morning, ActivityType.BreakfastDishes);
        public static Activity WednesdayLunchDishes = new Activity(DayOfWeek.Wednesday, TimeOfDay.Noon, ActivityType.LunchDishes);
        public static Activity WednesdayDinnerDishes = new Activity(DayOfWeek.Wednesday, TimeOfDay.Evening, ActivityType.DinnerDishes);

        public static Activity ThursdayBreakfastDishes = new Activity(DayOfWeek.Thursday, TimeOfDay.Morning, ActivityType.BreakfastDishes);
        public static Activity ThursdayLunchDishes = new Activity(DayOfWeek.Thursday, TimeOfDay.Noon, ActivityType.LunchDishes);
        public static Activity ThursdayDinnerDishes = new Activity(DayOfWeek.Thursday, TimeOfDay.Evening, ActivityType.DinnerDishes);

        public static Activity FridayBreakfastDishes = new Activity(DayOfWeek.Friday, TimeOfDay.Morning, ActivityType.BreakfastDishes);
        public static Activity FridayLunchDishes = new Activity(DayOfWeek.Friday, TimeOfDay.Noon, ActivityType.LunchDishes);
        public static Activity FridayDinnerDishes = new Activity(DayOfWeek.Friday, TimeOfDay.Evening, ActivityType.DinnerDishes);

        public static Activity SaturdayBreakfastDishes = new Activity(DayOfWeek.Saturday, TimeOfDay.Morning, ActivityType.BreakfastDishes);

        public static Activity[] SundayDishes
        {
            get => new Activity[3]
            {
                null,
                null,
                SundayDinnerDishes,
            };
        }

        public static Activity[] MondayDishes
        {
            get => new Activity[3]
            {
                MondayBreakfastDishes,
                MondayLunchDishes,
                MondayDinnerDishes,
            };
        }

        public static Activity[] TuesdayDishes
        {
            get => new Activity[3]
            {
                TuesdayBreakfastDishes,
                TuesdayLunchDishes,
                TuesdayDinnerDishes,
            };
        }

        public static Activity[] WednesdayDishes
        {
            get => new Activity[3]
            {
                WednesdayBreakfastDishes,
                WednesdayLunchDishes,
                WednesdayDinnerDishes,
            };
        }

        public static Activity[] ThursdayDishes
        {
            get => new Activity[3]
            {
                ThursdayBreakfastDishes,
                ThursdayLunchDishes,
                ThursdayDinnerDishes,
            };
        }

        public static Activity[] FridayDishes
        {
            get => new Activity[3]
            {
                FridayBreakfastDishes,
                FridayLunchDishes,
                FridayDinnerDishes,
            };
        }

        public static Activity[] SaturdayDishes
        {
            get => new Activity[3]
            {
                SaturdayBreakfastDishes,
                null,
                null,
            };
        }

        //public static Activity[,] Dishes
        //{
        //    get => new Activity[,]
        //    {
        //        SundayDishes,
        //        MondayDishes,
        //        TuesdayDishes,
        //        WednesdayDishes,
        //        ThursdayDishes,
        //        FridayDishes,
        //        SaturdayDishes,
        //    };
        //}

        #endregion Dishes

        #region Flag Raising 

        public static Activity MondayFlagRaising = new Activity(DayOfWeek.Monday, TimeOfDay.Morning, ActivityType.FlagRaising);
        public static Activity TuesdayFlagRaising = new Activity(DayOfWeek.Tuesday, TimeOfDay.Morning, ActivityType.FlagRaising);
        public static Activity WednesdayFlagRaising = new Activity(DayOfWeek.Wednesday, TimeOfDay.Morning, ActivityType.FlagRaising);
        public static Activity ThursdayFlagRaising = new Activity(DayOfWeek.Thursday, TimeOfDay.Morning, ActivityType.FlagRaising);
        public static Activity FridayFlagRaising = new Activity(DayOfWeek.Friday, TimeOfDay.Morning, ActivityType.FlagRaising);
        public static Activity SaturdayFlagRasing = new Activity(DayOfWeek.Saturday, TimeOfDay.Morning, ActivityType.FlagRaising);

        #endregion Flag Raising 

        #region Flag Lowering 

        public static Activity SundayFlagLowering = new Activity(DayOfWeek.Sunday, TimeOfDay.Evening, ActivityType.FlagLowering);
        public static Activity MondayFlagLowering = new Activity(DayOfWeek.Monday, TimeOfDay.Evening, ActivityType.FlagLowering);
        public static Activity TuesdayFlagLowering = new Activity(DayOfWeek.Tuesday, TimeOfDay.Evening, ActivityType.FlagLowering);
        public static Activity WednesdayFlagLowering = new Activity(DayOfWeek.Wednesday, TimeOfDay.Evening, ActivityType.FlagLowering);
        public static Activity ThursdayFlagLowering = new Activity(DayOfWeek.Thursday, TimeOfDay.Evening, ActivityType.FlagLowering);
        public static Activity FridayFlagLowering = new Activity(DayOfWeek.Friday, TimeOfDay.Evening, ActivityType.FlagLowering);

        public static Activity[] FlagLowerings
        {
            get => new Activity[7]
            {
                SundayFlagLowering,
                MondayFlagLowering,
                TuesdayFlagLowering,
                WednesdayFlagLowering,
                ThursdayFlagLowering,
                FridayFlagLowering,
                null
            };
        }

        #endregion Flag Lowering 

        #region Breakfast Grace 

        public static Activity MondayBreakfastGrace = new Activity(DayOfWeek.Monday, TimeOfDay.Morning, ActivityType.BreakfastGrace);
        public static Activity TuesdayBreakfastGrace = new Activity(DayOfWeek.Tuesday, TimeOfDay.Morning, ActivityType.BreakfastGrace);
        public static Activity WednesdayBreakfastGrace = new Activity(DayOfWeek.Wednesday, TimeOfDay.Morning, ActivityType.BreakfastGrace);
        public static Activity ThursdayBreakfastGrace = new Activity(DayOfWeek.Thursday, TimeOfDay.Morning, ActivityType.BreakfastGrace);
        public static Activity FridayBreakfastGrace = new Activity(DayOfWeek.Friday, TimeOfDay.Morning, ActivityType.BreakfastGrace);
        public static Activity SaturdayBreakfastGrace = new Activity(DayOfWeek.Sunday, TimeOfDay.Morning, ActivityType.BreakfastGrace);

        public static Activity[] BreakfastGraces
        {
            get => new Activity[7]
            {
                null,
                MondayBreakfastGrace,
                TuesdayBreakfastGrace,
                WednesdayBreakfastGrace,
                ThursdayBreakfastGrace,
                FridayBreakfastGrace,
                SaturdayBreakfastGrace
            };
        }
        
        #endregion Breakfast Grace

        #region Lunch Grace 

        public static Activity MondayLunchGrace = new Activity(DayOfWeek.Monday, TimeOfDay.Noon, ActivityType.LunchGrace);
        public static Activity TuesdayLunchGrace = new Activity(DayOfWeek.Tuesday, TimeOfDay.Noon, ActivityType.LunchGrace);
        public static Activity WednesdayLunchGrace = new Activity(DayOfWeek.Wednesday, TimeOfDay.Noon, ActivityType.LunchGrace);
        public static Activity ThursdayLunchGrace = new Activity(DayOfWeek.Thursday, TimeOfDay.Noon, ActivityType.LunchGrace);
        public static Activity FridayLunchGrace = new Activity(DayOfWeek.Friday, TimeOfDay.Noon, ActivityType.LunchGrace);

        public static Activity[] LunchGraces
        {
            get => new Activity[7]
            {
                null,
                MondayLunchGrace,
                TuesdayLunchGrace,
                WednesdayLunchGrace,
                ThursdayLunchGrace,
                FridayLunchGrace,
                null
            };
        }

        #endregion Lunch Grace 

        #region Dinner Grace 

        public static Activity SundayDinnerGrace = new Activity(DayOfWeek.Sunday, TimeOfDay.Evening, ActivityType.DinnerGrace);
        public static Activity MondayDinnerGrace = new Activity(DayOfWeek.Monday, TimeOfDay.Evening, ActivityType.DinnerGrace);
        public static Activity TuesdayDinnerGrace = new Activity(DayOfWeek.Tuesday, TimeOfDay.Evening, ActivityType.DinnerGrace);
        public static Activity WednesdayDinnerGrace = new Activity(DayOfWeek.Wednesday, TimeOfDay.Evening, ActivityType.DinnerGrace);
        public static Activity ThursdayDinnerGrace = new Activity(DayOfWeek.Thursday, TimeOfDay.Evening, ActivityType.DinnerGrace);
        public static Activity FridayDinnerGrace = new Activity(DayOfWeek.Friday, TimeOfDay.Evening, ActivityType.DinnerGrace);

        public static Activity[] DinnerGraces
        {
            get => new Activity[7]
            {
                SundayDinnerGrace,
                MondayDinnerGrace,
                TuesdayDinnerGrace,
                WednesdayDinnerGrace,
                ThursdayDinnerGrace,
                FridayDinnerGrace,
                null
            };
        }
        #endregion Dinner Grace 

    }

    public class CabinCoverageActivity : Activity
    {
        public CabinCoverageActivity(DayOfWeek day, TimeOfDay time, Cabin coverdCabin) : base(day, time, ActivityType.CabinCoverage)
        {
			CoveredCabin = coverdCabin;
		}

        public Cabin CoveredCabin { get; set; }

        public override string ToString()
        {
            return base.ToString() + " for " + CoveredCabin.Name;
        }
    }
}
