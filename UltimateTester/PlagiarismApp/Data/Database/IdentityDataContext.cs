using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlagiarismApp.Data.Database
{
    public partial class IdentityDataContext : IdentityDbContext
    {
        WebApplicationBuilder Builder { get; }

        public IdentityDataContext(DbContextOptions options) : base(options)
        {
            Builder = WebApplication.CreateBuilder();
        }

        public IdentityDataContext() : base()
        {
            Builder = WebApplication.CreateBuilder();
        }

        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<LabWork> LabWorks { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Builder.Configuration.GetConnectionString("Connection");
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<LabWork>(entity =>
            {
                entity.ToTable("lab_work");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.LabWorkId });

                entity.ToTable("project");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.LabWorkId).HasColumnName("lab_work_id");

                entity.Property(e => e.GitUrl)
                    .HasMaxLength(100)
                    .HasColumnName("git_url");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PathOnDisc)
                    .HasMaxLength(260)
                    .HasColumnName("path_on_disc");

                entity.HasOne(d => d.LabWork)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.LabWorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_project_lab_work");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_project_student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_student_group");
            });

            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
