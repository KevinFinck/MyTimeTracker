using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class TestBase<T>
	{
		public int SomeProperty1 { get; set; }
		public int SomeProperty2 { get; set; }

		private IEnumerable<T> _items;
		public virtual IEnumerable<T> Items 
		{ 
			get
			{
				if (_items == null)
					_items = new List<T>();	// Do Work... (read XML child nodes as list of T)
				return _items;
			}
			set { _items = value; }
		}

	}

	public class Test : TestBase<int>
	{
		private List<int> _items = null;

		//public override IEnumerable<int> TestBase<int>.Items { get; set; }

		public new List<int> Items
		{
			get
			{
				return base.Items.ToList();
			}
			set
			{
				_items = value; 
			}
		}
	}

	//IEnumerable<int> Test<int>.Items
	//{
	//	get { return _items; }
	//	set { _items = value; }
	//}

	public class Tester
	{
		public Tester()
		{
			Test tst = new Test();
			List<int> lst = tst.Items;
			lst.Add(1);
		}
	}



	/*
	public class DoSomething : IDoSomething<int>
	{
		private IEnumerable<int> _values;

		IEnumerable<int> IDoSomething<int>.Values
		{
			get { return _values; }
			set { _values = value; }
		}

		public List<int> Values
		{
			get { return _values as List<int>; }
			set { _values = value; }
		}
	}
	*/

}
