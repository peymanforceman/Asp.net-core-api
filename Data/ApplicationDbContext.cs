using Common.Utilities;
using Entities.Common;
using Entities.Post;
using Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        // setting database settings
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("");
        //    base.OnConfiguring(optionsBuilder);
        //}
        // otherwise we use a constructor to get it from Startup.cs if we have defined sql database in our startup.cs
        // and pass the option to it's parent
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        // traditional adding tables method:
        // public DbSet<User> Users { get; set; }

        // Modern method: auto add db entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // get all assemblies of objects that inherits from IEntity
            var entitiesAssembly = typeof(IEntity).Assembly;
            // register them all ( with the rules specified in the method in Common Solution )
            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);

            // traditional registering configurations method:
            // modelBuilder.ApplyConfiguration()

            // Modern method : auto register entity type configurations ( fluent APIs  ) :
            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);

            // change the behavior of foreign key relationships from cascade to restrict
            modelBuilder.AddRestrictDeleteBehaviorConvention();

            // auto change all Guid keys to auto sequential ( fix indexing issue , sorting and make less fragmentation )
            modelBuilder.AddSequentialGuidForIdConvention();

            // other stuff that we want to apply for database , example :
            // modelBuilder.Entity<Post>().Property(p => p.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

            // pluralize tables
            modelBuilder.AddPluralizingTableNameConvention();
        }
    }
}