using PetClinicDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace PetClinicDatabaseImplement
{
    public class PetClinicDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LIZA\SQLEXPRESS;Initial Catalog=PetClinicDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Medicine> Medicines { set; get; }
        public virtual DbSet<Service> Services { set; get; }
        public virtual DbSet<ServiceMedicine> ServiceMedicines { set; get; }
        public virtual DbSet<Visit> Visits { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<MessageInfo> MessageInfos { set; get; }
    }
}
