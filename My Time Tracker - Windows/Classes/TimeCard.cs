using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using FinckInc.Toolkit.Extensions;
using System.IO;

namespace MyTimeTracker.Classes
{
	public class TimeCard : XmlDataSourceBase
	{
		public TimeCard(string fullFilename) : base(new XmlDataSource(fullFilename), Resources.XMLRootNode)
		{
			//Categories    = new XMLHash<Category>(XMLDataSource, Resources.XMLNodeGroup_Categories, Resources.XMLNodeName_Category);
			Categories = new XmlCategories(XmlDataSource, Resources.XMLNodeGroup_Categories, Resources.XMLNodeName_Category);
			Projects = new XmlList<Project>(XmlDataSource, Resources.XMLNodeGroup_Projects, Resources.XMLNodeName_Project);
			TaskMgr       = new XmlList<Task>(XmlDataSource, Resources.XMLNodeGroup_Tasks, Resources.XMLNodeName_Task);
			TimeEntries   = new XmlList<TimeEntry>(XmlDataSource, Resources.XMLNodeGroup_TimeEntries, Resources.XMLNodeName_TimeEntry);
		}

		#region Properties

		//public XMLList<Category> Categories { get; private set; }
		public XmlCategories Categories { get; private set; }
		public XmlList<Project> Projects { get; private set; }
		public XmlList<Task> TaskMgr { get; private set; }
		public XmlList<TimeEntry> TimeEntries { get; private set; }

		//public Dictionary<string, Category> Categories { get { return categoryMgr.Categories; } }
		//public List<Project> Projects { get { return projectMgr.Projects; } }
		//public List<TimeEntry> TimeEntries { get { return timeEntryMgr.TimeEntries; } }

		#endregion

		#region Load

		public void Load()
		{
			XmlDataSource.Load();
		}

		#endregion

		#region Save

		public void Save()
		{
			Categories.Save();
			Projects.Save();
			TaskMgr.Save();
			TimeEntries.Save();

			XmlDataSource.Document.Save(XmlDataSource.FullFilename);

		}

		#endregion
	}
}
