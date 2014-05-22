/* *************************************** 
 *			 ModifyRegistry.cs
 * ---------------------------------------
 *         a very simple class 
 *    to read, write, delete and count
 *       registry values with C#
 * ---------------------------------------
 *      if you improve this code 
 *   please email me your improvement!
 * ---------------------------------------
 *         by Francesco Natali
 *        - fn.varie@libero.it -
 * ***************************************/

using System;			
using Microsoft.Win32;	
using System.Windows.Forms;

namespace MyTimeTracker
{
	/// <summary>
	/// An useful class to read/write/delete/count registry keys
	/// </summary>
	public class RegistryTool
	{
		private bool _showError = false;
		/// <summary>
		/// A property to show or hide error messages 
		/// (default = false)
		/// </summary>
		public bool ShowError
		{
			get { return _showError; }
			set	{ _showError = value; }
		}

		private string _subKey = "SOFTWARE\\" + Application.ProductName;
		/// <summary>
		/// A property to set the SubKey value
		/// (default = "SOFTWARE\\" + Application.ProductName.ToUpper())
		/// </summary>
		public string SubKey
		{
			get { return _subKey; }
			set	{ _subKey = value; }
		}

//		private RegistryKey baseRegistryKey = Registry.LocalMachine;
		private RegistryKey _baseRegistryKey = Registry.CurrentUser;
		/// <summary>
		/// A property to set the BaseRegistryKey value.
		/// (default = Registry.LocalMachine)
		/// </summary>
		public RegistryKey BaseRegistryKey
		{
			get { return _baseRegistryKey; }
			set	{ _baseRegistryKey = value; }
		}

		/* **************************************************************************
		 * **************************************************************************/

		/// <summary>
		/// To read a registry key.
		/// input: KeyName (string)
		/// output: value (string) 
		/// </summary>
		public object Read(string keyName)
		{
			// Opening the registry key
			RegistryKey rk = _baseRegistryKey ;
			
			// Open a subKey as read-only
			RegistryKey sk1 = rk.OpenSubKey(_subKey);
			
			// If the RegistrySubKey doesn't exist -> (null)
			if ( sk1 == null )
			{
				return null;
			}
			else
			{
				// If the RegistryKey exists I get its value
				// or null is returned.
				return sk1.GetValue(keyName);
			}
		}	

		/* **************************************************************************
		 * **************************************************************************/

		/// <summary>
		/// To write into a registry key.
		/// input: KeyName (string) , value (object)
		/// output: true or false 
		/// </summary>
		public bool Write(string keyName, object value)
		{
			// Setting
			RegistryKey reg = _baseRegistryKey ;
			
			// I have to use CreateSubKey 
			// (create or open it if already exits), 
			// 'cause OpenSubKey open a subKey as read-only
			RegistryKey sub = reg.CreateSubKey(_subKey);
			
			// Save the value
			if (sub == null)
				return false;
				
			sub.SetValue(keyName, value);

			return true;
		}

		/* **************************************************************************
		 * **************************************************************************/

		/// <summary>
		/// To delete a registry key.
		/// input: keyName (string)
		/// output: true or false 
		/// </summary>
		public bool DeleteKey(string keyName)
		{
			// Setting
			RegistryKey rk = _baseRegistryKey ;
			RegistryKey sk1 = rk.CreateSubKey(_subKey);
			// If the RegistrySubKey doesn't exists -> (true)
			if ( sk1 == null )
				return true;
			else
				sk1.DeleteValue(keyName);

			return true;
		}

		/* **************************************************************************
		 * **************************************************************************/

		/// <summary>
		/// To delete a sub key and any child.
		/// input: void
		/// output: true or false 
		/// </summary>
		public bool DeleteSubKeyTree()
		{
			try
			{
				// Setting
				RegistryKey rk = _baseRegistryKey ;
				RegistryKey sk1 = rk.OpenSubKey(_subKey);
				// If the RegistryKey exists, I delete it
				if ( sk1 != null )
					rk.DeleteSubKeyTree(_subKey);

				return true;
			}
			catch (Exception e)
			{
				// AAAAAAAAAAARGH, an error!
				ShowErrorMessage(e, "Deleting SubKey " + _subKey);
				return false;
			}
		}

		/* **************************************************************************
		 * **************************************************************************/

		/// <summary>
		/// Retrive the count of subkeys at the current key.
		/// input: void
		/// output: number of subkeys
		/// </summary>
		public int SubKeyCount()
		{
			try
			{
				// Setting
				RegistryKey rk = _baseRegistryKey ;
				RegistryKey sk1 = rk.OpenSubKey(_subKey);
				// If the RegistryKey exists...
				if ( sk1 != null )
					return sk1.SubKeyCount;
				else
					return 0; 
			}
			catch (Exception e)
			{
				// AAAAAAAAAAARGH, an error!
				ShowErrorMessage(e, "Retriving subkeys of " + _subKey);
				return 0;
			}
		}

		/* **************************************************************************
		 * **************************************************************************/

		/// <summary>
		/// Retrive the count of values in the key.
		/// input: void
		/// output: number of keys
		/// </summary>
		public int ValueCount()
		{
			try
			{
				// Setting
				RegistryKey rk = _baseRegistryKey ;
				RegistryKey sk1 = rk.OpenSubKey(_subKey);
				// If the RegistryKey exists...
				if ( sk1 != null )
					return sk1.ValueCount;
				else
					return 0; 
			}
			catch (Exception e)
			{
				// AAAAAAAAAAARGH, an error!
				ShowErrorMessage(e, "Retriving keys of " + _subKey);
				return 0;
			}
		}

		/* **************************************************************************
		 * **************************************************************************/
		
		private void ShowErrorMessage(Exception e, string title)
		{
			if (_showError == true)
				MessageBox.Show(e.Message,
				                title
				                ,MessageBoxButtons.OK
				                ,MessageBoxIcon.Error);
		}
	}
}