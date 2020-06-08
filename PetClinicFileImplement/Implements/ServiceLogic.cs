using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicFileImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinicFileImplement.Implements
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly FileDataListSingleton source;
        public ServiceLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ServiceBindingModel model)
        {
            Service tempService = model.Id.HasValue ? null : new Service { Id = 1 };
            foreach (var service in source.Services)
            {
                if (service.ServiceName == model.ServiceName && service.Id != model.Id)
                {
                    throw new Exception("Уже есть услуга с таким названием.");
                }
                if (!model.Id.HasValue && service.Id >= tempService.Id)
                {
                    tempService.Id = service.Id + 1;
                }
                else if (model.Id.HasValue && service.Id == model.Id)
                {
                    tempService = service;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempService == null)
                {
                    throw new Exception("Услуга не найдена.");
                }
                CreateModel(model, tempService);
            }
            else
            {
                source.Services.Add(CreateModel(model, tempService));
            }
        }
        public void Delete(ServiceBindingModel model)
        {
            for (int i = 0; i < source.ServiceMedicines.Count; ++i)
            {
                if (source.ServiceMedicines[i].ServiceId == model.Id)
                {
                    source.ServiceMedicines.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Services.Count; ++i)
            {
                if (source.Services[i].Id == model.Id)
                {
                    source.Services.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Услуга не найдена.");
        }
        private Service CreateModel(ServiceBindingModel model, Service mebel)
        {
            mebel.ServiceName = model.ServiceName;
            mebel.Price = model.Price;
            int maxId = 0;
            for (int i = 0; i < source.ServiceMedicines.Count; ++i)
            {
                if (source.ServiceMedicines[i].Id > maxId)
                {
                    maxId = source.ServiceMedicines[i].Id;
                }
                if (source.ServiceMedicines[i].ServiceId == mebel.Id)
                {
                    if
                    (model.ServiceMedicines.ContainsKey(source.ServiceMedicines[i].MedicineId))
                    {
                        source.ServiceMedicines[i].Count =
                        model.ServiceMedicines[source.ServiceMedicines[i].MedicineId].Item2;
                        model.ServiceMedicines.Remove(source.ServiceMedicines[i].MedicineId);
                    }
                    else
                    {
                        source.ServiceMedicines.RemoveAt(i--);
                    }
                }
            }
            foreach (var sm in model.ServiceMedicines)
            {
                source.ServiceMedicines.Add(new ServiceMedicine
                {
                    Id = ++maxId,
                    ServiceId = mebel.Id,
                    MedicineId = sm.Key,
                    Count = sm.Value.Item2
                });
            }
            return mebel;
        }
        public List<ServiceViewModel> Read(ServiceBindingModel model)
        {
            List<ServiceViewModel> result = new List<ServiceViewModel>();
            foreach (var service in source.Services)
            {
                if (model != null)
                {
                    if (service.Id == model.Id)
                    {
                        result.Add(CreateViewModel(service));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(service));
            }
            return result;
        }
        private ServiceViewModel CreateViewModel(Service service)
        {
            Dictionary<int, (string, int)> serviceMedicines = new Dictionary<int,(string, int)>();
            foreach (var sm in source.ServiceMedicines)
            {
                if (sm.ServiceId == service.Id)
                {
                    string medicineName = string.Empty;
                    foreach (var medicine in source.Medicines)
                    {
                        if (sm.MedicineId == medicine.Id)
                        {
                            medicineName = medicine.MedicineName;
                            break;
                        }
                    }
                    serviceMedicines.Add(sm.MedicineId, (medicineName, sm.Count));
                }
            }
            return new ServiceViewModel
            {
                Id = service.Id,
                ServiceName = service.ServiceName,
                Price = service.Price,
                ServiceMedicines = serviceMedicines
            };
        }
    }
}
