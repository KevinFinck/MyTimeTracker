using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinckInc.Toolkit.Extensions
{
	public static class ListExtensions
	{
		#region List<string>.Contains

		/// <summary>
		/// Determines if the given item is in the list of strings.  Will ignore the case, and any ending CR/LF's in the comparison.
		/// </summary>
		/// <param name="ignoreCase">Case insensitive comparison flag.</param>
		/// <param name="ignoreCrLf">If the strings match, except for an ending CR/LF, return true.</param>
		/// <returns></returns>
		public static bool Contains(this List<string> list, string item, bool ignoreCase, bool ignoreCrLf = true)
		{
			if (string.IsNullOrWhiteSpace(item))
				return false;

			if (!ignoreCrLf && !ignoreCase)
				return list.Contains(item);	// Fall back to the original routine.

			string compareString = ignoreCrLf ? item.RemoveCrLf() : item;

			foreach (string listItem in list)
			{
				if (string.Compare(compareString, ignoreCrLf ? listItem.RemoveCrLf() : listItem, ignoreCase) == 0)
					return true;
			}

			return false;
		}

		#endregion

		#region List<string>.Add

		/// <summary>
		/// Same as Add(), but can filter out any duplicates.  Filtering can be case insensitive, and ignore ending CR/LF's.
		/// </summary>
		/// <param name="uniqueOnly">Only add new items to the list.</param>
		/// <param name="ignoreCase">Case insensitive comparison flag.</param>
		/// <param name="ignoreCrLf">If the strings match, except for an ending CR/LF, return true.</param>
		/// <returns></returns>
		public static void Add(this List<string> thisList, string item, bool uniqueOnly, bool ignoreCase = true, bool ignoreCrLf = true)
		{
			if (string.IsNullOrWhiteSpace(item))
				return;

			if (!uniqueOnly)
			{
				thisList.Add(item);
				return;
			}

			if (thisList.Contains(item, ignoreCrLf, ignoreCase))
				return;

			thisList.Add(item);
		}

		#endregion

		#region List<string>.AddRange

		/// <summary>
		/// Same as AddRange(), but can filter out any duplicates.  Filtering can be case insensitive, and ignore ending CR/LF's.
		/// </summary>
		/// <param name="uniqueOnly">Only add new items to the list.</param>
		/// <param name="ignoreCase">Case insensitive comparison flag.</param>
		/// <param name="ignoreCrLf">If the strings match, except for an ending CR/LF, return true.</param>
		/// <returns></returns>
		public static void AddRange(this List<string> thisItems, IEnumerable<string> collection, bool uniqueOnly, bool ignoreCase = true, bool ignoreCrLf = true)
		{
			if (collection == null)
				return;

			if (!uniqueOnly && !ignoreCrLf && !ignoreCase)
			{
				thisItems.AddRange(collection);
				return;
			}

			foreach (string item in collection)
			{
				thisItems.Add(item, uniqueOnly, ignoreCrLf, ignoreCase);
			}

			return;
		}

		#endregion

		#region List<string>.Remove

		public static void Remove(this List<string> items, string item, bool ignoreCase, bool ignoreCrLf = true)
		{
			if (items.Count < 1)
				return;

			if (!ignoreCase && !ignoreCrLf)
				items.Remove(item);
			else
			{
				string compareItem = ignoreCrLf ? item.RemoveCrLf() : item;
				int i = 0;
				while (i < items.Count)
				{
					if (string.Compare(ignoreCrLf ? items[i].RemoveCrLf() : items[i], compareItem) == 0)
						items.Remove(items[i]);
					else
						i++;
				}
			}

			return;
		}

		#endregion

		#region List<string>.ToString
		public static string ToString(this List<string> items, string separator = null)
		{
			// Assert
			if ((items == null) || (items.Count < 1))
				return null;

			// Default to CR/LF since we can't in the definition.
			if (separator == null)
				separator = Environment.NewLine;

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < items.Count; i++)
			{
				sb.Append(items[i]);
				if (i < items.Count - 1)
					sb.Append(separator);	// Add if there are more items.
			}

			return sb.ToString();
		}
		#endregion

		#region List<string>.ToNumberedListString
		public static string ToNumberedListString(this List<string> items, string separator = "  ")
		{
			// Assert
			if ((items == null) || (items.Count < 1))
				return null;
			if (items.Count == 1)
				return items[0];

			// Default to CR/LF since we can't in the definition.
			if (separator == null)
				separator = string.Empty;

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < items.Count; i++)
			{
				sb.AppendFormat("({0}) {1}", i + 1, items[i]);
				if (i < items.Count - 1)
					sb.Append(separator);	// Add if there are more items.
			}

			return sb.ToString();
		}
		#endregion
	}
}
