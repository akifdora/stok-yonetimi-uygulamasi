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
    public partial class userControlDepoDurum : UserControl
    {
        public userControlDepoDurum()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=stok_yonetim;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        String malzeme;
        List<int> kritikseviye = new List<int>();

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

        public void MalzemeCekme(String depoadi)
        {
            komut = new SqlCommand("Select * from malzeme WHERE depo='" + depoadi + "'", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["ad"]);
            }
            baglanti.Close();
            depoadi = null;
        }

        void Kumulatif(String malzeme)
        {
            komut = new SqlCommand("Select sum(g_miktar) as textBox2 from depo_durum_listesi where malzeme_adi='" + malzeme + "'", baglanti);
            baglanti.Open();
            textBox2.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }

        public void ComboTemizle()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
        }

        void Arama(string textBox4, DataGridView dgw)
        {
            da = new SqlDataAdapter("Select *From depo_durum_listesi where malzeme_adi LIKE '" + textBox4 + "%'", baglanti);
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

        public void DepoDurumDoldur()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * From depo_durum_listesi", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        public void KritikSeviye()
        {
            komut = new SqlCommand("SELECT * FROM malzeme", baglanti);

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kritikseviye.Add(Convert.ToInt32(dr["kritik_seviye"]));
            }
            baglanti.Close();
        }

        void Renklendirme()
        {
            if(dataGridView1.Rows[0].Cells["g_miktar"].Value != null)
            {
            for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells["g_miktar"].Value) < kritikseviye[i])
                {
                    renk.BackColor = Color.FromArgb(218, 0, 55);
                    renk.ForeColor = Color.White;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
            }
            
        }

        private void userControlDepoDurum_Load(object sender, EventArgs e)
        {
            DepoCekme();
            DepoDurumDoldur();
            KritikSeviye();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(62, 120, 138);
            dataGridView1.Columns[0].HeaderText = "Kod";
            dataGridView1.Columns[1].HeaderText = "Depo";
            dataGridView1.Columns[2].HeaderText = "Malzeme";
            dataGridView1.Columns[3].HeaderText = "Giriş  Miktarı";
            dataGridView1.Columns[4].HeaderText = "Giriş Tarihi";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            String depoadi = comboBox1.SelectedItem.ToString();
            MalzemeCekme(depoadi);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string sorgu = "Insert into depo_durum_listesi (depo_adi,malzeme_adi,g_miktar,g_tarih) values (@depo_adi,@malzeme_adi,@g_miktar,@g_tarih)";
                komut = new SqlCommand(sorgu, baglanti);
                if (comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == String.Empty)
                {
                    MessageBox.Show("Bütün bilgileri doldurmak zorundasınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    komut.Parameters.AddWithValue("@depo_adi", comboBox1.Text);
                    komut.Parameters.AddWithValue("@malzeme_adi", comboBox2.Text);
                    komut.Parameters.AddWithValue("@g_miktar", textBox3.Text);
                    komut.Parameters.AddWithValue("@g_tarih", dateTimePicker1.Value.Date);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Temizle();
                    baglanti.Close();
                    DepoDurumDoldur();
            }
        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Arama(textBox4.Text, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
                string sorgu = "Update depo_durum_listesi Set depo_adi=@depo_adi,malzeme_adi=@malzeme_adi,g_miktar=@g_miktar Where kod=@kod";
                komut = new SqlCommand(sorgu, baglanti);
                if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox1.Text == String.Empty || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == String.Empty)
                {
                    MessageBox.Show("Bütün bilgileri doldurmak zorundasınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToInt32(textBox3.Text) < 0)
                    {
                        MessageBox.Show("Kalan miktar sıfırın altında olamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@kod", textBox1.Text);
                        komut.Parameters.AddWithValue("@depo_adi", comboBox1.Text);
                        komut.Parameters.AddWithValue("@malzeme_adi", comboBox2.Text);
                        komut.Parameters.AddWithValue("@g_miktar", textBox3.Text);
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        Temizle();
                        baglanti.Close();
                        DepoDurumDoldur();
                    }
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Seçtiğiniz malzeme için yapmak istediğiniz işlem nedir?", "İŞLEM ONAYI", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (cevap == DialogResult.Yes)
            {
                string sorgu = "Delete From depo_durum_listesi Where kod=@kod";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kod", textBox1.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                Temizle();
                baglanti.Close();
                DepoDurumDoldur();
            }
            else if (cevap == DialogResult.No)
            {
                string sorgu = "Update depo_durum_listesi Set g_miktar=@g_miktar Where kod=@kod";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kod", textBox1.Text);
                komut.Parameters.AddWithValue("@g_miktar", 0);
                baglanti.Open();
                komut.ExecuteNonQuery();
                Temizle();
                baglanti.Close();
                DepoDurumDoldur();
            }
        }



        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Renklendirme();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            malzeme = comboBox2.SelectedItem.ToString();
            Kumulatif(malzeme);
        }
    }
}
