using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PetClinicDatabaseImplement.Implements
{
    public class ServiceLogic : IServiceLogic
    {
        public void CreateOrUpdate(ServiceBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Service element = context.Services.FirstOrDefault(rec => rec.ServiceName == model.ServiceName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть услуга с таким названием.");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);

                            if (element == null)
                            {
                                throw new Exception("Услуга не найдена.");
                            }
                        }
                        else
                        {
                            element = new Service();
                            context.Services.Add(element);
                        }

                        element.ServiceName = model.ServiceName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var shipComponents = context.ServiceMedicines.Where(rec => rec.ServiceId == model.Id.Value).ToList();
                            context.ServiceMedicines.RemoveRange(shipComponents.Where(rec => !model.ServiceMedicines.ContainsKey(rec.MedicineId)).ToList());
                            context.SaveChanges();
                            foreach (var updateComponent in shipComponents)
                            {
                                updateComponent.Count =
                                model.ServiceMedicines[updateComponent.MedicineId].Item2;
                                model.ServiceMedicines.Remove(updateComponent.MedicineId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.ServiceMedicines)
                        {
                            context.ServiceMedicines.Add(new ServiceMedicine
                            {
                                ServiceId = element.Id,
                                MedicineId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(ServiceBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ServiceMedicines.RemoveRange(context.ServiceMedicines.Where(rec => rec.ServiceId == model.Id));
                        Service element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Services.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<ServiceViewModel> Read(ServiceBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                return context.Services
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new ServiceViewModel
                {
                    Id = rec.Id,
                    ServiceName = rec.ServiceName,
                    Price = rec.Price,
                    ServiceMedicines = context.ServiceMedicines
                .Include(recPC => recPC.Medicine)
                .Where(recPC => recPC.ServiceId == rec.Id)
                .ToDictionary(recPC => recPC.MedicineId, recPC =>
                (recPC.Medicine?.MedicineName, recPC.Count))
                })
                .ToList();
            }
        }

    }
}
