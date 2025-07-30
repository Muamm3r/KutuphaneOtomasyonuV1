namespace KutuphaneOtomasyonu
{
    partial class BarkodOlusturForm
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
            lblBaslik = new Label();
            btnPdfKaydet = new Button();
            btnBarkodOlustur = new Button();
            flpBarkodlar = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.Anchor = AnchorStyles.Right;
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("Microsoft Sans Serif", 20F);
            lblBaslik.Location = new Point(187, 19);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(243, 39);
            lblBaslik.TabIndex = 147;
            lblBaslik.Text = "Barkod Oluştur";
            // 
            // btnPdfKaydet
            // 
            btnPdfKaydet.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnPdfKaydet.Location = new Point(396, 739);
            btnPdfKaydet.Margin = new Padding(3, 4, 3, 4);
            btnPdfKaydet.Name = "btnPdfKaydet";
            btnPdfKaydet.Size = new Size(131, 49);
            btnPdfKaydet.TabIndex = 145;
            btnPdfKaydet.Text = "Yazdır";
            btnPdfKaydet.UseVisualStyleBackColor = true;
            btnPdfKaydet.Click += btnPdfKaydet_Click;
            // 
            // btnBarkodOlustur
            // 
            btnBarkodOlustur.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnBarkodOlustur.Location = new Point(82, 739);
            btnBarkodOlustur.Margin = new Padding(3, 4, 3, 4);
            btnBarkodOlustur.Name = "btnBarkodOlustur";
            btnBarkodOlustur.Size = new Size(220, 49);
            btnBarkodOlustur.TabIndex = 146;
            btnBarkodOlustur.Text = "Tüm Barkodları Oluştur";
            btnBarkodOlustur.UseVisualStyleBackColor = true;
            btnBarkodOlustur.Click += btnBarkodOlustur_Click;
            // 
            // flpBarkodlar
            // 
            flpBarkodlar.AutoScroll = true;
            flpBarkodlar.BorderStyle = BorderStyle.FixedSingle;
            flpBarkodlar.FlowDirection = FlowDirection.TopDown;
            flpBarkodlar.Location = new Point(82, 78);
            flpBarkodlar.Margin = new Padding(3, 4, 3, 4);
            flpBarkodlar.Name = "flpBarkodlar";
            flpBarkodlar.Size = new Size(445, 634);
            flpBarkodlar.TabIndex = 148;
            flpBarkodlar.WrapContents = false;
            // 
            // BarkodOlusturForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 829);
            Controls.Add(flpBarkodlar);
            Controls.Add(lblBaslik);
            Controls.Add(btnPdfKaydet);
            Controls.Add(btnBarkodOlustur);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "BarkodOlusturForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += BarkodOlusturForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnPdfKaydet;
        private System.Windows.Forms.Button btnBarkodOlustur;
        private System.Windows.Forms.FlowLayoutPanel flpBarkodlar;
    }
}