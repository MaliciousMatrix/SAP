using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
    public class OvernightActivity : ActivityBase
    {
        private OvernightActivity(DayOfWeek day) : base(day)
        {
            Time start = new Time(day, StartTime);
            Time end = new Time((DayOfWeek)(((int)day) + 1), EndTime);
            this.TimeSpan = new Duration(start, end);
        }

        public override ActivityType Type => ActivityType.Overnight;
        protected override double StartTime => 12.00;
        protected override double EndTime => 12.00;
    }
}
