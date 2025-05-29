using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form6: Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 siberGüven = new Form7();
            siberGüven.ShowDialog();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 adminPage = new Form1();
            adminPage.ShowDialog();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form8 java = new Form8();
            java.ShowDialog();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 Python = new Form9();
           Python.ShowDialog();
            this.Hide();
        }
    }
}
