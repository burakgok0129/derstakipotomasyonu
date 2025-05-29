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

namespace WindowsFormsApp2
{
    public partial class Form1: Form
    {

        public Form1()
        {
            InitializeComponent();
        }
           private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-A324J8C;Database=ders_takip;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM YonetıcıPage", con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            bool sonuc = false;
            string KullaniciAdi = textBox2.Text.Trim();
            string sifre = textBox1.Text.Trim();

            while (dr.Read())
            {
                if (dr["KullanıcıAdı"].ToString().Trim() == KullaniciAdi && dr["Sifre"].ToString().Trim() == sifre)
                {
                    sonuc = true;
                    break;
                }
            }

            con.Close();

            if (sonuc)
            {
                MessageBox.Show("Giriş Başarılı", "Giriş Ekranı");
                Form4 form1 = new Form4();
                form1.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!", "Giriş Ekranı");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-A324J8C;Database=ders_takip;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM OgrenciPage", con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            bool sonuc = false;
            string KullaniciAdi = textBox3.Text.Trim();
            string sifre = textBox4.Text.Trim();

            while (dr.Read())
            {
                if (dr["KullanıcıAdı"].ToString().Trim() == KullaniciAdi && dr["Sifre"].ToString().Trim() == sifre)
                {
                    sonuc = true;
                    break;
                }
            }

            con.Close();

            if (sonuc)
            {
                MessageBox.Show("Giriş Başarılı", "Giriş Ekranı");
                Form6 dersPage = new Form6();
                dersPage.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!", "Giriş Ekranı");
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 kayıtOL = new Form5();
            kayıtOL.ShowDialog();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }
    }
 }

