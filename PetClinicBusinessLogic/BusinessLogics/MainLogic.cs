using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Enums;
using PetClinicBusinessLogic.HelperModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinicBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IVisitLogic visitLogic;

        private readonly object locker = new object();

        public MainLogic(IVisitLogic visitLogic)
        {
            this.visitLogic = visitLogic;
        }

        public void CreateVisit(CreateVisitBindingModel model)
        {
            visitLogic.CreateOrUpdate(new VisitBindingModel
            {
                ServiceId = model.ServiceId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateVisit =model.DataVisit,
                Status = VisitStatus.Принят
            });
        }

        public void TakeVisitInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var visit = visitLogic.Read(new VisitBindingModel { Id = model.VisitId })?[0];

                if (visit == null)
                {
                    throw new Exception("Заявка на визит не найдена.");
                }

                if (visit.Status != VisitStatus.Принят)
                {
                    throw new Exception("Заявка на визит не находится в статусе \"Принят\".");
                }
                
                visitLogic.CreateOrUpdate(new VisitBindingModel
                {
                    Id = visit.Id,
                    ClientId = visit.ClientId,
                    ServiceId = visit.ServiceId,
                    Animal=visit.Animal,
                    AnimalName=visit.AnimalName,
                    Count = visit.Count,
                    Sum = visit.Sum,
                    DateVisit = visit.DateVisit,
                    Status = VisitStatus.Выполняется
                });
            }
        }

        public void FinishVisit(ChangeStatusBindingModel model)
        {
            var visit = visitLogic.Read(new VisitBindingModel { Id = model.VisitId })?[0];

            if (visit == null)
            {
                throw new Exception("Заявка на визит не найдена.");
            }

            if (visit.Status != VisitStatus.Выполняется)
            {
                throw new Exception("Заявка на визит не находится в статусе \"Выполняется\".");
            }

            visitLogic.CreateOrUpdate(new VisitBindingModel
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                ServiceId = visit.ServiceId,
                Animal=visit.Animal,
                AnimalName=visit.AnimalName,
                Count = visit.Count,
                Sum = visit.Sum,
                DateVisit = visit.DateVisit,
                Status = VisitStatus.Готов
            });
        }

        public void PayVisit(ChangeStatusBindingModel model)
        {
            var visit = visitLogic.Read(new VisitBindingModel { Id = model.VisitId })?[0];

            if (visit == null)
            {
                throw new Exception("Заявка на визит не найдена.");
            }

            if (visit.Status != VisitStatus.Готов)
            {
                throw new Exception("Заявка на визит не находится в статусе  \"Готов\".");
            }

            visitLogic.CreateOrUpdate(new VisitBindingModel
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                ServiceId = visit.ServiceId,
                Animal=visit.Animal,
                AnimalName=visit.AnimalName,
                Count = visit.Count,
                Sum = visit.Sum,
                DateVisit = visit.DateVisit,
                Status = VisitStatus.Оплачен
            });
        }
    }
}
