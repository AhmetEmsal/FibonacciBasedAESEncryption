namespace FibonacciBasedAESEncryption.EncryptForms
{
    partial class TxtFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TxtFileForm));
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_encType = new System.Windows.Forms.Label();
            this.rb_encType_image = new System.Windows.Forms.RadioButton();
            this.rb_encType_text = new System.Windows.Forms.RadioButton();
            this.pnl_encType = new System.Windows.Forms.Panel();
            this.rb_encType_txtFile = new System.Windows.Forms.RadioButton();
            this.btn_encrypt = new System.Windows.Forms.Button();
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
            this.gb_txtFile = new System.Windows.Forms.GroupBox();
            this.lbl_alternativeFilename = new System.Windows.Forms.Label();
            this.btn_selectTxtFile = new System.Windows.Forms.Button();
            this.lbl_fileSource = new System.Windows.Forms.Label();
            this.tb_filename = new System.Windows.Forms.TextBox();
            this.btn_chooseFolder = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_hr1 = new System.Windows.Forms.Label();
            this.lbl_dest = new System.Windows.Forms.Label();
            this.lbl_hr2 = new System.Windows.Forms.Label();
            this.lbl_source = new System.Windows.Forms.Label();
            this.vistaFolderBrowserDialog1 = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_encType.SuspendLayout();
            this.pnl_method.SuspendLayout();
            this.gb_key.SuspendLayout();
            this.gb_txtFile.SuspendLayout();
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
            this.rb_encType_text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_encType_text.Location = new System.Drawing.Point(178, 1);
            this.rb_encType_text.Name = "rb_encType_text";
            this.rb_encType_text.Size = new System.Drawing.Size(92, 19);
            this.rb_encType_text.TabIndex = 3;
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
            this.rb_encType_txtFile.Checked = true;
            this.rb_encType_txtFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_encType_txtFile.Location = new System.Drawing.Point(278, 1);
            this.rb_encType_txtFile.Name = "rb_encType_txtFile";
            this.rb_encType_txtFile.Size = new System.Drawing.Size(108, 19);
            this.rb_encType_txtFile.TabIndex = 4;
            this.rb_encType_txtFile.TabStop = true;
            this.rb_encType_txtFile.Text = "Encrypt .txt File";
            this.rb_encType_txtFile.UseVisualStyleBackColor = true;
            this.rb_encType_txtFile.CheckedChanged += new System.EventHandler(this.encTypeChanged);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_encrypt.Location = new System.Drawing.Point(3, 156);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(518, 24);
            this.btn_encrypt.TabIndex = 7;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.encrypt);
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
            this.rb_method_encrypt.Checked = true;
            this.rb_method_encrypt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_method_encrypt.Location = new System.Drawing.Point(251, 1);
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
            this.rb_method_decrypt.Location = new System.Drawing.Point(316, 1);
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
            this.lbl_method.Location = new System.Drawing.Point(140, 1);
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
            // gb_txtFile
            // 
            this.gb_txtFile.Controls.Add(this.lbl_alternativeFilename);
            this.gb_txtFile.Controls.Add(this.btn_selectTxtFile);
            this.gb_txtFile.Controls.Add(this.lbl_fileSource);
            this.gb_txtFile.Controls.Add(this.tb_filename);
            this.gb_txtFile.Controls.Add(this.btn_chooseFolder);
            this.gb_txtFile.Controls.Add(this.label8);
            this.gb_txtFile.Controls.Add(this.lbl_hr1);
            this.gb_txtFile.Controls.Add(this.lbl_dest);
            this.gb_txtFile.Controls.Add(this.lbl_hr2);
            this.gb_txtFile.Controls.Add(this.lbl_source);
            this.gb_txtFile.Controls.Add(this.btn_encrypt);
            this.gb_txtFile.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold);
            this.gb_txtFile.Location = new System.Drawing.Point(10, 188);
            this.gb_txtFile.Name = "gb_txtFile";
            this.gb_txtFile.Size = new System.Drawing.Size(524, 183);
            this.gb_txtFile.TabIndex = 14;
            this.gb_txtFile.TabStop = false;
            this.gb_txtFile.Text = "Encrypt a .txt File";
            // 
            // lbl_alternativeFilename
            // 
            this.lbl_alternativeFilename.AutoSize = true;
            this.lbl_alternativeFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lbl_alternativeFilename.Location = new System.Drawing.Point(24, 69);
            this.lbl_alternativeFilename.MaximumSize = new System.Drawing.Size(350, 0);
            this.lbl_alternativeFilename.Name = "lbl_alternativeFilename";
            this.lbl_alternativeFilename.Size = new System.Drawing.Size(344, 26);
            this.lbl_alternativeFilename.TabIndex = 22;
            this.lbl_alternativeFilename.Text = "You can enter a new name instead of the default name of the file where the encryp" +
    "tion result is saved:";
            this.lbl_alternativeFilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_selectTxtFile
            // 
            this.btn_selectTxtFile.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btn_selectTxtFile.Image = global::FibonacciBasedAESEncryption.Properties.Resources.browseFile16x16;
            this.btn_selectTxtFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_selectTxtFile.Location = new System.Drawing.Point(266, 131);
            this.btn_selectTxtFile.Name = "btn_selectTxtFile";
            this.btn_selectTxtFile.Size = new System.Drawing.Size(81, 22);
            this.btn_selectTxtFile.TabIndex = 18;
            this.btn_selectTxtFile.Text = ".txt File";
            this.btn_selectTxtFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_selectTxtFile.UseVisualStyleBackColor = true;
            this.btn_selectTxtFile.Click += new System.EventHandler(this.selectTxtFile);
            // 
            // lbl_fileSource
            // 
            this.lbl_fileSource.AutoSize = true;
            this.lbl_fileSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lbl_fileSource.Location = new System.Drawing.Point(178, 135);
            this.lbl_fileSource.Name = "lbl_fileSource";
            this.lbl_fileSource.Size = new System.Drawing.Size(88, 13);
            this.lbl_fileSource.TabIndex = 17;
            this.lbl_fileSource.Text = "From a txt file:";
            // 
            // tb_filename
            // 
            this.tb_filename.BackColor = System.Drawing.SystemColors.Window;
            this.tb_filename.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.tb_filename.Location = new System.Drawing.Point(374, 72);
            this.tb_filename.Name = "tb_filename";
            this.tb_filename.Size = new System.Drawing.Size(112, 20);
            this.tb_filename.TabIndex = 16;
            this.tb_filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_chooseFolder
            // 
            this.btn_chooseFolder.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.btn_chooseFolder.Image = global::FibonacciBasedAESEncryption.Properties.Resources.browseFile16x16;
            this.btn_chooseFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_chooseFolder.Location = new System.Drawing.Point(374, 37);
            this.btn_chooseFolder.Name = "btn_chooseFolder";
            this.btn_chooseFolder.Size = new System.Drawing.Size(112, 22);
            this.btn_chooseFolder.TabIndex = 14;
            this.btn_chooseFolder.Text = "Choose folder";
            this.btn_chooseFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_chooseFolder.UseVisualStyleBackColor = true;
            this.btn_chooseFolder.Click += new System.EventHandler(this.chooseFolder);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label8.Location = new System.Drawing.Point(39, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(335, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Select a directory for the file where the encryption result will be saved:";
            // 
            // lbl_hr1
            // 
            this.lbl_hr1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_hr1.Enabled = false;
            this.lbl_hr1.Location = new System.Drawing.Point(1, 35);
            this.lbl_hr1.Name = "lbl_hr1";
            this.lbl_hr1.Size = new System.Drawing.Size(522, 1);
            this.lbl_hr1.TabIndex = 12;
            // 
            // lbl_dest
            // 
            this.lbl_dest.AutoSize = true;
            this.lbl_dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_dest.Location = new System.Drawing.Point(217, 20);
            this.lbl_dest.Name = "lbl_dest";
            this.lbl_dest.Size = new System.Drawing.Size(91, 13);
            this.lbl_dest.TabIndex = 11;
            this.lbl_dest.Text = "DESTINATION";
            // 
            // lbl_hr2
            // 
            this.lbl_hr2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_hr2.Enabled = false;
            this.lbl_hr2.Location = new System.Drawing.Point(1, 127);
            this.lbl_hr2.Name = "lbl_hr2";
            this.lbl_hr2.Size = new System.Drawing.Size(522, 1);
            this.lbl_hr2.TabIndex = 10;
            // 
            // lbl_source
            // 
            this.lbl_source.AutoSize = true;
            this.lbl_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lbl_source.Location = new System.Drawing.Point(233, 112);
            this.lbl_source.Name = "lbl_source";
            this.lbl_source.Size = new System.Drawing.Size(58, 13);
            this.lbl_source.TabIndex = 9;
            this.lbl_source.Text = "SOURCE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FibonacciBasedAESEncryption.Properties.Resources._lock;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // TxtFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(543, 374);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gb_txtFile);
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
            this.Name = "TxtFileForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fibonacci Based AES Encryption - Encrypt .txt File";
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnl_encType.ResumeLayout(false);
            this.pnl_encType.PerformLayout();
            this.pnl_method.ResumeLayout(false);
            this.pnl_method.PerformLayout();
            this.gb_key.ResumeLayout(false);
            this.gb_key.PerformLayout();
            this.gb_txtFile.ResumeLayout(false);
            this.gb_txtFile.PerformLayout();
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
        private System.Windows.Forms.Button btn_encrypt;
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
        private System.Windows.Forms.GroupBox gb_txtFile;
        private System.Windows.Forms.Label lbl_hr2;
        private System.Windows.Forms.Label lbl_source;
        private System.Windows.Forms.TextBox tb_filename;
        private System.Windows.Forms.Button btn_chooseFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_hr1;
        private System.Windows.Forms.Label lbl_dest;
        private System.Windows.Forms.RadioButton rb_encType_txtFile;
        private System.Windows.Forms.Button btn_selectTxtFile;
        private System.Windows.Forms.Label lbl_fileSource;
        private Ookii.Dialogs.WinForms.VistaFolderBrowserDialog vistaFolderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_alternativeFilename;
    }
}

