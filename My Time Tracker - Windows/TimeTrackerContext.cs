using MyTimeTracker.Classes;
using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MyTimeTracker
{
	/// <summary>
	/// Framework for running application as a tray app.
	/// </summary>
	/// <remarks>
	/// Tray app code adapted from "Creating Applications with NotifyIcon in Windows Forms", Jessica Fosler,
	/// http://windowsclient.net/articles/notifyiconapplications.aspx
	/// </remarks>
	public class TimeTrackerContext : ApplicationContext
	{
		// TODO: Size pop-up

		/*	CoreContext Life Cycle
		 *		Main: Calls Application.Run(..);
		 *		
		 *		exitItem_Click: Calls ExitThread
		 *		ExitThreadCore
		 *		Dispose
		 *		OnApplicationExit
		 *		
		 *		Application.Run() completes.
		 */
	
		#region Constructor

		/// <summary>
		/// This class should be created and passed into Application.Run( ... )
		/// </summary>
		public TimeTrackerContext()
		{
			InitializeContext();

			// Handle the ApplicationExit event to know when the application is exiting.
			Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

			//var x = new CancelEventHandler()

		}

		private void InitializeContext()
		{
			// Components
			components = new Container();

			// System tray icon.
			MainNotifyIcon = new NotifyIcon(components)
			{
				ContextMenuStrip = new ContextMenuStrip(),
				Icon = Properties.Resources.Clock_16,
				Text = DefaultTooltip,
				Visible = true
			};

			MainNotifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
			MainNotifyIcon.MouseUp += notifyIcon_MouseUp;
			//notifyIcon.DoubleClick += notifyIcon_DoubleClick;

			// Timecard.
			InitializeTimecard();
		}

		private void InitializeTimecard()
		{
			//TODO: DefaultTaskName = (Registry.Read(REGKEY_LASTPROJECT) ?? "") as string;

			string dataFilename = Registry.DataFilename;
			if (string.IsNullOrEmpty(dataFilename))
			{
				dataFilename = Path.Combine(Application.StartupPath, Resources.DefaultFilename);
				Registry.DataFilename = dataFilename;
			}
			TimeCard = new TimeCard(dataFilename);

			//TestTimeCard();
		}

		private void TestTimeCard()
		{
			int catCount = TimeCard.Categories.Items.Count();
			int prjCount = TimeCard.Projects.Items.Count();
			int tskCount = TimeCard.TaskMgr.Items.Count();
			int timeCount = TimeCard.TimeEntries.Items.Count();

			TimeCard.Categories.Items.Add("new test", new Category("new test"));
			TimeCard.Projects.Items.Add(new Project("New Project"));
			TimeCard.TaskMgr.Items.Add(new Task("New timecard entry"));
			TimeCard.TimeEntries.Items.Add(new TimeEntry(taskName: "This Task", description: "My time entry"));

			TimeCard.Save();
		}

		#endregion

		#region Private Members/Data

		private static readonly string DefaultTooltip = "My Time Tracker";
		private static readonly string TaskComboName = "cmbTaskName";
		private System.ComponentModel.IContainer components;	// A list of components to dispose when the context is disposed.
		public NotifyIcon MainNotifyIcon { get; set; }			// The icon that sits in the system tray.

		#endregion

		#region Properties

		#region Registry

		private RegistryManager _reg = null;
		public RegistryManager Registry
		{
			get
			{
				if (_reg == null)
					_reg = new RegistryManager();
				return _reg;
			}
			set { _reg = value; }
		}

		#endregion

		#region TimeCard
		public TimeCard TimeCard { get; set; }
		#endregion

		#region Tasks
		public ComboBox.ObjectCollection TaskItems { get { return ((TaskCombo != null) ? TaskCombo.Items : null); } }

		public string CurrentTask
		{
			get
			{
				if (TaskCombo.SelectedIndex > -1)
					return TaskCombo.Items[TaskCombo.SelectedIndex].ToString();
				else
					return null;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					TaskCombo.SelectedIndex = -1;
					return;
				}
				if (TaskCombo.Items.Contains(value))
				{
					int id = TaskCombo.FindString(value);
					TaskCombo.SelectedIndex = id;
				}
				else
				{
					int newID = TaskCombo.Items.Add(value);
					TaskCombo.SelectedIndex = newID;
				}

				// Update registry with current task.
				Registry.CurrentTask = value;
			}
		}
		#endregion

		#region TaskCombo
		private ToolStripComboBox _taskCombo = null;
		public ToolStripComboBox TaskCombo
		{
			get
			{
				if (_taskCombo != null)
					return _taskCombo;

				if ((MainNotifyIcon != null) && (MainNotifyIcon.ContextMenuStrip != null))
				{
					var cmb = MainNotifyIcon.ContextMenuStrip.Items.Find(TaskComboName, true).FirstOrDefault();
					_taskCombo = (ToolStripComboBox)cmb;
				}

				return _taskCombo;
			}
			set { _taskCombo = value; }
		}
		#endregion

		#endregion

		#region NotifyIcon Event Handlers

		private void notifyIcon_Click(object sender, MouseEventArgs e)
		{
			// Kill normal click event.
		}

		// From http://stackoverflow.com/questions/2208690/invoke-notifyicons-context-menu
		private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
		{
		
			if (e.Button == MouseButtons.Right)
			{
				MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
				mi.Invoke(MainNotifyIcon, null);
			}
			else if (e.Button == MouseButtons.Left)
			{
				MessageBox.Show("Test");
			}
		}

		/*
		NotifyIcon1.Click +=new System.EventHandler(NotifyIcon1_Click);
			}


			// When user clicks the left mouse button display the shortcut menu.   
			// Use the SystemInformation.PrimaryMonitorMaximizedWindowSize property 
			// to place the menu at the lower corner of the screen. 
			private void NotifyIcon1_Click(object sender, System.EventArgs e)
			{
				System.Drawing.Size windowSize = 
					SystemInformation.PrimaryMonitorMaximizedWindowSize;
				System.Drawing.Point menuPoint = 
					new System.Drawing.Point(windowSize.Width-180, 
					windowSize.Height-5);
				menuPoint = this.PointToClient(menuPoint);

				NotifyIcon1.ContextMenu.Show(this, menuPoint);
		
			}
		 * */

		#endregion

		#region ContextMenuStrip Event Handlers

		private bool menuLoaded = false;
		private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (TaskCombo != null)
			{
				MainNotifyIcon.ContextMenuStrip.Focus();
				TaskCombo.Focus();
			}
			if (menuLoaded)
			{
				return;
			}

			e.Cancel = false;
			var menuItems = MainNotifyIcon.ContextMenuStrip.Items;
			menuItems.Clear();

			menuItems.Add(CreateTaskCombo());
			menuItems.Add(new ToolStripSeparator());

			menuItems.Add("&Debug: Show Items", null, Debug_ShowItems_Click);
			menuItems.Add("&Timesheet", null, ShowMainForm_Click);
			menuItems.Add("&About", null, ShowAboutForm_Click);
			menuItems.Add(new ToolStripSeparator());

			menuItems.Add("E&xit", null, exitItem_Click);

			menuLoaded = true;
		}
		private void Debug_ShowItems_Click(object sender, EventArgs e)
		{
			MessageBox.Show(string.Format(
				"Selected Item: {0}" + Environment.NewLine +
				"Selected Index: {1}" + Environment.NewLine +
				"Selected Text: {2}" + Environment.NewLine +
				"Items:" + Environment.NewLine + "{3}",
				TaskCombo.SelectedItem,
				TaskCombo.SelectedIndex,
				TaskCombo.SelectedText,
				ToFullString(TaskCombo.Items)));
		}
		private string ToFullString(ComboBox.ObjectCollection items)
		{
			StringBuilder sb = new StringBuilder();
			foreach (Object item in items)
			{
				sb.AppendLine("\t" + item.ToString());
			}
			return sb.ToString();
		}

		public ToolStripComboBox CreateTaskCombo()
		{
			// http://www.codeproject.com/Articles/3513/Multi-Column-ComboBox

			ToolStripComboBox cmbTasks = new ToolStripComboBox();
			TaskCombo = cmbTasks;

			// Set properties
			cmbTasks.Name = "cmbTasks";
			cmbTasks.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cmbTasks.AutoCompleteSource = AutoCompleteSource.CustomSource;
			cmbTasks.IntegralHeight = true;
			cmbTasks.MaxDropDownItems = 9;
			cmbTasks.MergeAction = MergeAction.Insert;
			cmbTasks.Sorted = false;
			cmbTasks.Size = new System.Drawing.Size(300, 25);	//
			//cmbTasks.DropDownHeight = 110;
			//cmbTasks.DropDownWidth = 122;
			cmbTasks.FlatStyle = FlatStyle.Standard;

			// Add events
			cmbTasks.KeyDown += cmbTasks_KeyDown;
			cmbTasks.SelectedIndexChanged += cmbTasks_SelectedIndexChanged;

			// Add items
			Object[] taskList = new Object[] 
			{
				"Task 1",
				"Task 2"
			};
			cmbTasks.Items.AddRange(taskList);

			return cmbTasks;
		}

		void cmbTasks_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if ((TaskCombo.Text.Length > 0) && (!TaskCombo.Items.Contains(TaskCombo.Text)))
				{
					int newID = TaskCombo.Items.Add(TaskCombo.Text);
					TaskCombo.SelectedIndex = newID;
				}
			}
		}

		void cmbTasks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (TaskCombo.SelectedIndex > -1)
			{
				MainNotifyIcon.ContextMenuStrip.Close();
				MessageBox.Show("Starting task: " + CurrentTask);
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// When the application is exiting, cleanup and shut down.
		/// </summary>
		private void OnApplicationExit(object sender, EventArgs e)
		{
			try
			{
				// WriteFormDataToFile();
				// userData.Close();
			}
			catch { }
		}

		#endregion

		#region Forms

		#region TimesheetForm
		private frmMain TimesheetForm { get; set; }
		private void ShowMainForm_Click(object sender, EventArgs e) { ShowMainForm(); }
		private void MainForm_Closed(object sender, EventArgs e) { TimesheetForm = null; }
		private void ShowMainForm()
		{
			if (TimesheetForm == null)
			{
				TimesheetForm = new frmMain(TimeCard);
				TimesheetForm.Closed += MainForm_Closed; // avoid reshowing a disposed form
				TimesheetForm.Show();
			}
			else { TimesheetForm.Activate(); }
		}
		#endregion

		#region EditProjectForm
		private frmMain EditProjectForm { get; set; }
		private void ShowEditProjectForm_Click(object sender, EventArgs e) { ShowEditProjectForm(); }
		private void EditProjectForm_Closed(object sender, EventArgs e) { TimesheetForm = null; }
		private void ShowEditProjectForm()
		{
			if (EditProjectForm == null)
			{
				EditProjectForm = new frmMain(TimeCard);
				EditProjectForm.Closed += MainForm_Closed; // avoid reshowing a disposed form
				EditProjectForm.Show();
			}
			else { EditProjectForm.Activate(); }
		}
		#endregion

		#region AboutForm
		private frmAbout AboutForm { get; set; }
		private void ShowAboutForm_Click(object sender, EventArgs e) { ShowAboutForm(); }
		private void FormAbout_Closed(object sender, EventArgs e) { AboutForm = null; }
		private void ShowAboutForm()
		{
			if (AboutForm == null)
			{
				AboutForm = new frmAbout();
				AboutForm.Closed += FormAbout_Closed; // avoid reshowing a disposed form
				AboutForm.Show();
			}
			else { AboutForm.Activate(); }
		}
		#endregion

		/*
		// attach to context menu items
		private void showOptionsItem_Click(object sender, EventArgs e)  { ShowOptionsForm();  }
		private OptionsForm optionsForm;
		private void ShowOptionsForm()
		{
			if (optionsForm == null)
			{
				optionsForm = new OptionsForm();
				optionsForm.Closed += optionsForm_Closed; // avoid reshowing a disposed form
				optionsForm.Show();
			}
			else { optionsForm.Activate(); }
		}
		// null out the forms so we know to create a new one.
		private void optionsForm_Closed(object sender, EventArgs e)     { optionsForm = null; }
		*/

		#endregion

		#region Generic Code Framework

		/// <summary>
		/// When the application context is disposed, dispose things like the notify icon.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			// Note: Calling base.Dispose() calls this method, endless loop.
			if (disposing && components != null) 
				components.Dispose();
		}

		/// <summary>
		/// When the exit menu item is clicked, make a call to terminate the ApplicationContext.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitItem_Click(object sender, EventArgs e)
		{
			ExitThread();
		}

		/// <summary>
		/// If we are presently showing a form, clean it up.
		/// </summary>
		protected override void ExitThreadCore()
		{
			// before we exit, let forms clean themselves up.
			//if (introForm != null) { introForm.Close(); }
			//if (detailsForm != null) { detailsForm.Close(); }

			MainNotifyIcon.Visible = false; // should remove lingering tray icon
			base.ExitThreadCore();
		}

		# endregion generic code framework




		#region Sample Code

		/*
			http://msdn.microsoft.com/en-us/library/system.windows.forms.applicationcontext(v=vs.110).aspx
		 * 
		 * 
			// Handle the ApplicationExit event to know when the application is exiting.
			Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

			try {
				// Create a file that the application will store user specific data in.
				userData = new FileStream(Application.UserAppDataPath + "\\appdata.txt", FileMode.OpenOrCreate);

			} catch(IOException e) {
				// Inform the user that an error occurred.
				MessageBox.Show("An error occurred while attempting to show the application." + 
								"The error is:" + e.ToString());

				// Exit the current thread instead of showing the windows.
				ExitThread();
			}
		 * 
		 * 
			private void OnFormClosing(object sender, CancelEventArgs e) {
				// When a form is closing, remember the form position so it 
				// can be saved in the user data file. 
				if (sender is AppForm1) 
					form1Position = ((Form)sender).Bounds;
				else if (sender is AppForm2)
					form2Position = ((Form)sender).Bounds;
			}
		 * 
		 * 
			// Get the form positions based upon the user specific data. 
			if (ReadFormDataFromFile()) {
				// If the data was read from the file, set the form 
				// positions manually.
				form1.StartPosition = FormStartPosition.Manual;
				form2.StartPosition = FormStartPosition.Manual;

				form1.Bounds = form1Position;
				form2.Bounds = form2Position;
			}
		*/
		#endregion

	}

}
