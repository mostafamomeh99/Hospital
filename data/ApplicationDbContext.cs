using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var connection = builder.GetConnectionString("DefaultConnection");


            optionsBuilder.UseSqlServer(connection);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                   new Doctor { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Image = "doctor1.jpg" },
                   new Doctor { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Image = "doctor2.jpg" },
                   new Doctor { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Image = "doctor4.jpg" },
                   new Doctor { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Image = "doctor3.jpg" },
                   new Doctor { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Image = "doctor5.jpg" }
               );

            modelBuilder.HasSequence<int>("IdNumbers");

            modelBuilder.Entity<Appointment>()
                .Property(o => o.AppointmentId)
                .HasDefaultValueSql("NEXT VALUE FOR IdNumbers");
        }

    }
}
