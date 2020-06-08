using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PetClinicBusinessLogic.Interfaces
{
    public interface IServiceLogic
    {
        List<ServiceViewModel> Read(ServiceBindingModel model);
        void CreateOrUpdate(ServiceBindingModel model);
        void Delete(ServiceBindingModel model);
    }
}
