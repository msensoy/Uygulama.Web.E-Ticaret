using Entity;
using Entity.Entities;
using EntityMapping;
using EntityMapping.EntityMappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public partial class SurpriseBoxDbContext : DbContext
    {


#if DEBUG
        public SurpriseBoxDbContext() : base("server=muhaf.database.windows.net; database=SuprizKutuDB; user id=muhaf; password=Alaf9090;")
        {
            Helper.Helpers.IsTest = true;
            //Database.SetInitializer(new SupriseBoxDBInitializer());


        }
#else
        public ProjeDbContext()
        {
            throw new Exception("Relase modda test dal katmanı kullanılamaz.");
        }
        protected ProjeDbContext(string connectionString) : base(connectionString){}
#endif

        public virtual DbSet<Box> Boxes { get; set; }
        public virtual DbSet<BoxType> BoxTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region FluentAPI

            //modelBuilder.Entity<MemberType>()
            //    .Property(e => e.Type)
            //    .IsUnicode(false);

            //modelBuilder.Entity<MemberType>()
            //    .HasMany(e => e.Members)
            //    .WithRequired(e => e.MemberType)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.OrderDetails)
            //    .WithRequired(e => e.Order)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Box>()
            //    .Property(e => e.ProductName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Box>()
            //    .Property(e => e.Price)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<Role>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Role>()
            //    .HasMany(e => e.Users)
            //    .WithMany(e => e.Roles)
            //    .Map(m => m.ToTable("UserRole").MapLeftKey("RoleID").MapRightKey("UserID"));

            //modelBuilder.Entity<User>()
            //    .Property(e => e.UserName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Customers)
            //    .WithRequired(e => e.User)
            //    .WillCascadeOnDelete(false);
            #endregion
            //modelBuilder.Configurations.Add(new ProductMapping());
            //modelBuilder.Configurations.Add(new CategoryMapping());

            //base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BoxMapping());
            modelBuilder.Configurations.Add(new BoxTypeMapping());
            modelBuilder.Configurations.Add(new CustomerMapping());
            modelBuilder.Configurations.Add(new MemberMapping());
            modelBuilder.Configurations.Add(new MemberTypeMapping());
            modelBuilder.Configurations.Add(new OrderDetailMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new UserMapping());

            base.OnModelCreating(modelBuilder);

        }
    }
}
