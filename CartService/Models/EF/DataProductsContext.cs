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
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=stk-academia-demo.database.windows.net; initial catalog=DataProducts; user id=he-man; password=yGvGnqfqwN3bsyq");
#pragma warning restore CS1030 // #warning directive
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
