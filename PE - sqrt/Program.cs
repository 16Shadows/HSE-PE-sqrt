using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE___sqrt
{
    using locale = Localization.Localization;

    static class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(!locale.Load() && (locale.Languages.Count == 0 || !locale.Languages.ContainsKey("en")))
            {
                locale.Languages.Add("en", new locale.LanguageEntry("English 0", new Dictionary<string, string>
                {
                    { "InputNumber", "Input your number:" },
                    { "ErrorEmpty", "Input is empty" },
                    { "ErrorInvalidInput", "Input contains invalid characters" },
                    { "Result", "The square root of your number is:" },
                    { "Error", "Error" }
                }));
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Background());
        }
    }
}
