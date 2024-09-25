using DynamicObject.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DynamicObject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<DynamicObjectModel> DynamicObjectModels { get; set; }
        public DbSet<ObjectField> ObjectFields { get; set; }
        public DbSet<ObjectData> ObjectDatas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DynamicObjectModel>()
                 .HasKey(x => x.Id);

            modelBuilder.Entity<DynamicObjectModel>()
                  .HasMany(d => d.ObjectFields)
                  .WithOne()
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ObjectField>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ObjectField>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ObjectData>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ObjectData>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


        }
    }
}
