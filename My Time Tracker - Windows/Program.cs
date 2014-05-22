using MyTimeTracker.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyTimeTracker
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// TODO: Cool effects.
			//https://code.google.com/p/dot-net-transitions/

			// Create our custom context as our application core.
			TimeTrackerContext context = null;

			// Check to see if it's already running.
			try
			{
				if (!SingleInstance.Start()) 
				{
					MessageBox.Show(string.Format("An instance of {0} is already running.", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name), "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;		// Mutex not obtained so exit cuz another is running.
				} 

			}
			catch { }

			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				context = new TimeTrackerContext();

				// Run the application with the specific context. It will exit on user request.
				Application.Run(context);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Program Terminated Unexpectedly", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if ((context != null) && (context.MainNotifyIcon != null))
				context.MainNotifyIcon.Visible = false;

			// Release our mutex so this app can be restarted.
			SingleInstance.Stop();
		}
	}
}
