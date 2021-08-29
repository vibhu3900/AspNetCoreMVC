using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineGroceryStore.Models;

#nullable disable

namespace OnlineGroceryStore.AdminDetailsModel
{
    public partial class OnlineGroceryStoreDBContext : DbContext
    {
        public OnlineGroceryStoreDBContext()
        {
        }

        public OnlineGroceryStoreDBContext(DbContextOptions<OnlineGroceryStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admindetail> Admindetails { get; set; }
        public virtual DbSet<Billdetail> Billdetails { get; set; }
        public virtual DbSet<Branddetail> Branddetails { get; set; }
        //public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Productoffersdetail> Productoffersdetails { get; set; }
        public virtual DbSet<Productstockdetail> Productstockdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:ogs.database.windows.net,1433;Initial Catalog=OnlineGroceryStoreDB;Persist Security Info=False;User ID=Saburi;Password=Value123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admindetail>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__admindet__4A3006F7EE264F1E");

                entity.ToTable("admindetails");

                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.AdminEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Email");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Name");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Password");

                entity.Property(e => e.AdminPhoneno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Phoneno");
            });

            modelBuilder.Entity<Billdetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("billdetails");

                entity.Property(e => e.Billdate)
                    .HasColumnType("date")
                    .HasColumnName("billdate");

                entity.Property(e => e.Brandname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brandname");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Noofproduct).HasColumnName("noofproduct");

                entity.Property(e => e.Productname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Totalbill).HasColumnName("totalbill");

                entity.HasOne(d => d.Cust)
                    .WithMany()
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("FK__billdetai__custi__6EF57B66");
            });

            modelBuilder.Entity<Branddetail>(entity =>
            {
                entity.HasKey(e => e.Brandname)
                    .HasName("PK__branddet__62E74E740EA2F3C5");

                entity.ToTable("branddetails");

                entity.Property(e => e.Brandname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brandname");

                entity.Property(e => e.Brandlogo)
                    .HasColumnType("image")
                    .HasColumnName("brandlogo");

                entity.Property(e => e.Contractstartdate)
                    .HasColumnType("date")
                    .HasColumnName("contractstartdate");

                entity.Property(e => e.Totalnoofyearcontract).HasColumnName("totalnoofyearcontract");
            });

            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("category");

            //    entity.Property(e => e.CategoryName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("category_name");

            //    entity.Property(e => e.SubCategory)
            //        .HasMaxLength(30)
            //        .IsUnicode(false)
            //        .HasColumnName("Sub_Category");
            //});

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Custid)
                    .HasName("PK__customer__973AFEFEEA25D9C7");

                entity.ToTable("customers");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Custcontactno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("custcontactno");

                entity.Property(e => e.Custemail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("custemail");

                entity.Property(e => e.Custname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("custname");
            });

            modelBuilder.Entity<Productoffersdetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productoffersdetails");

                entity.Property(e => e.Brandname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brandname");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Productname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Productspecialoffer)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("productspecialoffer");

                entity.HasOne(d => d.Productstockdetail)
                    .WithMany()
                    .HasForeignKey(d => new { d.Productname, d.Brandname })
                    .HasConstraintName("fk_prod_brand");
            });

            modelBuilder.Entity<Productstockdetail>(entity =>
            {
                entity.HasKey(e => new { e.Productname, e.Brandname })
                    .HasName("pk_prod_brand");

                entity.ToTable("productstockdetails");

                entity.Property(e => e.Productname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Brandname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brandname");

                entity.Property(e => e.Noofitemsavailable).HasColumnName("noofitemsavailable");

                entity.Property(e => e.Productcategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("productcategory");

                entity.Property(e => e.Productimage)
                    .HasColumnType("image")
                    .HasColumnName("productimage");

                entity.Property(e => e.Productprice).HasColumnName("productprice");

                entity.HasOne(d => d.BrandnameNavigation)
                    .WithMany(p => p.Productstockdetails)
                    .HasForeignKey(d => d.Brandname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__productst__brand__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
