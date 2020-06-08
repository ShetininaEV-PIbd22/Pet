using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicListImplement.Models;
using System;
using System.Collections.Generic;

namespace PetClinicListImplement.Implements
{
    public class MedicineLogic : IMedicineLogic
    {
        private readonly DataListSingleton source;

        public MedicineLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(MedicineBindingModel model)
        {
            Medicine tempMedicine = model.Id.HasValue ? null : new Medicine { Id = 1 };
            foreach (var medicine in source.Medicines)
            {
                if (medicine.MedicineName == model.MedicineName && medicine.Id != model.Id)
                    throw new Exception("Уже есть мкедикамент с таким названием.");
                if (!model.Id.HasValue && medicine.Id >= tempMedicine.Id)
                    tempMedicine.Id = medicine.Id + 1;
                else if (model.Id.HasValue && medicine.Id == model.Id)
                    tempMedicine = medicine;
            }
            if (model.Id.HasValue)
            {
                if (tempMedicine == null)
                    throw new Exception("Медикамент не найден.");
                CreateModel(model, tempMedicine);
            }
            else
            {
                source.Medicines.Add(CreateModel(model, tempMedicine));
            }
        }

        public void Delete(MedicineBindingModel model)
        {
            for (int i = 0; i < source.Medicines.Count; ++i)
                if (source.Medicines[i].Id == model.Id.Value)
                {
                    source.Medicines.RemoveAt(i);
                    return;
                }
            throw new Exception("Медикамент не найден.");
        }

        public List<MedicineViewModel> Read(MedicineBindingModel model)
        {
            List<MedicineViewModel> result = new List<MedicineViewModel>();
            foreach (var medicine in source.Medicines)
            {
                if (model != null)
                {
                    if (medicine.Id == model.Id)
                    {
                        result.Add(CreateViewModel(medicine));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(medicine));
            }
            return result;
        }

        private Medicine CreateModel(MedicineBindingModel model, Medicine medicine)
        {
            medicine.MedicineName = model.MedicineName;
            return medicine;
        }

        private MedicineViewModel CreateViewModel(Medicine medicine)
        {
            return new MedicineViewModel
            {
                Id = medicine.Id,
                MedicineName = medicine.MedicineName
            };
        }
    }
}
