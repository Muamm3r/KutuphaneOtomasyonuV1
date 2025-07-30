namespace KutuphaneOtomasyonu
{
    partial class AyarlarForm
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
            lblSube = new Label();
            nudSeviye = new NumericUpDown();
            txtSube = new TextBox();
            btnSinifKaydet = new Button();
            dgvSiniflar = new DataGridView();
            lblSeviye = new Label();
            lblSiniflar = new Label();
            lblSinifBaslik = new Label();
            pnlCizgi2 = new PictureBox();
            lblOkulBaslik = new Label();
            lblOkulAdi = new Label();
            rtxtOkulAdi = new RichTextBox();
            btnKaydetOkulAdi = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            silToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)nudSeviye).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSiniflar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCizgi2).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblSube
            // 
            lblSube.AutoSize = true;
            lblSube.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSube.Location = new Point(33, 189);
            lblSube.Name = "lblSube";
            lblSube.Size = new Size(70, 25);
            lblSube.TabIndex = 0;
            lblSube.Text = "Şube :";
            // 
            // nudSeviye
            // 
            nudSeviye.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            nudSeviye.Location = new Point(110, 130);
            nudSeviye.Margin = new Padding(3, 4, 3, 4);
            nudSeviye.Name = "nudSeviye";
            nudSeviye.Size = new Size(167, 30);
            nudSeviye.TabIndex = 1;
            // 
            // txtSube
            // 
            txtSube.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSube.Location = new Point(110, 185);
            txtSube.Margin = new Padding(3, 4, 3, 4);
            txtSube.Name = "txtSube";
            txtSube.Size = new Size(167, 30);
            txtSube.TabIndex = 2;
            // 
            // btnSinifKaydet
            // 
            btnSinifKaydet.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSinifKaydet.Location = new Point(177, 458);
            btnSinifKaydet.Margin = new Padding(3, 4, 3, 4);
            btnSinifKaydet.Name = "btnSinifKaydet";
            btnSinifKaydet.Size = new Size(100, 44);
            btnSinifKaydet.TabIndex = 3;
            btnSinifKaydet.Text = "Kaydet";
            btnSinifKaydet.UseVisualStyleBackColor = true;
            btnSinifKaydet.Click += btnSinifKaydet_Click;
            // 
            // dgvSiniflar
            // 
            dgvSiniflar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSiniflar.Location = new Point(110, 239);
            dgvSiniflar.Margin = new Padding(3, 4, 3, 4);
            dgvSiniflar.Name = "dgvSiniflar";
            dgvSiniflar.RowHeadersWidth = 51;
            dgvSiniflar.RowTemplate.Height = 24;
            dgvSiniflar.Size = new Size(167, 188);
            dgvSiniflar.TabIndex = 4;
            dgvSiniflar.MouseDown += dgvSiniflar_MouseDown;
            // 
            // lblSeviye
            // 
            lblSeviye.AutoSize = true;
            lblSeviye.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSeviye.Location = new Point(20, 134);
            lblSeviye.Name = "lblSeviye";
            lblSeviye.Size = new Size(83, 25);
            lblSeviye.TabIndex = 0;
            lblSeviye.Text = "Seviye :";
            // 
            // lblSiniflar
            // 
            lblSiniflar.AutoSize = true;
            lblSiniflar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSiniflar.Location = new Point(21, 239);
            lblSiniflar.Name = "lblSiniflar";
            lblSiniflar.Size = new Size(82, 25);
            lblSiniflar.TabIndex = 0;
            lblSiniflar.Text = "Sınıflar :";
            // 
            // lblSinifBaslik
            // 
            lblSinifBaslik.AutoSize = true;
            lblSinifBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSinifBaslik.Location = new Point(44, 38);
            lblSinifBaslik.Name = "lblSinifBaslik";
            lblSinifBaslik.Size = new Size(209, 39);
            lblSinifBaslik.TabIndex = 0;
            lblSinifBaslik.Text = "Sınıf Ayarları";
            // 
            // pnlCizgi2
            // 
            pnlCizgi2.BackColor = Color.Blue;
            pnlCizgi2.Location = new Point(302, 19);
            pnlCizgi2.Margin = new Padding(3, 4, 3, 4);
            pnlCizgi2.Name = "pnlCizgi2";
            pnlCizgi2.Size = new Size(1, 532);
            pnlCizgi2.TabIndex = 44;
            pnlCizgi2.TabStop = false;
            // 
            // lblOkulBaslik
            // 
            lblOkulBaslik.AutoSize = true;
            lblOkulBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulBaslik.Location = new Point(373, 32);
            lblOkulBaslik.Name = "lblOkulBaslik";
            lblOkulBaslik.Size = new Size(174, 39);
            lblOkulBaslik.TabIndex = 0;
            lblOkulBaslik.Text = "Okul Ayarı";
            // 
            // lblOkulAdi
            // 
            lblOkulAdi.AutoSize = true;
            lblOkulAdi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulAdi.Location = new Point(313, 129);
            lblOkulAdi.Name = "lblOkulAdi";
            lblOkulAdi.Size = new Size(98, 25);
            lblOkulAdi.TabIndex = 0;
            lblOkulAdi.Text = "Okul Adı :";
            // 
            // rtxtOkulAdi
            // 
            rtxtOkulAdi.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 162);
            rtxtOkulAdi.Location = new Point(417, 132);
            rtxtOkulAdi.Margin = new Padding(3, 4, 3, 4);
            rtxtOkulAdi.Name = "rtxtOkulAdi";
            rtxtOkulAdi.Size = new Size(214, 135);
            rtxtOkulAdi.TabIndex = 46;
            rtxtOkulAdi.Text = "";
            // 
            // btnKaydetOkulAdi
            // 
            btnKaydetOkulAdi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnKaydetOkulAdi.Location = new Point(531, 290);
            btnKaydetOkulAdi.Margin = new Padding(3, 4, 3, 4);
            btnKaydetOkulAdi.Name = "btnKaydetOkulAdi";
            btnKaydetOkulAdi.Size = new Size(100, 44);
            btnKaydetOkulAdi.TabIndex = 3;
            btnKaydetOkulAdi.Text = "Kaydet";
            btnKaydetOkulAdi.UseVisualStyleBackColor = true;
            btnKaydetOkulAdi.Click += btnKaydetOkulAdi_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { silToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(95, 28);
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new Size(94, 24);
            silToolStripMenuItem.Text = "Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // AyarlarForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 562);
            Controls.Add(rtxtOkulAdi);
            Controls.Add(pnlCizgi2);
            Controls.Add(dgvSiniflar);
            Controls.Add(btnKaydetOkulAdi);
            Controls.Add(btnSinifKaydet);
            Controls.Add(txtSube);
            Controls.Add(nudSeviye);
            Controls.Add(lblOkulAdi);
            Controls.Add(lblSiniflar);
            Controls.Add(lblOkulBaslik);
            Controls.Add(lblSinifBaslik);
            Controls.Add(lblSeviye);
            Controls.Add(lblSube);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(689, 609);
            MinimumSize = new Size(689, 609);
            Name = "AyarlarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += AyarlarForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudSeviye).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSiniflar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCizgi2).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSube;
        private System.Windows.Forms.NumericUpDown nudSeviye;
        private System.Windows.Forms.TextBox txtSube;
        private System.Windows.Forms.Button btnSinifKaydet;
        private System.Windows.Forms.DataGridView dgvSiniflar;
        private System.Windows.Forms.Label lblSeviye;
        private System.Windows.Forms.Label lblSiniflar;
        private System.Windows.Forms.Label lblSinifBaslik;
        private System.Windows.Forms.PictureBox pnlCizgi2;
        private System.Windows.Forms.Label lblOkulBaslik;
        private System.Windows.Forms.Label lblOkulAdi;
        private System.Windows.Forms.RichTextBox rtxtOkulAdi;
        private System.Windows.Forms.Button btnKaydetOkulAdi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}