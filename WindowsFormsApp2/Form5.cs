using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Form5: Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-A324J8C;Database=ders_takip;Trusted_Connection=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Tüm Alanları Giriniz", "Hata");
                }
                else
                {
                    cmd = new SqlCommand("insert into OgrenciPage(AdSoyad,KullanıcıAdı,Sifre,Maıl) values(@AdSoyad,@KullanıcıAdı,@Sifre,@Maıl )", con);
                    cmd.Parameters.AddWithValue("@AdSoyad", textBox1.Text);
                    cmd.Parameters.AddWithValue("@KullanıcıAdı", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Sifre", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Maıl", textBox4.Text);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üyeliğiniz Başarılı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hatalı Bilgi Girildi\n\n" + ex.Message, "Hata Ekranı");
            }
            finally
            {
                con.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anaSayfa = new Form1();
            anaSayfa.ShowDialog();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
