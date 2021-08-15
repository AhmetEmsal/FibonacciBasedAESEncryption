using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FibonacciBasedAESEncryption
{
    class Notepad
    {
        #region Imports
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        #endregion

        public static readonly int WM_SETTEXT = 0X000b;
        public static readonly int WM_PASTE = 0x0302;


        public static Process SendText(string text, Form form, int wParam = 0x0302)
        {
            Process notepad = Process.Start(@"notepad.exe");
            System.Threading.Thread.Sleep(250);
            IntPtr notepadTextbox = FindWindowEx(notepad.MainWindowHandle, IntPtr.Zero, "Edit", null);

            if (wParam == Notepad.WM_PASTE) {
                Clipboard.SetText(text);
                SendMessage(notepadTextbox, WM_PASTE, 0, text);
                Clipboard.Clear();
            }
            else
            {
                SendMessage(notepadTextbox, wParam, 0, text);
            }
            notepad.WaitForExit();
            form.Activate();
            return notepad;
        }
    }
}
