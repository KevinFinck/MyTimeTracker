using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class CategoryList : List<Category>
	{
		public CategoryList() {}
		public CategoryList(IEnumerable<Category> collection)
			//: base(collection)
		{
			foreach (Category item in collection)
			{
				Add(item);
			}
		}

		public new void Add(Category item)
		{
			// Check if it's null.
			if (item == null)
				return;

			// Check if it exists.
			foreach (Category cat in this)
			{
				if (string.Equals(cat.Name, item.Name, StringComparison.OrdinalIgnoreCase))
					return;
			}

			// If here, then we can add it.
			base.Add(item);
		}

	}
}
