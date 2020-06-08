using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.Interfaces;
using PetClinicDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace PetClinicView
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IMedicineLogic, MedicineLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IVisitLogic, VisitLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServiceLogic, ServiceLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<IImplementerLogic, ImplementerLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
