using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PetClinicBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
