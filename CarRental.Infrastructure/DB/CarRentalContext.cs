using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRental.Model.Models;
using CarRental.Model.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using CarRental.Infrastructure.Extensions.ModelBuilderStuff;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Infrastructure.DB
{
    public class CarRentalContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        
        public CarRentalContext(DbContextOptions<CarRentalContext> options)
            : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<CarCategory>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(c => c.Zip)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(c => c.DrivingLicenceNumber)
                .IsUnique();
            
            // implementing global query filter
            modelBuilder.Entity<City>().Property<bool>("IsDeleted");
            modelBuilder.Entity<City>().HasQueryFilter(r => EF.Property<bool>(r, "IsDeleted") == false);

            modelBuilder.Entity<CarCategory>().Property<bool>("IsDeleted");
            modelBuilder.Entity<CarCategory>().HasQueryFilter(r => EF.Property<bool>(r, "IsDeleted") == false);
            
            modelBuilder.Entity<User>().Property<bool>("IsDeleted");
            modelBuilder.Entity<User>().HasQueryFilter(r => EF.Property<bool>(r, "IsDeleted") == false);

            modelBuilder.Entity<Location>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Location>().HasQueryFilter(r => EF.Property<bool>(r, "IsDeleted") == false);

            modelBuilder.Entity<Car>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Car>().HasQueryFilter(r => EF.Property<bool>(r, "IsDeleted") == false);

            modelBuilder.Entity<Rental>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Rental>().HasQueryFilter(r => EF.Property<bool>(r, "IsDeleted") == false);
                                            
            //run seeds from extensions.seed
            modelBuilder.Seed();

        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if(entry.Entity is BaseModel)
                {
                    var now = DateTime.UtcNow;
                    BaseModel entity = (BaseModel) entry.Entity;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entity.ModifiedAt = now;
                            break;
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            break;
                    }
                }
            }
        
                                
        
        }
        

        // drugi nacin soft deleta
        
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is ISoftDeletable entity)
                {
                    // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                    item.State = EntityState.Unchanged;
                    // Only update the IsDeleted flag - only this will get sent to the Db
                    entity.IsDeleted = true;
                }
            }
            return base.SaveChanges();
        }
    
    }
}

