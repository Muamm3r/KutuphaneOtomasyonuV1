namespace KutuphaneOtomasyonu
{
    partial class OgrenciSil
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
            lblBaslik = new Label();
            dataGridOgrenciler = new DataGridView();
            txtAra = new TextBox();
            lblAra = new Label();
            label3 = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(1406, 76);
            lblBaslik.TabIndex = 182;
            lblBaslik.Text = "Öğrenciler";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridOgrenciler
            // 
            dataGridOgrenciler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridOgrenciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOgrenciler.Location = new Point(40, 173);
            dataGridOgrenciler.Margin = new Padding(40, 10, 40, 10);
            dataGridOgrenciler.Name = "dataGridOgrenciler";
            dataGridOgrenciler.RowHeadersWidth = 51;
            dataGridOgrenciler.RowTemplate.Height = 24;
            dataGridOgrenciler.Size = new Size(1326, 462);
            dataGridOgrenciler.TabIndex = 176;
            // 
            // txtAra
            // 
            txtAra.BorderStyle = BorderStyle.None;
            txtAra.Font = new Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtAra.ForeColor = Color.Black;
            txtAra.Location = new Point(230, 36);
            txtAra.Margin = new Padding(3, 4, 3, 4);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(200, 31);
            txtAra.TabIndex = 180;
            // 
            // lblAra
            // 
            lblAra.AutoSize = true;
            lblAra.Font = new Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAra.Location = new Point(41, 35);
            lblAra.Name = "lblAra";
            lblAra.Size = new Size(183, 31);
            lblAra.TabIndex = 179;
            lblAra.Text = "Öğrenci Ara :";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 175, 219);
            label3.ForeColor = Color.FromArgb(0, 175, 219);
            label3.Location = new Point(230, 72);
            label3.Name = "label3";
            label3.Size = new Size(200, 1);
            label3.TabIndex = 181;
            label3.Text = "label2";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtAra);
            panel2.Controls.Add(lblAra);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(1406, 71);
            panel2.TabIndex = 187;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblBaslik);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1406, 76);
            panel1.TabIndex = 186;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridOgrenciler);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1406, 654);
            panel3.TabIndex = 188;
            // 
            // OgrenciSil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 654);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(696, 701);
            Name = "OgrenciSil";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Label lblBaslik;
        private DataGridView dataGridOgrenciler;
        private TextBox txtAra;
        private Label lblAra;
        private Label label3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
    }
}