namespace KutuphaneOtomasyonu
{
    partial class CezaForm
    {
        private System.ComponentModel.IContainer components = null;

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

        private void InitializeComponent()
        {
            dataGridGecikmeler = new DataGridView();
            txtCezaTuru = new TextBox();
            txtAciklama = new TextBox();
            btnCezaVer = new Button();
            lblCezaTuru = new Label();
            lblAciklama = new Label();
            dataGridCezalar = new DataGridView();
            btnDurumGuncelle = new Button();
            label9 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridGecikmeler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridCezalar).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridGecikmeler
            // 
            dataGridGecikmeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridGecikmeler.Dock = DockStyle.Fill;
            dataGridGecikmeler.Location = new Point(3, 47);
            dataGridGecikmeler.Margin = new Padding(3, 4, 3, 4);
            dataGridGecikmeler.Name = "dataGridGecikmeler";
            dataGridGecikmeler.RowHeadersWidth = 51;
            dataGridGecikmeler.Size = new Size(913, 315);
            dataGridGecikmeler.TabIndex = 0;
            // 
            // txtCezaTuru
            // 
            txtCezaTuru.Anchor = AnchorStyles.Right;
            txtCezaTuru.Font = new Font("Microsoft Sans Serif", 12F);
            txtCezaTuru.Location = new Point(147, 17);
            txtCezaTuru.Margin = new Padding(3, 7, 3, 4);
            txtCezaTuru.Name = "txtCezaTuru";
            txtCezaTuru.Size = new Size(594, 30);
            txtCezaTuru.TabIndex = 1;
            // 
            // txtAciklama
            // 
            txtAciklama.Anchor = AnchorStyles.Right;
            txtAciklama.Font = new Font("Microsoft Sans Serif", 12F);
            txtAciklama.Location = new Point(147, 16);
            txtAciklama.Margin = new Padding(3, 4, 3, 4);
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(594, 30);
            txtAciklama.TabIndex = 2;
            // 
            // btnCezaVer
            // 
            btnCezaVer.Anchor = AnchorStyles.Right;
            btnCezaVer.Font = new Font("Microsoft Sans Serif", 12F);
            btnCezaVer.Location = new Point(781, 4);
            btnCezaVer.Margin = new Padding(3, 4, 3, 4);
            btnCezaVer.Name = "btnCezaVer";
            btnCezaVer.Size = new Size(120, 38);
            btnCezaVer.TabIndex = 3;
            btnCezaVer.Text = "Ceza Ver";
            btnCezaVer.UseVisualStyleBackColor = true;
            btnCezaVer.Click += btnCezaVer_Click;
            // 
            // lblCezaTuru
            // 
            lblCezaTuru.Anchor = AnchorStyles.Right;
            lblCezaTuru.AutoSize = true;
            lblCezaTuru.Font = new Font("Microsoft Sans Serif", 12F);
            lblCezaTuru.Location = new Point(21, 22);
            lblCezaTuru.Name = "lblCezaTuru";
            lblCezaTuru.Size = new Size(111, 25);
            lblCezaTuru.TabIndex = 5;
            lblCezaTuru.Text = "Ceza Türü:";
            // 
            // lblAciklama
            // 
            lblAciklama.Anchor = AnchorStyles.Right;
            lblAciklama.AutoSize = true;
            lblAciklama.Font = new Font("Microsoft Sans Serif", 12F);
            lblAciklama.Location = new Point(21, 15);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(98, 25);
            lblAciklama.TabIndex = 5;
            lblAciklama.Text = "Açıklama:";
            // 
            // dataGridCezalar
            // 
            dataGridCezalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCezalar.Dock = DockStyle.Fill;
            dataGridCezalar.Location = new Point(3, 493);
            dataGridCezalar.Margin = new Padding(3, 4, 3, 4);
            dataGridCezalar.Name = "dataGridCezalar";
            dataGridCezalar.RowHeadersWidth = 51;
            dataGridCezalar.Size = new Size(913, 315);
            dataGridCezalar.TabIndex = 6;
            // 
            // btnDurumGuncelle
            // 
            btnDurumGuncelle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDurumGuncelle.Font = new Font("Microsoft Sans Serif", 12F);
            btnDurumGuncelle.Location = new Point(722, 816);
            btnDurumGuncelle.Margin = new Padding(3, 4, 3, 4);
            btnDurumGuncelle.Name = "btnDurumGuncelle";
            btnDurumGuncelle.Size = new Size(194, 38);
            btnDurumGuncelle.TabIndex = 4;
            btnDurumGuncelle.Text = "Durumu Güncelle";
            btnDurumGuncelle.UseVisualStyleBackColor = true;
            btnDurumGuncelle.Click += btnDurumGuncelle_Click;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Top;
            label9.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            label9.Location = new Point(3, 0);
            label9.Name = "label9";
            label9.Size = new Size(913, 39);
            label9.TabIndex = 128;
            label9.Text = "Cezalar";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(dataGridCezalar, 0, 4);
            tableLayoutPanel1.Controls.Add(panel2, 0, 3);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Controls.Add(dataGridGecikmeler, 0, 1);
            tableLayoutPanel1.Controls.Add(label9, 0, 0);
            tableLayoutPanel1.Controls.Add(btnDurumGuncelle, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 79F));
            tableLayoutPanel1.Size = new Size(919, 891);
            tableLayoutPanel1.TabIndex = 129;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtAciklama);
            panel2.Controls.Add(btnCezaVer);
            panel2.Controls.Add(lblAciklama);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 436);
            panel2.Name = "panel2";
            panel2.Size = new Size(913, 50);
            panel2.TabIndex = 130;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtCezaTuru);
            panel1.Controls.Add(lblCezaTuru);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 369);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 61);
            panel1.TabIndex = 129;
            // 
            // CezaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 891);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(937, 938);
            Name = "CezaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += CezaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridGecikmeler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridCezalar).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridGecikmeler;
        private System.Windows.Forms.TextBox txtCezaTuru;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnCezaVer;
        private System.Windows.Forms.Label lblCezaTuru;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.DataGridView dataGridCezalar;
        private System.Windows.Forms.Button btnDurumGuncelle;
        private System.Windows.Forms.Label label9;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel1;
    }
}
