using System;
using System.Windows.Forms;

namespace WILDLINK_CLIENTS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the LoginForm first
            Application.Run(new LoginForm());
        }
    }
}
