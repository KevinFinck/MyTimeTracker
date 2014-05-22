using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class Project
	{
		#region Constructor
		public Project() { }
		public Project(string name = null, string categoryName = null)
		{
			Name = name;
			CategoryName = categoryName;
		}
		#endregion

		#region Properties

		public string Name { get; set; }
		public string CategoryName { get; set; }

		#endregion
	}
}
