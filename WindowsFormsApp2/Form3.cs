using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form3: Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-A324J8C;Database=ders_takip;Trusted_Connection=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        public void listele()
        {
            da = new SqlDataAdapter("select*from DegerlendirmePage", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 anaSayfa = new Form4();
            anaSayfa.ShowDialog();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
