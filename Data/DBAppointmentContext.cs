using System;
using AppointmentService.Domain.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppointmentService.Data
{
    public partial class DBAppointmentContext : DbContext
    {
        public DBAppointmentContext()
        {
        }

        public DBAppointmentContext(DbContextOptions<DBAppointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adverties> Adverties { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AppointmentType> AppointmentType { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Definition> Definition { get; set; }
        public virtual DbSet<DefinitionType> DefinitionType { get; set; }
        public virtual DbSet<Expert> Expert { get; set; }
        public virtual DbSet<Expertise> Expertise { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<OTPS> OTPS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;DataBase=DBAppointment;User ID=sa;Password=M.s677093;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adverties>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Desciption).HasMaxLength(200);

                entity.Property(e => e.Reference).IsRequired();

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ExpertId).HasColumnName("ExpertID");

                entity.Property(e => e.MiladiDate).HasColumnType("date");
            });

            modelBuilder.Entity<AppointmentType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpertId).HasColumnName("ExpertID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(50);


                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NationalCode).HasMaxLength(10);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Definition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DefinitionTypeId).HasColumnName("DefinitionTypeID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DefinitionType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpertMobile).HasMaxLength(11);

                entity.Property(e => e.ExpertNo)
                    .HasColumnName("ExpertNO")
                    .HasMaxLength(50);

                entity.Property(e => e.ExpertiseId).HasColumnName("ExpertiseID");

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PictureAddress).HasMaxLength(1000);

                entity.Property(e => e.SecretaryMobile).HasMaxLength(50);

                entity.Property(e => e.Sheba).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(11);

                entity.Property(e => e.VirtualMobile).HasMaxLength(50);
                
                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Expertise>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorityId).HasColumnName("AuthorityID");

                entity.Property(e => e.MiladiDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.RefId).HasColumnName("RefID");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Transactiondate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(11).HasColumnName("Title");

            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleId).HasColumnName("RoleId");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionId");
                
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Mobile).HasMaxLength(11).HasColumnName("Mobile");

                entity.Property(e => e.Password).HasColumnName("Password").IsRequired();

                entity.Property(e => e.Name)
                                    .HasMaxLength(50);

                entity.Property(e => e.Family)                 
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.RoleId).HasColumnName("RoleId");
                

            });

            modelBuilder.Entity<OTPS>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                
                entity.Property(e => e.Mobile).HasMaxLength(11).HasColumnName("Mobile");

                entity.Property(e => e.OTP).HasColumnName("OTP");
                
                entity.Property(e => e.State).HasColumnName("State");
                
                entity.Property(e => e.Type).HasColumnName("Type");
                
                entity.Property(e => e.Time).HasColumnType("datetime");

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
