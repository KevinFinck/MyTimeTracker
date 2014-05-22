using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class Category
	{
		public Category() { }
		public Category(string name) { Name = name; }

		public string Name { get; set; }
	}
}
