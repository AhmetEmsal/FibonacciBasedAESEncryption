using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FibonacciBasedAESEncryption
{
    class FormCommonEvents
    {
        public static void HanderFormClosing(object sender, FormClosingEventArgs e, MainForm mainForm)
        {
            if (!new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
            { //If user click the close button
                mainForm.Close();
                //Console.WriteLine("Uygulama sonlanıyor!");
                return;
            }
            //Console.WriteLine("Bu pencere, uygulama tarafından kapatıldı.");
        }


        #region TextBox Key Events
        public static void HandlerTbKeyPress(object sender, KeyPressEventArgs e, Label key, Label keyInfo)
        {
            TextBox tb_key = sender as TextBox;
            if (e.KeyChar < 32)
            {
                return;
            }
            else if (tb_key.Text.Length >= tb_key.MaxLength)
            {
                e.Handled = true;
                keyInfo.ForeColor = Color.Olive;
                keyInfo.Text = "Key is okay!";
                keyInfo.Visible = true;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
                return;
            }
            else if (e.KeyChar > 255)
            {
                e.Handled = true;
                keyInfo.ForeColor = Color.Maroon;
                keyInfo.Text = "Only 8-bit char. Not allowed " + e.KeyChar.ToString() + ".";
                keyInfo.Visible = true;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
                return;
            }
            else if (e.KeyChar > 127)
            {
                e.Handled = true;
                keyInfo.ForeColor = Color.Maroon;
                keyInfo.Text = "Only printable char. Not allowed " + e.KeyChar.ToString() + ".";
                keyInfo.Visible = true;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
            }
            else if (e.KeyChar == 127)
            {
                e.Handled = true; //Delete char
            }
        }
        public static void HandlerTbKeyTextChanged(object sender, EventArgs e, Label key, Label keyInfo)
        {
            TextBox tb_key = sender as TextBox;
            int missing = tb_key.MaxLength - tb_key.Text.Length;
            if (missing > 0)
            {
                keyInfo.ForeColor = Color.Blue;
                keyInfo.Text = "Enter " + missing.ToString() + " more 8-bit "+(missing==1?"char":"chars");
                keyInfo.Visible = true;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
            }
            else
            {
                keyInfo.ForeColor = Color.Green;
                keyInfo.Text = "Key is okay!";
                keyInfo.Visible = true;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
            }
        }
        public static void HandlerTbKeyTextEnter(object sender, EventArgs e, Label key, Label keyInfo)
        {
            TextBox tb_key = sender as TextBox;
            int missing = tb_key.MaxLength - tb_key.Text.Length;
            if (missing == 0)
            {
                keyInfo.ForeColor = Color.Green;
                keyInfo.Text = "Key is okay!";
                keyInfo.Visible = true;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
            }
        }
        public static void HandlerTbKeyLeave(object sender, EventArgs e, Label key, Label keyInfo)
        {
            TextBox tb_key = sender as TextBox;
            int maxLength = tb_key.MaxLength,
                length = tb_key.Text.Length,
                missing = maxLength - length;
            if (missing == 0)
            {
                keyInfo.Text = "";
                keyInfo.Visible = false;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
            }
            else
            {
                keyInfo.ForeColor = Color.Maroon;
                keyInfo.Text = "Enter " + missing.ToString() + " more 8-bit " + (missing==1?"char":"chars");
                keyInfo.Visible = true;
                FormCommonEvents.HorizontalCenter(new List<Control> { key, tb_key, keyInfo });
            }
        }
        public static void HandlerTbKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.CapsLock) e.SuppressKeyPress = true;
        }
        public static void HorizontalCenter(List<Control> controls, int spaces=0)
        {
            controls = controls.FindAll(control => control.Visible);
            byte count = Convert.ToByte(controls.Count);
            if (count == 0) return;

            int controlsWidth = 0,
                totalWidth = controls[0].Parent.Width;
            foreach (Control ctl in controls)
                controlsWidth += ctl.Width;

            controls[0].Left = Math.Max(
                0,
                Convert.ToInt32((totalWidth - (controlsWidth + (spaces * (controls.Count - 1)))) / 2)
            );
            for (byte i = 1; i < count; i++)
                controls[i].Left = controls[i - 1].Left + controls[i - 1].Width + spaces;
        }
        #endregion



        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        public static int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    }
}
