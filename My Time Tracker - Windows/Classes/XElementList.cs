using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MyTimeTracker.Classes
{
	/*
	public class XElementList<T> : IList<T> where T: IXElementObject<T>, new()
	{
		#region Constructors

		public XElementList(XElement rootElement)
		{
			RootElement = rootElement;
		}

		#endregion

		#region Properties

		public XElement RootElement { get; set; }

		#endregion

		#region IList Methods

		public int IndexOf(T item)
		{
			if ((RootElement == null) || (item == null))
				return -1;

			int index = 0;
			foreach (XElement elem in RootElement.Descendants())
			{
				T tFromElem = new T();
				tFromElem.LoadFromElement(elem);
				if (item.Equals(tFromElem))
					return index;

				index++;
			}
			return -1;
		}

		public void Insert(int index, T item)
		{
			if (item == null)
				return;
			if (RootElement == null)
				throw new ApplicationException(string.Format("Error in Insert.  RootElement is not defined for {0} list.", typeof(T).Name));

			// If the tree is empty, add as first element regardless.
			if (!RootElement.HasElements)
			{
				RootElement.AddFirst(item.ToElement());
				return;
			}

			// Check if we're adding a new last element.
			if (index >= (Count - 1))
			{
				var last = RootElement.Nodes().Last();
				if (last != null)
					last.AddAfterSelf(item.ToElement());
				return;
			}

			// Auto-bug-fix if index is invalid.
			if (index < 0)
				index = 0;

			// Must be within the list, find it and insert above the found index.
			XElement nextElem = null;
			int i = 0;
			foreach (XElement elem in RootElement.Descendants())
			{
				if (i == index)
				{
					nextElem = elem;
					break;
				}
				i++;
			}
			if (nextElem == null)
				nextElem = RootElement;

			nextElem.AddBeforeSelf(item.ToElement());
		}

		public void RemoveAt(int index)
		{
			if ((index < 0) || (index > (Count - 1)))
				return;

			int i = 0;
			foreach (XElement elem in RootElement.Descendants())
			{
				if (i == index)
				{
					elem.Remove();
					break;
				}
				i++;
			}
		}

		public T this[int index]
		{
			get
			{
				if (index < 0)
					index = 0;
				if (index > Count - 1)
					index = Count - 1;

				int item = 0;
				foreach (XElement elem in RootElement.Descendants())
				{
					if (item == index)
					{
						T retval = new T();
						retval.LoadFromElement(elem);
						return retval;
					}

					item++;
				}
				return default(T);
			}
			set
			{
				if (index < 0)
					index = 0;
				if (index > Count - 1)
					index = Count - 1;
				throw new NotImplementedException();
			}
		}

		public void Add(T item)
		{
			if (item == null)
				return;
			if (RootElement == null)
				throw new ApplicationException(string.Format("Error in Add.  RootElement is not defined for {0} list.", typeof(T).Name));
			RootElement.Add(item.ToElement());
		}

		public void Clear()
		{
			if (RootElement == null)
				return;
			RootElement.RemoveAll();
		}

		public bool Contains(T item)
		{
			if (item == null)
				return false;
			return (IndexOf(item) >= 0);
		}

		public int Count
		{
			get 
			{
				if (RootElement != null)
					return RootElement.Descendants().Count();
				else
					return 0;
			}
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(T item)
		{
			if (item == null)
				return false;
			foreach (XElement elem in RootElement.Descendants())
			{
				T tFromElem = new T();
				tFromElem.LoadFromElement(elem);
				if (item.Equals(tFromElem))
				{
					elem.Remove();
					return true;
				}
			}
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			IEnumerable<T> tList =
				from node in RootElement.Descendants()
				select new T().LoadFromElement(node);

			return tList.GetEnumerator();
		}

		#region Not Implemented Methods

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		#endregion

		#endregion
	}
	*/
}
