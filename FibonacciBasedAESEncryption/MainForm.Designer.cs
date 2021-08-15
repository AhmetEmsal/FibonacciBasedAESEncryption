namespace FibonacciBasedAESEncryption
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_encType = new System.Windows.Forms.Label();
            this.rb_encType_image = new System.Windows.Forms.RadioButton();
            this.rb_encType_text = new System.Windows.Forms.RadioButton();
            this.pnl_encType = new System.Windows.Forms.Panel();
            this.rb_encType_txtFile = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnl_method = new System.Windows.Forms.Panel();
            this.rb_method_encrypt = new System.Windows.Forms.RadioButton();
            this.rb_method_decrypt = new System.Windows.Forms.RadioButton();
            this.lbl_method = new System.Windows.Forms.Label();
            this.lbl_decType = new System.Windows.Forms.Label();
            this.rb_decType_image = new System.Windows.Forms.RadioButton();
            this.rb_decType_text = new System.Windows.Forms.RadioButton();
            this.pnl_decType = new System.Windows.Forms.Panel();
            this.rb_decType_txtFile = new System.Windows.Forms.RadioButton();
            this.pnl_encType.SuspendLayout();
            this.pnl_method.SuspendLayout();
            this.pnl_decType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(157, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fibonacci Based AES Encryption";
            // 
            // lbl_encType
            // 
            this.lbl_encType.AutoSize = true;
            this.lbl_encType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_encType.Location = new System.Drawing.Point(29, 0);
            this.lbl_encType.Name = "lbl_encType";
            this.lbl_encType.Size = new System.Drawing.Size(139, 15);
            this.lbl_encType.TabIndex = 1;
            this.lbl_encType.Text = "Choose encrypt type:";
            // 
            // rb_encType_image
            // 
            this.rb_encType_image.AutoSize = true;
            this.rb_encType_image.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb_encType_image.Location = new System.Drawing.Point(394, 0);
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
            this.rb_encType_text.Location = new System.Drawing.Point(178, 0);
            this.rb_encType_text.Name = "rb_encType_text";
            this.rb_encType_text.Size = new System.Drawing.Size(92, 19);
            this.rb_encType_text.TabIndex = 3;
            this.rb_encType_text.Text = "Encrypt Text";
            this.rb_encType_text.UseVisualStyleBackColor = true;
            this.rb_encType_text.CheckedChanged += new System.EventHandler(this.encTypeChanged);
            // 
            // pnl_encType
            // 
            this.pnl_encType.BackColor = System.Drawing.Color.Transparent;
            this.pnl_encType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_encType.Controls.Add(this.rb_encType_txtFile);
            this.pnl_encType.Controls.Add(this.rb_encType_text);
            this.pnl_encType.Controls.Add(this.rb_encType_image);
            this.pnl_encType.Controls.Add(this.lbl_encType);
            this.pnl_encType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pnl_encType.Location = new System.Drawing.Point(8, 93);
            this.pnl_encType.Name = "pnl_encType";
            this.pnl_encType.Size = new System.Drawing.Size(524, 21);
            this.pnl_encType.TabIndex = 4;
            // 
            // rb_encType_txtFile
            // 
            this.rb_encType_txtFile.AutoSize = true;
            this.rb_encType_txtFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_encType_txtFile.Location = new System.Drawing.Point(278, 0);
            this.rb_encType_txtFile.Name = "rb_encType_txtFile";
            this.rb_encType_txtFile.Size = new System.Drawing.Size(108, 19);
            this.rb_encType_txtFile.TabIndex = 4;
            this.rb_encType_txtFile.Text = "Encrypt .txt File";
            this.rb_encType_txtFile.UseVisualStyleBackColor = true;
            this.rb_encType_txtFile.CheckedChanged += new System.EventHandler(this.encTypeChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pnl_method
            // 
            this.pnl_method.BackColor = System.Drawing.Color.Transparent;
            this.pnl_method.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_method.Controls.Add(this.rb_method_encrypt);
            this.pnl_method.Controls.Add(this.rb_method_decrypt);
            this.pnl_method.Controls.Add(this.lbl_method);
            this.pnl_method.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pnl_method.Location = new System.Drawing.Point(8, 66);
            this.pnl_method.Name = "pnl_method";
            this.pnl_method.Size = new System.Drawing.Size(524, 21);
            this.pnl_method.TabIndex = 5;
            // 
            // rb_method_encrypt
            // 
            this.rb_method_encrypt.AutoSize = true;
            this.rb_method_encrypt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_method_encrypt.Location = new System.Drawing.Point(252, 1);
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
            // pnl_decType
            // 
            this.pnl_decType.BackColor = System.Drawing.Color.Transparent;
            this.pnl_decType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_decType.Controls.Add(this.rb_decType_txtFile);
            this.pnl_decType.Controls.Add(this.rb_decType_text);
            this.pnl_decType.Controls.Add(this.rb_decType_image);
            this.pnl_decType.Controls.Add(this.lbl_decType);
            this.pnl_decType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.pnl_decType.Location = new System.Drawing.Point(8, 120);
            this.pnl_decType.Name = "pnl_decType";
            this.pnl_decType.Size = new System.Drawing.Size(525, 21);
            this.pnl_decType.TabIndex = 10;
            // 
            // rb_decType_txtFile
            // 
            this.rb_decType_txtFile.AutoSize = true;
            this.rb_decType_txtFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rb_decType_txtFile.Location = new System.Drawing.Point(274, 0);
            this.rb_decType_txtFile.Name = "rb_decType_txtFile";
            this.rb_decType_txtFile.Size = new System.Drawing.Size(117, 19);
            this.rb_decType_txtFile.TabIndex = 4;
            this.rb_decType_txtFile.Text = "Decrypt .faes File";
            this.rb_decType_txtFile.UseVisualStyleBackColor = true;
            this.rb_decType_txtFile.CheckedChanged += new System.EventHandler(this.decTypeChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(541, 157);
            this.Controls.Add(this.pnl_method);
            this.Controls.Add(this.pnl_decType);
            this.Controls.Add(this.pnl_encType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fibonacci Based AES Encryption";
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnl_encType.ResumeLayout(false);
            this.pnl_encType.PerformLayout();
            this.pnl_method.ResumeLayout(false);
            this.pnl_method.PerformLayout();
            this.pnl_decType.ResumeLayout(false);
            this.pnl_decType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_encType;
        private System.Windows.Forms.Panel pnl_encType;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel pnl_method;
        private System.Windows.Forms.Label lbl_method;
        public System.Windows.Forms.RadioButton rb_method_decrypt;
        private System.Windows.Forms.Label lbl_decType;
        private System.Windows.Forms.Panel pnl_decType;
        public System.Windows.Forms.RadioButton rb_method_encrypt;
        public System.Windows.Forms.RadioButton rb_encType_image;
        public System.Windows.Forms.RadioButton rb_encType_text;
        public System.Windows.Forms.RadioButton rb_encType_txtFile;
        public System.Windows.Forms.RadioButton rb_decType_image;
        public System.Windows.Forms.RadioButton rb_decType_text;
        public System.Windows.Forms.RadioButton rb_decType_txtFile;
    }
}

