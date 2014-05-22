using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyTimeTracker
{
	public partial class frmEditProject : Form
	{
		public frmEditProject()
		{
			InitializeComponent();
		}

		public string Title 
		{
			get { return this.Text; }
			set { this.Text = value; }
		}
		
		public string ProjectName 
		{ 
			get { return txtProjectName.Text; }
			set { txtProjectName.Text = value; }
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Hide();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtProjectName.Text))
			{
				MessageBox.Show("Please enter a Project Name.", "Missing Project Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			this.DialogResult = DialogResult.OK;
			Hide();
		}
	}
}
