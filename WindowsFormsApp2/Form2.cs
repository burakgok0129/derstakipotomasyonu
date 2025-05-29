using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-A324J8C;Database=ders_takip;Trusted_Connection=True;");
        SqlCommand cmd;
        SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
        }

        public void listele()
        {
            try
            {
                da = new SqlDataAdapter("SELECT * FROM DersProgramAdd", con);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablo getirilemedi: " + ex.Message, "Hata");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken hata oluştu: " + ex.Message, "Hata");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value?.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value?.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value?.ToString();
                pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[4].Value?.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Tüm alanları doldurunuz.", "Hata");
                    return;
                }

                cmd = new SqlCommand("INSERT INTO DersProgramAdd (DersAdı, DersHafta, DersSaat, Resim) VALUES (@DersAdı, @DersHafta, @DersSaat, @Resim)", con);
                cmd.Parameters.AddWithValue("@DersAdı", textBox1.Text);
                cmd.Parameters.AddWithValue("@DersHafta", textBox2.Text);
                cmd.Parameters.AddWithValue("@DersSaat", textBox3.Text);
                cmd.Parameters.AddWithValue("@Resim", pictureBox1.ImageLocation ?? "");

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Listeye eklendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hatalı bilgi girildi: " + ex.Message, "Hata Ekranı");
            }
            finally
            {
                con.Close();
                listele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim dosyaları |*.jpg;*.png;*.jpeg";
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dosya.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM DersProgramAdd WHERE DersAdı = @DersAdı", con);
                cmd.Parameters.AddWithValue("@DersAdı", textBox1.Text);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                    MessageBox.Show("Listeden silindi.");
                else
                    MessageBox.Show("Belirtilen ders bulunamadı.");

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız: " + ex.Message, "Hata");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 anaSayfa = new Form4();
            anaSayfa.ShowDialog();
            this.Hide();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
