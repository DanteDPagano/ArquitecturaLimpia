using DomainClass.Common;
using DomainClass.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Persistence.Contexts
{
    public class InstituteAppContext : DbContext
    {
        public InstituteAppContext(DbContextOptions<InstituteAppContext> options) : base(options)
        {
            //Configurar QueryTrackingBehavior como NoTracking impide el seguimiento de cambios
            //que se realizan en las entidades del contexto, por tal motivo, si se realizan cambios
            //estos no se veran reflejados en el base de datos.

            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        DbSet<UserSystem> UsersSystem { set; get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken= new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = 0;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        //entry.Entity.CreateBy = 0;
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
