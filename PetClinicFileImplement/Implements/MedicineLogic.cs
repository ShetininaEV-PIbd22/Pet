using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicFileImplement.Models;

namespace PetClinicFileImplement.Implements
{
    public class MedicineLogic: IMedicineLogic
    {
        private readonly FileDataListSingleton source;
        public MedicineLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(MedicineBindingModel model)
        {
            Medicine element = source.Medicines.FirstOrDefault(rec => rec.MedicineName == model.MedicineName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть медикамент с таким названием.");
            }
            if (model.Id.HasValue)
            {
                element = source.Medicines.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Медикамент не найден.");
                }
            }
            else
            {
                int maxId = source.Medicines.Count > 0 ? source.Medicines.Max(rec => rec.Id) : 0;
                element = new Medicine { Id = maxId + 1 };
                source.Medicines.Add(element);
            }
            element.MedicineName = model.MedicineName;
        }
        public void Delete(MedicineBindingModel model)
        {
            Medicine element = source.Medicines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Medicines.Remove(element);
            }
            else
            {
                throw new Exception("Медикамент не найден.");
            }
        }
        public List<MedicineViewModel> Read(MedicineBindingModel model)
        {
            return source.Medicines
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new MedicineViewModel
            {
                Id = rec.Id,
                MedicineName = rec.MedicineName
            })
            .ToList();
        }
    }
}
