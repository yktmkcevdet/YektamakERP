using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FirmaTanimlamaPaneli_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = true;
        }
    }
}
