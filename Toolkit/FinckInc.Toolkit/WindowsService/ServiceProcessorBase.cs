using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using FinckInc.Toolkit.Extensions;

namespace FinckInc.Toolkit.WindowsService
{
	/// <summary>
	/// Base class for an object that will be used as a "processor" within a Windows Service.  In the
	/// service OnStart() method, the derived class of this would be instantiated and StartProcessing called.
	/// Note, this is setup for a single thread operation.
	/// </summary>
	public abstract class ServiceProcessorBase
	{
		#region Constructor

		public ServiceProcessorBase() { }
		public ServiceProcessorBase(EventLog serviceEventLog)
		{
			ServiceEventLog = serviceEventLog;
		}

		#endregion

		#region Abstract Properties

		/// <summary>
		/// LoggingSource used by logger.
		/// </summary>
		public abstract string LoggingSource { get; }

		/// <summary>
		/// Name of this process used by Heartbeat().
		/// </summary>
		public abstract string ProcessName { get; }

		/// <summary>
		/// Maximum number of milliseconds the system will wait for the main thread to stop processing upon request to halt.
		/// </summary>
		public virtual int StopProcessingTimeOut { get { return 300000; } } // Defaults to 5 minute maximum wait on Stop request.

		#endregion

		#region Properties

		protected static bool ThreadStopping = false;				// Flag for ProcessingThread, whether or not to continue.
		public Thread ProcessingThread { get; set; }

		public EventLog ServiceEventLog { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// This will start a thread running that MUST be shut down by calling StopMonitoring().
		/// </summary>
		public abstract void StartProcessing();

		/// <summary>
		/// This will start a thread running that MUST be shut down by calling StopMonitoring().
		/// </summary>
		public virtual void StartProcessing(ThreadStart threadDelegate, string threadName)
		{
			try
			{
				LogEvent("StartProcessing() called.");

				// Create an async thread for polling for responses, and start it.
				ProcessingThread = new Thread(threadDelegate);
				ProcessingThread.Name = threadName;
				ProcessingThread.IsBackground = false;
				ProcessingThread.Start();

				LogEvent("Process thread started.");
				Trace.WriteLine("Started thread: " + ProcessingThread.Name);
			}
			catch (Exception ex)
			{
				try
				{
					string err = string.Format("Error in StartProcessing(). {0}{1}", Environment.NewLine, ex.ToFullString());
					LogErrorEvent(err);
					Trace.WriteLine(err);
				}
				catch { }
			}
		}

		/// <summary>
		/// Called by OnStop of the Service, to halt current processing.
		/// </summary>
		public void StopProcessing()
		{
			try
			{
				ThreadStopping = true;
				if (ProcessingThread != null)
					ProcessingThread.Join(StopProcessingTimeOut);	// Give it up to 5 minutes to finish.

				LogEvent("Processing thread stopped.");
				Trace.WriteLine("Stopped thread: " + ProcessingThread.Name);
			}
			catch (Exception ex)
			{
				try
				{
					string err = string.Format("Error in StopProcessing(). {0}{1}", Environment.NewLine, ex.ToFullString());
					LogErrorEvent(err);
					Trace.WriteLine(err);
				}
				catch { }
			}
		}

		public virtual void LogErrorEvent(string message) { LogEvent(message, EventLogEntryType.Error); }
		public virtual void LogEvent(string message, EventLogEntryType eventType = EventLogEntryType.Information)
		{
			if (ServiceEventLog != null)
				ServiceEventLog.WriteEntry(message, eventType);
		}

		#endregion
	}
}
