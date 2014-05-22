using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{

	class NonCaseStringComparer : IEqualityComparer<string>
	{
		public bool Equals(string value1, string value2)
		{
			return string.Equals(value1, value2, StringComparison.OrdinalIgnoreCase);
		}
		public int GetHashCode(string value)
		{
			return value.GetHashCode();
		}
	}
	class CategoryComparer : IEqualityComparer<Category>
	{
		public bool Equals(Category cat1, Category cat2)
		{
			return string.Equals(cat1.Name, cat2.Name, StringComparison.OrdinalIgnoreCase);
		}
		public int GetHashCode(Category cat)
		{
			return cat.Name.GetHashCode();
		}
	}

	public class XmlCategories : XmlItemsBase<Category>
	{
		#region Constructor
		public XmlCategories(XmlDataSource xmlDataSource, string parentNodeName, string itemNodeName) : base(xmlDataSource, parentNodeName, itemNodeName) { }
		#endregion

		#region Items Replacement

		private Dictionary<string, Category> _items = null;
		public Dictionary<string, Category> Items
		{
			get
			{
				if (_items == null)
				{
					NonCaseStringComparer eqComp = new NonCaseStringComparer();
					_items = new Dictionary<string, Category>(eqComp);
					_items = base.XmlList.Distinct(new CategoryComparer()).ToDictionary(cat => cat.Name);
					//var qry =
					//		from cat in base.XmlList
					//		select cat
					//		dist


					//_items = base.XmlList
					//			.GroupBy(item => item.Name)
					//			.ToDictionary(dic => dic.Key, dic => dic.ToList());
					//_items = base.XmlList.ToList();

					//var appliancesByType = stock
					//	.GroupBy(item => item.Type)
					//	.ToDictionary(grp => grp.Key, grp => grp.ToList());
	
				}
				return _items;
			}
			set { _items = value; }
		}

		#endregion

	}
}
