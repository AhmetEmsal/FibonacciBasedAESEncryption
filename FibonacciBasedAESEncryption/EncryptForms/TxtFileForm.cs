using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FibonacciBasedAESEncryption.EncryptForms
{
    public partial class TxtFileForm : Form
    {
        public MainForm mainForm;
        Color activeColor = MainForm.activeColor;
        Faes faes = MainForm.faes;

        private const string defaultEncryptedFileName = "encrypted";
        //Required for button enabled or disabled
        byte requiredParams = 3;
        bool keyOkay = false;
        bool folderDirOkay = false;
        bool txtFileOkay = false;

        public TxtFileForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            //Initialize radio buttons: method_encrypt and encType_txtFile
            rb_method_encrypt.Checked = rb_encType_txtFile.Checked = true;
            rb_method_encrypt.ForeColor = rb_encType_txtFile.ForeColor = activeColor;

            //Initialize lbl_key_info
            lbl_key_info.Text = "";
            lbl_key_info.Visible = false;
            FormCommonEvents.HorizontalCenter(new List<Control> { lbl_key, tb_key, lbl_key_info });

            //Set placeholder to filename
            FormCommonEvents.SendMessage(
                tb_filename.Handle,
                FormCommonEvents.EM_SETCUEBANNER,
                0,
                defaultEncryptedFileName
            );

            //Disable the encrypt button
            btn_encrypt.Enabled = false;

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
                            btn_encrypt.Enabled = true;
                    }
                }
                else if (keyOkay)
                {
                    keyOkay = false;
                    ++requiredParams;
                    btn_encrypt.Enabled = false;
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
                mainForm.rb_method_decrypt.Checked = true;
                this.Close();
                mainForm.Show();
            }
        }

        private void encTypeChanged(object sender, EventArgs e)
        {

            RadioButton rb = sender as RadioButton;
            if (rb == rb_encType_text)
            {
                this.Close();
                this.mainForm.rb_encType_text.Checked = true;
            }
            else if (rb == rb_encType_image)
            {
                this.Close();
                this.mainForm.rb_encType_image.Checked = true;
            }
            else return;
        }

        private void selectTxtFile(object sender, EventArgs e)
        {
            using(OpenFileDialog dialog = openFileDialog)
            {
                dialog.Filter = "Txt Dosyaları|*.txt";
                dialog.Title = "Select .txt text file.";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    if (txtFileOkay)
                    {
                        txtFileOkay = false;
                        ++requiredParams;
                        btn_encrypt.Enabled = false;
                    }
                    return;
                }

                if (!txtFileOkay)
                {
                    txtFileOkay = true;
                    if (--requiredParams == 0)
                        btn_encrypt.Enabled = true;
                }
            }
        }

        private void chooseFolder(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog dialog = vistaFolderBrowserDialog1)
            {
                if(dialog.ShowDialog() != DialogResult.OK)
                {
                    if (folderDirOkay)
                    {
                        folderDirOkay = false;
                        ++requiredParams;
                        btn_encrypt.Enabled = false;
                    }
                    return;
                }

                if (!folderDirOkay)
                {
                    folderDirOkay = true;
                    if (--requiredParams == 0)
                        btn_encrypt.Enabled = true;
                }
            }
        }

        private void encrypt(object sender, EventArgs e)
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

            string folderPath = vistaFolderBrowserDialog1.SelectedPath?.Trim();
            if (String.IsNullOrEmpty(folderPath)) //Folder Control
            {
                MessageBox.Show(
                    "You must select the folder of the file where the encryption result will be saved.",
                    "No folder selected!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                btn_chooseFolder.Focus();
                return;
            }

            string filename = tb_filename.Text?.Trim();
            if (String.IsNullOrEmpty(filename)) //Filename Control
                filename = defaultEncryptedFileName;
            
            string txtFilePath = openFileDialog.FileName?.Trim();
            if (string.IsNullOrEmpty(txtFilePath)) //Txt File Control
            {
                MessageBox.Show(
                    "You must select a file with the .txt extension that you want to be encrypted.",
                    "File not choosed!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                btn_selectTxtFile.PerformClick();
                return;
            }

            string text = File.ReadAllText(txtFilePath);
            if (string.IsNullOrEmpty(text))
            {
                DialogResult result = MessageBox.Show(
                    "The content of the selected file(named " + Path.GetFileName(txtFilePath) + ") is empty.\n\n"+ "Do you want to choose another txt file?",
                    "Empty Content",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if(result == DialogResult.Yes)
                    btn_selectTxtFile.PerformClick();
                return;
            }

            string encrypted = "";
            try
            {
                Stopwatch sw = new Stopwatch();

                CancellationTokenSource source = new CancellationTokenSource();
                Task.Run(() =>
                { //Encryption part
                    sw.Start();
                    encrypted = faes.encryptText(text, key);
                    sw.Stop();
                }, source.Token);


                //Form
                ProcessForm pf = new ProcessForm();
                pf.Text = "ENCRYPTION PROCESS";
                pf.pbarText = "Encryption txt file";
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
                        //Write a faes file
                        string filePath = Path.Combine(folderPath, filename + ".faes");
                        File.WriteAllText(filePath, encrypted);

                        //Open faes file with notepad
                        Process notepad = Process.Start(@"notepad.exe", filePath);

                        pf.FormClosed += (object oo, FormClosedEventArgs ee) =>
                        {
                            this.Close();
                            mainForm.rb_method_decrypt.Checked = true;
                            mainForm.rb_decType_txtFile.Checked = true;
                        };
                    }
                );
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "An error occurred when encrypt the txt file.\n\nError Message:\n" + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace,
                    "Encryption Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }
    }
}