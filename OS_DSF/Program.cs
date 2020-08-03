using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OS_DSF
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
            Application.Run(new DIGITAL_SHOP_FLOOR_OS());
            //Application.Run(new FRM_SMT_ROLL_TOPO_WEEKLY());
          // Application.Run(new FRM_SMT_PU_OSD_YEAR());
         ///////dfdfsdf
        }
    }
}
