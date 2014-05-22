using FinckInc.Toolkit.Extensions;
using MyTimeTracker.Classes;
using MyTimeTracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace MyTimeTracker
{
	public partial class frmMain : Form
	{
		#region Globals/Constants

		private bool formIsLoading = false;

		//public const string REGKEY_LASTPROJECT = "LastProject";
		public const int DEFAULT_MAXMRUITEMS = 20;

		#endregion

		#region Form Load

		public frmMain(TimeCard timeCard)
		{
			TimeCard = timeCard;
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			formIsLoading = true;

			InitializeControls();
			MinimizeToTray();
			formIsLoading = false;
			//ShowForm();
		}

		private void ShowError(Exception ex)
		{
			ShowError(ex.ToFullString());
		}
		private void ShowError(string errorMessage)
		{
			MessageBox.Show(errorMessage, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void InitializeControls()
		{
			try
			{
				this.Close();
				return;

				// Load the saved project list.
				//ProjectMRU.Add(DefaultProject);
				ProjectMRU.Load();
				UpdateProjectMenuItemsFromMRU();

				// Get last project used.
				// TODO: DefaultTaskName = (Registry.Read(REGKEY_LASTPROJECT) ?? "") as string;
			}
			catch (Exception ex)
			{
				ShowError(ex);
			}
			finally
			{
				DefaultTrayIcon = niSysTray.Icon;
				DefaultTrayToolTip = niSysTray.Text;
				niSysTray.BalloonTipText = Title;
				UpdateSysTrayIcon();
			}
		}

		#endregion Form Load

		#region Properties

		public string Title
		{
			get
			{
				Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
				return string.Format("Time Tracker {0}.{0}", ver.Major.ToString(), ver.Minor.ToString());
			}
		}

		public TimeCard TimeCard { get; set; }

		public string DefaultTaskName { get; set; }
		public string CurrentTaskName { get; set; }
		public DateTime? ProjectStartTime { get; set; }

		public Icon DefaultTrayIcon { get; set; }
		public string DefaultTrayToolTip { get; set; }

		#region MRU

		private List<ToolStripMenuItem> projectMenuItems = new List<ToolStripMenuItem>();

		private MostRecentUsed<string> _projectMRU = null;
		public MostRecentUsed<string> ProjectMRU
		{
			get
			{
				if (_projectMRU == null)
				{
					_projectMRU = new MostRecentUsed<string>(DEFAULT_MAXMRUITEMS);
				}
				return _projectMRU;
			}
			set { _projectMRU = value; }
		}

		#endregion MRU

		#endregion Properties


		#region Form Methods

		private void ShowForm()
		{
			if (WindowState != FormWindowState.Normal)
			{
				// Restore to normal windowed mode.
				this.WindowState = FormWindowState.Normal;
				Show();
			}
			this.ShowInTaskbar = true;
			niSysTray.Visible = false;

			// Load the Project combo.
			GridViewColumn col = grdTimeLog.Columns["cmbProject"];
			GridViewComboBoxColumn cmb = (col as GridViewComboBoxColumn);
			
			//TODO: Remove this debug code
			List<Project> projList = new List<Project>();
			foreach (string proj in ProjectMRU.Items)
			{
				projList.Add(new Project() { Name = proj });
			}

			cmb.DataSource = ProjectMRU.Items;
			cmb.DisplayMember = "Name";
			cmb.ValueMember = "Name";


			// Load the grid.
			grdTimeLog.DataSource = TimeCard.TimeEntries;
			if (grdTimeLog.Rows.Count > 0)
			{
				int selectRow = grdTimeLog.Rows.Count - 1;
				//grdTimeLog.CurrentRow = grdTimeLog.Rows[0];
				grdTimeLog.Rows[selectRow].IsCurrent = true;
				//grdTimeLog.Rows[selectRow].IsSelected = true;
			}
		}

		private void MinimizeToTray()
		{
			niSysTray.Visible = true;
			//niSysTray.Text = "Balloon Text that shows when minimized to tray for 2 seconds";

			if (this.WindowState != FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Minimized;
			}

			this.ShowInTaskbar = false;
		}

		public void ShutDown()
		{
			trayMenu.Close();
			niSysTray.Visible = false;
			StopProject(false);
			this.Refresh();
			this.Close();
			Application.Exit();
		}

		#endregion

		#region Form Events

		private void frmMain_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				MinimizeToTray();
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			niSysTray.Visible = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			MinimizeToTray();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult retval = MessageBox.Show("Are you sure you want to replace the time file with these changes?", "Overrite Time File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (retval == DialogResult.Yes)
			{
				TimeCard.Save();
				MinimizeToTray();
			}
		}

		private void mnuEditProjects_Click(object sender, EventArgs e)
		{
			EditProjects();
		}

		private void mnuAbout_Click(object sender, EventArgs e)
		{
			new frmAbout().ShowDialog();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			ShutDown();
		}

		#endregion Form Events


		#region Project Methods

		private string AddTask()
		{
			using (frmEditProject form = new frmEditProject())
			{
				form.Title = "New Project";
				DialogResult result = form.ShowDialog();
				if (result == DialogResult.OK)
				{
					AddTask(form.ProjectName);
					return form.ProjectName;
				}
			}
			return null;
		}

		private void AddTask(string name)
		{
			AddMRUItem(name);
			UpdateProjectMenuItemsFromMRU();
		}

		private void RemoveTask(string name)
		{
			if (string.Equals(name, CurrentTaskName, StringComparison.OrdinalIgnoreCase))
			{
				MessageBox.Show(string.Format("Cannot delete project \"{0}\" while it is the current project.", name), "Deleting Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ProjectMRU.Remove(name);
			ProjectMRU.Save();
			UpdateProjectMenuItemsFromMRU();
		}

		private void StartTask()
		{
			string projectName = AddTask();
			if (!string.IsNullOrEmpty(projectName))
			{
				StartTask(projectName);
			}
		}

		private void StartTask(string name)
		{
			if (CurrentTaskName != null)
			{
				StopProject(false);
			}

			if (string.IsNullOrEmpty(name))
			{
				niSysTray.ShowBalloonTip(1, "No Project Selected", "Please right-click and select a project to begin recording time.", ToolTipIcon.Error);
				//Point pos = new Point(trayMenu.Bounds.X, trayMenu.Bounds.Y);
				//trayMenu.Show(pos);
				//trayMenu_Project.Focus();
				return;
			}

			DefaultTaskName = name;
			CurrentTaskName = DefaultTaskName;

			ProjectStartTime = DateTime.Now;
			TimeCard.TimeEntries.Items.Add(new TimeEntry(startTime: ProjectStartTime, taskName: DefaultTaskName));

			trayMenu_Stop.Enabled = true;

			string msg = string.Format("{0} started {1}. Click to stop.", name, ProjectStartTime.Value.ToShortTimeString());
			msg = msg.Substring(0, Math.Min(msg.Length, 63));
			niSysTray.Text = msg;
			niSysTray.Icon = Properties.Resources.Hourglass_16;

			niSysTray.ShowBalloonTip(2, "Project Started", string.Format("Project {0} started at {1}.", name, ProjectStartTime.Value.ToShortTimeString()), ToolTipIcon.Info);
		}

		private void RenameProjectMRUItem(string oldName, string newName)
		{
			if (string.IsNullOrEmpty(oldName) || string.IsNullOrEmpty(newName))
				return;

			List<string> itemList = ProjectMRU.Items as List<string>;

			// See if list already contains the new name, and remove old one if it does.
			foreach (string item in itemList)
			{
				if (string.Compare(item, newName, true) == 0)
				{
					itemList.Remove(item);
					break;
				}
			}

			// Rename the old name.
			for (int i = 0; i < itemList.Count; i++)
			{
				if (string.Compare(itemList[i], oldName, true) == 0)
				{
					itemList[i] = newName;
					break;
				}
			}

			ProjectMRU.Save();
		}

		private void EditTask(string previousTaskName)
		{
			using (frmEditProject form = new frmEditProject())
			{
				form.Title = "Edit Project";
				form.ProjectName = previousTaskName;

				DialogResult result = form.ShowDialog();
				if ((result == DialogResult.OK) && (!string.IsNullOrEmpty(form.ProjectName)) && (form.ProjectName != previousTaskName))
				{
					//MessageBox.Show(string.Format("Changing project \"{0}\" to \"{1}\".", previousProjectName, form.ProjectName));
					// Change name in MRU
					RenameProjectMRUItem(previousTaskName, form.ProjectName);

					UpdateProjectMenuItemsFromMRU();

					// Change DefaultName if it's the same as old.
					if (string.Equals(DefaultTaskName, previousTaskName, StringComparison.OrdinalIgnoreCase))
						DefaultTaskName = form.ProjectName;

					//TODO: Change name in time records.
				}
			}
		}

		private void ValidateProjectMRU()
		{
			// If the current project was removed, add it back.
			if ((CurrentTaskName != null) && (!ProjectMRU.Items.Contains<string>(CurrentTaskName)))
			{
				ProjectMRU.Add(CurrentTaskName);
				MessageBox.Show(string.Format("Project \"{0}\" added back to the project list because it is the current project.", CurrentTaskName), "Project Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			// If the default project is no longer in the list, clear it.
			if ((DefaultTaskName != null) && (!ProjectMRU.Items.Contains<string>(DefaultTaskName)))
				DefaultTaskName = null;
		}

		public void EditProjects()
		{
			using (frmProjects frm = new frmProjects())
			{
				frm.ProjectList = (ProjectMRU.Items as List<string>);
				if (frm.ShowDialog() == DialogResult.OK)
				{
					// Reload MRU list from form's grid.
					ProjectMRU.Clear();
					ProjectMRU.AddRange(frm.ProjectList);

					ValidateProjectMRU();
					ProjectMRU.Save();

					// Now update the tray menu items.
					UpdateProjectMenuItemsFromMRU();
				}
			}
		}


		private void StopProject(bool showBalloon)
		{
			if (CurrentTaskName != null)
			{
				TimeSpan span = DateTime.Now.Subtract(ProjectStartTime.Value);
				TimeCard.Save();	//TODO: This needs new logic  ==>  .SaveTime(CurrentProject, ProjectStartTime, DateTime.Now);

				if (showBalloon)
				{
					niSysTray.ShowBalloonTip(2, CurrentTaskName + " Stopped", string.Format("Elapsed time: {0:00}:{1:00} minute(s).", span.Hours.ToString(), span.Minutes.ToString()), ToolTipIcon.Info);
				}
			}

			CurrentTaskName = null;
			ProjectStartTime = null;
			trayMenu_Stop.Enabled = false;

			niSysTray.BalloonTipText = null;
			UpdateSysTrayIcon();
		}

		#endregion

		#region Time Records

		private void LoadTimeRecord(TimeEntry timeRec)
		{
			if (!timeRec.StartTime.HasValue || timeRec.EndTime.HasValue)
				return;

			DefaultTaskName = timeRec.TaskName;
			CurrentTaskName = timeRec.TaskName;
			ProjectStartTime = timeRec.StartTime;

			trayMenu_Stop.Enabled = true;

			string msg = string.Format("{0} started {1}. Click to stop.", CurrentTaskName, ProjectStartTime.Value.ToShortTimeString());
			msg = msg.Substring(0, Math.Min(msg.Length, 63));
			niSysTray.Text = msg;
			niSysTray.Icon = Properties.Resources.Hourglass_16;

			niSysTray.ShowBalloonTip(2, "Project Started", string.Format("Project {0} started at {1}.", CurrentTaskName, ProjectStartTime.Value.ToShortTimeString()), ToolTipIcon.Info);
		}

		#endregion


		#region Project Menu Items

		private void AddMRUItem(string projectName)
		{
			ProjectMRU.Remove(projectName);
			ProjectMRU.Add(projectName);
			ProjectMRU.Save();
		}

		private void ClearProjectMenuItems()
		{
			foreach (ToolStripMenuItem item in projectMenuItems)
			{
				trayMenu.Items.Remove(item);
			}
			projectMenuItems.Clear();
		}

		private void UpdateProjectMenuItemsFromMRU()
		{
			bool menuWasEmpty = (projectMenuItems.Count == 0);
			ClearProjectMenuItems();

			int lastPos = -1;
			foreach (string project in ProjectMRU.Items)
			{
				// Create a new Menu Item.
				ToolStripMenuItem menuItem = new ToolStripMenuItem(project);
				menuItem.MouseDown += new MouseEventHandler(OnProjectMenuItemMouseDown);
				menuItem.MouseUp += new MouseEventHandler(OnProjectMenuItemMouseUp);

				// Add the menu item at the next position after the last "project" menu item.
				lastPos++;
				trayMenu.Items.Insert(lastPos, menuItem);

				// Add the menu item to our "list" so we know which one's to remove later.
				projectMenuItems.Add(menuItem);	
			}

			// Add a separator line if we've added our first item(s).
			if (menuWasEmpty && (lastPos >= 0))
				trayMenu.Items.Insert(lastPos + 1, new ToolStripSeparator());

		}

		#endregion

		#region Project Menu Item Events

		//public class ContextMenuContext : IDisposable
		//{
		//    public ContextMenuContext(ToolStripMenuItem item)
		//    {
		//        MenuItem = item;
		//    }

		//    ToolStripMenuItem MenuItem { get; set; }
		
		//    public void  Dispose()
		//    {
		//        this.Dispose();
		//    }
		//}
		public ToolStripMenuItem ContextItem = null;

		private void OnProjectMenuItemMouseDown(object sender, MouseEventArgs e)
		{
			ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
			if (e.Button == MouseButtons.Right)
			{
				ContextItem = menuItem;
				//TODO: How to use context pattern.
				//using (ContextMenuContext context = new ContextMenuContext(menuItem))	
				//{
				ctxProjectMenu.Show(Control.MousePosition);
				//}
				//ContextItem = null;
			}
		}

		private void OnProjectMenuItemMouseUp(object sender, MouseEventArgs e)
		{
			ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
			if (e.Button == MouseButtons.Left)
			{
				AddTask(menuItem.Text);
				StartTask(menuItem.Text);
			}

			if (e.Button == MouseButtons.Right)
			{
				//MessageBox.Show(string.Format("Remove '{0}' coming soon...", menuItem.Text));
				//ctxProjectMenu.Show(Control.MousePosition);
				//if (MessageBox.Show(string.Format("Remove project '{0}'?", menuItem.Text), "Remove Project", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				//{
				//    RemoveProject(menuItem.Text);
				//}
			}
		}

		private void ctxPrjMnu_Add_Click(object sender, EventArgs e)
		{
			AddTask();
		}

		private void ctxPrjMnu_Edit_Click(object sender, EventArgs e)
		{
			string projectName = (ContextItem == null) ? null : ContextItem.Text;
			ContextItem = null;
			ctxProjectMenu.Dispose();

			EditTask(projectName);
		}

		private void ctxPrjMnu_Delete_Click(object sender, EventArgs e)
		{
			string projectName = (ContextItem == null) ? null : ContextItem.Text;
			ContextItem = null;
			ctxProjectMenu.Dispose();

			if (string.Equals(CurrentTaskName, projectName, StringComparison.OrdinalIgnoreCase))
			{
				MessageBox.Show(string.Format("Cannot delete project \"{0}\" while it is the current project.", projectName), "Deleting Project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show(string.Format("Delete project \"{0}\"?", projectName), "Delete Project", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				RemoveTask(projectName);
			}
		}

		#endregion


		#region System Tray

		private void UpdateSysTrayIcon()
		{
			if (DefaultTaskName == null)
			{
				niSysTray.Icon = DefaultTrayIcon;
				niSysTray.Text = DefaultTrayToolTip;
			}
			else
			{
				niSysTray.Icon = Properties.Resources.Start_16;
				string msg = string.Format("Click to resume {0}.", DefaultTaskName);
				msg = msg.Substring(0, Math.Min(msg.Length, 63));
				niSysTray.Text = msg;
			} 
		}

		#endregion

		#region Tray Menu Events

		private void trayMenu_Open_Click(object sender, EventArgs e)
		{
			ShowForm();
		}

		private void trayMenu_Exit_Click(object sender, EventArgs e)
		{
			ShutDown();
		}


		private void trayMenu_Stop_Click(object sender, EventArgs e)
		{
			trayMenu.Close();
			StopProject(true);
		}

		#endregion

		#region System Tray Events

		private void niSysTray_Click(object sender, EventArgs e)
		{
			if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (ProjectStartTime.HasValue)
				{
					StopProject(true);
				}
				else
				{
					StartTask(DefaultTaskName);
				}
			}
		}

		private void niSysTray_DoubleClick(object sender, EventArgs e)
		{
			ShowForm();
		}

		private void niSysTray_MouseDown(object sender, MouseEventArgs e)
		{
			if(e.Clicks==1) 
			{ 
				//execute code for single click 
				niSysTray_Click(sender, e);
			} 
			
			if(e.Clicks==2) 
			{ 
				//execute code for double-click 
				niSysTray_DoubleClick(sender, e);
			}

		}

		private void trayMenu_Start_Click(object sender, EventArgs e)
		{
			StartTask();
		}

		private void trayMenu_EditProjects_Click(object sender, EventArgs e)
		{
			EditProjects();
		}

		#endregion Events

		#region Grid Events

		private void grdTimeLog_DataError(object sender, Telerik.WinControls.UI.GridViewDataErrorEventArgs e)
		{
			MessageBox.Show("That data sucks.");
		}

		private void grdTimeLog_Validating(object sender, CancelEventArgs e)
		{

		}

		private void grdTimeLog_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{

		}

		private void grdTimeLog_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
		{
			switch (Util.ToUpper(e.Column.Name))
			{
				case "COLSTARTNAME":
					break;

				default:
					break;
			}
		}

		private void grdTimeLog_CellValidated(object sender, Telerik.WinControls.UI.CellValidatedEventArgs e)
		{

		}

		#endregion


	}
}
