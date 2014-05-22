using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace FinckInc.Toolkit.Extensions
{
	public static class StringExtensions
	{
		#region Is
		/// <summary>
		/// Case insensitive string comparison.  If both strings are null, result is true.
		/// </summary>
		/// <param name="thisValue"></param>
		/// <param name="value"></param>
		/// <param name="treatNullAsBlank">Optional:  If true, blank and null are treated as the same thing.  If x = null, then x.Is("", true) returns true.</param>
		/// <returns></returns>
		public static bool Is(this string thisValue, string value, bool treatNullAsBlank = false)
		{
			if (treatNullAsBlank)
			{
				if (string.IsNullOrEmpty(thisValue) && string.IsNullOrEmpty(value))
					return true;
			}

			if (thisValue == null)
				return (value == null);

			return string.Equals(thisValue, value, StringComparison.OrdinalIgnoreCase);
		}

		#endregion

		#region Append
		/// <summary>
		/// Returns the string with the given value appended as a new line.
		/// </summary>
		public static string AppendLine(this string thisValue, string value)
		{
			if (string.IsNullOrWhiteSpace(thisValue))
				return value;
			if (string.IsNullOrWhiteSpace(value))
				return thisValue;
			return thisValue + Environment.NewLine + value;
		}
		#endregion

		#region Combine

		/// <summary>
		/// Combines the string array into a string, separating each item with the given separator.
		/// </summary>
		public static string Combine(this string[] items, string separator = ", ")
		{
			string retval = "";
			for (int i = 0; i < items.Length; i++)
			{
				if (!string.IsNullOrEmpty(items[i]))
					retval += ((retval.Length > 0) ? separator ?? "" : "") + items[i];
			}
			return retval;
		}

		#endregion

		#region Trunc

		/// <summary>
		/// Returns original string (or null), but will truncate if it exceeds the given maxLength;
		/// </summary>
		/// <param name="value"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static string Trunc(this string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value))
				return value;

			return value.Length <= maxLength ? value : value.Substring(0, maxLength);
		}

		#endregion


		#region RemoveCrLf

		/// <summary>
		/// Returns the given string without the ending CR/LF, if it has one.
		/// </summary>
		public static string RemoveCrLf(this string value)
		{
			return value.EndsWith(Environment.NewLine) ? value.Remove(value.Length - 2) : value;
		}

		#endregion

		#region Contains

		public static bool Contains(this string source, string toCheck, StringComparison comparison)
		{
			return source.IndexOf(toCheck, comparison) >= 0;
		}

		#endregion

		#region FirstAlpha

		/// <summary>
		/// Returns the absolute index of the first Alpha character in the given string, 
		/// optionally starting with the startIndex.
		/// </summary>
		public static int FirstAlpha(this string value, int startIndex = 0)
		{
			if (string.IsNullOrWhiteSpace(value))
				return -1;
			if (startIndex > (value.Length - 1))
				return -1;

			string alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

			for (int chr = startIndex; chr < value.Length; chr++)
			{
				if (alpha.IndexOf(value[chr]) >= 0)
					return chr;
			}

			return -1;
		}

		#endregion

		#region TrySubstring

		/// <summary>
		/// Will try to perform a Substring.  It will always return a string, not null, and will not throw an error.
		/// If the given range is invalid, then the portion that applies is returned, or if nothing applies a blank string is returned.
		/// </summary>
		public static string TrySubstring(this string value, int startIndex, int length)
		{
			try
			{
				if (string.IsNullOrEmpty(value) || (length < 1))
					return "";

				if (startIndex > (value.Length - 1))
					return "";

				if (startIndex + length > value.Length)
					length = value.Length - startIndex;

				return value.Substring(startIndex, length);
			}
			catch
			{
				return "";
			}
		}


		#endregion

		#region XML

		public static T ToObject<T>(this String xmlData)
			where T : class
		{
			if (xmlData == null)
				return null;

			XmlSerializer xml = new XmlSerializer(typeof(T));

			using (StringReader sr = new StringReader(xmlData))
				return (T)xml.Deserialize(sr);
		}

		public static XmlDocument ToXmlDocument(this string xmlString)
		{
			XmlDocument doc = new XmlDocument();
			if (!string.IsNullOrWhiteSpace(xmlString))
				doc.LoadXml(xmlString);
			return doc;
		}

		#endregion
	}
}
