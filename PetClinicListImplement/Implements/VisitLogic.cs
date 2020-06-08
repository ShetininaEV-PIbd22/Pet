using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Enums;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinicListImplement.Implements
{
    public class VisitLogic : IVisitLogic
    {
        private readonly DataListSingleton source;

        public VisitLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(VisitBindingModel model)
        {
            Visit tempVisit = model.Id.HasValue ? null : new Visit { Id = 1 };

            foreach (var visit in source.Visits)
            {
                if (!model.Id.HasValue && visit.Id >= tempVisit.Id)
                {
                    tempVisit.Id = visit.Id + 1;
                }
                else if (model.Id.HasValue && visit.Id == model.Id)
                {
                    tempVisit = visit;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempVisit == null)
                {
                    throw new Exception("Заявка на визит не найдена.");
                }

                CreateModel(model, tempVisit);
            }
            else
            {
                source.Visits.Add(CreateModel(model, tempVisit));
            }
        }

        public void Delete(VisitBindingModel model)
        {
            for (int i = 0; i < source.Visits.Count; ++i)
            {
                if (source.Visits[i].Id == model.Id)
                {
                    source.Visits.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Заявка на визит не найдена.");
        }

        private Visit CreateModel(VisitBindingModel model, Visit visit)
        {
            visit.ServiceId = model.ServiceId;
            visit.Animal = model.Animal;
            visit.AnimalName = model.AnimalName;
            visit.Count = model.Count;
            visit.ClientId = (int)model.ClientId;
            visit.DateVisit = model.DateVisit;
            visit.Sum = model.Sum;
            visit.Status = model.Status;

            return visit;
        }

        public List<VisitViewModel> Read(VisitBindingModel model)
        {
            List<VisitViewModel> result = new List<VisitViewModel>();

            foreach (var visit in source.Visits)
            {
                if (
                    model != null && visit.Id == model.Id
                    || model.DateFrom.HasValue && model.DateTo.HasValue && visit.DateVisit >= model.DateFrom && visit.DateVisit <= model.DateTo
                    //|| model.FreeOrders.HasValue && model.FreeOrders.Value
                )
                {
                    result.Add(CreateViewModel(visit));
                    break;
                }

                result.Add(CreateViewModel(visit));
            }

            return result;
        }

        private VisitViewModel CreateViewModel(Visit visit)
        {
            string serviceName = null;

            foreach (var service in source.Services)
            {
                if (service.Id == visit.ServiceId)
                {
                    serviceName = service.ServiceName;
                }
            }

            if (serviceName == null)
            {
                throw new Exception("Услуга не найдена.");
            }

            return new VisitViewModel
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                ServiceId = visit.ServiceId,
                ServiceName = serviceName,
                Animal= visit.Animal,
                AnimalName= visit.AnimalName,
                Count = visit.Count,
                Sum = visit.Sum,
                Status = visit.Status,
                DateVisit = visit.DateVisit,
            };
        }
    }
}
