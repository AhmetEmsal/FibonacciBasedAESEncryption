using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FibonacciBasedAESEncryption.DecryptForms
{
    public partial class FaesFileForm : Form
    {
        public MainForm mainForm;
        Color activeColor = MainForm.activeColor;
        Faes faes = MainForm.faes;

        //Required for button enabled or disabled
        byte requiredParams = 2;
        bool keyOkay = false;
        bool sourceFileOkay = false;

        public FaesFileForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            //Initialize radio buttons: method_decrypt and decType_txtFile
            rb_method_decrypt.Checked = rb_decType_txtFile.Checked = true;
            rb_method_decrypt.ForeColor = rb_decType_txtFile.ForeColor = activeColor;

            //Initialize lbl_key_info
            lbl_key_info.Text = "";
            lbl_key_info.Visible = false;
            FormCommonEvents.HorizontalCenter(new List<Control> { lbl_key, tb_key, lbl_key_info });

            //Disable the decrypt button
            btn_decrypt.Enabled = false;

            //Add common events for passing required params
            this.FormClosing += (object s, FormClosingEventArgs ee) => FormCommonEvents.HanderFormClosing(s, ee, this.mainForm);
            this.tb_key.TextChanged += (object s, EventArgs ee) =>
            {
                FormCommonEvents.HandlerTbKeyTextChanged(s, ee, lbl_key, lbl_key_info);
                if (tb_key.Text.Length == faes.bytesForKey)
                {
                    if (!keyOkay)
                    {
                        keyOkay = true;
                        if (--requiredParams == 0)
                            btn_decrypt.Enabled = true;
                    }
                }
                else if (keyOkay)
                {
                    keyOkay = false;
                    ++requiredParams;
                    btn_decrypt.Enabled = false;
                }
            };
            this.tb_key.Enter += (object s, EventArgs ee) => FormCommonEvents.HandlerTbKeyTextEnter(s, ee, lbl_key, lbl_key_info);
            this.tb_key.KeyPress += (object s, KeyPressEventArgs ee) => FormCommonEvents.HandlerTbKeyPress(s, ee, lbl_key, lbl_key_info);
            this.tb_key.Leave += (object s, EventArgs ee) => FormCommonEvents.HandlerTbKeyLeave(s, ee, lbl_key, lbl_key_info);
            this.tb_key.KeyDown += FormCommonEvents.HandlerTbKeyDown;
        }

        private void methodChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb == rb_method_decrypt)
            {
                mainForm.rb_method_encrypt.Checked = true;
                this.Close();
                mainForm.Show();
            }
        }

        private void decTypeChanged(object sender, EventArgs e)
        {

            RadioButton rb = sender as RadioButton;
            if (rb == rb_decType_text)
            {
                this.Close();
                this.mainForm.rb_decType_text.Checked = true;
            }
            else if (rb == rb_decType_image)
            {
                this.Close();
                this.mainForm.rb_decType_image.Checked = true;
            }
            else return;
        }

        private void chooseFaesFile(object sender, EventArgs e)
        {
            OpenFileDialog dialog = openFileDialog;
            dialog.Filter = "FAES Enrypted|*.faes";
            dialog.Title = "Select .faes text file.";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                if (sourceFileOkay)
                {
                    sourceFileOkay = false;
                    ++requiredParams;
                    btn_decrypt.Enabled = false;
                }
                return;
            }
            if (!sourceFileOkay)
            {
                sourceFileOkay = true;
                if (--requiredParams == 0)
                    btn_decrypt.Enabled = true;
            }
        }

        private void decrypt(object sender, EventArgs e)
        {
            string key = tb_key.Text?.Trim();
            if (key.Length != faes.bytesForKey) //Key control
            {
                MessageBox.Show(
                    "Length of key must be " + faes.bytesForKey.ToString() + "!",
                    "Key is not valid!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                tb_key.Focus();
                return;
            }

            string sourcePath = openFileDialog.FileName?.Trim();
            if(string.IsNullOrEmpty(sourcePath))
            {
                MessageBox.Show(
                    "You must select the .faes file you want to decrypt.",
                    "No .faes text file selected!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                btn_chooseFaesFile.PerformClick();
                return;
            }
            string decrypted = "";
            try
            {
                Stopwatch sw = new Stopwatch();

                CancellationTokenSource source = new CancellationTokenSource();
                Task.Run(() =>
                { //Decryption part
                    sw.Start();
                    decrypted = faes.decryptText(File.ReadAllText(sourcePath), key);
                    sw.Stop();
                }, source.Token);

                //Form
                ProcessForm pf = new ProcessForm();
                pf.Text = "DECRYPTION PROCESS";
                pf.pbarText = "Decryption faes file";
                pf.lbl_imageSize.Visible = false;
                this.Hide();
                pf.Show();
                pf.Activate();
                pf.startProcess(
                    faes: this.faes,
                    sw: sw,
                    source: source,
                    Process.GetCurrentProcess(),
                    Finished: delegate ()
                    {
                        //Show decrypted text with notepad
                        Process np = Notepad.SendText(decrypted, this, Notepad.WM_PASTE);

                        pf.FormClosed += (object oo, FormClosedEventArgs ee) =>
                        {
                            this.Show();
                            this.Activate();
                        };
                    }
                );
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "An error occurred when decrypt the faes file.\n\nError Message:\n" + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace,
                    "Decryption Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }
    }
}