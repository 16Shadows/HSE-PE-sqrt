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
            try
            {
                InstallationRoutine.PreParse();
            }
            catch(Exception e)
            {
                MessageBox.Show("Critical error: " + e.Message, "UniversalInstaller", MessageBoxButtons.OK);
                Environment.Exit(1);
            }

            if(args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ProgramWindow());
            }
            else
            {
                if(!InstallationRoutine.Run(args[0])) Environment.Exit(1);
            }
        }
    }
}
