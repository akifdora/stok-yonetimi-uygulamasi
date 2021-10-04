using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_yonetimi_uygulaması
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userControlMalzeme1.Show();
            userControlDepo1.Hide();
            userControlDepoDurum1.Hide();
            userControlDepoTeslim1.Hide();
            MessageBoxManager.Yes = "Sil";
            MessageBoxManager.No = "Sıfırla";
            MessageBoxManager.Register();

            userControlMalzeme1.ComboTemizle();
            userControlMalzeme1.DepoCekme();

        }

        private void buttonMalzeme_Click(object sender, EventArgs e)
        {
            panelTakip.Height = buttonMalzeme.Height;
            panelTakip.Top = buttonMalzeme.Top;

            userControlMalzeme1.Show();
            userControlMalzeme1.BringToFront();
            userControlDepo1.Hide();
            userControlDepoDurum1.Hide();
            userControlDepoTeslim1.Hide();

            userControlMalzeme1.ComboTemizle();
            userControlMalzeme1.DepoCekme();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDepo_Click(object sender, EventArgs e)
        {
            panelTakip.Height = buttonDepo.Height;
            panelTakip.Top = buttonDepo.Top;

            userControlMalzeme1.Hide();
            userControlDepo1.BringToFront();
            userControlDepo1.Show();
            userControlDepoDurum1.Hide();
            userControlDepoTeslim1.Hide();
            
        }

        private void buttonDepoDurum_Click(object sender, EventArgs e)
        {
            panelTakip.Height = buttonDepoDurum.Height;
            panelTakip.Top = buttonDepoDurum.Top;

            userControlMalzeme1.Hide();
            userControlDepoTeslim1.BringToFront();
            userControlDepo1.Hide();
            userControlDepoDurum1.Show();
            userControlDepoTeslim1.Hide();

            userControlDepoDurum1.ComboTemizle();
            userControlDepoDurum1.DepoCekme();
            userControlDepoDurum1.KritikSeviye();
            userControlDepoDurum1.DepoDurumDoldur();
            userControlMalzeme1.MalzemeDoldur();
        }

        private void buttonDepoTeslim_Click(object sender, EventArgs e)
        {
            panelTakip.Height = buttonDepoTeslim.Height;
            panelTakip.Top = buttonDepoTeslim.Top;

            userControlMalzeme1.Hide();
            userControlDepoTeslim1.BringToFront();
            userControlDepo1.Hide();
            userControlDepoDurum1.Hide();
            userControlDepoTeslim1.Show();
            userControlDepoTeslim1.Temizle();
            userControlDepoTeslim1.DepoCekme();
            
        }
    }
}
