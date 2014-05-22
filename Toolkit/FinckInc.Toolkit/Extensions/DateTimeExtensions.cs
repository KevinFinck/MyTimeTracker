using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinckInc.Toolkit.Extensions
{
	public static class DateTimeExtensions
	{
		#region TimeSpan.ElapsedTime
		public static string ElapsedTime(this TimeSpan totalTime)
		{
			return String.Format("{0:00}:{1:00}:{2:00}.{3:00}", totalTime.Hours, totalTime.Minutes, totalTime.Seconds, totalTime.Milliseconds / 10);
		}
		#endregion
	}
}
