using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWAT
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // creates mutex that another instance can not be open
            bool ok;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "NWAT_Mutex", out ok);

            if (!ok)
            {
                MessageBox.Show("Eine andere Instanz läuft bereits");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NWAT_Start_View());   

            GC.KeepAlive(m);                
          
        }
    }
}
