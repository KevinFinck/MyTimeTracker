using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyTimeTracker.Support
{
	// From: http://www.codeproject.com/Articles/32908/C-Single-Instance-App-With-the-Ability-To-Restore
	static public class SingleInstance
	{
		public static readonly int WM_SHOWFIRSTINSTANCE = WinAPI.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", ProgramInfo.AssemblyGuid);
		static Mutex mutex;

		static public bool Start()
		{
			bool onlyInstance = false;
			string mutexName = String.Format("Local\\{0}", ProgramInfo.AssemblyGuid);

			// if you want your app to be limited to a single instance
			// across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
			// string mutexName = String.Format("Global\\{0}", ProgramInfo.AssemblyGuid);

			mutex = new Mutex(true, mutexName, out onlyInstance);
			return onlyInstance;
		}
		static public void ShowFirstInstance()
		{
			WinAPI.PostMessage(
				(IntPtr)WinAPI.HWND_BROADCAST,
				WM_SHOWFIRSTINSTANCE,
				IntPtr.Zero,
				IntPtr.Zero);
		}
		static public void Stop()
		{
			mutex.ReleaseMutex();
		}
	}
}
