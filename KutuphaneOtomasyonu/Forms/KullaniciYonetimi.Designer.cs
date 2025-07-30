namespace KutuphaneOtomasyonu
{
    partial class KullaniciYonetimi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                db?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciYonetimi));
            label4 = new Label();
            txtSifre = new TextBox();
            label2 = new Label();
            txtKullaniciAdi = new TextBox();
            label1 = new Label();
            txtSoyad = new TextBox();
            label3 = new Label();
            txtAd = new TextBox();
            lblAd = new Label();
            lblSoyad = new Label();
            lblKullaniciAdi = new Label();
            lblRafNo = new Label();
            cbRol = new ComboBox();
            label5 = new Label();
            lblRol = new Label();
            dataGridKullanicilar = new DataGridView();
            lblBaslik = new Label();
            btnKaydet = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            silToolStripMenuItem = new ToolStripMenuItem();
            düzenleToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridKullanicilar).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(0, 175, 219);
            label4.ForeColor = Color.FromArgb(0, 175, 219);
            label4.Location = new Point(192, 344);
            label4.Name = "label4";
            label4.Size = new Size(200, 1);
            label4.TabIndex = 154;
            label4.Text = "label2";
            // 
            // txtSifre
            // 
            txtSifre.BorderStyle = BorderStyle.None;
            txtSifre.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSifre.ForeColor = Color.Black;
            txtSifre.Location = new Point(192, 309);
            txtSifre.Margin = new Padding(3, 4, 3, 4);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(200, 25);
            txtSifre.TabIndex = 153;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(0, 175, 219);
            label2.ForeColor = Color.FromArgb(0, 175, 219);
            label2.Location = new Point(192, 290);
            label2.Name = "label2";
            label2.Size = new Size(200, 1);
            label2.TabIndex = 152;
            label2.Text = "label2";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.BorderStyle = BorderStyle.None;
            txtKullaniciAdi.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtKullaniciAdi.ForeColor = Color.Black;
            txtKullaniciAdi.Location = new Point(192, 255);
            txtKullaniciAdi.Margin = new Padding(3, 4, 3, 4);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(200, 25);
            txtKullaniciAdi.TabIndex = 151;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 175, 219);
            label1.ForeColor = Color.FromArgb(0, 175, 219);
            label1.Location = new Point(192, 239);
            label1.Name = "label1";
            label1.Size = new Size(200, 1);
            label1.TabIndex = 150;
            label1.Text = "label2";
            // 
            // txtSoyad
            // 
            txtSoyad.BorderStyle = BorderStyle.None;
            txtSoyad.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSoyad.ForeColor = Color.Black;
            txtSoyad.Location = new Point(192, 204);
            txtSoyad.Margin = new Padding(3, 4, 3, 4);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(200, 25);
            txtSoyad.TabIndex = 149;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 175, 219);
            label3.ForeColor = Color.FromArgb(0, 175, 219);
            label3.Location = new Point(192, 186);
            label3.Name = "label3";
            label3.Size = new Size(200, 1);
            label3.TabIndex = 148;
            label3.Text = "label2";
            // 
            // txtAd
            // 
            txtAd.BorderStyle = BorderStyle.None;
            txtAd.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtAd.ForeColor = Color.Black;
            txtAd.Location = new Point(192, 151);
            txtAd.Margin = new Padding(3, 4, 3, 4);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(200, 25);
            txtAd.TabIndex = 147;
            // 
            // lblAd
            // 
            lblAd.Anchor = AnchorStyles.Right;
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Microsoft Sans Serif", 12F);
            lblAd.Location = new Point(128, 152);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(48, 25);
            lblAd.TabIndex = 143;
            lblAd.Text = "Ad :";
            // 
            // lblSoyad
            // 
            lblSoyad.Anchor = AnchorStyles.Right;
            lblSoyad.AutoSize = true;
            lblSoyad.Font = new Font("Microsoft Sans Serif", 12F);
            lblSoyad.Location = new Point(96, 205);
            lblSoyad.Name = "lblSoyad";
            lblSoyad.Size = new Size(80, 25);
            lblSoyad.TabIndex = 144;
            lblSoyad.Text = "Soyad :";
            // 
            // lblKullaniciAdi
            // 
            lblKullaniciAdi.Anchor = AnchorStyles.Right;
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Font = new Font("Microsoft Sans Serif", 12F);
            lblKullaniciAdi.Location = new Point(46, 256);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(130, 25);
            lblKullaniciAdi.TabIndex = 145;
            lblKullaniciAdi.Text = "Kullanıcı Adı :";
            // 
            // lblRafNo
            // 
            lblRafNo.Anchor = AnchorStyles.Right;
            lblRafNo.AutoSize = true;
            lblRafNo.Font = new Font("Microsoft Sans Serif", 12F);
            lblRafNo.Location = new Point(113, 310);
            lblRafNo.Name = "lblRafNo";
            lblRafNo.Size = new Size(63, 25);
            lblRafNo.TabIndex = 146;
            lblRafNo.Text = "Şifre :";
            // 
            // cbRol
            // 
            cbRol.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(192, 366);
            cbRol.Margin = new Padding(3, 4, 3, 4);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(200, 30);
            cbRol.TabIndex = 240;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(0, 175, 219);
            label5.ForeColor = Color.FromArgb(0, 175, 219);
            label5.Location = new Point(192, 408);
            label5.Name = "label5";
            label5.Size = new Size(200, 1);
            label5.TabIndex = 239;
            label5.Text = "label2";
            // 
            // lblRol
            // 
            lblRol.Anchor = AnchorStyles.Right;
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Microsoft Sans Serif", 12F);
            lblRol.Location = new Point(125, 371);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(51, 25);
            lblRol.TabIndex = 238;
            lblRol.Text = "Rol :";
            // 
            // dataGridKullanicilar
            // 
            dataGridKullanicilar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridKullanicilar.Location = new Point(431, 151);
            dataGridKullanicilar.Margin = new Padding(3, 4, 3, 4);
            dataGridKullanicilar.Name = "dataGridKullanicilar";
            dataGridKullanicilar.RowHeadersWidth = 51;
            dataGridKullanicilar.RowTemplate.Height = 24;
            dataGridKullanicilar.Size = new Size(346, 258);
            dataGridKullanicilar.TabIndex = 241;
            dataGridKullanicilar.MouseDown += dataGridKullanicilar_MouseDown;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Right;
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(277, 34);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(236, 39);
            lblBaslik.TabIndex = 242;
            lblBaslik.Text = "Kullanıcı Ekle";
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Right;
            btnKaydet.BackColor = Color.Transparent;
            btnKaydet.BackgroundImage = (Image)resources.GetObject("btnKaydet.BackgroundImage");
            btnKaydet.BackgroundImageLayout = ImageLayout.Zoom;
            btnKaydet.FlatAppearance.BorderColor = SystemColors.Control;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Microsoft Sans Serif", 12F);
            btnKaydet.ForeColor = Color.Transparent;
            btnKaydet.Location = new Point(192, 435);
            btnKaydet.Margin = new Padding(3, 4, 3, 4);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(200, 50);
            btnKaydet.TabIndex = 243;
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnEkle_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { silToolStripMenuItem, düzenleToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(133, 52);
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new Size(132, 24);
            silToolStripMenuItem.Text = "Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // düzenleToolStripMenuItem
            // 
            düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            düzenleToolStripMenuItem.Size = new Size(132, 24);
            düzenleToolStripMenuItem.Text = "Düzenle";
            düzenleToolStripMenuItem.Click += düzenleToolStripMenuItem_Click;
            // 
            // KullaniciYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(btnKaydet);
            Controls.Add(lblBaslik);
            Controls.Add(dataGridKullanicilar);
            Controls.Add(cbRol);
            Controls.Add(label5);
            Controls.Add(lblRol);
            Controls.Add(label4);
            Controls.Add(txtSifre);
            Controls.Add(label2);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label1);
            Controls.Add(txtSoyad);
            Controls.Add(label3);
            Controls.Add(txtAd);
            Controls.Add(lblAd);
            Controls.Add(lblSoyad);
            Controls.Add(lblKullaniciAdi);
            Controls.Add(lblRafNo);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(818, 609);
            MinimumSize = new Size(818, 609);
            Name = "KullaniciYonetimi";
            StartPosition = FormStartPosition.CenterScreen;
            Load += KullaniciYonetimi_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridKullanicilar).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblRafNo;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.DataGridView dataGridKullanicilar;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
    }
}