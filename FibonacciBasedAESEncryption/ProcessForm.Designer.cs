namespace FibonacciBasedAESEncryption
{
    partial class ProcessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_blockLength = new System.Windows.Forms.Label();
            this.lbl_processedBlock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_remainingTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_passingTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_msPerBlock = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_imageSize = new System.Windows.Forms.Label();
            this.lbl_imageSizeHeader = new System.Windows.Forms.Label();
            this.pnl_labels = new System.Windows.Forms.Panel();
            this.lbl_algSpeed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.PictureBox();
            this.pnl_labels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(40, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Block count:";
            // 
            // lbl_blockLength
            // 
            this.lbl_blockLength.AutoSize = true;
            this.lbl_blockLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_blockLength.Location = new System.Drawing.Point(132, 4);
            this.lbl_blockLength.Name = "lbl_blockLength";
            this.lbl_blockLength.Size = new System.Drawing.Size(53, 16);
            this.lbl_blockLength.TabIndex = 4;
            this.lbl_blockLength.Text = "125.500";
            // 
            // lbl_processedBlock
            // 
            this.lbl_processedBlock.AutoSize = true;
            this.lbl_processedBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_processedBlock.Location = new System.Drawing.Point(132, 20);
            this.lbl_processedBlock.Name = "lbl_processedBlock";
            this.lbl_processedBlock.Size = new System.Drawing.Size(46, 16);
            this.lbl_processedBlock.TabIndex = 6;
            this.lbl_processedBlock.Text = "51.122";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Processed block:";
            // 
            // lbl_remainingTime
            // 
            this.lbl_remainingTime.AutoSize = true;
            this.lbl_remainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_remainingTime.Location = new System.Drawing.Point(132, 36);
            this.lbl_remainingTime.Name = "lbl_remainingTime";
            this.lbl_remainingTime.Size = new System.Drawing.Size(15, 16);
            this.lbl_remainingTime.TabIndex = 9;
            this.lbl_remainingTime.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(11, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Remaning Time:";
            // 
            // lbl_passingTime
            // 
            this.lbl_passingTime.AutoSize = true;
            this.lbl_passingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_passingTime.Location = new System.Drawing.Point(132, 52);
            this.lbl_passingTime.Name = "lbl_passingTime";
            this.lbl_passingTime.Size = new System.Drawing.Size(15, 16);
            this.lbl_passingTime.TabIndex = 11;
            this.lbl_passingTime.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(25, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Passing Time:";
            // 
            // lbl_msPerBlock
            // 
            this.lbl_msPerBlock.AutoSize = true;
            this.lbl_msPerBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_msPerBlock.Location = new System.Drawing.Point(132, 68);
            this.lbl_msPerBlock.Name = "lbl_msPerBlock";
            this.lbl_msPerBlock.Size = new System.Drawing.Size(15, 16);
            this.lbl_msPerBlock.TabIndex = 13;
            this.lbl_msPerBlock.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(31, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ms per block:";
            // 
            // lbl_imageSize
            // 
            this.lbl_imageSize.AutoSize = true;
            this.lbl_imageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_imageSize.Location = new System.Drawing.Point(194, 59);
            this.lbl_imageSize.Name = "lbl_imageSize";
            this.lbl_imageSize.Size = new System.Drawing.Size(63, 16);
            this.lbl_imageSize.TabIndex = 15;
            this.lbl_imageSize.Text = "1280x720";
            // 
            // lbl_imageSizeHeader
            // 
            this.lbl_imageSizeHeader.AutoSize = true;
            this.lbl_imageSizeHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_imageSizeHeader.Location = new System.Drawing.Point(107, 59);
            this.lbl_imageSizeHeader.Name = "lbl_imageSizeHeader";
            this.lbl_imageSizeHeader.Size = new System.Drawing.Size(87, 16);
            this.lbl_imageSizeHeader.TabIndex = 14;
            this.lbl_imageSizeHeader.Text = "Image size:";
            // 
            // pnl_labels
            // 
            this.pnl_labels.Controls.Add(this.lbl_algSpeed);
            this.pnl_labels.Controls.Add(this.label7);
            this.pnl_labels.Controls.Add(this.lbl_msPerBlock);
            this.pnl_labels.Controls.Add(this.label6);
            this.pnl_labels.Controls.Add(this.lbl_passingTime);
            this.pnl_labels.Controls.Add(this.label5);
            this.pnl_labels.Controls.Add(this.lbl_remainingTime);
            this.pnl_labels.Controls.Add(this.label3);
            this.pnl_labels.Controls.Add(this.lbl_processedBlock);
            this.pnl_labels.Controls.Add(this.label2);
            this.pnl_labels.Controls.Add(this.lbl_blockLength);
            this.pnl_labels.Controls.Add(this.label1);
            this.pnl_labels.Location = new System.Drawing.Point(62, 72);
            this.pnl_labels.Name = "pnl_labels";
            this.pnl_labels.Size = new System.Drawing.Size(229, 111);
            this.pnl_labels.TabIndex = 16;
            // 
            // lbl_algSpeed
            // 
            this.lbl_algSpeed.AutoSize = true;
            this.lbl_algSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_algSpeed.Location = new System.Drawing.Point(132, 84);
            this.lbl_algSpeed.Name = "lbl_algSpeed";
            this.lbl_algSpeed.Size = new System.Drawing.Size(15, 16);
            this.lbl_algSpeed.TabIndex = 15;
            this.lbl_algSpeed.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(7, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Algorithm speed:";
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(-1, 189);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(354, 26);
            this.pbar.TabIndex = 19;
            this.pbar.TabStop = false;
            this.pbar.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingProgressBar);
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 214);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.lbl_imageSize);
            this.Controls.Add(this.lbl_imageSizeHeader);
            this.Controls.Add(this.pnl_labels);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessForm";
            this.Padding = new System.Windows.Forms.Padding(23, 69, 23, 23);
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Process";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.pnl_labels.ResumeLayout(false);
            this.pnl_labels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbl_blockLength;
        public System.Windows.Forms.Label lbl_processedBlock;
        public System.Windows.Forms.Label lbl_remainingTime;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lbl_passingTime;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lbl_msPerBlock;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lbl_imageSize;
        private System.Windows.Forms.Label lbl_imageSizeHeader;
        private System.Windows.Forms.Panel pnl_labels;
        public System.Windows.Forms.Label lbl_algSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbar;
    }
}