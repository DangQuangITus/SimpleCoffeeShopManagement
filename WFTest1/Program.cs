using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFTest1
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

            //khi load len CT se nap
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(5000);
            t.Abort();
            fLogin f = new fLogin();
            Application.Run(f);
            f.WindowState = FormWindowState.Normal;
        }
        //fload
        static private void SplashScreen()
        {
            Application.Run(new fLoad());
        }
    }
}
