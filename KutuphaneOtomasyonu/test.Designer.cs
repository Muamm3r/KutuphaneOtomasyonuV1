namespace KutuphaneOtomasyonu
{
    partial class test
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
            label3 = new Label();
            txtAra = new TextBox();
            dataGridOgrenciler = new DataGridView();
            lblBaslik = new Label();
            lblAra = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 175, 219);
            label3.ForeColor = Color.FromArgb(0, 175, 219);
            label3.Location = new Point(134, 208);
            label3.Name = "label3";
            label3.Size = new Size(200, 1);
            label3.TabIndex = 178;
            label3.Text = "label2";
            // 
            // txtAra
            // 
            txtAra.BorderStyle = BorderStyle.None;
            txtAra.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtAra.ForeColor = Color.Black;
            txtAra.Location = new Point(134, 173);
            txtAra.Margin = new Padding(3, 4, 3, 4);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(200, 25);
            txtAra.TabIndex = 177;
            // 
            // dataGridOgrenciler
            // 
            dataGridOgrenciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOgrenciler.Location = new Point(3, 256);
            dataGridOgrenciler.Margin = new Padding(40, 10, 40, 10);
            dataGridOgrenciler.Name = "dataGridOgrenciler";
            dataGridOgrenciler.RowHeadersWidth = 51;
            dataGridOgrenciler.RowTemplate.Height = 24;
            dataGridOgrenciler.Size = new Size(1326, 462);
            dataGridOgrenciler.TabIndex = 175;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(683, 9);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(184, 39);
            lblBaslik.TabIndex = 174;
            lblBaslik.Text = "Öğrenciler";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAra
            // 
            lblAra.AutoSize = true;
            lblAra.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAra.Location = new Point(-14, 173);
            lblAra.Name = "lblAra";
            lblAra.Size = new Size(148, 25);
            lblAra.TabIndex = 176;
            lblAra.Text = "Öğrenci Ara :";
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 724);
            Controls.Add(label3);
            Controls.Add(txtAra);
            Controls.Add(lblAra);
            Controls.Add(dataGridOgrenciler);
            Controls.Add(lblBaslik);
            Name = "test";
            Text = "test";
            ((System.ComponentModel.ISupportInitialize)dataGridOgrenciler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox txtAra;
        private DataGridView dataGridOgrenciler;
        private Label lblBaslik;
        private Label lblAra;
    }
}