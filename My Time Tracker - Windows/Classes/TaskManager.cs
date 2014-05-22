using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyTimeTracker.Classes
{
	//public class TaskManager : XmlDataSourceBase
	public class zzTaskManager	// : XmlListBase<Task>
	{
		#region Constructors

		//public TaskManager(XMLDataSource xmlDataSource) : base(xmlDataSource, Resources.XMLNodeGroup_Tasks) { }
		//public TaskManager(XMLDataSource xmlDataSource, string parentNodeName, string itemNodeName) : base(xmlDataSource, parentNodeName, itemNodeName) { }

		#endregion

		#region Properties

		//private XmlListBase<Task> _tasks = null;
		//public XmlListBase<Task> Tasks
		

		/*
		private List<Task> _tasks = null;
		[XmlArray(ElementName="TaskList")]
		public List<Task> Tasks
		{
			get
			{
				if (_tasks == null)
				{
					try
					{
						IEnumerable<Task> tasks =
							from task in ParentNode.Descendants()
							select new Task
								{
									Name = task.Value,
									ProjectName =
										(task.Attribute(Resources.XMLAttribute_Project) != null ?
											(string)task.Attribute(Resources.XMLAttribute_Project) :
											null)

								};
						_tasks = tasks.ToList<Task>();
					}
					catch (Exception ex)
					{
						throw new ApplicationException(string.Format("Unable to read {0} nodes from \"{1}\".", ParentNodeName, XMLDataSource.FullFilename), ex);
					}
				}
				return _tasks;
			}
			private set { _tasks = value; }
		}
		*/


		//private XElementList<Task> _tasks = null;
		//public XElementList<Task> Tasks
		//{
		//	get
		//	{
		//		if (_tasks == null)
		//		{
		//			_tasks = new XElementList<Task>(ParentNode);
		//		}
		//		return _tasks;
		//	}
		//}


		#endregion


		#region Methods

		#region Save

		//public void Save()
		//{
			/*
			Tasks.Insert(0, new Task("I'm First!!!", "my project!"));

			// Serialize Tasks.
			XmlSerializer serializer = new XmlSerializer(Tasks.GetType());
			MemoryStream ms = new MemoryStream();
			serializer.Serialize(ms, Tasks);
			ms.Position = 0;
			XDocument taskDoc = XDocument.Load(ms);

			ParentNode.RemoveAll();
			ParentNode.Add(taskDoc.Root.Descendants("Task"));
	
			ms.Position = 0;
			List<Task> newTasks = serializer.Deserialize(ms) as List<Task>;
			*/


			//xml = sw.ToString();

			//XmlSerializer xml = new XmlSerializer(data.GetType());
			//StringWriter sw = new StringWriter();
			//xml.Serialize(sw, data);

			//using (var sr = new StreamReader(@"c:\test.xml"))
			//{
			//	var deserializer = new XmlSerializer(typeof(List<SimpleObject>));
			//	list = (List<SimpleObject>)deserializer.Deserialize(sr);
			//}
		//}

		#endregion

		#endregion

	}

}
