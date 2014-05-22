using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimeTracker.Classes
{
	public class RegistryManager
	{
		#region RegTool

		private RegistryTool _reg = null;
		protected RegistryTool RegTool
		{
			get
			{
				if (_reg == null)
					_reg = new RegistryTool();
				return _reg;
			}
			set { _reg = value; }
		}

		#endregion

		#region CurrentTask
		private string _currentTask = null;
		public string CurrentTask
		{
			get 
			{
				if (string.IsNullOrEmpty(_currentTask)) { _currentTask = (RegTool.Read(Resources.RegKey_CurrentTask) ?? string.Empty) as string; }
				return _currentTask;
			}
			set 
			{
				RegTool.Write(Resources.RegKey_CurrentTask, value);
				_currentTask = value;
			}
		}
		#endregion

		#region DataFilename
		private string _dataFilename = null;
		public string DataFilename
		{
			get 
			{
				if (string.IsNullOrEmpty(_dataFilename)) { _dataFilename = (RegTool.Read(Resources.RegKey_DataFilename) ?? string.Empty) as string; }
				return _currentTask;
			}
			set 
			{
				RegTool.Write(Resources.RegKey_DataFilename, value);
				_dataFilename = value;
			}
		}
		#endregion
	}
}
