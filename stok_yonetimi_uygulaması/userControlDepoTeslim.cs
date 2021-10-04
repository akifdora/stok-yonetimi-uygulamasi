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
    public partial class userControlDepoTeslim : UserControl
    {
        public userControlDepoTeslim()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=stok_yonetim;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        String malzeme;
        List<int> malzemekalanmiktar = new List<int>();
        int index;

        void Arama(string textBox5, DataGridView dgw)
        {
            da = new SqlDataAdapter("Select *From depo_teslim where malzeme LIKE '" + textBox5 + "%'", baglanti);
            baglanti.Open();
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgw.DataSource = tablo;
            dgw.Refresh();
            baglanti.Close();
        }

        void KumulatifMalzeme(String malzeme)
        {
            komut = new SqlCommand("Select sum(cikis_miktari) as textBox2 from depo_teslim where malzeme='" + malzeme + "'", baglanti);
            baglanti.Open();
            textBox2.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }

        void DepoTeslimDoldur()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * From depo_teslim", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        public void DepoCekme()
        {
            komut = new SqlCommand("SELECT * FROM depo", baglanti);

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
            komut = new SqlCommand("Select * from depo_durum_listesi WHERE depo_adi='"+ depoadi +"' order by g_tarih",baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["malzeme_adi"]);
                malzemekalanmiktar.Add(int.Parse(dr["g_miktar"].ToString()));
            }
            baglanti.Close();
            depoadi = null;
        }

       public void Temizle()
        {
            textBox1.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void userControlDepoTeslim_Load(object sender, EventArgs e)
        {
            DepoTeslimDoldur();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(62, 120, 138);
            dataGridView1.Columns[0].HeaderText = "Kod";
            dataGridView1.Columns[1].HeaderText = "Depo";
            dataGridView1.Columns[2].HeaderText = "Malzeme";
            dataGridView1.Columns[3].HeaderText = "Çıkış Miktarı";
            dataGridView1.Columns[4].HeaderText = "Teslim Alan Kişi";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Arama(textBox5.Text, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                
                if (int.Parse(textBox3.Text) > malzemekalanmiktar[index])
                    {
                        MessageBox.Show("Çıkış miktarı depoda kalan miktardan fazla olamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string sorgu = "Insert into depo_teslim (depo,malzeme,cikis_miktari,teslim_alan_kisi) values (@depo,@malzeme,@cikis_miktari,@teslim_alan_kisi)";
                        komut = new SqlCommand(sorgu, baglanti);
                        if (comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == String.Empty || textBox4.Text == String.Empty)
                        {
                            MessageBox.Show("Bütün bilgileri doldurmak zorundasınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("@depo", comboBox1.Text);
                            komut.Parameters.AddWithValue("@malzeme", comboBox2.Text);
                            komut.Parameters.AddWithValue("@cikis_miktari", textBox3.Text);
                            komut.Parameters.AddWithValue("@teslim_alan_kisi", textBox4.Text);
                            baglanti.Open();
                            komut.ExecuteNonQuery();

                            baglanti.Close();
                            DepoTeslimDoldur();
                            Temizle();
                        }
                    }
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Update depo_teslim Set depo=@depo,malzeme=@malzeme,cikis_miktari=@cikis_miktari,teslim_alan_kisi=@teslim_alan_kisi Where kod=@kod";
            komut = new SqlCommand(sorgu, baglanti);
            if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox1.Text == String.Empty || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == String.Empty || textBox4.Text == String.Empty)
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
                    komut.Parameters.AddWithValue("@depo", comboBox1.Text);
                    komut.Parameters.AddWithValue("@malzeme", comboBox2.Text);
                    komut.Parameters.AddWithValue("@cikis_miktari", textBox3.Text);
                    komut.Parameters.AddWithValue("@teslim_alan_kisi", textBox4.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Temizle();
                    baglanti.Close();
                    DepoTeslimDoldur();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Seçiminiz için yapmak istediğiniz işlem nedir?", "İŞLEM ONAYI", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (cevap == DialogResult.Yes)
            {
                string sorgu = "Delete From depo_teslim Where kod=@kod";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kod", textBox1.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                Temizle();
                baglanti.Close();
                DepoTeslimDoldur();
            }
            else if (cevap == DialogResult.No)
            {
                string sorgu = "Update depo_teslim Set cikis_miktari=@cikis_miktari Where kod=@kod";
                komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kod", textBox1.Text);
                komut.Parameters.AddWithValue("@cikis_miktari", 0);
                baglanti.Open();
                komut.ExecuteNonQuery();
                Temizle();
                baglanti.Close();
                DepoTeslimDoldur();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            String depoadi = comboBox1.SelectedItem.ToString();
            MalzemeCekme(depoadi);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox2.SelectedIndex;

            malzeme = comboBox2.SelectedItem.ToString();
            KumulatifMalzeme(malzeme);
        }

    }
}
