namespace FibonacciBasedAESEncryption.EncryptForms
{
    partial class TextForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextForm));
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_encType = new System.Windows.Forms.Label();
            this.rb_encType_image = new System.Windows.Forms.RadioButton();
            this.rb_encType_text = new System.Windows.Forms.RadioButton();
            this.pnl_encType = new System.Windows.Forms.Panel();
            this.rb_encType_txtFile = new System.Windows.Forms.RadioButton();
            this.tb_text = new System.Windows.Forms.TextBox();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.pnl_method = new System.Windows.Forms.Panel();
            this.rb_method_encrypt = new System.Windows.Forms.RadioButton();
            this.rb_method_decrypt = new System.Windows.Forms.RadioButton();
            this.lbl_method = new System.Windows.Forms.Label();
            this.lbl_key_info = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.gb_key = new System.Windows.Forms.GroupBox();
            this.lbl_key = new System.Windows.Forms.Label();
            this.cb_remindKey = new System.Windows.Forms.CheckBox();
            this.gb_text = new System.Windows.Forms.GroupBox();
            this.lbl_hr2 = new System.Windows.Forms.Label();
            this.lbl_source_header = new System.Windows.Forms.Label();
            this.tb_filename = new System.Windows.Forms.TextBox();
            this.lbl_alternativeFilename = new System.Windows.Forms.Label();
            this.btn_chooseFolder = new System.Windows.Forms.Button();
            this.lbl_chooseFolder = new System.Windows.Forms.Label();
            this.lbl_hr1 = new System.Windows.Forms.Label();
            this.lbl_dest_header = new System.Windows.Forms.Label();
            this.vistaFolderBrowserDialog1 = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_encType.SuspendLayout();
            this.pnl_method.SuspendLayout();
            this.gb_key.SuspendLayout();
            this.gb_text.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_header.Location = new System.Drawing.Point(158, 23);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(227, 19);
            this.lbl_header.TabIndex = 0;
            this.lbl_header.Text = "Fibonacci Based AES Encryption";
            // 
            // lbl_encType
            // 
            this.lbl_encType.AutoSize = true;
            this.lbl_encType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_encType.Location = new System.Drawing.Point(31, 1);
            this.lbl_encType.Name = "lbl_encType";
            this.lbl_encType.Size = new System.Drawing.Size(139, 15);
            this.lbl_encType.TabIndex = 1;
            this.lbl_encType.Text = "Choose encrypt type:";
            // 
            // rb_encType_image
            // 
            this.rb_encType_image.AutoSize = true;
            this.rb_encType_image.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb_encType_image.Location = new System.Drawing.Point(394, 1);
            this.rb_encType_image.Name = "rb_encType_image";
            this.rb_encType_image.Size = new System.Drawing.Size(100, 19);
            this.rb_encType_image.TabIndex = 2;
            this.rb_encType_image.Text = "Encrypt Image";
            this.rb_encType_image.UseVisualStyleBackColor = true;
            this.rb_encType_image.CheckedChanged += new System.EventHandler(this.encTypeChanged);
            // 
            // rb_encType_text
            // 
            this.rb_encType_text.AutoSize = true;
            this.rb_encType_text.Checked = true;
            this.rb_encType_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_encType_text.Location = new System.Drawing.Point(178, 1);
            this.rb_encType_text.Name = "rb_encType_text";
            this.rb_encType_text.Size = new System.Drawing.Size(92, 19);
            this.rb_encType_text.TabIndex = 3;
            this.rb_encType_text.TabStop = true;
            this.rb_encType_text.Text = "Encrypt Text";
            this.rb_encType_text.UseVisualStyleBackColor = true;
            this.rb_encType_text.CheckedChanged += new System.EventHandler(this.encTypeChanged);
            // 
            // pnl_encType
            // 
            this.pnl_encType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_encType.Controls.Add(this.rb_encType_txtFile);
            this.pnl_encType.Controls.Add(this.rb_encType_text);
            this.pnl_encType.Controls.Add(this.rb_encType_image);
            this.pnl_encType.Controls.Add(this.lbl_encType);
            this.pnl_encType.Location = new System.Drawing.Point(10, 93);
            this.pnl_encType.Name = "pnl_encType";
            this.pnl_encType.Size = new System.Drawing.Size(524, 21);
            this.pnl_encType.TabIndex = 4;
            // 
            // rb_encType_txtFile
            // 
            this.rb_encType_txtFile.AutoSize = true;
            this.rb_encType_txtFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_encType_txtFile.Location = new System.Drawing.Point(278, 1);
            this.rb_encType_txtFile.Name = "rb_encType_txtFile";
            this.rb_encType_txtFile.Size = new System.Drawing.Size(108, 19);
            this.rb_encType_txtFile.TabIndex = 4;
            this.rb_encType_txtFile.Text = "Encrypt .txt File";
            this.rb_encType_txtFile.UseVisualStyleBackColor = true;
            this.rb_encType_txtFile.CheckedChanged += new System.EventHandler(this.encTypeChanged);
            // 
            // tb_text
            // 
            this.tb_text.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_text.Location = new System.Drawing.Point(6, 126);
            this.tb_text.Multiline = true;
            this.tb_text.Name = "tb_text";
            this.tb_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_text.Size = new System.Drawing.Size(512, 135);
            this.tb_text.TabIndex = 6;
            this.tb_text.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_encrypt.Location = new System.Drawing.Point(3, 263);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(518, 24);
            this.btn_encrypt.TabIndex = 7;
            this.btn_encrypt.Text = "Encrypt Text";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.encrypt);
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
            this.rb_method_encrypt.Checked = true;
            this.rb_method_encrypt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_method_encrypt.Location = new System.Drawing.Point(252, 1);
            this.rb_method_encrypt.Name = "rb_method_encrypt";
            this.rb_method_encrypt.Size = new System.Drawing.Size(65, 19);
            this.rb_method_encrypt.TabIndex = 3;
            this.rb_method_encrypt.TabStop = true;
            this.rb_method_encrypt.Text = "Encrypt";
            this.rb_method_encrypt.UseVisualStyleBackColor = true;
            this.rb_method_encrypt.CheckedChanged += new System.EventHandler(this.methodChanged);
            // 
            // rb_method_decrypt
            // 
            this.rb_method_decrypt.AutoSize = true;
            this.rb_method_decrypt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb_method_decrypt.Location = new System.Drawing.Point(317, 1);
            this.rb_method_decrypt.Name = "rb_method_decrypt";
            this.rb_method_decrypt.Size = new System.Drawing.Size(66, 19);
            this.rb_method_decrypt.TabIndex = 2;
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
            this.tb_key.CausesValidation = false;
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
            // gb_text
            // 
            this.gb_text.Controls.Add(this.lbl_hr2);
            this.gb_text.Controls.Add(this.lbl_source_header);
            this.gb_text.Controls.Add(this.tb_filename);
            this.gb_text.Controls.Add(this.lbl_alternativeFilename);
            this.gb_text.Controls.Add(this.btn_chooseFolder);
            this.gb_text.Controls.Add(this.lbl_chooseFolder);
            this.gb_text.Controls.Add(this.lbl_hr1);
            this.gb_text.Controls.Add(this.lbl_dest_header);
            this.gb_text.Controls.Add(this.btn_encrypt);
            this.gb_text.Controls.Add(this.tb_text);
            this.gb_text.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.gb_text.Location = new System.Drawing.Point(10, 188);
            this.gb_text.Name = "gb_text";
            this.gb_text.Size = new System.Drawing.Size(524, 290);
            this.gb_text.TabIndex = 14;
            this.gb_text.TabStop = false;
            this.gb_text.Text = "Encrypt Text";
            // 
            // lbl_hr2
            // 
            this.lbl_hr2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_hr2.Enabled = false;
            this.lbl_hr2.Location = new System.Drawing.Point(1, 116);
            this.lbl_hr2.Name = "lbl_hr2";
            this.lbl_hr2.Size = new System.Drawing.Size(522, 1);
            this.lbl_hr2.TabIndex = 24;
            // 
            // lbl_source_header
            // 
            this.lbl_source_header.AutoSize = true;
            this.lbl_source_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_source_header.Location = new System.Drawing.Point(233, 101);
            this.lbl_source_header.Name = "lbl_source_header";
            this.lbl_source_header.Size = new System.Drawing.Size(58, 13);
            this.lbl_source_header.TabIndex = 23;
            this.lbl_source_header.Text = "SOURCE";
            // 
            // tb_filename
            // 
            this.tb_filename.BackColor = System.Drawing.SystemColors.Window;
            this.tb_filename.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.tb_filename.Location = new System.Drawing.Point(374, 70);
            this.tb_filename.Name = "tb_filename";
            this.tb_filename.Size = new System.Drawing.Size(112, 20);
            this.tb_filename.TabIndex = 22;
            this.tb_filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_alternativeFilename
            // 
            this.lbl_alternativeFilename.AutoSize = true;
            this.lbl_alternativeFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lbl_alternativeFilename.Location = new System.Drawing.Point(27, 67);
            this.lbl_alternativeFilename.MaximumSize = new System.Drawing.Size(350, 0);
            this.lbl_alternativeFilename.Name = "lbl_alternativeFilename";
            this.lbl_alternativeFilename.Size = new System.Drawing.Size(344, 26);
            this.lbl_alternativeFilename.TabIndex = 21;
            this.lbl_alternativeFilename.Text = "You can enter a new name instead of the default name of the file where the encryp" +
    "tion result is saved:";
            this.lbl_alternativeFilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_chooseFolder
            // 
            this.btn_chooseFolder.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btn_chooseFolder.Image = global::FibonacciBasedAESEncryption.Properties.Resources.browseFile16x16;
            this.btn_chooseFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_chooseFolder.Location = new System.Drawing.Point(374, 37);
            this.btn_chooseFolder.Name = "btn_chooseFolder";
            this.btn_chooseFolder.Size = new System.Drawing.Size(112, 22);
            this.btn_chooseFolder.TabIndex = 20;
            this.btn_chooseFolder.Text = "Choose folder";
            this.btn_chooseFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_chooseFolder.UseVisualStyleBackColor = true;
            this.btn_chooseFolder.Click += new System.EventHandler(this.chooseFolder);
            // 
            // lbl_chooseFolder
            // 
            this.lbl_chooseFolder.AutoSize = true;
            this.lbl_chooseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lbl_chooseFolder.Location = new System.Drawing.Point(44, 42);
            this.lbl_chooseFolder.Name = "lbl_chooseFolder";
            this.lbl_chooseFolder.Size = new System.Drawing.Size(327, 13);
            this.lbl_chooseFolder.TabIndex = 19;
            this.lbl_chooseFolder.Text = "Choose a folder for the file where the encryption result will be saved:";
            // 
            // lbl_hr1
            // 
            this.lbl_hr1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_hr1.Enabled = false;
            this.lbl_hr1.Location = new System.Drawing.Point(1, 35);
            this.lbl_hr1.Name = "lbl_hr1";
            this.lbl_hr1.Size = new System.Drawing.Size(522, 1);
            this.lbl_hr1.TabIndex = 18;
            // 
            // lbl_dest_header
            // 
            this.lbl_dest_header.AutoSize = true;
            this.lbl_dest_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_dest_header.Location = new System.Drawing.Point(217, 20);
            this.lbl_dest_header.Name = "lbl_dest_header";
            this.lbl_dest_header.Size = new System.Drawing.Size(91, 13);
            this.lbl_dest_header.TabIndex = 17;
            this.lbl_dest_header.Text = "DESTINATION";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FibonacciBasedAESEncryption.Properties.Resources._lock;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // TextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(543, 490);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gb_text);
            this.Controls.Add(this.gb_key);
            this.Controls.Add(this.pnl_method);
            this.Controls.Add(this.pnl_encType);
            this.Controls.Add(this.lbl_header);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TextForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fibonacci Based AES Encryption - Encrypt Text";
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnl_encType.ResumeLayout(false);
            this.pnl_encType.PerformLayout();
            this.pnl_method.ResumeLayout(false);
            this.pnl_method.PerformLayout();
            this.gb_key.ResumeLayout(false);
            this.gb_key.PerformLayout();
            this.gb_text.ResumeLayout(false);
            this.gb_text.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_encType;
        private System.Windows.Forms.RadioButton rb_encType_image;
        private System.Windows.Forms.RadioButton rb_encType_text;
        private System.Windows.Forms.Panel pnl_encType;
        private System.Windows.Forms.TextBox tb_text;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.Panel pnl_method;
        private System.Windows.Forms.RadioButton rb_method_encrypt;
        private System.Windows.Forms.RadioButton rb_method_decrypt;
        private System.Windows.Forms.Label lbl_method;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Label lbl_key_info;
        private System.Windows.Forms.GroupBox gb_key;
        private System.Windows.Forms.Label lbl_key;
        private System.Windows.Forms.CheckBox cb_remindKey;
        private System.Windows.Forms.GroupBox gb_text;
        private System.Windows.Forms.RadioButton rb_encType_txtFile;
        private System.Windows.Forms.Label lbl_hr2;
        private System.Windows.Forms.Label lbl_source_header;
        private System.Windows.Forms.TextBox tb_filename;
        private System.Windows.Forms.Label lbl_alternativeFilename;
        private System.Windows.Forms.Button btn_chooseFolder;
        private System.Windows.Forms.Label lbl_chooseFolder;
        private System.Windows.Forms.Label lbl_hr1;
        private System.Windows.Forms.Label lbl_dest_header;
        private Ookii.Dialogs.WinForms.VistaFolderBrowserDialog vistaFolderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

