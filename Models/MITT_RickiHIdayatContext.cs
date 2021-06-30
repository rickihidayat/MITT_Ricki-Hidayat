using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MITT_Ricki_Hidayat.Models
{
    public partial class MITT_RickiHIdayatContext : DbContext
    {
        public MITT_RickiHIdayatContext()
        {
        }

        public MITT_RickiHIdayatContext(DbContextOptions<MITT_RickiHIdayatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=RICKIHIDAYAT-PC\\RICKIHIDAYAT;Initial Catalog=MITT_RickiHIdayat;Persist Security Info=True;User ID=sa;Password=1sampai8;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.SkillId)
                    .ValueGeneratedNever()
                    .HasColumnName("SkillID");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.ToTable("SkillLevel");

                entity.Property(e => e.SkillLevelId)
                    .ValueGeneratedNever()
                    .HasColumnName("SkillLevelID");

                entity.Property(e => e.SkillLevelName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__F3DBC57365B39398");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("UserProfile");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.Bod)
                    .HasColumnType("date")
                    .HasColumnName("bod");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<UserProfile>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_ToTable");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.Property(e => e.UserSkillId).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_UserSkills_ToTable_1");

                entity.HasOne(d => d.SkillLevel)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillLevelId)
                    .HasConstraintName("FK_UserSkills_ToTable_2");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_UserSkills_ToTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
