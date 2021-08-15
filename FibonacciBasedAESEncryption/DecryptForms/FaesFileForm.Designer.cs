namespace FibonacciBasedAESEncryption.DecryptForms
{
    partial class FaesFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaesFileForm));
            this.lbl_header = new System.Windows.Forms.Label();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnl_method = new System.Windows.Forms.Panel();
            this.rb_method_encrypt = new System.Windows.Forms.RadioButton();
            this.rb_method_decrypt = new System.Windows.Forms.RadioButton();
            this.lbl_method = new System.Windows.Forms.Label();
            this.lbl_key_info = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.gb_key = new System.Windows.Forms.GroupBox();
            this.lbl_key = new System.Windows.Forms.Label();
            this.cb_remindKey = new System.Windows.Forms.CheckBox();
            this.gb_decryptFaesFile = new System.Windows.Forms.GroupBox();
            this.btn_chooseFaesFile = new System.Windows.Forms.Button();
            this.lbl_faesFileSource = new System.Windows.Forms.Label();
            this.pnl_decType = new System.Windows.Forms.Panel();
            this.rb_decType_txtFile = new System.Windows.Forms.RadioButton();
            this.rb_decType_text = new System.Windows.Forms.RadioButton();
            this.rb_decType_image = new System.Windows.Forms.RadioButton();
            this.lbl_decType = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_method.SuspendLayout();
            this.gb_key.SuspendLayout();
            this.gb_decryptFaesFile.SuspendLayout();
            this.pnl_decType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_header.Location = new System.Drawing.Point(157, 23);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(229, 19);
            this.lbl_header.TabIndex = 0;
            this.lbl_header.Text = "Fibonacci Based AES Decryption";
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_decrypt.Location = new System.Drawing.Point(3, 39);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(518, 24);
            this.btn_decrypt.TabIndex = 7;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.decrypt);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pnl_method
            // 
            this.pnl_method.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_method.Controls.Add(this.rb_method_encrypt);
            this.pnl_method.Controls.Add(this.rb_method_decrypt);
            this.pnl_method.Controls.Add(this.lbl_method);
            this.pnl_method.Location = new System.Drawing.Point(10, 66);
            this.pnl_method.Name = "pnl_method";
            this.pnl_method.Size = new System.Drawing.Size(524, 21);
            this.pnl_method.TabIndex = 5;
            // 
            // rb_method_encrypt
            // 
            this.rb_method_encrypt.AutoSize = true;
            this.rb_method_encrypt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_method_encrypt.Location = new System.Drawing.Point(252, 0);
            this.rb_method_encrypt.Name = "rb_method_encrypt";
            this.rb_method_encrypt.Size = new System.Drawing.Size(65, 19);
            this.rb_method_encrypt.TabIndex = 3;
            this.rb_method_encrypt.Text = "Encrypt";
            this.rb_method_encrypt.UseVisualStyleBackColor = true;
            this.rb_method_encrypt.CheckedChanged += new System.EventHandler(this.methodChanged);
            // 
            // rb_method_decrypt
            // 
            this.rb_method_decrypt.AutoSize = true;
            this.rb_method_decrypt.Checked = true;
            this.rb_method_decrypt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb_method_decrypt.Location = new System.Drawing.Point(317, 0);
            this.rb_method_decrypt.Name = "rb_method_decrypt";
            this.rb_method_decrypt.Size = new System.Drawing.Size(66, 19);
            this.rb_method_decrypt.TabIndex = 2;
            this.rb_method_decrypt.TabStop = true;
            this.rb_method_decrypt.Text = "Decrypt";
            this.rb_method_decrypt.UseVisualStyleBackColor = true;
            this.rb_method_decrypt.CheckedChanged += new System.EventHandler(this.methodChanged);
            // 
            // lbl_method
            // 
            this.lbl_method.AutoSize = true;
            this.lbl_method.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_method.Location = new System.Drawing.Point(141, 1);
            this.lbl_method.Name = "lbl_method";
            this.lbl_method.Size = new System.Drawing.Size(111, 15);
            this.lbl_method.TabIndex = 1;
            this.lbl_method.Text = "Choose method:";
            // 
            // lbl_key_info
            // 
            this.lbl_key_info.AutoSize = true;
            this.lbl_key_info.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_key_info.Location = new System.Drawing.Point(315, 18);
            this.lbl_key_info.Name = "lbl_key_info";
            this.lbl_key_info.Size = new System.Drawing.Size(78, 16);
            this.lbl_key_info.TabIndex = 13;
            this.lbl_key_info.Text = "lbl_key_info";
            this.lbl_key_info.Visible = false;
            // 
            // tb_key
            // 
            this.tb_key.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.tb_key.Location = new System.Drawing.Point(205, 16);
            this.tb_key.MaxLength = 16;
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(110, 20);
            this.tb_key.TabIndex = 2;
            this.tb_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_key.UseSystemPasswordChar = true;
            // 
            // gb_key
            // 
            this.gb_key.Controls.Add(this.tb_key);
            this.gb_key.Controls.Add(this.lbl_key);
            this.gb_key.Controls.Add(this.lbl_key_info);
            this.gb_key.Controls.Add(this.cb_remindKey);
            this.gb_key.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.gb_key.Location = new System.Drawing.Point(10, 120);
            this.gb_key.Name = "gb_key";
            this.gb_key.Size = new System.Drawing.Size(524, 62);
            this.gb_key.TabIndex = 13;
            this.gb_key.TabStop = false;
            this.gb_key.Text = "KEY(8-bit Chars)";
            // 
            // lbl_key
            // 
            this.lbl_key.AutoSize = true;
            this.lbl_key.Location = new System.Drawing.Point(131, 18);
            this.lbl_key.Name = "lbl_key";
            this.lbl_key.Size = new System.Drawing.Size(74, 16);
            this.lbl_key.TabIndex = 14;
            this.lbl_key.Text = "Key String:";
            // 
            // cb_remindKey
            // 
            this.cb_remindKey.AutoSize = true;
            this.cb_remindKey.Enabled = false;
            this.cb_remindKey.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            this.cb_remindKey.Location = new System.Drawing.Point(159, 40);
            this.cb_remindKey.Name = "cb_remindKey";
            this.cb_remindKey.Size = new System.Drawing.Size(202, 19);
            this.cb_remindKey.TabIndex = 15;
            this.cb_remindKey.Text = "Remind the last used key(Disabled)";
            this.cb_remindKey.UseVisualStyleBackColor = true;
            // 
            // gb_decryptFaesFile
            // 
            this.gb_decryptFaesFile.Controls.Add(this.btn_chooseFaesFile);
            this.gb_decryptFaesFile.Controls.Add(this.lbl_faesFileSource);
            this.gb_decryptFaesFile.Controls.Add(this.btn_decrypt);
            this.gb_decryptFaesFile.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.gb_decryptFaesFile.Location = new System.Drawing.Point(10, 188);
            this.gb_decryptFaesFile.Name = "gb_decryptFaesFile";
            this.gb_decryptFaesFile.Size = new System.Drawing.Size(524, 66);
            this.gb_decryptFaesFile.TabIndex = 14;
            this.gb_decryptFaesFile.TabStop = false;
            this.gb_decryptFaesFile.Text = "Decrypt a Encrypted .faes File";
            // 
            // btn_chooseFaesFile
            // 
            this.btn_chooseFaesFile.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btn_chooseFaesFile.Image = global::FibonacciBasedAESEncryption.Properties.Resources.browseFile16x16;
            this.btn_chooseFaesFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_chooseFaesFile.Location = new System.Drawing.Point(287, 14);
            this.btn_chooseFaesFile.Name = "btn_chooseFaesFile";
            this.btn_chooseFaesFile.Size = new System.Drawing.Size(89, 22);
            this.btn_chooseFaesFile.TabIndex = 18;
            this.btn_chooseFaesFile.Text = ".faes File";
            this.btn_chooseFaesFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_chooseFaesFile.UseVisualStyleBackColor = true;
            this.btn_chooseFaesFile.Click += new System.EventHandler(this.chooseFaesFile);
            // 
            // lbl_faesFileSource
            // 
            this.lbl_faesFileSource.AutoSize = true;
            this.lbl_faesFileSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lbl_faesFileSource.Location = new System.Drawing.Point(156, 18);
            this.lbl_faesFileSource.Name = "lbl_faesFileSource";
            this.lbl_faesFileSource.Size = new System.Drawing.Size(131, 13);
            this.lbl_faesFileSource.TabIndex = 17;
            this.lbl_faesFileSource.Text = "Choose a source file: ";
            // 
            // pnl_decType
            // 
            this.pnl_decType.BackColor = System.Drawing.Color.Transparent;
            this.pnl_decType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_decType.Controls.Add(this.rb_decType_txtFile);
            this.pnl_decType.Controls.Add(this.rb_decType_text);
            this.pnl_decType.Controls.Add(this.rb_decType_image);
            this.pnl_decType.Controls.Add(this.lbl_decType);
            this.pnl_decType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pnl_decType.Location = new System.Drawing.Point(10, 93);
            this.pnl_decType.Name = "pnl_decType";
            this.pnl_decType.Size = new System.Drawing.Size(525, 21);
            this.pnl_decType.TabIndex = 16;
            // 
            // rb_decType_txtFile
            // 
            this.rb_decType_txtFile.AutoSize = true;
            this.rb_decType_txtFile.Checked = true;
            this.rb_decType_txtFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_decType_txtFile.Location = new System.Drawing.Point(274, 0);
            this.rb_decType_txtFile.Name = "rb_decType_txtFile";
            this.rb_decType_txtFile.Size = new System.Drawing.Size(117, 19);
            this.rb_decType_txtFile.TabIndex = 4;
            this.rb_decType_txtFile.TabStop = true;
            this.rb_decType_txtFile.Text = "Decrypt .faes File";
            this.rb_decType_txtFile.UseVisualStyleBackColor = true;
            this.rb_decType_txtFile.CheckedChanged += new System.EventHandler(this.decTypeChanged);
            // 
            // rb_decType_text
            // 
            this.rb_decType_text.AutoSize = true;
            this.rb_decType_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_decType_text.Location = new System.Drawing.Point(178, 0);
            this.rb_decType_text.Name = "rb_decType_text";
            this.rb_decType_text.Size = new System.Drawing.Size(93, 19);
            this.rb_decType_text.TabIndex = 3;
            this.rb_decType_text.Text = "Decrypt Text";
            this.rb_decType_text.UseVisualStyleBackColor = true;
            this.rb_decType_text.CheckedChanged += new System.EventHandler(this.decTypeChanged);
            // 
            // rb_decType_image
            // 
            this.rb_decType_image.AutoSize = true;
            this.rb_decType_image.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb_decType_image.Location = new System.Drawing.Point(394, 0);
            this.rb_decType_image.Name = "rb_decType_image";
            this.rb_decType_image.Size = new System.Drawing.Size(101, 19);
            this.rb_decType_image.TabIndex = 2;
            this.rb_decType_image.Text = "Decrypt Image";
            this.rb_decType_image.UseVisualStyleBackColor = true;
            this.rb_decType_image.CheckedChanged += new System.EventHandler(this.decTypeChanged);
            // 
            // lbl_decType
            // 
            this.lbl_decType.AutoSize = true;
            this.lbl_decType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_decType.Location = new System.Drawing.Point(29, 0);
            this.lbl_decType.Name = "lbl_decType";
            this.lbl_decType.Size = new System.Drawing.Size(139, 15);
            this.lbl_decType.TabIndex = 1;
            this.lbl_decType.Text = "Choose decrypt type:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FibonacciBasedAESEncryption.Properties.Resources.unlock;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // FaesFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(543, 260);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnl_decType);
            this.Controls.Add(this.gb_decryptFaesFile);
            this.Controls.Add(this.gb_key);
            this.Controls.Add(this.pnl_method);
            this.Controls.Add(this.lbl_header);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FaesFileForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fibonacci Based AES Encryption - Decrypt .faes File";
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnl_method.ResumeLayout(false);
            this.pnl_method.PerformLayout();
            this.gb_key.ResumeLayout(false);
            this.gb_key.PerformLayout();
            this.gb_decryptFaesFile.ResumeLayout(false);
            this.gb_decryptFaesFile.PerformLayout();
            this.pnl_decType.ResumeLayout(false);
            this.pnl_decType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel pnl_method;
        private System.Windows.Forms.RadioButton rb_method_encrypt;
        private System.Windows.Forms.RadioButton rb_method_decrypt;
        private System.Windows.Forms.Label lbl_method;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Label lbl_key_info;
        private System.Windows.Forms.GroupBox gb_key;
        private System.Windows.Forms.Label lbl_key;
        private System.Windows.Forms.CheckBox cb_remindKey;
        private System.Windows.Forms.GroupBox gb_decryptFaesFile;
        private System.Windows.Forms.Button btn_chooseFaesFile;
        private System.Windows.Forms.Label lbl_faesFileSource;
        private System.Windows.Forms.Panel pnl_decType;
        public System.Windows.Forms.RadioButton rb_decType_txtFile;
        public System.Windows.Forms.RadioButton rb_decType_text;
        public System.Windows.Forms.RadioButton rb_decType_image;
        private System.Windows.Forms.Label lbl_decType;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

