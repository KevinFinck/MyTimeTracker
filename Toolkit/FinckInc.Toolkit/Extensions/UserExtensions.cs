using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinckInc.Toolkit.Extensions
{
	public static class UserExtensions
	{
		// NOTE: There is currently no code here to avoid using ITools if not required.

		#region DomainUsers.FirstAndLastName

		/// <summary>
		/// Returns the user's First and Last name separated by a space.
		/// </summary>
		//public static string FirstAndLastName(this DomainUsers user)
		//{
		//    if (string.IsNullOrWhiteSpace(user.FirstName) && string.IsNullOrWhiteSpace(user.LastName))
		//        return "";

		//    if (string.IsNullOrWhiteSpace(user.FirstName))
		//        return user.LastName.Trim();

		//    if (string.IsNullOrWhiteSpace(user.LastName))
		//        return user.FirstName.Trim();

		//    return string.Format("{0} {1}", user.FirstName.Trim(), user.LastName.Trim());
		//}

		#endregion

	}
}
