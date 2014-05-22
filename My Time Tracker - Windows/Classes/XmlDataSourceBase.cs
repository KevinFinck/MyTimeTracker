using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyTimeTracker.Classes
{
	public class XmlDataSourceBase
	{
		#region Constructors

		public XmlDataSourceBase(XmlDataSource xmlDataSource, string parentNodeName)
		{
			XmlDataSource = xmlDataSource;
			ParentNodeName = parentNodeName;
			ParentNode = XmlDataSource.Document.Root.Element(parentNodeName);
		}

		#endregion

		#region Properties

		public XmlDataSource XmlDataSource { get; private set; }
		public XElement ParentNode { get; private set; }
		public string ParentNodeName { get; private set; }

		#endregion
	}
}
