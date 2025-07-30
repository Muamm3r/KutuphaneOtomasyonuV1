namespace KutuphaneOtomasyonu
{
    partial class EnCokOkuyanOgrenciler
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
            dataGridOgrenciler = new DataGridView();
            lblBaslik = new Label();
            dataGridSiniflar = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridSiniflar).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridOgrenciler
            // 
            dataGridOgrenciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOgrenciler.Dock = DockStyle.Fill;
            dataGridOgrenciler.Location = new Point(34, 115);
            dataGridOgrenciler.Margin = new Padding(34, 115, 34, 25);
            dataGridOgrenciler.Name = "dataGridOgrenciler";
            dataGridOgrenciler.RowHeadersWidth = 51;
            dataGridOgrenciler.RowTemplate.Height = 24;
            dataGridOgrenciler.Size = new Size(747, 424);
            dataGridOgrenciler.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(253, 26);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(668, 39);
            lblBaslik.TabIndex = 164;
            lblBaslik.Text = "En Çok Kitap Okuyan Öğrenciler ve Sınıf";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridSiniflar
            // 
            dataGridSiniflar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSiniflar.Dock = DockStyle.Fill;
            dataGridSiniflar.Location = new Point(849, 115);
            dataGridSiniflar.Margin = new Padding(34, 115, 34, 25);
            dataGridSiniflar.Name = "dataGridSiniflar";
            dataGridSiniflar.RowHeadersWidth = 51;
            dataGridSiniflar.RowTemplate.Height = 24;
            dataGridSiniflar.Size = new Size(296, 424);
            dataGridSiniflar.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.12638F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.873621F));
            tableLayoutPanel1.Controls.Add(dataGridOgrenciler, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridSiniflar, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1179, 564);
            tableLayoutPanel1.TabIndex = 165;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1179, 89);
            panel1.TabIndex = 166;
            // 
            // EnCokOkuyanOgrenciler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 564);
            Controls.Add(lblBaslik);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1197, 611);
            Name = "EnCokOkuyanOgrenciler";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridSiniflar).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridOgrenciler;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.DataGridView dataGridSiniflar;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
    }
}