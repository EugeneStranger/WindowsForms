using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace WindowsForms
{
	public partial class Font : Form
	{
		public System.Drawing.Font NewFont { get; set; }
		public System.Drawing.Font OldFont { get; set; }

		public Font(System.Drawing.Font oldFont)
		{
			InitializeComponent();
			if(Directory.GetCurrentDirectory().Contains("bin"))Directory.SetCurrentDirectory("..\\..\\Fonts");
			string currentDirectory = Directory.GetCurrentDirectory();
			//MessageBox.Show(this, currentDirectory, "Current directory",MessageBoxButtons.OK);
			foreach(string i in Directory.GetFiles(currentDirectory))
			{
				if(i.Split('\\').Last().Contains(".ttf"))this.cbFont.Items.Add(i.Split('\\').Last());
			}
			OldFont = oldFont;
			numericUpDownFontSize.Value = (decimal)OldFont.Size;
			cbFont.SelectedItem = oldFont.Name;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			//NewFont.Size = (int)numericUpDownFontSize.Value;
			OldFont = NewFont;
			this.Close();
		}

		private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			PrivateFontCollection pfs = new PrivateFontCollection();
			pfs.AddFontFile(cbFont.SelectedItem.ToString());
			NewFont = new System.Drawing.Font(pfs.Families[0], (int)numericUpDownFontSize.Value);
			//NewFont = new System.Drawing.Font(pfs.Families[0], lblExample.Font.Size);
			lblExample.Font = NewFont;
		}
	}
}
