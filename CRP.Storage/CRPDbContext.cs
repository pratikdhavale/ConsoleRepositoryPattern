using CRP.Domain.Infrastructure;
using CRP.Domain.Models;
using CRP.Storage.Mappings;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;

namespace CRP.Storage
{
    public class CRPDbContext : DbContext
    {
        public CRPDbContext() : base("Name=CRPConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DbInitializer());
        }

        IDbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserMap());

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                var modifiedEntries = ChangeTracker.Entries()
                       .Where(x => x.Entity is AuditableEntity
                           && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    if (entry.Entity is AuditableEntity entity)
                    {
                        string identityName = Thread.CurrentPrincipal.Identity.Name;
                        DateTime now = DateTime.Now;

                        if (entry.State == System.Data.Entity.EntityState.Added)
                        {
                            entity.CreatedBy = identityName;
                            entity.CreatedOn = now;
                        }
                        else if (entry.State == System.Data.Entity.EntityState.Modified)
                        {
                            entity.UpdatedBy = identityName;
                            entity.UpdatedOn = now;
                        }
                        else
                        {
                            base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            base.Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                            entity.UpdatedBy = identityName;
                            entity.UpdatedOn = now;
                        }
                    }
                }
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
