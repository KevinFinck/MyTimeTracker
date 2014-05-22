using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MyTimeTracker.Classes
{
	public class CategoryManager : XmlDataSourceBase
	{
		#region Constructors
		public CategoryManager(XmlDataSource xmlDataSource) : base(xmlDataSource, Resources.XMLNodeGroup_Categories) { }
		#endregion

		#region Properties

		private Dictionary<string, Category> _categories = null;
		public Dictionary<string, Category> Categories
		{
			get
			{
				if (_categories == null)
				{
					try
					{
						IEnumerable<Category> cats =
							from category in XmlDataSource.Document.Descendants(Resources.XMLNodeName_Category)
							select new Category(category.Value);
						_categories = cats.ToDictionary(cat => cat.Name);
					}
					catch (Exception ex)
					{
						throw new ApplicationException(string.Format("Unable to read {0} nodes from \"{1}\".", Resources.XMLNodeName_Category, XmlDataSource.FullFilename), ex);
					}
				}
				return _categories;
			}
			private set { _categories = value; }
		}

		#endregion

		public XElement CatToXML()
		{
			XElement catRoot = new XElement(Resources.XMLNodeGroup_Categories);
			return null;
		}
	}
}
