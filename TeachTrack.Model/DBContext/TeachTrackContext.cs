using Microsoft.EntityFrameworkCore;
using TeachTrack.Model.Models;
using Microsoft.Extensions.Configuration;

namespace TeachTrack.Model.DBContext;

public partial class TeachTrackContext : DbContext {
    public TeachTrackContext() { }

    public TeachTrackContext(DbContextOptions<TeachTrackContext> options) : base(options) { }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectSchedule> SubjectSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var config = new ConfigurationBuilder()
                     .AddUserSecrets<TeachTrackContext>()
                     .Build();
        var connString = config.GetConnectionString("DefaultConn");
        optionsBuilder.UseNpgsql(connString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Career>(entity => {
            entity.HasKey(e => e.Careerid).HasName("Career_pkey");

            entity.ToTable("Career");

            entity.Property(e => e.Careerid).HasColumnName("careerid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Shortname)
                .HasMaxLength(30)
                .HasColumnName("shortname");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Degree>(entity => {
            entity.HasKey(e => e.Degreeid).HasName("Degree_pkey");

            entity.ToTable("Degree");

            entity.Property(e => e.Degreeid).HasColumnName("degreeid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Shortname)
                .HasMaxLength(30)
                .HasColumnName("shortname");
        });

        modelBuilder.Entity<Schedule>(entity => {
            entity
                .HasNoKey()
                .ToTable("Schedule");

            entity.Property(e => e.Scheduleid).HasColumnName("scheduleid");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Subjectid).HasColumnName("subjectid");
        });

        modelBuilder.Entity<Semester>(entity => {
            entity.HasKey(e => e.Semesterid).HasName("Semester_pkey");

            entity.ToTable("Semester");

            entity.Property(e => e.Semesterid).HasColumnName("semesterid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Shortname)
                .HasMaxLength(30)
                .HasColumnName("shortname");
        });

        modelBuilder.Entity<Student>(entity => {
            entity.HasKey(e => e.Studentid).HasName("Student_pkey");

            entity.ToTable("Student");

            entity.Property(e => e.Studentid)
                .HasDefaultValueSql("nextval('squence_student'::regclass)")
                .HasColumnName("studentid");
            entity.Property(e => e.Careerid).HasColumnName("careerid");
            entity.Property(e => e.Degreeid).HasColumnName("degreeid");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Score)
                .HasPrecision(6, 2)
                .HasColumnName("score");
            entity.Property(e => e.Semesterid).HasColumnName("semesterid");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");

            entity.HasOne(d => d.Career).WithMany(p => p.Students)
                .HasForeignKey(d => d.Careerid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_student2");

            entity.HasOne(d => d.Degree).WithMany(p => p.Students)
                .HasForeignKey(d => d.Degreeid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_student1");

            entity.HasOne(d => d.Semester).WithMany(p => p.Students)
                .HasForeignKey(d => d.Semesterid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_student3");
        });

        modelBuilder.Entity<Subject>(entity => {
            entity.HasKey(e => e.Subjectid).HasName("Subject_pkey");

            entity.ToTable("Subject");

            entity.Property(e => e.Subjectid)
                .HasDefaultValueSql("nextval('sequence_subject'::regclass)")
                .HasColumnName("subjectid");
            entity.Property(e => e.Careerid).HasColumnName("careerid");
            entity.Property(e => e.Degreeid).HasColumnName("degreeid");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .HasColumnName("name");
            entity.Property(e => e.Semesterid).HasColumnName("semesterid");
            entity.Property(e => e.Shortname)
                .HasMaxLength(15)
                .HasColumnName("shortname");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");

            entity.HasOne(d => d.Career).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.Careerid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_subject2");

            entity.HasOne(d => d.Degree).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.Degreeid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_subject1");

            entity.HasOne(d => d.Semester).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.Semesterid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_subject3");
        });

        modelBuilder.Entity<SubjectSchedule>(entity => {
            entity.HasKey(e => e.Scheduleid).HasName("SubjectSchedule_pkey");

            entity.ToTable("SubjectSchedule");

            entity.Property(e => e.Scheduleid).HasColumnName("scheduleid");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Schedule)
                .HasMaxLength(75)
                .HasColumnName("schedule");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");
            entity.Property(e => e.Subjectid).HasColumnName("subjectid");
        });
        modelBuilder.HasSequence("sequence_subject")
            .StartsAt(11003L)
            .IncrementsBy(3);
        modelBuilder.HasSequence("squence_student")
            .StartsAt(21000L)
            .IncrementsBy(2);
        modelBuilder.HasSequence("studentsequence")
            .StartsAt(21000L)
            .IncrementsBy(2);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
