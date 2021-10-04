
namespace stok_yonetimi_uygulaması
{
    partial class Form2
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDepoTeslim = new System.Windows.Forms.Button();
            this.buttonDepoDurum = new System.Windows.Forms.Button();
            this.buttonDepo = new System.Windows.Forms.Button();
            this.buttonMalzeme = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTakip = new System.Windows.Forms.Panel();
            this.userControlDepoTeslim1 = new stok_yonetimi_uygulaması.userControlDepoTeslim();
            this.userControlDepoDurum1 = new stok_yonetimi_uygulaması.userControlDepoDurum();
            this.userControlDepo1 = new stok_yonetimi_uygulaması.userControlDepo();
            this.userControlMalzeme1 = new stok_yonetimi_uygulaması.userControlMalzeme();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDepoTeslim);
            this.panel1.Controls.Add(this.buttonDepoDurum);
            this.panel1.Controls.Add(this.buttonDepo);
            this.panel1.Controls.Add(this.buttonMalzeme);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 450);
            this.panel1.TabIndex = 0;
            // 
            // buttonDepoTeslim
            // 
            this.buttonDepoTeslim.FlatAppearance.BorderSize = 0;
            this.buttonDepoTeslim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDepoTeslim.Font = new System.Drawing.Font("Bahnschrift SemiLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDepoTeslim.ForeColor = System.Drawing.Color.White;
            this.buttonDepoTeslim.Image = ((System.Drawing.Image)(resources.GetObject("buttonDepoTeslim.Image")));
            this.buttonDepoTeslim.Location = new System.Drawing.Point(0, 342);
            this.buttonDepoTeslim.Name = "buttonDepoTeslim";
            this.buttonDepoTeslim.Size = new System.Drawing.Size(152, 64);
            this.buttonDepoTeslim.TabIndex = 1;
            this.buttonDepoTeslim.Text = "Depo Teslim";
            this.buttonDepoTeslim.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDepoTeslim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDepoTeslim.UseVisualStyleBackColor = true;
            this.buttonDepoTeslim.Click += new System.EventHandler(this.buttonDepoTeslim_Click);
            // 
            // buttonDepoDurum
            // 
            this.buttonDepoDurum.FlatAppearance.BorderSize = 0;
            this.buttonDepoDurum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDepoDurum.Font = new System.Drawing.Font("Bahnschrift SemiLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDepoDurum.ForeColor = System.Drawing.Color.White;
            this.buttonDepoDurum.Image = ((System.Drawing.Image)(resources.GetObject("buttonDepoDurum.Image")));
            this.buttonDepoDurum.Location = new System.Drawing.Point(0, 260);
            this.buttonDepoDurum.Name = "buttonDepoDurum";
            this.buttonDepoDurum.Size = new System.Drawing.Size(152, 64);
            this.buttonDepoDurum.TabIndex = 1;
            this.buttonDepoDurum.Text = "Depo Durum";
            this.buttonDepoDurum.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDepoDurum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDepoDurum.UseVisualStyleBackColor = true;
            this.buttonDepoDurum.Click += new System.EventHandler(this.buttonDepoDurum_Click);
            // 
            // buttonDepo
            // 
            this.buttonDepo.FlatAppearance.BorderSize = 0;
            this.buttonDepo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDepo.Font = new System.Drawing.Font("Bahnschrift SemiLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDepo.ForeColor = System.Drawing.Color.White;
            this.buttonDepo.Image = ((System.Drawing.Image)(resources.GetObject("buttonDepo.Image")));
            this.buttonDepo.Location = new System.Drawing.Point(0, 179);
            this.buttonDepo.Name = "buttonDepo";
            this.buttonDepo.Size = new System.Drawing.Size(152, 64);
            this.buttonDepo.TabIndex = 1;
            this.buttonDepo.Text = "Depo";
            this.buttonDepo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDepo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDepo.UseVisualStyleBackColor = true;
            this.buttonDepo.Click += new System.EventHandler(this.buttonDepo_Click);
            // 
            // buttonMalzeme
            // 
            this.buttonMalzeme.FlatAppearance.BorderSize = 0;
            this.buttonMalzeme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMalzeme.Font = new System.Drawing.Font("Bahnschrift SemiLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonMalzeme.ForeColor = System.Drawing.Color.White;
            this.buttonMalzeme.Image = ((System.Drawing.Image)(resources.GetObject("buttonMalzeme.Image")));
            this.buttonMalzeme.Location = new System.Drawing.Point(0, 96);
            this.buttonMalzeme.Name = "buttonMalzeme";
            this.buttonMalzeme.Size = new System.Drawing.Size(152, 64);
            this.buttonMalzeme.TabIndex = 1;
            this.buttonMalzeme.Text = "Malzeme";
            this.buttonMalzeme.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonMalzeme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonMalzeme.UseVisualStyleBackColor = true;
            this.buttonMalzeme.Click += new System.EventHandler(this.buttonMalzeme_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 78);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 17.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 78);
            this.label2.TabIndex = 0;
            this.label2.Text = "Stok Yönetimi Uygulaması";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panelTakip
            // 
            this.panelTakip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.panelTakip.Location = new System.Drawing.Point(153, 96);
            this.panelTakip.Name = "panelTakip";
            this.panelTakip.Size = new System.Drawing.Size(7, 64);
            this.panelTakip.TabIndex = 4;
            this.panelTakip.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // userControlDepoTeslim1
            // 
            this.userControlDepoTeslim1.Location = new System.Drawing.Point(162, 21);
            this.userControlDepoTeslim1.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.userControlDepoTeslim1.Name = "userControlDepoTeslim1";
            this.userControlDepoTeslim1.Size = new System.Drawing.Size(620, 417);
            this.userControlDepoTeslim1.TabIndex = 8;
            // 
            // userControlDepoDurum1
            // 
            this.userControlDepoDurum1.Location = new System.Drawing.Point(162, 21);
            this.userControlDepoDurum1.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.userControlDepoDurum1.Name = "userControlDepoDurum1";
            this.userControlDepoDurum1.Size = new System.Drawing.Size(620, 417);
            this.userControlDepoDurum1.TabIndex = 7;
            // 
            // userControlDepo1
            // 
            this.userControlDepo1.Location = new System.Drawing.Point(162, 21);
            this.userControlDepo1.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.userControlDepo1.Name = "userControlDepo1";
            this.userControlDepo1.Size = new System.Drawing.Size(620, 417);
            this.userControlDepo1.TabIndex = 6;
            // 
            // userControlMalzeme1
            // 
            this.userControlMalzeme1.Location = new System.Drawing.Point(162, 21);
            this.userControlMalzeme1.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.userControlMalzeme1.Name = "userControlMalzeme1";
            this.userControlMalzeme1.Size = new System.Drawing.Size(620, 417);
            this.userControlMalzeme1.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userControlDepoTeslim1);
            this.Controls.Add(this.userControlDepoDurum1);
            this.Controls.Add(this.userControlDepo1);
            this.Controls.Add(this.userControlMalzeme1);
            this.Controls.Add(this.panelTakip);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonMalzeme;
        private System.Windows.Forms.Button buttonDepoTeslim;
        private System.Windows.Forms.Button buttonDepoDurum;
        private System.Windows.Forms.Button buttonDepo;
        private System.Windows.Forms.Panel panelTakip;
        private userControlMalzeme userControlMalzeme1;
        private userControlDepo userControlDepo1;
        private userControlDepoDurum userControlDepoDurum1;
        private userControlDepoTeslim userControlDepoTeslim1;
    }
}

