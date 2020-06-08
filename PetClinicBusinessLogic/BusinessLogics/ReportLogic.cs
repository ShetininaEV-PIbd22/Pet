using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.HelperModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinicBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IMedicineLogic medicineLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly IVisitLogic visitLogic;
        public ReportLogic(IServiceLogic serviceLogic, IMedicineLogic medicineLogic, IVisitLogic visitLogic)
        {
            this.serviceLogic = serviceLogic;
            this.medicineLogic = medicineLogic;
            this.visitLogic = visitLogic;
        }
        public List<ReportServiceMedicineViewModel> GetServiceMedicine()
        {
            var medicines = medicineLogic.Read(null);
            var services = serviceLogic.Read(null);
            var list = new List<ReportServiceMedicineViewModel>();
            foreach (var service in services)
            {
                    foreach (var medicine in medicines)
                    {
                        if (service.ServiceMedicines.ContainsKey(medicine.Id))
                        {
                            list.Add(new ReportServiceMedicineViewModel
                            {
                                ServiceName= service.ServiceName,
                                MedicineName = medicine.MedicineName,
                                Count = service.ServiceMedicines[medicine.Id].Item2
                            });
                        }

                    }
            }
                return list;
        }
        public List<ReportVisitsViewModel> GetVisits(ReportBindingModel model)
        {
            return visitLogic.Read(new VisitBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportVisitsViewModel
            {
                DateVisit = x.DateVisit,
                ServiceName = x.ServiceName,
                Animal=x.Animal,
                AnimalName=x.AnimalName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        public void SaveServicesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список услуг",
                Services = serviceLogic.Read(null)
            });
        }
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список визитов",
                Visits = GetVisits(model)
            });
        }
        public void SaveServiceMedicinesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список услуг с необходимыми медикаментами",
                ServiceMedicines = GetServiceMedicine()
            });
        }
    }
}
