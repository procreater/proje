namespace Mvc.dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<PageSection> PageSection { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategories>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategories)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
