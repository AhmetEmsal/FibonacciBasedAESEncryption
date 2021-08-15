using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FibonacciBasedAESEncryption
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
      {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            EncryptForms.ImageForm subForm = new EncryptForms.ImageForm();
            subForm.mainForm = mainForm;

            Application.Run(mainForm);
        }
    }
}
