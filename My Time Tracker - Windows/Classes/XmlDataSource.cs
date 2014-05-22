using System;
using System.Xml.Linq;

namespace MyTimeTracker.Classes
{
	public class XmlDataSource
	{
		#region Constructors

		public XmlDataSource(string fullFilename)
		{
			FullFilename = fullFilename;
		}

		#endregion

		#region Properties

		#region FullFilename

		private string _fullFilename = null;
		public string FullFilename 
		{ 
			get { return _fullFilename; }
			private set
			{
				_fullFilename = value;
				Document = null;
			}
		}

		#endregion

		#region Document

		private XDocument _document = null;
		public XDocument Document 
		{	get
			{
				if (_document == null)
				{
					Load();
				}
				return _document;
			}
			private set { _document = value; }
		} 

		#endregion

		#endregion

		#region Load
		public void Load()
		{
			try
			{
				Document = XDocument.Load(FullFilename);
			}
			catch (Exception ex)
			{
				throw new ApplicationException(string.Format("Unable to load data file \"{0}\".", FullFilename), ex);
			}
		}
		#endregion
	}
}
