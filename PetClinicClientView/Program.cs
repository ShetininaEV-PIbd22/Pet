using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace PetClinicClientView
{
    static class Program
    {
        public static ClientViewModel Client { get; set; }
        public static ReportLogic logic { get; set; }
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APIClient.Connect();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new FormEnter();
            form.ShowDialog();
            if (Client != null)
            {
                Application.Run(new FormMain());
            }
        }
    }
}
