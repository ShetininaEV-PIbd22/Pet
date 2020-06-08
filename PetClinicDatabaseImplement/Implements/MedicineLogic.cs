using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDatabaseImplement.Implements
{
    public class MedicineLogic : IMedicineLogic
    {
        public void CreateOrUpdate(MedicineBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                Medicine element = context.Medicines.FirstOrDefault(rec => rec.MedicineName == model.MedicineName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть медикамент с таким названием.");
                }
                if (model.Id.HasValue)
                {
                    element = context.Medicines.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Медикамент не найден");
                    }
                }
                else
                {
                    element = new Medicine();
                    context.Medicines.Add(element);
                }

                element.MedicineName = model.MedicineName;
                context.SaveChanges();
            }
        }
        public void Delete(MedicineBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                Medicine element = context.Medicines.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Medicines.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Медикамент не найден");
                }
            }
        }
        public List<MedicineViewModel> Read(MedicineBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                return context.Medicines
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
}
