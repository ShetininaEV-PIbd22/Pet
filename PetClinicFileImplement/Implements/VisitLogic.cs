using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Enums;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicFileImplement.Implements
{
    public class VisitLogic : IVisitLogic
    {
        private readonly FileDataListSingleton source;
        public VisitLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(VisitBindingModel model)
        {
            Visit element;

            if (model.Id.HasValue)
            {
                element = source.Visits.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Visits.Count > 0 ? source.Visits.Max(rec => rec.Id) : 0;
                element = new Visit { Id = maxId + 1 };
                source.Visits.Add(element);
            }

            element.ServiceId = model.ServiceId == 0 ? element.ServiceId : model.ServiceId;
            element.ClientId = model.ClientId.Value;
            element.Animal = model.Animal;
            element.AnimalName = model.AnimalName;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateVisit = model.DateVisit;
        }

        public void Delete(VisitBindingModel model)
        {
            Visit order = source.Visits.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Visits.Remove(order);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<VisitViewModel> Read(VisitBindingModel model)
        {
            return source.Visits
             .Where(
                 rec => model == null
                 || rec.Id == model.Id
                 || model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateVisit >= model.DateFrom && rec.DateVisit <= model.DateTo
                 || model.ClientId.HasValue && rec.ClientId == model.ClientId
                 //|| model.FreeOrders.HasValue && model.FreeOrders.Value && !rec.ImplementerId.HasValue
                 //|| model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == VisitStatus.Выполняется
             )
             .Select(rec => new VisitViewModel
             {
                 Id = rec.Id,
                 ClientId = rec.ClientId,
                 ServiceId = rec.ServiceId,
                 Animal=rec.Animal,
                 AnimalName=rec.AnimalName,
                 ClientFIO = source.Clients.FirstOrDefault(recC => recC.Id == rec.ClientId)?.FIO,
                 ServiceName = source.Services.FirstOrDefault(recP => recP.Id == rec.ServiceId)?.ServiceName,
                 Count = rec.Count,
                 Sum = rec.Sum,
                 Status = rec.Status,
                 DateVisit = rec.DateVisit,
             })
             .ToList();
        }
    }
}
