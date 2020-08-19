using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLStartUpTemplate1
{
    public partial class ModalDialog : Form
    {
        public ModalDialog()
        {
            InitializeComponent();
        }

        //property in c#
        public decimal Seed
        {
            get
            {
                return numericUpDown1Seed.Value;
            }
            set
            {
                numericUpDown1Seed.Value = value; 
            }

        }
        //public decimal GetSeed()
        //{
        //    return numericUpDown1Seed.Value;
        //}

        //public void SetSeed(decimal seed)
        //{
        //    numericUpDown1Seed.Value = seed; 
        //}


        private void ModalDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1OK_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1Seed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1Seed_Click(object sender, EventArgs e)
        {

        }

        private void button1Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
