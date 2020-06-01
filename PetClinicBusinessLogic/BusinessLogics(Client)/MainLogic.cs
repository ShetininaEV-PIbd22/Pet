using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Enums;
using PetClinicBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.BusinessLogics_Client_
{
    public class MainLogic
    {
        private readonly IVisitLogic visitLogic;
        public MainLogic(IVisitLogic visitLogic)
        {
            this.visitLogic = visitLogic;
        }
        public void CreateVisit(CreateVisitBindingModel model)
        {
            visitLogic.CreateOrUpdate(new VisitBindingModel
            {
                ClientId = model.ClientId,
                ClientFIO = model.ClientFIO,
                DateVisit = DateTime.Now,
                Animal = model.Animal,
                AnimalName=model.AnimalName,
                Sum = model.Sum,
                Status = VisitStatus.Принят
            }) ;
        }
        public void PayVisit(ChangeStatusBindingModel model)
        {
            var visit = visitLogic.Read(new VisitBindingModel { Id = model.VisitId })?[0];
            if (visit == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (visit.Status != VisitStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            visitLogic.CreateOrUpdate(new VisitBindingModel
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                ClientFIO = visit.ClientFIO,
                DateVisit = DateTime.Now,
                Animal = visit.Animal,
                AnimalName = visit.AnimalName,
                Sum = visit.Sum,
                Status = VisitStatus.Оплачен
            });
        }
    }
}
