using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicDatabaseImplement.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBusinessLogic.Enums;

namespace PetClinicDatabaseImplement.Implements
{
    public class VisitLogic : IVisitLogic
    {
        private readonly PetClinicDatabase source;
        public void CreateOrUpdate(VisitBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                Visit element;

                if (model.Id.HasValue)
                {
                    element = context.Visits.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Заявка на визит не найдена.");
                    }
                }
                else
                {
                    element = new Visit();
                    context.Visits.Add(element);
                }

                element.ServiceId = model.ServiceId == 0 ? element.ServiceId : model.ServiceId;
                element.ClientId = model.ClientId.Value;
                element.Animal = model.Animal;
                element.AnimalName = model.AnimalName;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateVisit = model.DateVisit;
                context.SaveChanges();
            }
        }

        public void Delete(VisitBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                Visit element = context.Visits.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Visits.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заявка на визит не найдена.");
                }
            }
        }

        public List<VisitViewModel> Read(VisitBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                return context.Visits
               .Where(
                   rec => model == null
                   || rec.Id == model.Id && model.Id.HasValue
                   || model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateVisit >= model.DateFrom && rec.DateVisit <= model.DateTo
                   || model.ClientId.HasValue && rec.ClientId == model.ClientId
               )
               .Include(rec => rec.Service)
               .Include(rec => rec.Client)
               .Select(rec => new VisitViewModel
               {
                   Id = rec.Id,
                   ClientId = rec.ClientId,
                   ServiceId = rec.ServiceId,
                   Animal=rec.Animal,
                   AnimalName=rec.AnimalName,
                   Count = rec.Count,
                   Sum = rec.Sum,
                   Status = rec.Status,
                   DateVisit = rec.DateVisit,
                   ServiceName = rec.Service.ServiceName,
                   ClientFIO = rec.Client.FIO,
               })
               .ToList();
            }
        }
    }
}
