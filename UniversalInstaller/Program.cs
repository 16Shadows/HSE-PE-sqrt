using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalInstaller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                InstallationRoutine.PreParse();
            }
            catch(Exception e)
            {
                MessageBox.Show("Critical error: " + e.Message, "UniversalInstaller", MessageBoxButtons.OK);
                Console.Error.Write(e.Message);
                Environment.Exit(1);
            }

            if(args.Length == 0)
            {
                Application.Run(new ProgramWindow());
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                try
                {
                    InstallationRoutine.Run(args[0]);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Installation error:\n" + e.Message);
                    Environment.Exit(1);
                }
                if(args.Length > 1)
                {
                    System.Diagnostics.Process.Start(args[1]);
                }
            }
        }
    }
}
