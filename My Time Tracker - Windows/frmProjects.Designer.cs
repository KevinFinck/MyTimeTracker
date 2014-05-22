namespace MyTimeTracker
{
    partial class frmProjects
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
			Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
			this.grdProjects = new Telerik.WinControls.UI.RadGridView();
			this.btnOK = new Telerik.WinControls.UI.RadButton();
			this.btnCancel = new Telerik.WinControls.UI.RadButton();
			((System.ComponentModel.ISupportInitialize)(this.grdProjects)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// grdProjects
			// 
			this.grdProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this.grdProjects.Cursor = System.Windows.Forms.Cursors.Default;
			this.grdProjects.Dock = System.Windows.Forms.DockStyle.Top;
			this.grdProjects.EnterKeyMode = Telerik.WinControls.UI.RadGridViewEnterKeyMode.EnterMovesToNextRow;
			this.grdProjects.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.grdProjects.ForeColor = System.Drawing.Color.Black;
			this.grdProjects.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.grdProjects.Location = new System.Drawing.Point(0, 0);
			// 
			// grdProjects
			// 
			this.grdProjects.MasterTemplate.AllowColumnReorder = false;
			this.grdProjects.MasterTemplate.AllowDragToGroup = false;
			this.grdProjects.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
			gridViewTextBoxColumn1.AllowGroup = false;
			gridViewTextBoxColumn1.FormatString = "";
			gridViewTextBoxColumn1.HeaderText = "Project Name";
			gridViewTextBoxColumn1.Name = "colProjectName";
			gridViewTextBoxColumn1.Width = 335;
			this.grdProjects.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
			this.grdProjects.MasterTemplate.EnableAlternatingRowColor = true;
			this.grdProjects.MasterTemplate.EnableGrouping = false;
			this.grdProjects.Name = "grdProjects";
			this.grdProjects.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// 
			// 
			this.grdProjects.RootElement.ForeColor = System.Drawing.Color.Black;
			this.grdProjects.ShowGroupPanel = false;
			this.grdProjects.Size = new System.Drawing.Size(356, 230);
			this.grdProjects.TabIndex = 0;
			this.grdProjects.Text = "radGridView1";
			this.grdProjects.ThemeName = "Office2010Blue";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnOK.Location = new System.Drawing.Point(46, 239);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(104, 29);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(207, 239);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 29);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmProjects
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(356, 277);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.grdProjects);
			this.Name = "frmProjects";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Projects";
			this.ThemeName = "ControlDefault";
			((System.ComponentModel.ISupportInitialize)(this.grdProjects)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private Telerik.WinControls.UI.RadGridView grdProjects;
		private Telerik.WinControls.UI.RadButton btnOK;
		private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
