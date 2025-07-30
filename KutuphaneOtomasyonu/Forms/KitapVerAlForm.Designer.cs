namespace KutuphaneOtomasyonu
{
    partial class KitapVerAlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitapVerAlForm));
            label1 = new Label();
            cbKitap = new ComboBox();
            dataGridKitaplar = new DataGridView();
            dataGridIslemler = new DataGridView();
            lblKitapAdi = new Label();
            label3 = new Label();
            cbOgrenci = new ComboBox();
            lblOgrenciAdi = new Label();
            btnAl = new Button();
            lblBaslik = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnVer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridIslemler).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.FromArgb(0, 175, 219);
            label1.ForeColor = Color.FromArgb(0, 175, 219);
            label1.Location = new Point(763, 67);
            label1.Name = "label1";
            label1.Size = new Size(393, 1);
            label1.TabIndex = 193;
            label1.Text = "label2";
            // 
            // cbKitap
            // 
            cbKitap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbKitap.Font = new Font("Microsoft Sans Serif", 15F);
            cbKitap.FormattingEnabled = true;
            cbKitap.Location = new Point(763, 27);
            cbKitap.Margin = new Padding(3, 4, 3, 4);
            cbKitap.Name = "cbKitap";
            cbKitap.Size = new Size(393, 37);
            cbKitap.TabIndex = 192;
            // 
            // dataGridKitaplar
            // 
            dataGridKitaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridKitaplar.Dock = DockStyle.Fill;
            dataGridKitaplar.Location = new Point(628, 170);
            dataGridKitaplar.Margin = new Padding(20, 170, 20, 20);
            dataGridKitaplar.Name = "dataGridKitaplar";
            dataGridKitaplar.RowHeadersWidth = 51;
            dataGridKitaplar.RowTemplate.Height = 24;
            dataGridKitaplar.Size = new Size(569, 366);
            dataGridKitaplar.TabIndex = 190;
            dataGridKitaplar.CellClick += dataGridKitaplar_CellClick;
            // 
            // dataGridIslemler
            // 
            dataGridIslemler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridIslemler.Dock = DockStyle.Fill;
            dataGridIslemler.Location = new Point(20, 170);
            dataGridIslemler.Margin = new Padding(20, 170, 20, 20);
            dataGridIslemler.Name = "dataGridIslemler";
            dataGridIslemler.RowHeadersWidth = 51;
            dataGridIslemler.RowTemplate.Height = 24;
            dataGridIslemler.Size = new Size(568, 366);
            dataGridIslemler.TabIndex = 191;
            // 
            // lblKitapAdi
            // 
            lblKitapAdi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblKitapAdi.AutoSize = true;
            lblKitapAdi.Font = new Font("Microsoft Sans Serif", 15F);
            lblKitapAdi.Location = new Point(628, 31);
            lblKitapAdi.Name = "lblKitapAdi";
            lblKitapAdi.Size = new Size(129, 29);
            lblKitapAdi.TabIndex = 189;
            lblKitapAdi.Text = "Kitap Adı :";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 175, 219);
            label3.ForeColor = Color.FromArgb(0, 175, 219);
            label3.Location = new Point(194, 68);
            label3.Name = "label3";
            label3.Size = new Size(393, 1);
            label3.TabIndex = 188;
            label3.Text = "label2";
            // 
            // cbOgrenci
            // 
            cbOgrenci.Font = new Font("Microsoft Sans Serif", 15F);
            cbOgrenci.FormattingEnabled = true;
            cbOgrenci.Location = new Point(194, 27);
            cbOgrenci.Margin = new Padding(3, 4, 3, 4);
            cbOgrenci.Name = "cbOgrenci";
            cbOgrenci.Size = new Size(393, 37);
            cbOgrenci.TabIndex = 187;
            // 
            // lblOgrenciAdi
            // 
            lblOgrenciAdi.AutoSize = true;
            lblOgrenciAdi.Font = new Font("Microsoft Sans Serif", 15F);
            lblOgrenciAdi.Location = new Point(30, 31);
            lblOgrenciAdi.Name = "lblOgrenciAdi";
            lblOgrenciAdi.Size = new Size(159, 29);
            lblOgrenciAdi.TabIndex = 186;
            lblOgrenciAdi.Text = "Öğrenci Adı :";
            // 
            // btnAl
            // 
            btnAl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAl.BackgroundImage = (Image)resources.GetObject("btnAl.BackgroundImage");
            btnAl.BackgroundImageLayout = ImageLayout.Zoom;
            btnAl.FlatAppearance.BorderColor = SystemColors.Control;
            btnAl.FlatStyle = FlatStyle.Flat;
            btnAl.Location = new Point(20, 560);
            btnAl.Margin = new Padding(20, 4, 420, 4);
            btnAl.Name = "btnAl";
            btnAl.Size = new Size(168, 102);
            btnAl.TabIndex = 185;
            btnAl.UseVisualStyleBackColor = true;
            btnAl.Click += BtnAl_Click;
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            lblBaslik.Location = new Point(3, 2);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(1214, 52);
            lblBaslik.TabIndex = 194;
            lblBaslik.Text = "Kitap Al Ver";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblBaslik);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1217, 60);
            panel3.TabIndex = 195;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbKitap);
            panel2.Controls.Add(lblOgrenciAdi);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cbOgrenci);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblKitapAdi);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(1217, 72);
            panel2.TabIndex = 195;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dataGridKitaplar, 1, 0);
            tableLayoutPanel1.Controls.Add(dataGridIslemler, 0, 0);
            tableLayoutPanel1.Controls.Add(btnVer, 1, 1);
            tableLayoutPanel1.Controls.Add(btnAl, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 83.48348F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5165157F));
            tableLayoutPanel1.Size = new Size(1217, 666);
            tableLayoutPanel1.TabIndex = 196;
            // 
            // btnVer
            // 
            btnVer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnVer.BackgroundImage = (Image)resources.GetObject("btnVer.BackgroundImage");
            btnVer.BackgroundImageLayout = ImageLayout.Zoom;
            btnVer.FlatAppearance.BorderColor = SystemColors.Control;
            btnVer.FlatStyle = FlatStyle.Flat;
            btnVer.Location = new Point(1028, 560);
            btnVer.Margin = new Padding(420, 4, 20, 4);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(169, 102);
            btnVer.TabIndex = 192;
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += BtnVer_Click;
            // 
            // KitapVerAlForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 666);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1235, 713);
            Name = "KitapVerAlForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += KitapVerAlForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridKitaplar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridIslemler).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKitap;
        private System.Windows.Forms.DataGridView dataGridKitaplar;
        private System.Windows.Forms.DataGridView dataGridIslemler;
        private System.Windows.Forms.Label lblKitapAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOgrenci;
        private System.Windows.Forms.Label lblOgrenciAdi;
        private System.Windows.Forms.Button btnAl;
        private System.Windows.Forms.Label lblBaslik;
        private Panel panel3;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnVer;
    }
}