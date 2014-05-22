using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinckInc.Toolkit.Extensions
{
	public static class NumericExtensions
	{
		/// <summary>
		/// Returns the NON-rounded value divided by 1000 (in K), with 2 decimal points followed by "KB".
		/// </summary>
		public static string ToKBString(this int value)
		{
			return string.Format("{0:N2} KB", Math.Truncate((double)value / 10) / 100);
		}
	}
}
