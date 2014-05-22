using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class MostRecentUsed<T>
	{
		#region Constants
		private string regKey_MaxItems = "MRU_MaxItems";
		private string regKey_ItemCount = "MRU_ItemCount";
		private string regKey_mruBaseName = "MRU_Item";
		#endregion

		public MostRecentUsed(int maxItems)
		{
			MaxItems = maxItems;
		}

		#region Properties

		private int _maxItems = 20;
		public int MaxItems
		{
			get { return _maxItems; }
			set
			{
				_maxItems = value;
				Registry.Write(regKey_MaxItems, value);
			}
		}

		private List<T> _items = new List<T>();
		public IEnumerable<T> Items { get { return _items; } }

		public int ItemCount { get { return _items.Count; } }

		private RegistryTool _registry = new RegistryTool();
		public RegistryTool Registry { get { return _registry; } }
		#endregion

		#region Methods

		public void Add(T item)
		{
			_items.Add(item);
			if (_items.Count > MaxItems)
			{
				for (int i = 0; i < _items.Count -1; i++)
				{
					_items[i] = _items[i + 1];
				}
				_items.RemoveAt(MaxItems);
			}
		}

		public void AddRange(IEnumerable<T> items)
		{
			if (items != null)
				_items.AddRange(items);
		}

		public void Insert(T item)
		{
			_items.Insert(0, item);
			if (_items.Count > MaxItems)
				_items.RemoveAt(MaxItems);
		}

		public bool Remove(T item)
		{
			return _items.Remove(item);
		}

		public void Clear() { _items.Clear(); }

		public virtual void Load()
		{
			Clear();

			int itemCount = 0;
			int.TryParse((Registry.Read(regKey_ItemCount) ?? 0).ToString(), out itemCount);

			T item;
			for (int i = 1; i <= itemCount; i++)
			{
				item = (T)Registry.Read(ItemName(i));
				if (item != null)
					Add(item);
			}
		}

		public virtual void Save()
		{
			// Save the number of current items.
			Registry.Write(regKey_ItemCount, _items.Count);

			// Write each item to the registry.
			int itemNumber = 0;
			foreach (T item in Items)
			{
				itemNumber++;
				Registry.Write(ItemName(itemNumber), item);
			}
		}

		private string ItemName(int itemNumber)
		{
			return string.Format("{0}{1}", regKey_mruBaseName, itemNumber);
		}
		#endregion

	}
}
