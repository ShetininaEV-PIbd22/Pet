using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicListImplement.Implements
{
    public class VisitLogic: IVisitLogic
    {
        private readonly DataListSingleton source;

        public VisitLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(VisitBindingModel model)
        {
            Visit tempOrder = model.Id.HasValue ? null : new Visit { Id = 1 };

            foreach (var order in source.Visits)
            {
                if (!model.Id.HasValue && order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
                else if (model.Id.HasValue && order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }

                CreateModel(model, tempOrder);
            }
            else
            {
                source.Visits.Add(CreateModel(model, tempOrder));
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

            throw new Exception("Элемент не найден");
        }

        private Visit CreateModel(VisitBindingModel model, Visit visit)
        {
            visit.ClientId = model.ClientId;
            visit.ClientFIO = source.Clients.FirstOrDefault((n) => n.Id == visit.ClientId).FIO;
            visit.DateVisit = model.DateVisit;
            visit.Animal = model.Animal;
            visit.AnimalName = model.AnimalName;
            visit.Status = model.Status;
            visit.Sum = model.Sum;
            
            return visit;
        }

        public List<VisitViewModel> Read(VisitBindingModel model)
        {
            List<VisitViewModel> result = new List<VisitViewModel>();
            foreach (var visit in source.Visits)
            {
                if (model != null)
                {
                    if (visit.Id == model.Id && visit.ClientId == model.ClientId)
                    {
                        result.Add(CreateViewModel(visit));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(visit));
            }
            return result;
        }

        private VisitViewModel CreateViewModel(Visit visit)
        {
            return new VisitViewModel
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                ClientFIO = source.Clients.FirstOrDefault((n) => n.Id == visit.ClientId).FIO,
                DateVisit = visit.DateVisit,
                Animal=visit.Animal,
                AnimalName=visit.AnimalName,
                Status = visit.Status,
                Sum = visit.Sum
            };
        }
    }
}

