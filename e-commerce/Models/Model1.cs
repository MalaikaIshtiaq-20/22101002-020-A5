using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace e_commerce.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<M_Admin> M_Admin { get; set; }
        public virtual DbSet<M_Category> M_Category { get; set; }
        public virtual DbSet<M_Product> M_Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_Category>()
                .HasMany(e => e.M_Product)
                .WithRequired(e => e.M_Category)
                .HasForeignKey(e => e.Category_FId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_Product>()
                .Property(e => e.Product_Sale_Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<M_Product>()
                .Property(e => e.Product_Purchase_Price)
                .HasPrecision(18, 0);
        }
    }
}
