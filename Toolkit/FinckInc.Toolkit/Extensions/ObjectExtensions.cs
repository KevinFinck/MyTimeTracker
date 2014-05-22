using System;
using System.IO;
using System.Xml.Serialization;

namespace FinckInc.Toolkit.Extensions
{
	public static class ObjectExtensions
	{
		#region Object.ToXmlString

		public static string ToXmlString(this Object data)
		{
			if (data == null)
				return null;

			XmlSerializer xml = new XmlSerializer(data.GetType());
			StringWriter sw = new StringWriter();
			xml.Serialize(sw, data);

			return sw.ToString();
		}

		#endregion
	}
}
