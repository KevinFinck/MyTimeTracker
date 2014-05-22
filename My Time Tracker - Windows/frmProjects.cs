using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace MyTimeTracker
{
	public partial class frmProjects : Telerik.WinControls.UI.RadForm
	{
		public frmProjects()
		{
			InitializeComponent();
		}

		#region Properties

		//private List<string> _projectList = null;
		public List<string> ProjectList 
		{
			get	
			{
				List<string> projList = new List<string>();
				foreach (GridViewRowInfo row in grdProjects.Rows)
				{
					projList.Add(row.Cells[0].Value.ToString());
				}
				return projList; 
			}
			set 
			{ 
				//_projectList = value;
				grdProjects.DataSource = null;
				foreach (string project in value)
				{
					grdProjects.Rows.Add(project);
				}
				
			} 
		}

		#endregion

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Hide();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Hide();
		}
	
	}
}
