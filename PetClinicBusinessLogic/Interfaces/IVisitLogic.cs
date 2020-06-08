using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PetClinicBusinessLogic.Interfaces
{
    public interface IVisitLogic
    {
        List<VisitViewModel> Read(VisitBindingModel model);
        void CreateOrUpdate(VisitBindingModel model);
        void Delete(VisitBindingModel model);
    }
}
