using System;
using System.Windows.Forms;

namespace Animals.WinForms
{
    internal static class Program
    {
        // ����� ����� WinForms-����������.
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
