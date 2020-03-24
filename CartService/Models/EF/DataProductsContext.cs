using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CartService.Models.EF
{
    public partial class DataProductsContext : DbContext
    {
        public DataProductsContext()
        {
        }

        public DataProductsContext(DbContextOptions<DataProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatTypeDetails> CatTypeDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string server   = Environment.GetEnvironmentVariable("db_products_server"   );
                string user     = Environment.GetEnvironmentVariable("db_products_user"     );
                string password = Environment.GetEnvironmentVariable("db_products_password" );
                string nameDb   = Environment.GetEnvironmentVariable("db_products_name_db"  );

                optionsBuilder.UseSqlServer(
                    "data source=" + server + ";" +
                    "initial catalog=" + nameDb + ";" +
                    "user id=" + user + ";" +
                    "password=" + password
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatTypeDetails>(entity =>
            {
                entity.HasKey(e => e.IdTypeDetail);

                entity.HasIndex(e => e.IdType)
                    .HasName("IX_FK_CatTypeProductCatTypeDetails");

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
