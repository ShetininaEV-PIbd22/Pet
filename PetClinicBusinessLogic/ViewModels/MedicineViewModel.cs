using System.ComponentModel;

namespace PetClinicBusinessLogic.ViewModels
{
    public class MedicineViewModel
    {
        public int Id { get; set; }

        [DisplayName("Медикамент")] 
        public string MedicineName { get; set; }
    }
}
