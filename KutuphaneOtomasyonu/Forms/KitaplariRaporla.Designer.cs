namespace KutuphaneOtomasyonu
{
    partial class KitaplariRaporla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitaplariRaporla));
            panel1 = new Panel();
            lblBaslik = new Label();
            btnPdfAktar = new Button();
            dataGridKitaplar = new DataGridView();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblBaslik);
            panel1.Controls.Add(btnPdfAktar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1716, 146);
            panel1.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(1716, 39);
            lblBaslik.TabIndex = 170;
            lblBaslik.Text = "Kitap Raporları";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPdfAktar
            // 
            btnPdfAktar.BackgroundImage = (Image)resources.GetObject("btnPdfAktar.BackgroundImage");
            btnPdfAktar.BackgroundImageLayout = ImageLayout.Zoom;
            btnPdfAktar.FlatAppearance.BorderColor = SystemColors.Control;
            btnPdfAktar.FlatStyle = FlatStyle.Flat;
            btnPdfAktar.Location = new Point(12, 80);
            btnPdfAktar.Margin = new Padding(3, 4, 3, 4);
            btnPdfAktar.Name = "btnPdfAktar";
            btnPdfAktar.Size = new Size(200, 62);
            btnPdfAktar.TabIndex = 169;
            btnPdfAktar.UseVisualStyleBackColor = true;
            // 
            // dataGridKitaplar
            // 
            dataGridKitaplar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridKitaplar.Location = new Point(38, 182);
            dataGridKitaplar.Margin = new Padding(3, 4, 3, 4);
            dataGridKitaplar.Name = "dataGridKitaplar";
            dataGridKitaplar.RowHeadersWidth = 51;
            dataGridKitaplar.RowTemplate.Height = 24;
            dataGridKitaplar.Size = new Size(1640, 671);
            dataGridKitaplar.TabIndex = 168;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 146);
            panel2.Name = "panel2";
            panel2.Size = new Size(1716, 743);
            panel2.TabIndex = 171;
            // 
            // KitaplariRaporla
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1716, 889);
            Controls.Add(dataGridKitaplar);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1734, 936);
            Name = "KitaplariRaporla";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lblBaslik;
        private Button btnPdfAktar;
        private DataGridView dataGridKitaplar;
        private Panel panel2;
    }
}