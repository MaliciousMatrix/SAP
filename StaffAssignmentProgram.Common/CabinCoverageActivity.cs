using SAP.Common.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
    public class CabinCoverageActivity : ActivityBase
    {
        private CabinCoverageActivity(DayOfWeek day, Cabin cabin) : base(day)
        {
            this.CoveredCabin = cabin;
        }

        public override ActivityType Type => ActivityType.CabinCoverage;

        protected override double StartTime => 18.00;

        protected override double EndTime => 23.99;

        public Cabin CoveredCabin { get; private set; }

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

        private static CabinCoverageActivity GetOrCreateCabinCoverageActivity(DayOfWeek day, Cabin cabin)
        {
            CabinCoverageActivity activity = CabinCoverageActivities
                .Where(x => x.Day == day && x.CoveredCabin == cabin)
                .FirstOrDefault();
            if(activity == null)
            {
                _cabinCoverageActivities.Add(new CabinCoverageActivity(day, cabin));
                return GetOrCreateCabinCoverageActivity(day, cabin);
            }
            return activity;
        }

        public static CabinCoverageActivity GetMondayCabinCoverage(Cabin cabin)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Monday, cabin);
        }

        public static CabinCoverageActivity GetTuesdayCabinCoverage(Cabin cabin)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Tuesday, cabin);
        }

        public static CabinCoverageActivity GetWednesdayCabinCoverage(Cabin cabin)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Wednesday, cabin);
        }

        public static CabinCoverageActivity GetThursdayCabinCoverage(Cabin cabin)
        {
            return GetOrCreateCabinCoverageActivity(DayOfWeek.Thursday, cabin);
        }
    }
}
