// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Anwalt.Web.Data.Models;
using Anwalt.Web.Data.Models.Base;
using Anwalt.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Anwalt.Web.Data
{
    public class AnwaltDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService _currentUser;

        public AnwaltDbContext(DbContextOptions<AnwaltDbContext> options, ICurrentUserService currentUser) :
            base(options) => _currentUser = currentUser;

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Home> Homes { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }

        public DbSet<VCard> VCards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne()
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Home>()
                .HasMany(h => h.Cards)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<About>()
                .HasMany(a => a.Links)
                .WithOne();

            builder
                .Entity<EmployeeActivity>()
                .HasKey(ea => new {ea.EmployeeId, ea.ActivityId});

            builder
                .Entity<EmployeeActivity>()
                .HasOne(ea => ea.Employee)
                .WithMany(e => e.EmployeeActivities)
                .HasForeignKey(ea => ea.EmployeeId);

            builder
                .Entity<EmployeeActivity>()
                .HasOne(ea => ea.Activity)
                .WithMany(a => a.EmployeeActivities)
                .HasForeignKey(ea => ea.ActivityId);

            builder
                .Entity<Employee>()
                .HasOne(e => e.VCard)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            ApplyAuditInformation();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            ApplyAuditInformation();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAuditInformation() =>
            ChangeTracker?
                .Entries()
                .ToList()
                .ToList()
                .ForEach(entry =>
                {
                    var userName = _currentUser.GetUserName();

                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deletableEntity.DeletedAt = DateTime.UtcNow;
                            deletableEntity.DeletedBy = userName;
                            deletableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;

                            return;
                        }
                    }

                    if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedAt = DateTime.UtcNow;
                            entity.ModifiedAt = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifiedAt = DateTime.UtcNow;
                            entity.ModifiedBy = userName;
                        }
                    }
                });
    }
}