namespace KutuphaneOtomasyonu
{
    partial class KitapSilForm
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
            label9 = new Label();
            txtAra = new TextBox();
            label3 = new Label();
            lblAra = new Label();
            dataGridKitaplar = new DataGridView();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(1406, 78);
            label9.TabIndex = 189;
            label9.Text = "Kitaplar";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAra
            // 
            txtAra.BorderStyle = BorderStyle.None;
            txtAra.Font = new Font("Verdana", 15F);
            txtAra.ForeColor = Color.Black;
            txtAra.Location = new Point(196, 33);
            txtAra.Margin = new Padding(3, 4, 3, 4);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(200, 31);
            txtAra.TabIndex = 159;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 175, 219);
            label3.ForeColor = Color.FromArgb(0, 175, 219);
            label3.Location = new Point(196, 68);
            label3.Name = "label3";
            label3.Size = new Size(200, 1);
            label3.TabIndex = 160;
            label3.Text = "label2";
            // 
            // lblAra
            // 
            lblAra.AutoSize = true;
            lblAra.Font = new Font("Verdana", 15F);
            lblAra.Location = new Point(40, 33);
            lblAra.Name = "lblAra";
            lblAra.Size = new Size(150, 31);
            lblAra.TabIndex = 158;
            lblAra.Text = "Kitap Ara :";
            // 
            // dataGridKitaplar
            // 
            dataGridKitaplar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridKitaplar.Location = new Point(40, 173);
            dataGridKitaplar.Margin = new Padding(3, 4, 3, 4);
            dataGridKitaplar.Name = "dataGridKitaplar";
            dataGridKitaplar.RowHeadersWidth = 51;
            dataGridKitaplar.RowTemplate.Height = 24;
            dataGridKitaplar.Size = new Size(1326, 462);
            dataGridKitaplar.TabIndex = 188;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 149);
            panel3.Name = "panel3";
            panel3.Size = new Size(1406, 505);
            panel3.TabIndex = 192;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtAra);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblAra);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 78);
            panel2.Name = "panel2";
            panel2.Size = new Size(1406, 71);
            panel2.TabIndex = 190;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1406, 78);
            panel1.TabIndex = 191;
            // 
            // KitapSilForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 654);
            Controls.Add(label9);
            Controls.Add(dataGridKitaplar);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(696, 701);
            Name = "KitapSilForm";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Label label9;
        private TextBox txtAra;
        private Label label3;
        private Label lblAra;
        private DataGridView dataGridKitaplar;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}