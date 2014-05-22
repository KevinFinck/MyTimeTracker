using FinckInc.Toolkit.Extensions;
using MyTimeTracker.Properties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace MyTimeTracker.Classes
{
	//[XmlRoot(ElementName="myTask")]
	public class Task
	{
		#region Constructors
	
		public Task() { }

		public Task(string name, string projectName = null)
		{
			Name = name;
			ProjectName = projectName;
		}

		#endregion

		#region Properties

		public string Name { get; set; }

		[XmlAttribute]
		public string ProjectName { get; set; }

		#endregion
	}
}
