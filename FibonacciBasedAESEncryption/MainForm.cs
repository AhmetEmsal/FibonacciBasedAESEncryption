using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FibonacciBasedAESEncryption
{
    public partial class MainForm : Form
    {

        #region Global Vars
        public static Color activeColor = SystemColors.Desktop;
        private Color deactiveColor;
        public static Faes faes = new Faes();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            pnl_decType.Top = pnl_encType.Top;
            //Form başlangıç durumuna getiriliyor
            if (!rb_method_encrypt.Checked && !rb_method_decrypt.Checked)
            {
                pnl_encType.Visible = false;
                pnl_decType.Visible = false;
                this.UpdateHeight(pnl_method);

                deactiveColor = rb_method_encrypt.ForeColor;
            }
            else
            {
            }


            //Test Case
            //rb_method_encrypt.Checked = true;
            //rb_encType_text.Checked = true;
            //tb_key.Text = "AHMETEMSALKEY123";
            //tb_encText.Text = "HELLO FRM LONDON";
            //btn_encTextOrTxtFile.Enabled = true;
            //btn_encTextOrTxtFile.PerformClick();
        }

        public void methodChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return;

            rb.ForeColor = activeColor;
            if (rb == rb_method_encrypt)
            {
                //Deactivate
                rb_method_decrypt.ForeColor = deactiveColor;
                pnl_decType.Visible = false;
                foreach (RadioButton rb_ in pnl_decType.Controls.OfType<RadioButton>())
                    rb_.Checked = false;

                //Activate
                rb.ForeColor = activeColor;
                pnl_encType.Visible = true;
                this.UpdateHeight(pnl_encType);
            }
            else
            {
                //Deactivate
                rb_method_encrypt.ForeColor = deactiveColor;
                pnl_encType.Visible = false;
                foreach (RadioButton rb_ in pnl_encType.Controls.OfType<RadioButton>())
                    rb_.Checked = false;

                //Activate
                rb.ForeColor = activeColor;
                pnl_decType.Visible = true;
                this.UpdateHeight(pnl_decType);
            }

        }
        private void encTypeChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return;

            Form form = null;
            if (rb == rb_encType_image)
            {
                form = new EncryptForms.ImageForm();
                (form as EncryptForms.ImageForm).mainForm = this;
            }
            else if (rb == rb_encType_text) {
                form = new EncryptForms.TextForm();
                (form as EncryptForms.TextForm).mainForm = this;
            }
            else if (rb == rb_encType_txtFile)
            {
                form = new EncryptForms.TxtFileForm();
                (form as EncryptForms.TxtFileForm).mainForm = this;
            }
            else
            {
                MessageBox.Show("Encrypt Type: " + rb?.Name, "Unexpected Choosed Encrypt Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            form.Show();

        }
        private void decTypeChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return;

            Form form = null;
            if (rb == rb_decType_image)
            {
                form = new DecryptForms.ImageForm();
                (form as DecryptForms.ImageForm).mainForm = this;

            }
            else if (rb == rb_decType_text)
            {
                form = new DecryptForms.TextForm();
                (form as DecryptForms.TextForm).mainForm = this;

            }
            else if (rb == rb_decType_txtFile)
            {
                form = new DecryptForms.FaesFileForm();
                (form as DecryptForms.FaesFileForm).mainForm = this;

            }
            else
            {
                MessageBox.Show("Decrypt Type: " + rb?.Name, "Unexpected Choosed Decrypt Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            form.Show();
        }

        void UpdateHeight(Control bottom, int add = 10)
        {
            add += this.Height - ClientRectangle.Height;
            this.Height = bottom.Top + bottom.Height + add;
            this.CenterToScreen();
        }
    }
}