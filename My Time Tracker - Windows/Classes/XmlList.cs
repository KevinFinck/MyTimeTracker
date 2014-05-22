using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class XmlList<T> : XmlItemsBase<T>
	{
		#region Constructor
		public XmlList(XmlDataSource xmlDataSource, string parentNodeName, string itemNodeName) : base(xmlDataSource, parentNodeName, itemNodeName) { }
		#endregion

		#region Items Replacement

		private List<T> _items = null;
		public List<T> Items
		{
			get
			{
				if (_items == null)
					_items = base.XmlList.ToList();
				return _items;
			}
			set { _items = value; }
		}

		#endregion
	}
}
