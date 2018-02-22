using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleGenerationEngine
{
    public class GenerationEngine
    {
		public GenerationEngine(ScheduleCreationInfo scheduleCreationInfo)
		{
			_scheduleCreationInfo = scheduleCreationInfo;
		}

		private ScheduleCreationInfo _scheduleCreationInfo;

		public void GenerateSchedule()
		{

		}
    }
}
