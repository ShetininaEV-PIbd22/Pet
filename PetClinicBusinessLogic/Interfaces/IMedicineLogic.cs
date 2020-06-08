using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PetClinicBusinessLogic.Interfaces
{
    public interface IMedicineLogic
    {
        List<MedicineViewModel> Read(MedicineBindingModel model);
        void CreateOrUpdate(MedicineBindingModel model);
        void Delete(MedicineBindingModel model);
    }
}