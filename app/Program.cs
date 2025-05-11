// Точка входа: при запуске с аргументом --server стартует сервер,
// иначе запускается клиент-GUI (MainForm).
using System;
using System.Windows.Forms;
using Animals.Networking;

namespace Animals
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "--server")
            {
                var server = new AnimalServer(port: 9000);
                Console.WriteLine("AnimalServer started on port 9000. Press Enter to stop.");
                Console.ReadLine();
                server.Stop();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
