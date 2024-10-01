using DynamicObject.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DynamicObject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     

    

            modelBuilder.Entity<ProductImage>()
         .HasKey(x => x.Id);
            modelBuilder.Entity<ProductImage>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductDetail>()
            .HasKey(x => x.Id);
            modelBuilder.Entity<ProductDetail>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<Product>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Customer>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<Customer>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomerAddress>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<CustomerAddress>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomerOrder>()
          .HasKey(x => x.Id);
            modelBuilder.Entity<CustomerOrder>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

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
