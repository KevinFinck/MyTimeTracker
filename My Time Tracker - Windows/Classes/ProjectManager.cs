using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MyTimeTracker.Classes
{
	public class ProjectManager : XmlDataSourceBase
	{
		#region Constructors
		public ProjectManager(XmlDataSource xmlDataSource) : base(xmlDataSource, Resources.XMLNodeName_Project) { }
		#endregion

		#region Properties

		private List<Project> _projects = null;
		public List<Project> Projects
		{
			get
			{
				if (_projects == null)
				{
					try
					{
						IEnumerable<Project> projects =
							from project in XmlDataSource.Document.Descendants(Resources.XMLNodeName_Project)
							select new Project
								{
									Name = project.Value,
									CategoryName = 
										(project.Attribute(Resources.XMLAttribute_Category) != null ?
											(string)project.Attribute(Resources.XMLAttribute_Category) :
											null
										)
								};
						_projects = projects.ToList<Project>();
					}
					catch (Exception ex)
					{
						throw new ApplicationException(string.Format("Unable to read {0} nodes from \"{1}\".", Resources.XMLNodeName_Project, XmlDataSource.FullFilename), ex);
					}
				}
				return _projects;
			}
			private set { _projects = value; }
		}

		#endregion
	}
}
