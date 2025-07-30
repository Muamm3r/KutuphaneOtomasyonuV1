namespace KutuphaneOtomasyonu
{
    partial class OgrencileriRaporla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrencileriRaporla));
            dataGridOgrenciler = new DataGridView();
            lblBaslik = new Label();
            btnPdfAktar = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridOgrenciler
            // 
            dataGridOgrenciler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridOgrenciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOgrenciler.Location = new Point(29, 147);
            dataGridOgrenciler.Margin = new Padding(1);
            dataGridOgrenciler.Name = "dataGridOgrenciler";
            dataGridOgrenciler.RowHeadersWidth = 51;
            dataGridOgrenciler.RowTemplate.Height = 24;
            dataGridOgrenciler.Size = new Size(1348, 489);
            dataGridOgrenciler.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(1406, 48);
            lblBaslik.TabIndex = 164;
            lblBaslik.Text = "Öğrenci Raporları";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPdfAktar
            // 
            btnPdfAktar.BackgroundImage = (Image)resources.GetObject("btnPdfAktar.BackgroundImage");
            btnPdfAktar.BackgroundImageLayout = ImageLayout.Zoom;
            btnPdfAktar.FlatAppearance.BorderColor = SystemColors.Control;
            btnPdfAktar.FlatStyle = FlatStyle.Flat;
            btnPdfAktar.Location = new Point(35, 7);
            btnPdfAktar.Margin = new Padding(3, 4, 3, 4);
            btnPdfAktar.Name = "btnPdfAktar";
            btnPdfAktar.Size = new Size(200, 62);
            btnPdfAktar.TabIndex = 165;
            btnPdfAktar.UseVisualStyleBackColor = true;
            btnPdfAktar.Click += btnPdfAktar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblBaslik);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1406, 64);
            panel1.TabIndex = 166;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnPdfAktar);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 64);
            panel2.Name = "panel2";
            panel2.Size = new Size(1406, 77);
            panel2.TabIndex = 166;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridOgrenciler);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1406, 654);
            panel3.TabIndex = 166;
            // 
            // OgrencileriRaporla
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 654);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1424, 701);
            Name = "OgrencileriRaporla";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridOgrenciler;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnPdfAktar;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}