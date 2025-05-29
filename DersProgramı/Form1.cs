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

namespace DersProgramı
{
    public partial class Form1: Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-LH5U4S4;Database=BurakÖdev;Trusted_Connection=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        public void listele()
        {
            da = new SqlDataAdapter("select*from DersProgram", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        public void temizle()
        {
            textBox1.Text = "";
            pictureBox1.ImageLocation = "";

        }
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listele();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Tüm Alanları Giriniz", "Hata");
                }
                else
                {
                    cmd = new SqlCommand("insert into DersProgram(DersAdı,Resim) values(@DersAdı,@Resim)", con);
                    cmd.Parameters.AddWithValue("@DersAdı", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Resim", pictureBox1.ImageLocation);

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

        private void btnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "resim dosyalari |*.jpg; *.png";
            dosya.ShowDialog();
            pictureBox1.ImageLocation = dosya.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                temizle();
         
        }

        private void button2_Click(object sender, EventArgs e)
        
            {
                cmd = new SqlCommand("delete from DersProgram where DersAdı=@DersAdı", con);
                cmd.Parameters.AddWithValue("@DersAdı", textBox1.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Listeden Silindi!");
                listele();
            }
        }
   
}
