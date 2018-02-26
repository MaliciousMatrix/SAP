using SAP.Common.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{

    // Up in SAP.Common because it relies on 
    public class CabinCoverageActivity : ActivityBase
    {
        private CabinCoverageActivity(DayOfWeek day, string cabinName) : base(day)
        {
            this.CoveredCabin = cabinName;
        }

        public override ActivityType Type => ActivityType.CabinCoverage;

        protected override double StartTime => 18.00;

        protected override double EndTime => 23.99;

        public string CoveredCabin { get; private set; }

        private static List<CabinCoverageActivity> _cabinCoverageActivities;
        public static List<CabinCoverageActivity> CabinCoverageActivities
        {
            get
            {
                if (_cabinCoverageActivities == null)
                    _cabinCoverageActivities = new List<CabinCoverageActivity>();
                return _cabinCoverageActivities;
            }
        }

        private static CabinCoverageActivity GetOrCreateCabinCoverageActivity(DayOfWeek day, string cabinName)
        {
            CabinCoverageActivity activity = CabinCoverageActivities
                .Where(x => x.Day == day && x.CoveredCabin == cabinName)
                .FirstOrDefault();
            if(activity == null)
            {
                _cabinCoverageActivities.Add(new CabinCoverageActivity(day, cabinName));
                return GetOrCreateCabinCoverageActivity(day, cabinName);
            }
            return activity;
        }

        public static CabinCoverageActivity GetMondayCabinCoverage(string cabinName)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Monday, cabinName);
        }

        public static CabinCoverageActivity GetTuesdayCabinCoverage(string cabinName)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Tuesday, cabinName);
        }

        public static CabinCoverageActivity GetWednesdayCabinCoverage(string cabinName)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Wednesday, cabinName);
        }

        public static CabinCoverageActivity GetThursdayCabinCoverage(string cabinName)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Thursday, cabinName);
        }
    }
}
