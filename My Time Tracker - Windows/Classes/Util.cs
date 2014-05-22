using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public static class Util
	{
		public static string ToUpper(string value)
		{
			if (string.IsNullOrEmpty(value))
				return value;
			else
				return value.ToUpper();
		}
	}
}
