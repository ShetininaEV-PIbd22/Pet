using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetClinicRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IVisitLogic _order;
        private readonly IServiceLogic _product;
        private readonly MainLogic _main;
        private ReportClientLogic _report;

        public MainController(IVisitLogic order, IServiceLogic product, MainLogic main, ReportClientLogic report)
        {
            _order = order;
            _product = product;
            _main = main;
             _report = report;
        }
        [HttpGet]
        public List<ServiceModel> GetServiceList() => _product.Read(null)?.Select(rec => Convert(rec)).ToList();
        [HttpGet]
        public ServiceModel GetService(int serviceId) => Convert(_product.Read(new ServiceBindingModel { Id = serviceId })?[0]);
        [HttpGet]
        public List<VisitViewModel> GetVisits(int clientId) => _order.Read(new VisitBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateVisit(CreateVisitBindingModel model) => _main.CreateVisit(model);
        public List<VisitViewModel> GetVisitsList() => _order.Read(null).ToList();
        
        private ServiceModel Convert(ServiceViewModel model)
        {
            if (model == null) return null;
            return new ServiceModel
            {
                Id = model.Id,
                ServiceName = model.ServiceName,
                Price = model.Price
            };
        }
        [HttpPost]
        public void SendMessage(ReportBindingModel model) => _report.SendMessage(model);
        [HttpPost]
        public void SaveServicesToWordFile(ReportBindingModel model) => _report.SaveServicesToWordFile(model);
        [HttpPost]
        public void SaveServicesToExcelFile(ReportBindingModel model) => _report.SaveServicesToExcelFile(model);
        [HttpPost]
        [Obsolete]
        public void SaveVisitsToPdfFile(ReportBindingModel model) => _report.SaveVisitsToPdfFile(model);
    }
}