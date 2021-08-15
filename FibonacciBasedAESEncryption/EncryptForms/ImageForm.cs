using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FibonacciBasedAESEncryption.EncryptForms
{
    public partial class ImageForm : Form
    {
        public MainForm mainForm;
        Color activeColor = MainForm.activeColor;
        Faes faes = MainForm.faes;

        private const string defaultEncryptedFileName = "encryptedImage";
        enum FileEditor
        {
            @default,
            photoViewer
        }
        FileEditor fileEditor = FileEditor.photoViewer;

        //Required for button enabled or disabled
        private byte requiredValues = 3;
        private bool keyOkay = false;
        private bool folderOkay = false;
        private bool fileOkay = false;

        public ImageForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            //Initialize radio buttons: method_encrypt and encType_image
            rb_method_encrypt.Checked = rb_encType_image.Checked = true;
            rb_method_encrypt.ForeColor = rb_encType_image.ForeColor = activeColor;

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
                if(tb_key.Text.Length == faes.bytesForKey)
                {
                    if (!keyOkay)
                    {
                        keyOkay = true;
                        if (--requiredValues == 0)
                            btn_encrypt.Enabled = true;
                    }
                }
                else if (keyOkay)
                {
                    keyOkay = false;
                    ++requiredValues;
                    btn_encrypt.Enabled = false;
                }
            };
            this.tb_key.Enter += (object s, EventArgs ee) => FormCommonEvents.HandlerTbKeyTextEnter(s, ee, lbl_key, lbl_key_info);
            this.tb_key.KeyPress += (object s, KeyPressEventArgs ee) => FormCommonEvents.HandlerTbKeyPress(s, ee, lbl_key, lbl_key_info);
            this.tb_key.Leave += (object s, EventArgs ee) => FormCommonEvents.HandlerTbKeyLeave(s, ee, lbl_key, lbl_key_info);
            this.tb_key.KeyDown += FormCommonEvents.HandlerTbKeyDown;


            //For Test
            //tb_key.Text = "AhmetEmsalCipher";
            //vistaFolderBrowserDialog1.SelectedPath = openFileDialog.InitialDirectory = @"C:\Users\ahmet\OneDrive\Masaüstü\Test";
            //openFileDialog.FileName = @"C:\Users\ahmet\OneDrive\Masaüstü\Test\resim.jpg";
            //btn_encrypt.Enabled = true;
        }

        private void methodChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == rb_method_decrypt)
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
            else if (rb == rb_encType_txtFile)
            {
                this.Close();
                this.mainForm.rb_encType_txtFile.Checked = true;
            }
            else return;
        }

        private void chooseFolder(object sender, EventArgs e)
        {
            using(VistaFolderBrowserDialog dialog = vistaFolderBrowserDialog1)
            {
                dialog.Description = "Choose a folder";
                if(dialog.ShowDialog() != DialogResult.OK)
                {
                    if (folderOkay)
                    {
                        folderOkay = false;
                        ++requiredValues;
                        btn_encrypt.Enabled = false;
                    }
                    return;
                }

                if (!folderOkay)
                {
                    folderOkay = true;
                    if (--requiredValues == 0)
                        btn_encrypt.Enabled = true;
                }
            }
        }

        private void chooseImage(object sender, EventArgs e)
        {
            using(OpenFileDialog dialog = openFileDialog)
            {
                dialog.Title = "Select the image file to encrypt";
                //dialog.Filter = "Only Png File|*.png";
                dialog.Filter = "Image Files (.png;.jpg;.jpeg)|*.png;*.jpg;*.jpeg";

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    if (fileOkay)
                    {
                        fileOkay = false;
                        ++requiredValues;
                        btn_encrypt.Enabled = false;
                    }
                    return;
                }

                if (!fileOkay)
                {
                    fileOkay = true;
                    if (--requiredValues == 0)
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

            string imagePath = openFileDialog.FileName?.Trim();
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show(
                    "You need to select the image you want to encrypt.",
                    "No Image Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                btn_chooseImage.PerformClick();
                return;
            }

            Bitmap image = new Bitmap(imagePath);
            string imageExt = Path.GetExtension(imagePath);
            try
            {
                Stopwatch sw = new Stopwatch();

                CancellationTokenSource source = new CancellationTokenSource();
                Task.Run(() =>
                { //Encryption part
                    sw.Start();
                    faes.encryptImage(image, key);
                    sw.Stop();
                }, source.Token);

                //Form
                ProcessForm pf = new ProcessForm();
                pf.Text = "ENCRYPTION PROCESS";
                pf.pbarText = "Encryption image";
                pf.lbl_imageSize.Text = image.Width.ToString() + "x" + image.Height.ToString();
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
                        //Write a image file
                        string filePath = Path.Combine(folderPath, filename + imageExt);
                        image.Save(filePath, ImageFormat.Png);

                        //Open image file with viewer
                        Process imageViewer = null;
                        if(fileEditor == FileEditor.@default)
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
                            startInfo.Verb = "edit";
                            imageViewer = Process.Start(startInfo);
                        }
                        else if(fileEditor == FileEditor.photoViewer)
                        {
                            string appPath = Environment.GetFolderPath(
                                Environment.SpecialFolder.ProgramFiles
                            );

                            ProcessStartInfo psi = new ProcessStartInfo(
                                "rundll32.exe",
                               String.Format(
                                "\"{0}{1}\", ImageView_Fullscreen {2}",
                                @"C:\WINDOWS\System32\",
                                @"shimgvw.dll",
                                filePath)
                            );
                            psi.UseShellExecute = false;
                            imageViewer = Process.Start(psi);
                        }

                        if (imageViewer != null)
                        {
                            Thread.Sleep(1000);
                            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

                            IntPtr id = imageViewer.MainWindowHandle;
                            int counter = 0;
                            while(id == IntPtr.Zero)
                            {
                                if (++counter < 1000) break;
                                Thread.Sleep(10);
                                id = imageViewer.MainWindowHandle;
                            }
                            if(id != IntPtr.Zero)
                            {
                                bool res = FormCommonEvents.MoveWindow(id, 0, 0, Convert.ToInt32(screen.Width / 2), screen.Height, true);
                                if (!res)
                                {
                                    //Todo: Give an info about error
                                }
                            }
                        }

                    }
                );
                pf.FormClosed += (object oo, FormClosedEventArgs ee) =>
                {
                    Console.WriteLine("pf.FormClosed!");
                    if(!faes.working && !faes.stopped)
                    {
                        this.Close();
                        mainForm.rb_method_decrypt.Checked = true;
                        mainForm.rb_decType_image.Checked = true;
                    }
                    else
                    {
                        this.Show();
                    }
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "An error occurred when encrypt the image.\n\nError Message:\n" + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace,
                    "Encryption Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }
    }
}