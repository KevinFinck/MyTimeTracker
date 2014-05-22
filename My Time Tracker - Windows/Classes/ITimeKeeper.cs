using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyTimeTracker.Classes
{
	public interface ITimeKeeper
	{
		void SaveTime(string projectName, DateTime? startTime, DateTime? endTime);
		string ReadTime();
	}
}
