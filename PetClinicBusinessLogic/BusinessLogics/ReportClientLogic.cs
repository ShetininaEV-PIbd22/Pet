using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.HelperModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace PetClinicBusinessLogic.BusinessLogics
{
    public class ReportClientLogic
    {
        private readonly IServiceLogic serviceLogic;
        private readonly IVisitLogic visitLogic;
        
        public ReportClientLogic(IServiceLogic serviceLogic, IVisitLogic visitLogic)
        {
            this.serviceLogic = serviceLogic;
            this.visitLogic = visitLogic;
        }
        
        public List<ReportVisitsViewModel> GetVisits(ReportBindingModel model)
        {
            return visitLogic.Read(null)
            .Where(rec => rec.ClientId == model.ClientId)
            .Where(rec => rec.DateVisit.Date <= model.DateFrom.Value.Date)
            .Where(rec => rec.DateVisit.Date >= model.DateTo.Value.Date)
            .Select(x => new ReportVisitsViewModel
            {
                DateVisit = x.DateVisit,
                ServiceName = x.ServiceName,
                Animal = x.Animal,
                AnimalName = x.AnimalName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        
        public List<ReportServiceViewModel> GetServices()
        {
            var list = new List<ReportServiceViewModel>();
            var services = serviceLogic.Read(null);
            foreach (var service in services)
            {
                list.Add(new ReportServiceViewModel
                {
                    ServiceName = service.ServiceName,
                    Price = Convert.ToInt32(service.Price)
                });
            }
            return list;
        }
        
        public void SaveServicesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocForServices(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список услуг",
                Services = GetServices()
            });
        }
        
        public void SaveServicesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocForServices(new ExcelInfo
            {
                FileName = model.FileName, 
                Title = "Список услуг",
                Services = GetServices()
            });
        }
        
        public void SaveVisitsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocForVisits(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список визитов",
                Visits = model.Visits
            });
        }
        
        public void SendMessage(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            MailAddress to = new MailAddress(model.Email);
            MailMessage message = new MailMessage(from, to);
            message.Attachments.Add(new Attachment(model.FileName));
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}
