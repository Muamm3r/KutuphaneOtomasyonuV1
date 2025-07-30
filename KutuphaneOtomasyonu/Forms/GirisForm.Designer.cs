namespace KutuphaneOtomasyonu
{
    partial class GirisForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            btnGirisYap = new Button();
            txtKullaniciAdi = new TextBox();
            txtSifre = new TextBox();
            panel1 = new Panel();
            lblOkulAdi = new Label();
            picBoxLogo = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGirisYap
            // 
            btnGirisYap.BackColor = Color.FromArgb(67, 142, 216);
            btnGirisYap.Font = new Font("Segoe UI", 14F);
            btnGirisYap.ForeColor = Color.White;
            btnGirisYap.Location = new Point(547, 529);
            btnGirisYap.Margin = new Padding(3, 4, 3, 4);
            btnGirisYap.Name = "btnGirisYap";
            btnGirisYap.Size = new Size(339, 62);
            btnGirisYap.TabIndex = 11;
            btnGirisYap.Text = "Giriş Yap";
            btnGirisYap.UseVisualStyleBackColor = false;
            btnGirisYap.Click += btnGirisYap_Click;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Font = new Font("Segoe UI", 15F);
            txtKullaniciAdi.ForeColor = Color.Black;
            txtKullaniciAdi.Location = new Point(547, 329);
            txtKullaniciAdi.Margin = new Padding(3, 4, 3, 4);
            txtKullaniciAdi.Multiline = true;
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(339, 57);
            txtKullaniciAdi.TabIndex = 9;
            txtKullaniciAdi.Text = "Kullanıcı Adı";
            txtKullaniciAdi.Click += txtKullaniciAdi_Click;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 15F);
            txtSifre.ForeColor = Color.Black;
            txtSifre.Location = new Point(547, 422);
            txtSifre.Margin = new Padding(3, 4, 3, 4);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(339, 41);
            txtSifre.TabIndex = 10;
            txtSifre.Text = "Şifre";
            txtSifre.UseSystemPasswordChar = true;
            txtSifre.Click += txtSifre_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 175, 219);
            panel1.Controls.Add(lblOkulAdi);
            panel1.Controls.Add(picBoxLogo);
            panel1.Location = new Point(-5, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 659);
            panel1.TabIndex = 16;
            // 
            // lblOkulAdi
            // 
            lblOkulAdi.BackColor = Color.Transparent;
            lblOkulAdi.Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblOkulAdi.ForeColor = Color.White;
            lblOkulAdi.Location = new Point(48, 26);
            lblOkulAdi.Name = "lblOkulAdi";
            lblOkulAdi.Size = new Size(389, 246);
            lblOkulAdi.TabIndex = 1;
            lblOkulAdi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picBoxLogo
            // 
            picBoxLogo.BackColor = Color.Transparent;
            picBoxLogo.Image = (Image)resources.GetObject("picBoxLogo.Image");
            picBoxLogo.Location = new Point(15, 258);
            picBoxLogo.Margin = new Padding(3, 4, 3, 4);
            picBoxLogo.Name = "picBoxLogo";
            picBoxLogo.Size = new Size(465, 401);
            picBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxLogo.TabIndex = 0;
            picBoxLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(573, 22);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 280);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // GirisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 635);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(btnGirisYap);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(txtSifre);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(943, 682);
            MinimumSize = new Size(943, 682);
            Name = "GirisForm";
            Padding = new Padding(20, 75, 20, 25);
            StartPosition = FormStartPosition.CenterScreen;
            Load += GirisForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblOkulAdi;
    }
}