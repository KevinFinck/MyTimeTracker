using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyTimeTracker.Classes
{
	public class XmlItemsBase<T>
	{
		#region Constructor

		public XmlItemsBase(XmlDataSource xmlDataSource, string parentNodeName, string itemNodeName)
		{
			ParentNodeName = parentNodeName;
			ItemNodeName = itemNodeName;
			XmlDataSource = xmlDataSource;
		}

		#endregion

		#region Properties

		public XmlDataSource XmlDataSource { get; private set; }

		private XElement _parentNode = null;
		public XElement ParentNode 
		{
			get
			{	
				if (_parentNode == null)
				{
					_parentNode = XmlDataSource.Document.Root.Element(ParentNodeName);
				}
				return _parentNode;
			}
			private set { _parentNode = value; }
		}
	
		public string ParentNodeName { get; private set; }
		public string ItemNodeName { get; set; }

		#region XmlList

		private IEnumerable<T> _xmlList = null;
		protected IEnumerable<T> XmlList
		{
			get
			{
				if (_xmlList == null)
				{
					if (ParentNode == null)
						_xmlList = new List<T>();
					else
					{
						try
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
							_xmlList = serializer.Deserialize(reader.ReadSubtree()) as List<T>;	//this gives serializer the part of XML that is for  the innerObject data

							reader.Close(); 
						}
						catch (Exception ex)
						{
							throw new ApplicationException(string.Format("Unable to read {0} nodes from \"{1}\".", ParentNodeName, XmlDataSource.FullFilename), ex);
						}
					}
				
				}
				return _xmlList;
			}
			private set { _xmlList = value; }
		}

		#endregion

		#endregion

		#region Save

		public void Save()
		{
			// Serialize Items.
			MemoryStream ms = new MemoryStream();
			XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(ParentNodeName));
			serializer.Serialize(ms, XmlList);
			ms.Position = 0;
			XDocument listDoc = XDocument.Load(ms);

			if (ParentNode == null)
			{
				ParentNode = new XElement(ParentNodeName);
				XmlDataSource.Document.Root.Add(ParentNode);
			}
			else
			{
				ParentNode.RemoveAll();
			}
			ParentNode.Add(listDoc.Root.Nodes());
		}

		#endregion
	}

}
