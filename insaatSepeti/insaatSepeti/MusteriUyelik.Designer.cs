namespace insaatSepeti
{
    partial class MusteriUyelik
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKaydet = new MaterialSkin.Controls.MaterialButton();
            this.txtMail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtTelefon = new MaterialSkin.Controls.MaterialTextBox();
            this.boxİLCE = new MaterialSkin.Controls.MaterialComboBox();
            this.boxİL = new MaterialSkin.Controls.MaterialComboBox();
            this.txtKullaniciAdi = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtKullaniciSoyad = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAdres = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(421, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 3);
            this.panel1.TabIndex = 15;
            // 
            // btnKaydet
            // 
            this.btnKaydet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKaydet.Depth = 0;
            this.btnKaydet.DrawShadows = true;
            this.btnKaydet.HighEmphasis = true;
            this.btnKaydet.Icon = null;
            this.btnKaydet.Location = new System.Drawing.Point(500, 545);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKaydet.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(219, 36);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "                                        KAYDET                                   " +
    "     ";
            this.btnKaydet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKaydet.UseAccentColor = true;
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtMail
            // 
            this.txtMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMail.Depth = 0;
            this.txtMail.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtMail.Hint = "E-mail";
            this.txtMail.Location = new System.Drawing.Point(636, 312);
            this.txtMail.MaxLength = 50;
            this.txtMail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMail.Multiline = false;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(228, 50);
            this.txtMail.TabIndex = 13;
            this.txtMail.Text = "";
            // 
            // txtTelefon
            // 
            this.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefon.Depth = 0;
            this.txtTelefon.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtTelefon.Hint = "Telefon";
            this.txtTelefon.Location = new System.Drawing.Point(382, 314);
            this.txtTelefon.MaxLength = 50;
            this.txtTelefon.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTelefon.Multiline = false;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(228, 50);
            this.txtTelefon.TabIndex = 12;
            this.txtTelefon.Text = "";
            // 
            // boxİLCE
            // 
            this.boxİLCE.AutoResize = false;
            this.boxİLCE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.boxİLCE.Depth = 0;
            this.boxİLCE.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.boxİLCE.DropDownHeight = 174;
            this.boxİLCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxİLCE.DropDownWidth = 121;
            this.boxİLCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.boxİLCE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.boxİLCE.FormattingEnabled = true;
            this.boxİLCE.Hint = "İLÇE";
            this.boxİLCE.IntegralHeight = false;
            this.boxİLCE.ItemHeight = 43;
            this.boxİLCE.Location = new System.Drawing.Point(636, 237);
            this.boxİLCE.MaxDropDownItems = 4;
            this.boxİLCE.MouseState = MaterialSkin.MouseState.OUT;
            this.boxİLCE.Name = "boxİLCE";
            this.boxİLCE.Size = new System.Drawing.Size(228, 49);
            this.boxİLCE.TabIndex = 11;
            // 
            // boxİL
            // 
            this.boxİL.AutoResize = false;
            this.boxİL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.boxİL.Depth = 0;
            this.boxİL.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.boxİL.DropDownHeight = 174;
            this.boxİL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxİL.DropDownWidth = 121;
            this.boxİL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.boxİL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.boxİL.FormattingEnabled = true;
            this.boxİL.Hint = "İL";
            this.boxİL.IntegralHeight = false;
            this.boxİL.ItemHeight = 43;
            this.boxİL.Location = new System.Drawing.Point(382, 238);
            this.boxİL.MaxDropDownItems = 4;
            this.boxİL.MouseState = MaterialSkin.MouseState.OUT;
            this.boxİL.Name = "boxİL";
            this.boxİL.Size = new System.Drawing.Size(228, 49);
            this.boxİL.TabIndex = 10;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciAdi.Depth = 0;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtKullaniciAdi.Hint = "Ad";
            this.txtKullaniciAdi.Location = new System.Drawing.Point(382, 161);
            this.txtKullaniciAdi.MaxLength = 50;
            this.txtKullaniciAdi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKullaniciAdi.Multiline = false;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(228, 50);
            this.txtKullaniciAdi.TabIndex = 9;
            this.txtKullaniciAdi.Text = "";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(425, 78);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(389, 29);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Lütfen Üyelik Bilgilerinizi Doldurunuz";
            // 
            // txtKullaniciSoyad
            // 
            this.txtKullaniciSoyad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKullaniciSoyad.Depth = 0;
            this.txtKullaniciSoyad.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtKullaniciSoyad.Hint = "Soyad";
            this.txtKullaniciSoyad.Location = new System.Drawing.Point(636, 161);
            this.txtKullaniciSoyad.MaxLength = 50;
            this.txtKullaniciSoyad.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKullaniciSoyad.Multiline = false;
            this.txtKullaniciSoyad.Name = "txtKullaniciSoyad";
            this.txtKullaniciSoyad.Size = new System.Drawing.Size(228, 50);
            this.txtKullaniciSoyad.TabIndex = 16;
            this.txtKullaniciSoyad.Text = "";
            // 
            // txtAdres
            // 
            this.txtAdres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtAdres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdres.Depth = 0;
            this.txtAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAdres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAdres.Hint = "";
            this.txtAdres.Location = new System.Drawing.Point(382, 386);
            this.txtAdres.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(482, 130);
            this.txtAdres.TabIndex = 17;
            this.txtAdres.Text = "Adres";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1027, 173);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Visible = false;
            // 
            // MusteriUyelik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 602);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtKullaniciSoyad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.boxİLCE);
            this.Controls.Add(this.boxİL);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.materialLabel1);
            this.Name = "MusteriUyelik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Üyelik Bilgileri";
            this.Load += new System.EventHandler(this.MusteriUyelik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton btnKaydet;
        private MaterialSkin.Controls.MaterialTextBox txtMail;
        private MaterialSkin.Controls.MaterialTextBox txtTelefon;
        private MaterialSkin.Controls.MaterialComboBox boxİLCE;
        private MaterialSkin.Controls.MaterialComboBox boxİL;
        private MaterialSkin.Controls.MaterialTextBox txtKullaniciAdi;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox txtKullaniciSoyad;
        private MaterialSkin.Controls.MaterialMultiLineTextBox txtAdres;
        private System.Windows.Forms.TextBox textBox1;
    }
}