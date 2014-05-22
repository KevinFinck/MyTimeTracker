using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyTimeTracker.Classes
{
	public class XmlManager
	{
		public XmlManager(XmlDataSource xmlDataSource, string parentNodeName, string itemNodeName)
		{
			ParentNodeName = parentNodeName;
			ItemNodeName = itemNodeName;
			XMLDataSource = xmlDataSource;
		}

		#region Properties

		public XmlDataSource XMLDataSource { get; private set; }

		private XElement _parentNode = null;
		public XElement ParentNode
		{
			get
			{
				if (_parentNode == null)
				{
					_parentNode = XMLDataSource.Document.Root.Element(ParentNodeName);
				}
				return _parentNode;
			}
			private set { _parentNode = value; }
		}

		public string ParentNodeName { get; private set; }
		public string ItemNodeName { get; set; }

		#endregion

		public IEnumerable<T> GetItems<T>()
		{
			// Create a reader for the XML section.
			XmlReader reader = ParentNode.CreateReader();
			reader.ReadToDescendant(ParentNodeName);		// Position where this list starts in the XML document.

			// Create an attribute that allows a null namespace.
			XmlRootAttribute xRoot = new XmlRootAttribute();
			xRoot.ElementName = ParentNodeName;
			xRoot.IsNullable = true;
			XmlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);

			// Now deserialize the XML data into our typed List<T>.
			var retval = serializer.Deserialize(reader.ReadSubtree()) as List<T>;	//this gives serializer the part of XML that is for  the innerObject data

			reader.Close();
			return retval;
		}

	}
}
