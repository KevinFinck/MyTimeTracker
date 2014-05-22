using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FinckInc.Toolkit.Extensions
{
	public static class ReflectionExtensions
	{
		#region Type.Contains

		/// <summary>
		/// Returns the PropertyInfo for the given propertyName, via a case-insensitive search.
		/// </summary>
		/// <param name="propertyName">Name of property to find.</param>
		public static PropertyInfo FindProperty(this Type type, string propertyName)
		{
			foreach (PropertyInfo info in type.GetProperties())
			{
				if (string.Compare(info.Name, propertyName, true) == 0)
					return info;
			}
			return null;
		}

		#endregion

		#region Type.Contains

		public static bool ContainsProperty(this Type type, string propertyName)
		{
			return (type.FindProperty(propertyName) != null);
		}

		#endregion

		#region Type.IsNullableType
		/// <summary>
		/// Determines if the current Type is a Nullable<> generic.
		/// </summary>
		public static bool IsNullableType(this Type type)
		{
			return
				type.IsGenericType
			&& type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
		}
		#endregion

		#region PropertyInfo.SetValue
		/// <summary>
		/// Extends the PropertyInfo's SetValue() method by adding a type conversion before making the assignment.
		/// </summary>
		/// <param name="info">PropertyInfo of the property to be set.</param>
		/// <param name="instance">The instance of the object containing the property to be set.</param>
		/// <param name="value">The value to set the property to.</param>
		public static void SetValue(this PropertyInfo info, object instance, object value)
		{
			var targetType = info.PropertyType.IsNullableType()
				 ? Nullable.GetUnderlyingType(info.PropertyType)
				 : info.PropertyType;

			var convertedValue = value == null ? null : Convert.ChangeType(value, targetType);

			info.SetValue(instance, convertedValue, null);
		}
		#endregion
	}
}
