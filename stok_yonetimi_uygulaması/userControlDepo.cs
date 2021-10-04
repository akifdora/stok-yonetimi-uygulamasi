using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace stok_yonetimi_uygulaması
{
    public partial class userControlDepo : UserControl
    {
        public userControlDepo()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=stok_yonetim;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;

        void Arama(string textBox4, DataGridView dgw)
        {
            da = new SqlDataAdapter("Select *From depo where adi LIKE '" + textBox4 + "%'", baglanti);
            baglanti.Open();
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgw.DataSource = tablo;
            dgw.Refresh();
            baglanti.Close();
        }

        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        void DepoDoldur()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select *From depo", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void userControlDepo_Load(object sender, EventArgs e)
        {
            DepoDoldur();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(62, 120, 138);
            dataGridView1.Columns[0].HeaderText = "Kod";
            dataGridView1.Columns[1].HeaderText = "Depo";
            dataGridView1.Columns[2].HeaderText = "Sorumlu Kişiler";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Arama(textBox4.Text, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string sorgu = "Insert into depo (adi,sorumlu_kisiler) values (@adi,@sorumlu_kisiler)";
                komut = new SqlCommand(sorgu, baglanti);
                if (textBox2.Text == "" || textBox3.Text == "" || textBox2.Text == String.Empty || textBox3.Text == String.Empty)
                {
                    MessageBox.Show("Bütün bilgileri doldurmak zorundasınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    komut.Parameters.AddWithValue("@adi", textBox2.Text);
                    komut.Parameters.AddWithValue("@sorumlu_kisiler", textBox3.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Temizle();
                    baglanti.Close();
                    DepoDoldur();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                string sorgu = "Update depo Set adi=@adi,sorumlu_kisiler=@sorumlu_kisiler Where kod=@kod";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kod", textBox1.Text);
                komut.Parameters.AddWithValue("@adi", textBox2.Text);
                komut.Parameters.AddWithValue("@sorumlu_kisiler", textBox3.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                Temizle();
                baglanti.Close();
                DepoDoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From depo Where kod=@kod";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kod", textBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            Temizle();
            baglanti.Close();
            DepoDoldur();
        }
    }
}
