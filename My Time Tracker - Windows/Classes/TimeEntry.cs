using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class TimeEntry
	{
		#region Constructor
		
		public TimeEntry() {}

		public TimeEntry(DateTime? startTime = null, DateTime? endTime = null, TimeSpan? duration = null, string taskName = null, string description = null, int? week = null)
			: base()
		{
			StartTime = startTime;
			EndTime = endTime;
			if (!duration.HasValue && startTime.HasValue && endTime.HasValue)
				Duration = endTime.Value.Subtract(startTime.Value);
			else
				Duration = duration;
			Description = description;
			TaskName = taskName;
			Week = week;
		}

		#endregion

		#region Properties

		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public TimeSpan? Duration { get; set; }
		public string Description { get; set; }
		public string TaskName { get; set; }
		public int? Week { get; set; }

		#endregion

		#region Overrides

		public override string ToString()
		{
			return
				string.Format("{0},\t{1},\t{2},\t{3}{4}",
					TaskName,
					(StartTime.HasValue) ? StartTime.Value.ToString("M/d/yyyy h:mm tt") : "",
					(EndTime.HasValue) ? EndTime.Value.ToString("M/d/yyyy h:mm tt") : "",
					(Duration.HasValue) ? string.Format("{0:0}:{1:00}", decimal.Truncate((decimal)Duration.Value.TotalHours), decimal.Truncate((decimal)Duration.Value.Minutes)) : "",
					string.IsNullOrEmpty(Description) ? "" : ",\t" + Description);
		}

		#endregion
	}
}
