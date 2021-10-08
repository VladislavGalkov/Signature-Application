using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SignatureApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string exepath = Environment.CurrentDirectory;
            string exeDir = System.IO.Path.GetDirectoryName(exepath);
            DirectoryInfo binDir = System.IO.Directory.GetParent(exeDir);


            Trace.WriteLine(Path.Combine(binDir.ToString(), @"Database"));

        }
    }
}
