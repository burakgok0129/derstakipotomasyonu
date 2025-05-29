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
    public partial class Form7: Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-A324J8C;Database=ders_takip;Trusted_Connection=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        public void listele()
        {
            da = new SqlDataAdapter("select*from DegerlendirmePage", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
           
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            listele();

        }
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "" || comboBox8.Text == "" || comboBox9.Text == "" || comboBox10.Text == "" || comboBox11.Text == "" || comboBox12.Text == "")
                {
                    MessageBox.Show("Tüm Alanları Giriniz", "Hata");
                }
                else
                {
                    cmd = new SqlCommand("insert into DegerlendirmePage(hft1,hft2,hft3,hft4,hft5,hft6,hft7,hft8,hft9,hft10,hft11,hft12,DeğerlendirmePuanı,KullanıcıAdı,AldıgıDers) values( @hft1,@hft2,@hft3,@hft4,@hft5,@hft6,@hft7,@hft8,@hft9,@hft10,@hft11,@hft12,@DeğerlendirmePuanı,@KullanıcıAdı,@AldıgıDers)", con);
                    cmd.Parameters.AddWithValue("@hft1", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@hft2", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@hft3", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@hft4", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@hft5", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@hft6", comboBox6.Text);
                    cmd.Parameters.AddWithValue("@hft7", comboBox7.Text);
                    cmd.Parameters.AddWithValue("@hft8", comboBox8.Text);
                    cmd.Parameters.AddWithValue("@hft9", comboBox9.Text);
                    cmd.Parameters.AddWithValue("@hft10", comboBox10.Text);
                    cmd.Parameters.AddWithValue("@hft11", comboBox11.Text);
                    cmd.Parameters.AddWithValue("@hft12", comboBox12.Text);
                    cmd.Parameters.AddWithValue("@DeğerlendirmePuanı", textBox2.Text);
                    cmd.Parameters.AddWithValue("@KullanıcıAdı", textBox1.Text);
                    cmd.Parameters.AddWithValue("@AldıgıDers", textBox3.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Listeye Eklendi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hatalı Bilgi Girildi\n\n" + ex.Message, "Hata Ekranı");
            }
            finally
            {
                con.Close();
                listele();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 anaSayfa = new Form6();
            anaSayfa.ShowDialog();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
