using System;
using System.Reflection;

namespace MyTimeTracker.Support
{
	// From: http://www.codeproject.com/Articles/32908/C-Single-Instance-App-With-the-Ability-To-Restore
	static public class ProgramInfo
	{
		static public string AssemblyGuid
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
				if (attributes.Length == 0)
				{
					return String.Empty;
				}
				return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
			}
		}
	}
}
