using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class TradingPostActivity : ActivityBase
	{
		private TradingPostActivity(DayOfWeek day) : base(day) { }

		public override ActivityType Type => ActivityType.TradingPost;
		protected override double StartTime => 20.00;
		protected override double EndTime => 21.00;

		public static TradingPostActivity Monday = new TradingPostActivity(DayOfWeek.Monday);
		public static TradingPostActivity Tuesday = new TradingPostActivity(DayOfWeek.Tuesday);
		public static TradingPostActivity Wednesday = new TradingPostActivity(DayOfWeek.Wednesday);
		public static TradingPostActivity Thursday = new TradingPostActivity(DayOfWeek.Thursday);
		public static TradingPostActivity Friday = new TradingPostActivity(DayOfWeek.Friday);
	}
}
