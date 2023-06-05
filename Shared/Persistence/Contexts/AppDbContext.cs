using Microsoft.EntityFrameworkCore;
using server.CargoTrack.Domain.Models;

namespace Shared.Persistence.Contexts;

public class AppDbContext:DbContext
{
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Person>Persons { get; set; }
        public DbSet<BrandVehicle>BrandVehicles { get; set; }
        public DbSet<Courier>Couriers { get; set; }
        public DbSet<License>Licenses { get; set; }
        public DbSet<PaymentMethod>PaymentMethods { get; set; }
        public DbSet<PaymentService>PaymentServices { get; set; }
        public DbSet<Service>Services { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<UserRequest>UserRequests { get; set; }
        public DbSet<Vehicle>Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*-----------------------Properties and keys-----------------------*/
                
            //Person
            builder.Entity<Person>().ToTable("Persons");
            builder.Entity<Person>().HasKey(p => p.Id);
            builder.Entity<Person>().Property(p=>p.Id).IsRequired();
            builder.Entity<Person>().Property(p => p.Phone).HasMaxLength(50);
            
            //BrandVehicle
            builder.Entity<BrandVehicle>().ToTable("BrandVehicles");
            builder.Entity<BrandVehicle>().HasKey(p => p.Id);
            builder.Entity<BrandVehicle>().Property(p=>p.Id).IsRequired();
            builder.Entity<BrandVehicle>().Property(p => p.Brand).HasMaxLength(50);
            
            //Courier
            builder.Entity<Courier>().ToTable("Couriers");
            builder.Entity<Courier>().HasKey(p => p.PersonId);
            builder.Entity<Courier>().Property(p=>p.PersonId).IsRequired();
            builder.Entity<Courier>().Property(p=>p.DNI).HasMaxLength(50);
            builder.Entity<Courier>().Property(p=>p.Name).HasMaxLength(50);
            builder.Entity<Courier>().Property(p=>p.LastName).HasMaxLength(50);
            builder.Entity<Courier>().Property(p=>p.BirthDay).HasMaxLength(10);
            builder.Entity<Courier>().Property(p=>p.Email).HasMaxLength(50);
            builder.Entity<Courier>().Property(p=>p.LicenseNumber);
            
            //License
            builder.Entity<License>().ToTable("Licenses");
            builder.Entity<License>().HasKey(p => p.Id);
            builder.Entity<License>().Property(p=>p.Id).IsRequired();
            builder.Entity<License>().Property(p=>p.Class);
            builder.Entity<License>().Property(p=>p.Category);
            
            //PaymentMethod
            builder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            builder.Entity<PaymentMethod>().HasKey(p => p.Id);
            builder.Entity<PaymentMethod>().Property(p=>p.Id).IsRequired();
            builder.Entity<PaymentMethod>().Property(p=>p.Type);
            
            //PaymentService
            builder.Entity<PaymentService>().ToTable("PaymentServices");
            builder.Entity<PaymentService>().HasKey(p => p.Id);
            builder.Entity<PaymentService>().Property(p=>p.Id).IsRequired();
            builder.Entity<PaymentService>().Property(p=>p.CardUser);
            builder.Entity<PaymentService>().Property(p=>p.CardCourier);
            
            //Service
            builder.Entity<Service>().ToTable("Services");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p=>p.Id).IsRequired();
            builder.Entity<Service>().Property(p=>p.IsFinalized);
            
            //User
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.PersonId);
            builder.Entity<User>().Property(p=>p.PersonId).IsRequired();

            //UserRequest
            builder.Entity<UserRequest>().ToTable("UserRequests");
            builder.Entity<UserRequest>().HasKey(p => p.Id);
            builder.Entity<UserRequest>().Property(p=>p.Id).IsRequired();
            builder.Entity<UserRequest>().Property(p=>p.AddressStart).HasMaxLength(500);
            builder.Entity<UserRequest>().Property(p=>p.AddressEnd).HasMaxLength(500);
            builder.Entity<UserRequest>().Property(p=>p.ReferenceAddress).HasMaxLength(500);
            builder.Entity<UserRequest>().Property(p=>p.Photo).HasMaxLength(500);
            builder.Entity<UserRequest>().Property(p=>p.Description).HasMaxLength(500);
            builder.Entity<UserRequest>().Property(p=>p.Date).HasMaxLength(30);
            builder.Entity<UserRequest>().Property(p=>p.Hour).HasMaxLength(15);

            //Vehicle
            builder.Entity<Vehicle>().ToTable("Vehicles");
            builder.Entity<Vehicle>().HasKey(p => p.Id);
            builder.Entity<Vehicle>().Property(p=>p.Id).IsRequired();
            builder.Entity<Vehicle>().Property(p=>p.Plate).HasMaxLength(10);
            builder.Entity<Vehicle>().Property(p=>p.Photo).HasMaxLength(500);
            builder.Entity<Vehicle>().Property(p=>p.CirculationCard).HasMaxLength(50);
            
            /*----------------------- Relationships and Foreignkeys -----------------------*/
            
            // --------------------------- Person -------------------------------- //
        
            //Person with User
            builder.Entity<Person>()
                .HasOne(p => p.User)
                .WithOne(p => p.Person)
                .HasForeignKey<User>(p => p.PersonId).IsRequired();
            
            //Person with Courier
            builder.Entity<Person>()
                .HasOne(p => p.Courier)
                .WithOne(p => p.Person)
                .HasForeignKey<Courier>(p => p.PersonId).IsRequired();
            
            
            // --------------------------- Courier -------------------------------- //
        
            //Courier with License
            builder.Entity<Courier>()
                .HasMany(p => p.Licenses)
                .WithOne(p => p.Courier)
                .HasForeignKey(p => p.Courier_PersonId);
            
            //Courier with Vehicle
            builder.Entity<Courier>()
                .HasMany(p => p.Vehicles)
                .WithOne(p => p.Courier)
                .HasForeignKey(p => p.Courier_PersonId);
            
            //Courier with Service
            builder.Entity<Courier>()
                .HasMany(p => p.Services)
                .WithOne(p => p.Courier)
                .HasForeignKey(p => p.Courier_PersonId);
        
            // --------------------------- UserRequest -------------------------------- //
        
            //UserRequest with User
            builder.Entity<UserRequest>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserRequests)
                .HasForeignKey(p => p.User_PersonId)
                .IsRequired(false);
      
            //UserRequest with Service
            builder.Entity<UserRequest>()
                .HasMany(p => p.Services)
                .WithOne(p => p.UserRequest)
                .HasForeignKey(p => p.UserRequestId);
            
            // --------------------------- Vehicle -------------------------------- //
        
            //Vehicle with BrandVehicle
            builder.Entity<Vehicle>()
                .HasOne(p => p.BrandVehicle)
                .WithOne(p => p.Vehicle)
                .HasForeignKey<Vehicle>(p => p.BrandVehicleId);
            
            // --------------------------- PaymentService -------------------------------- //
        
            //PaymentService with PaymentMethod
            builder.Entity<PaymentService>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(p => p.PaymentServices)
                .HasForeignKey(p => p.PaymentMethodId)
                .IsRequired(false);
      
            //PaymentService with Service
            builder.Entity<PaymentService>()
                .HasOne(p => p.Service)
                .WithOne(p => p.PaymentService)
                .HasForeignKey<Service>(p => p.PaymentServiceId);

        }
}
