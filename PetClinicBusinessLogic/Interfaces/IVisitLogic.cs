using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinicBusinessLogic.Interfaces
{
    public interface IVisitLogic
    {
        List<VisitViewModel> Read(VisitBindingModel model);
        void CreateOrUpdate(VisitBindingModel model);
        void Delete(VisitBindingModel model);
    }
}
