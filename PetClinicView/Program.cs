using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.HelperModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicDatabaseImplement.Implements;
using System;
using System.Configuration;
using System.Threading;
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
        static void Main()
        {
            var container = BuildUnityContainer();
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
            });
            // создаем таймер
            var timer = new System.Threading.Timer(new TimerCallback(MailCheck), new MailCheckInfo
            {
                PopHost = ConfigurationManager.AppSettings["PopHost"],
                PopPort = Convert.ToInt32(ConfigurationManager.AppSettings["PopPort"]),
                Logic = container.Resolve<IMessageInfoLogic>()
            }, 0, 100000);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
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
            currentContainer.RegisterType<IMessageInfoLogic, MessageInfoLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
