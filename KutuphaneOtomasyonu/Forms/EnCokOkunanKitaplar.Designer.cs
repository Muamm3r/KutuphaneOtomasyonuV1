namespace KutuphaneOtomasyonu
{
    partial class EnCokOkunanKitaplar
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
            dataGridKitaplar = new DataGridView();
            lblBaslik = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridKitaplar
            // 
            dataGridKitaplar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridKitaplar.Location = new Point(42, 115);
            dataGridKitaplar.Margin = new Padding(3, 4, 3, 4);
            dataGridKitaplar.Name = "dataGridKitaplar";
            dataGridKitaplar.RowHeadersWidth = 51;
            dataGridKitaplar.RowTemplate.Height = 24;
            dataGridKitaplar.Size = new Size(716, 422);
            dataGridKitaplar.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(0, 2);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(800, 76);
            lblBaslik.TabIndex = 163;
            lblBaslik.Text = "En Çok Okunan Kitaplar";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblBaslik);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 83);
            panel1.TabIndex = 164;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 562);
            panel2.TabIndex = 165;
            // 
            // EnCokOkunanKitaplar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 562);
            Controls.Add(dataGridKitaplar);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(818, 609);
            Name = "EnCokOkunanKitaplar";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridKitaplar;
        private System.Windows.Forms.Label lblBaslik;
        private Panel panel1;
        private Panel panel2;
    }
}