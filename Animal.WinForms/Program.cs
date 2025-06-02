using System;
using System.Windows.Forms;

namespace Animals.WinForms
{
    internal static class Program
    {
        // Точка входа WinForms-приложения.
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
