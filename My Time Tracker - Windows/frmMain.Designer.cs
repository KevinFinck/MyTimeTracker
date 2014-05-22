namespace MyTimeTracker
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
			Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
			Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
			this.niSysTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.trayMenu_Start = new System.Windows.Forms.ToolStripMenuItem();
			this.trayMenu_Stop = new System.Windows.Forms.ToolStripMenuItem();
			this.trayMenu_EditProjects = new System.Windows.Forms.ToolStripMenuItem();
			this.trayMenu_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.trayMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grdTimeLog = new Telerik.WinControls.UI.RadGridView();
			this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
			this.mnuMain = new Telerik.WinControls.UI.RadMenu();
			this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
			this.mnuExit = new Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
			this.mnuEditProjects = new Telerik.WinControls.UI.RadMenuItem();
			this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
			this.mnuAbout = new Telerik.WinControls.UI.RadMenuItem();
			this.ctxProjectMenu = new Telerik.WinControls.UI.RadContextMenu(this.components);
			this.ctxPrjMnu_Edit = new Telerik.WinControls.UI.RadMenuItem();
			this.ctxPrjMnu_Delete = new Telerik.WinControls.UI.RadMenuItem();
			this.ctxPrjMnu_Add = new Telerik.WinControls.UI.RadMenuItem();
			this.timeRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.trayMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdTimeLog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mnuMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// niSysTray
			// 
			this.niSysTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.niSysTray.ContextMenuStrip = this.trayMenu;
			this.niSysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niSysTray.Icon")));
			this.niSysTray.Text = "Right-click to select a project to record time for.";
			this.niSysTray.MouseDown += new System.Windows.Forms.MouseEventHandler(this.niSysTray_MouseDown);
			// 
			// trayMenu
			// 
			this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenu_Start,
            this.trayMenu_Stop,
            this.trayMenu_EditProjects,
            this.trayMenu_Open,
            this.trayMenu_Exit});
			this.trayMenu.Name = "ctxSysTray";
			this.trayMenu.Size = new System.Drawing.Size(176, 114);
			// 
			// trayMenu_Start
			// 
			this.trayMenu_Start.Name = "trayMenu_Start";
			this.trayMenu_Start.Size = new System.Drawing.Size(175, 22);
			this.trayMenu_Start.Text = "&Create New Project";
			this.trayMenu_Start.Click += new System.EventHandler(this.trayMenu_Start_Click);
			// 
			// trayMenu_Stop
			// 
			this.trayMenu_Stop.Enabled = false;
			this.trayMenu_Stop.Name = "trayMenu_Stop";
			this.trayMenu_Stop.Size = new System.Drawing.Size(175, 22);
			this.trayMenu_Stop.Text = "Sto&p Project";
			this.trayMenu_Stop.Click += new System.EventHandler(this.trayMenu_Stop_Click);
			// 
			// trayMenu_EditProjects
			// 
			this.trayMenu_EditProjects.Name = "trayMenu_EditProjects";
			this.trayMenu_EditProjects.Size = new System.Drawing.Size(175, 22);
			this.trayMenu_EditProjects.Text = "&Edit Project List";
			this.trayMenu_EditProjects.Click += new System.EventHandler(this.trayMenu_EditProjects_Click);
			// 
			// trayMenu_Open
			// 
			this.trayMenu_Open.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.trayMenu_Open.Name = "trayMenu_Open";
			this.trayMenu_Open.Size = new System.Drawing.Size(175, 22);
			this.trayMenu_Open.Text = "&Open";
			this.trayMenu_Open.Click += new System.EventHandler(this.trayMenu_Open_Click);
			// 
			// trayMenu_Exit
			// 
			this.trayMenu_Exit.Name = "trayMenu_Exit";
			this.trayMenu_Exit.Size = new System.Drawing.Size(175, 22);
			this.trayMenu_Exit.Text = "E&xit";
			this.trayMenu_Exit.Click += new System.EventHandler(this.trayMenu_Exit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnSave.Location = new System.Drawing.Point(407, 478);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 32);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(560, 478);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 32);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// grdTimeLog
			// 
			this.grdTimeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdTimeLog.BackColor = System.Drawing.SystemColors.Control;
			this.grdTimeLog.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdTimeLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdTimeLog.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grdTimeLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.grdTimeLog.Location = new System.Drawing.Point(2, 22);
			// 
			// grdTimeLog
			// 
			this.grdTimeLog.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewComboBoxColumn1.DisplayMember = null;
			gridViewComboBoxColumn1.FieldName = "Project";
			gridViewComboBoxColumn1.FormatString = "";
			gridViewComboBoxColumn1.HeaderText = "Project Name";
			gridViewComboBoxColumn1.Name = "cmbProject";
			gridViewComboBoxColumn1.ValueMember = null;
			gridViewComboBoxColumn1.Width = 231;
			gridViewDateTimeColumn1.DataEditFormatString = "{0:g}";
			gridViewDateTimeColumn1.DataType = typeof(System.Nullable<System.DateTime>);
			gridViewDateTimeColumn1.FieldName = "StartTime";
			gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			gridViewDateTimeColumn1.FormatString = "";
			gridViewDateTimeColumn1.HeaderText = "Start Time";
			gridViewDateTimeColumn1.Name = "colStartTime";
			gridViewDateTimeColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
			gridViewDateTimeColumn1.Width = 150;
			gridViewDateTimeColumn2.DataType = typeof(System.Nullable<System.DateTime>);
			gridViewDateTimeColumn2.FieldName = "EndTime";
			gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			gridViewDateTimeColumn2.FormatString = "";
			gridViewDateTimeColumn2.HeaderText = "End Time";
			gridViewDateTimeColumn2.Name = "colEndTime";
			gridViewDateTimeColumn2.Width = 125;
			gridViewTextBoxColumn1.DataType = typeof(System.Nullable<System.TimeSpan>);
			gridViewTextBoxColumn1.FieldName = "Duration";
			gridViewTextBoxColumn1.FormatString = "{0:h\\:mm}";
			gridViewTextBoxColumn1.HeaderText = "Duration";
			gridViewTextBoxColumn1.Name = "colDuration";
			gridViewTextBoxColumn1.Width = 98;
			gridViewTextBoxColumn2.FieldName = "Description";
			gridViewTextBoxColumn2.FormatString = "";
			gridViewTextBoxColumn2.HeaderText = "Remarks";
			gridViewTextBoxColumn2.Name = "colRemarks";
			gridViewTextBoxColumn2.Width = 372;
			gridViewTextBoxColumn3.FieldName = "Project";
			gridViewTextBoxColumn3.FormatString = "";
			gridViewTextBoxColumn3.HeaderText = "Project";
			gridViewTextBoxColumn3.IsAutoGenerated = true;
			gridViewTextBoxColumn3.Name = "Project";
			gridViewTextBoxColumn3.Width = 48;
			this.grdTimeLog.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
			this.grdTimeLog.MasterTemplate.DataSource = this.timeRecordBindingSource;
			this.grdTimeLog.MasterTemplate.EnableAlternatingRowColor = true;
			this.grdTimeLog.MasterTemplate.MultiSelect = true;
			sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
			sortDescriptor1.PropertyName = "colStartTime";
			this.grdTimeLog.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
			this.grdTimeLog.Name = "grdTimeLog";
			this.grdTimeLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grdTimeLog.Size = new System.Drawing.Size(1040, 448);
			this.grdTimeLog.TabIndex = 4;
			this.grdTimeLog.Text = "Time Log";
			this.grdTimeLog.ThemeName = "Office2010Blue";
			this.grdTimeLog.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdTimeLog_CellEndEdit);
			this.grdTimeLog.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(this.grdTimeLog_CellValidating);
			this.grdTimeLog.CellValidated += new Telerik.WinControls.UI.CellValidatedEventHandler(this.grdTimeLog_CellValidated);
			this.grdTimeLog.DataError += new Telerik.WinControls.UI.GridViewDataErrorEventHandler(this.grdTimeLog_DataError);
			this.grdTimeLog.Validating += new System.ComponentModel.CancelEventHandler(this.grdTimeLog_Validating);
			((Telerik.WinControls.UI.RadGridViewElement)(this.grdTimeLog.GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
			// 
			// mnuMain
			// 
			this.mnuMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.mnuMain.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2,
            this.radMenuItem3});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Owner = null;
			this.mnuMain.Size = new System.Drawing.Size(1042, 21);
			this.mnuMain.TabIndex = 0;
			this.mnuMain.Text = "radMenu1";
			this.mnuMain.ThemeName = "Office2010Blue";
			// 
			// radMenuItem1
			// 
			this.radMenuItem1.AccessibleDescription = "&File";
			this.radMenuItem1.AccessibleName = "&File";
			this.radMenuItem1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuExit});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "&File";
			this.radMenuItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			// 
			// mnuExit
			// 
			this.mnuExit.AccessibleDescription = "radMenuItem2";
			this.mnuExit.AccessibleName = "radMenuItem2";
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// radMenuItem2
			// 
			this.radMenuItem2.AccessibleDescription = "&Edit";
			this.radMenuItem2.AccessibleName = "&Edit";
			this.radMenuItem2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuEditProjects});
			this.radMenuItem2.Name = "radMenuItem2";
			this.radMenuItem2.Text = "&Edit";
			this.radMenuItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			// 
			// mnuEditProjects
			// 
			this.mnuEditProjects.AccessibleDescription = "radMenuItem3";
			this.mnuEditProjects.AccessibleName = "radMenuItem3";
			this.mnuEditProjects.Name = "mnuEditProjects";
			this.mnuEditProjects.Text = "&Projects";
			this.mnuEditProjects.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			this.mnuEditProjects.Click += new System.EventHandler(this.mnuEditProjects_Click);
			// 
			// radMenuItem3
			// 
			this.radMenuItem3.AccessibleDescription = "&Help";
			this.radMenuItem3.AccessibleName = "&Help";
			this.radMenuItem3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuAbout});
			this.radMenuItem3.Name = "radMenuItem3";
			this.radMenuItem3.Text = "&Help";
			this.radMenuItem3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			// 
			// mnuAbout
			// 
			this.mnuAbout.AccessibleDescription = "&About";
			this.mnuAbout.AccessibleName = "&About";
			this.mnuAbout.Name = "mnuAbout";
			this.mnuAbout.Text = "&About";
			this.mnuAbout.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// ctxProjectMenu
			// 
			this.ctxProjectMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ctxPrjMnu_Edit,
            this.ctxPrjMnu_Delete,
            this.ctxPrjMnu_Add});
			// 
			// ctxPrjMnu_Edit
			// 
			this.ctxPrjMnu_Edit.AccessibleDescription = "&Edit Project";
			this.ctxPrjMnu_Edit.AccessibleName = "&Edit Project";
			this.ctxPrjMnu_Edit.Name = "ctxPrjMnu_Edit";
			this.ctxPrjMnu_Edit.Text = "&Edit Project";
			this.ctxPrjMnu_Edit.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			this.ctxPrjMnu_Edit.Click += new System.EventHandler(this.ctxPrjMnu_Edit_Click);
			// 
			// ctxPrjMnu_Delete
			// 
			this.ctxPrjMnu_Delete.AccessibleDescription = "&Delete Project";
			this.ctxPrjMnu_Delete.AccessibleName = "&Delete Project";
			this.ctxPrjMnu_Delete.Name = "ctxPrjMnu_Delete";
			this.ctxPrjMnu_Delete.Text = "&Delete Project";
			this.ctxPrjMnu_Delete.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			this.ctxPrjMnu_Delete.Click += new System.EventHandler(this.ctxPrjMnu_Delete_Click);
			// 
			// ctxPrjMnu_Add
			// 
			this.ctxPrjMnu_Add.AccessibleDescription = "&Add New Project";
			this.ctxPrjMnu_Add.AccessibleName = "&Add New Project";
			this.ctxPrjMnu_Add.Name = "ctxPrjMnu_Add";
			this.ctxPrjMnu_Add.Text = "&Add New Project";
			this.ctxPrjMnu_Add.Visibility = Telerik.WinControls.ElementVisibility.Visible;
			this.ctxPrjMnu_Add.Click += new System.EventHandler(this.ctxPrjMnu_Add_Click);
			// 
			// timeRecordBindingSource
			// 
			this.timeRecordBindingSource.DataSource = typeof(MyTimeTracker.Classes.TimeEntry);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(1042, 522);
			this.Controls.Add(this.mnuMain);
			this.Controls.Add(this.grdTimeLog);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "Time Tracker";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.trayMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdTimeLog)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mnuMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon niSysTray;
		private System.Windows.Forms.ContextMenuStrip trayMenu;
		private System.Windows.Forms.ToolStripMenuItem trayMenu_Stop;
		private System.Windows.Forms.ToolStripMenuItem trayMenu_Exit;
		private System.Windows.Forms.ToolStripMenuItem trayMenu_Open;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ToolStripMenuItem trayMenu_Start;
		private Telerik.WinControls.UI.RadGridView grdTimeLog;
		private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
		private System.Windows.Forms.BindingSource timeRecordBindingSource;
		private Telerik.WinControls.UI.RadMenu mnuMain;
		private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
		private Telerik.WinControls.UI.RadMenuItem mnuExit;
		private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
		private Telerik.WinControls.UI.RadMenuItem mnuEditProjects;
		private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
		private Telerik.WinControls.UI.RadMenuItem mnuAbout;
		private System.Windows.Forms.ToolStripMenuItem trayMenu_EditProjects;
		private Telerik.WinControls.UI.RadContextMenu ctxProjectMenu;
		private Telerik.WinControls.UI.RadMenuItem ctxPrjMnu_Edit;
		private Telerik.WinControls.UI.RadMenuItem ctxPrjMnu_Delete;
		private Telerik.WinControls.UI.RadMenuItem ctxPrjMnu_Add;
	}
}

