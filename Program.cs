using System;
using System.Windows.Forms;

namespace PepperAndChurchSaveEditor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }

        internal const string VERSION = "0.3.3";
        internal const string DATAPATH = "PepperAndChurchSaveEditor.data";
    }
}