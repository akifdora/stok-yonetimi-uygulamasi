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
    public partial class userControlMalzeme : UserControl
    {
        public userControlMalzeme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=stok_yonetim;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;

        void Arama(string textBox5, DataGridView dgw)
        {
            da = new SqlDataAdapter("Select *From malzeme where ad LIKE '"+textBox5+"%'", baglanti);
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
            comboBox1.SelectedItem = null;
            textBox3.Clear();
            textBox4.Clear();
        }

        public void DepoCekme()
        {
            komut = new SqlCommand("SELECT *FROM depo", baglanti);

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["adi"]);
            }
            baglanti.Close();
        }

        public void ComboTemizle()
        {
            comboBox1.Items.Clear();
        }

        public void MalzemeDoldur()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select *From malzeme", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void userControlMalzeme_Load(object sender, EventArgs e)
        {
            MalzemeDoldur();
            DepoCekme();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(62, 120, 138);
            dataGridView1.Columns[0].HeaderText = "Kod";
            dataGridView1.Columns[1].HeaderText = "Adı";
            dataGridView1.Columns[2].HeaderText = "Depo";
            dataGridView1.Columns[3].HeaderText = "Birim Fiyat";
            dataGridView1.Columns[4].HeaderText = "Kritik Seviye";
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string sorgu = "Insert into malzeme (ad,depo,fiyat,kritik_seviye) values (@ad,@depo,@fiyat,@kritik_seviye)";
                komut = new SqlCommand(sorgu, baglanti);
                if (textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox2.Text == String.Empty || comboBox1.Text == String.Empty || textBox3.Text == String.Empty || textBox4.Text == String.Empty)
                {
                    MessageBox.Show("Bütün bilgileri doldurmak zorundasınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    komut.Parameters.AddWithValue("@ad", textBox2.Text);
                    komut.Parameters.AddWithValue("@depo", comboBox1.Text);
                    komut.Parameters.AddWithValue("@fiyat", textBox3.Text);
                    komut.Parameters.AddWithValue("@kritik_seviye", textBox4.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Temizle();
                    baglanti.Close();
                    MalzemeDoldur();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                string sorgu = "Update malzeme Set ad=@ad,depo=@depo,fiyat=@fiyat,kritik_seviye=@kritik_seviye Where kod=@kod";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kod", textBox1.Text);
                komut.Parameters.AddWithValue("@ad", textBox2.Text);
                komut.Parameters.AddWithValue("@depo", comboBox1.Text);
                komut.Parameters.AddWithValue("@fiyat", textBox3.Text);
                komut.Parameters.AddWithValue("@kritik_seviye", textBox4.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                Temizle();
                baglanti.Close();
                MalzemeDoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From malzeme Where kod=@kod";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kod", textBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            Temizle();
            baglanti.Close();
            MalzemeDoldur();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Arama(textBox5.Text, dataGridView1);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
