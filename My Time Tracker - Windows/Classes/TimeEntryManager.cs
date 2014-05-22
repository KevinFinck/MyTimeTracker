using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MyTimeTracker.Classes
{
	public class TimeEntryManager : XmlDataSourceBase
	{
		#region Constructors
		public TimeEntryManager(XmlDataSource xmlDataSource) : base(xmlDataSource, Resources.XMLNodeName_TimeEntry) { }
		#endregion

		#region Properties

		#region TimeEntries

		private List<TimeEntry> _timeEntries = null;
		public List<TimeEntry> TimeEntries
		{
			get
			{
				if (_timeEntries == null)
				{
					try
					{
						IEnumerable<TimeEntry> times =
							from timeEntry in XmlDataSource.Document.Descendants(Resources.XMLNodeName_TimeEntry)
							select new TimeEntry
							{
								Description = timeEntry.Value,
								TaskName =
									(timeEntry.Attribute(Resources.XMLAttribute_Task) != null ?
										(string)timeEntry.Attribute(Resources.XMLAttribute_Category) :
										null
									)
							};
						_timeEntries = times.ToList<TimeEntry>();
					}
					catch (Exception ex)
					{
						throw new ApplicationException(string.Format("Unable to read {0} nodes from \"{1}\".", Resources.XMLNodeName_TimeEntry, XmlDataSource.FullFilename), ex);
					}
				}
				return _timeEntries;
			}
			private set { _timeEntries = value; }
		}

		#endregion
		
		#endregion
	}
}
