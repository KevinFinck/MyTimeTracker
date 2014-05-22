using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinckInc.Toolkit.Extensions
{
	public static class ExceptionExtensions
	{
		#region Exception.ToFullString

		/// <summary>
		/// Returns the message from the exception, and all inner exceptions, as a single string with a CR/LF added to the end of each message.
		/// </summary>
		/// <param name="ex">Exception to process.</param>
		/// <param name="innerPrefixString">Optional string with which to prefix each inner exception message.</param>
		/// <returns>Combined string of all exception messages.</returns>
		public static string ToFullString(this Exception ex, string prefixString = "---> ", string currentPrefix = null)
		{
			if ((ex == null) || string.IsNullOrWhiteSpace(ex.Message))
				return null;

			StringBuilder sb = new StringBuilder();

			if (ex.Message.EndsWith(Environment.NewLine))
				sb.Append((currentPrefix ?? "") + ex.Message);
			else
				sb.AppendLine((currentPrefix ?? "") + ex.Message);

			sb.Append(ex.InnerException.ToFullString(prefixString, prefixString + (currentPrefix ?? "")));

			return sb.ToString();
		}

		#endregion

		#region Exception.ToList

		/// <summary>
		/// Returns the message from the exception, and all inner exceptions, as a list of strings.
		/// </summary>
		/// <param name="ex">Exception to process.</param>
		/// <param name="innerPrefixString">Optional string with which to prefix each inner exception message.</param>
		/// <returns>List of exception messages.</returns>
		public static List<string> ToList(this Exception ex, string innerPrefixString = "---> ")
		{
			if (ex == null)
				return null;

			List<string> messages = new List<string>();

			if (!string.IsNullOrWhiteSpace(ex.Message))
				messages.Add(ex.Message);

			while (ex.InnerException != null)
			{
				ex = ex.InnerException;
				if (!string.IsNullOrWhiteSpace(ex.Message))
					messages.Add(ex.Message);
			}

			return messages;
		}

		#endregion
	}
}
