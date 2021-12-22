using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTL_ASP.NET_Nhom7.Models
{
    public partial class WineStoreDB : DbContext
    {
        public WineStoreDB()
            : base("name=WineStoreDB")
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Catalogy> Catalogy { get; set; }
        public virtual DbSet<GroupUsers> GroupUsers { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Catalogy>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Catalogy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupUsers>()
                .HasMany(e => e.User)
                .WithRequired(e => e.GroupUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<BTL_ASP.NET_Nhom7.Models.Custom.RegisterModel> RegisterModels { get; set; }
    }
}
