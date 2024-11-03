using Microsoft.EntityFrameworkCore;
using shared;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Equipment> Equipment { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "Molding Machine A", CurrentState = EquipmentState.Red },
                new Equipment { Id = 2, Name = "Molding Machine B", CurrentState = EquipmentState.Yellow },
                new Equipment { Id = 3, Name = "Molding Machine C", CurrentState = EquipmentState.Green },
                new Equipment { Id = 4, Name = "Assembly Line A", CurrentState = EquipmentState.Red },
                new Equipment { Id = 5, Name = "Assembly Line B", CurrentState = EquipmentState.Yellow },
                new Equipment { Id = 6, Name = "Assembly Line C", CurrentState = EquipmentState.Green },
                new Equipment { Id = 7, Name = "Packaging Unit A", CurrentState = EquipmentState.Red },
                new Equipment { Id = 8, Name = "Packaging Unit B", CurrentState = EquipmentState.Yellow },
                new Equipment { Id = 9, Name = "Packaging Unit C", CurrentState = EquipmentState.Green }
            );
        }
    }
}

