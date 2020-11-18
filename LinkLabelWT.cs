﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matixs_Mod_Installer
{
    public class LinkLabelWT : LinkLabel
    {
        const int WM_SETCURSOR = 32,
              IDC_HAND = 32649;

        [DllImport("user32.dll")]
        public static extern int LoadCursor(int hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        public static extern int SetCursor(int hCursor);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETCURSOR)
            {
                int cursor = LoadCursor(0, IDC_HAND);

                SetCursor(cursor);

                m.Result = IntPtr.Zero; // Handled

                return;
            }

            base.WndProc(ref m);
        }
    }
}
