using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLStartUpTemplate1
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            //Read Settings (when accessing settings, assign to local variables, use them to change program)
            //panel1.BackColor = Properties.Settings.Default.PanelColor;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = panel1.BackColor; 

            if(DialogResult.OK == dlg.ShowDialog())
            {
                panel1.BackColor = dlg.Color;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
