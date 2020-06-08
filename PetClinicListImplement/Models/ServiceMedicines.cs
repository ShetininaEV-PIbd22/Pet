namespace PetClinicListImplement.Models
{
    /// <summary>
    /// Сколько компонентов требуется при изготовлении изделия
    /// </summary>
    public class ServiceMedicines
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int MedicineId { get; set; }
        public int Count { get; set; }
    }
}
