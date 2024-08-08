using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeachTrack.Data.Models;

namespace TeachTrack.Data.DBContext;

public partial class TeachTrackContext : DbContext
{
    public TeachTrackContext()
    {
    }

    public TeachTrackContext(DbContextOptions<TeachTrackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<InfoStudent> InfoStudents { get; set; }

    public virtual DbSet<InfoTeacher> InfoTeachers { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<StatusGrade> StatusGrades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Degree>(entity =>
        {
            entity.HasKey(e => e.Degreeid).HasName("degree_pkey");

            entity.ToTable("degree");

            entity.Property(e => e.Degreeid)
                .HasDefaultValueSql("nextval('squence_degree'::regclass)")
                .HasColumnName("degreeid");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Gradeid).HasName("grades_pkey");

            entity.ToTable("grades");

            entity.Property(e => e.Gradeid).HasColumnName("gradeid");
            entity.Property(e => e.Finalgrade)
                .HasPrecision(5, 2)
                .HasColumnName("finalgrade");
            entity.Property(e => e.Firstperiod)
                .HasPrecision(5, 2)
                .HasColumnName("firstperiod");
            entity.Property(e => e.Gradedate).HasColumnName("gradedate");
            entity.Property(e => e.Secondperiod)
                .HasPrecision(5, 2)
                .HasColumnName("secondperiod");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Subjectid).HasColumnName("subjectid");
            entity.Property(e => e.Thirdperiod)
                .HasPrecision(5, 2)
                .HasColumnName("thirdperiod");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("fk_status");
        });

        modelBuilder.Entity<InfoStudent>(entity =>
        {
            entity.HasKey(e => new { e.Studentid, e.Schoolemail }).HasName("pk_info_student");

            entity.ToTable("info_student");

            entity.HasIndex(e => e.Dni, "info_student_dni_key").IsUnique();

            entity.HasIndex(e => e.Personalemail, "info_student_personalemail_key").IsUnique();

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Schoolemail)
                .HasMaxLength(50)
                .HasColumnName("schoolemail");
            entity.Property(e => e.Adress)
                .HasMaxLength(12)
                .HasColumnName("adress");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Personalemail)
                .HasMaxLength(50)
                .HasColumnName("personalemail");

            entity.HasOne(d => d.Student).WithMany(p => p.InfoStudents)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("fk_studentid");
        });

        modelBuilder.Entity<InfoTeacher>(entity =>
        {
            entity.HasKey(e => new { e.Teacherid, e.Schoolemail }).HasName("pk_info_teacher");

            entity.ToTable("info_teacher");

            entity.HasIndex(e => e.Cedula, "info_teacher_cedula_key").IsUnique();

            entity.HasIndex(e => e.Dni, "info_teacher_dni_key").IsUnique();

            entity.HasIndex(e => e.Personalemail, "info_teacher_personalemail_key").IsUnique();

            entity.Property(e => e.Teacherid).HasColumnName("teacherid");
            entity.Property(e => e.Schoolemail)
                .HasMaxLength(50)
                .HasColumnName("schoolemail");
            entity.Property(e => e.Adress)
                .HasMaxLength(12)
                .HasColumnName("adress");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .HasColumnName("cedula");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Personalemail)
                .HasMaxLength(50)
                .HasColumnName("personalemail");

            entity.HasOne(d => d.Teacher).WithMany(p => p.InfoTeachers)
                .HasForeignKey(d => d.Teacherid)
                .HasConstraintName("fk_teacherid");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Programid).HasName("program_pkey");

            entity.ToTable("program");

            entity.HasIndex(e => e.Name, "program_name_key").IsUnique();

            entity.HasIndex(e => e.Programcode, "program_programcode_key").IsUnique();

            entity.Property(e => e.Programid)
                .HasDefaultValueSql("nextval('sequence_program'::regclass)")
                .HasColumnName("programid");
            entity.Property(e => e.Degree).HasColumnName("degree");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Programcode)
                .HasMaxLength(50)
                .HasColumnName("programcode");

            entity.HasOne(d => d.DegreeNavigation).WithMany(p => p.Programs)
                .HasForeignKey(d => d.Degree)
                .HasConstraintName("fk_degreeid");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Scheduleid).HasName("schedule_pkey");

            entity.ToTable("schedule");

            entity.Property(e => e.Scheduleid).HasColumnName("scheduleid");
            entity.Property(e => e.Dayofweek1)
                .HasMaxLength(15)
                .HasColumnName("dayofweek1");
            entity.Property(e => e.Dayofweek2)
                .HasMaxLength(15)
                .HasColumnName("dayofweek2");
            entity.Property(e => e.Dayofweek3)
                .HasMaxLength(15)
                .HasColumnName("dayofweek3");
            entity.Property(e => e.Endtime1).HasColumnName("endtime1");
            entity.Property(e => e.Endtime2).HasColumnName("endtime2");
            entity.Property(e => e.Endtime3).HasColumnName("endtime3");
            entity.Property(e => e.Room)
                .HasMaxLength(30)
                .HasColumnName("room");
            entity.Property(e => e.Starttime1).HasColumnName("starttime1");
            entity.Property(e => e.Starttime2).HasColumnName("starttime2");
            entity.Property(e => e.Starttime3).HasColumnName("starttime3");
            entity.Property(e => e.Subject).HasColumnName("subject");

            entity.HasOne(d => d.SubjectNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.Subject)
                .HasConstraintName("fk_subjectsched");

            entity.HasMany(d => d.Students).WithMany(p => p.Schedules)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentSchedule",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("Studentid")
                        .HasConstraintName("fk_studentsche"),
                    l => l.HasOne<Schedule>().WithMany()
                        .HasForeignKey("Scheduleid")
                        .HasConstraintName("fk_sche_sche"),
                    j =>
                    {
                        j.HasKey("Scheduleid", "Studentid").HasName("pk_student_sche");
                        j.ToTable("student_schedule");
                        j.IndexerProperty<int>("Scheduleid").HasColumnName("scheduleid");
                        j.IndexerProperty<int>("Studentid").HasColumnName("studentid");
                    });

            entity.HasMany(d => d.Teachers).WithMany(p => p.Schedules)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherSchedule",
                    r => r.HasOne<Teacher>().WithMany()
                        .HasForeignKey("Teacherid")
                        .HasConstraintName("fk_teachersche"),
                    l => l.HasOne<Schedule>().WithMany()
                        .HasForeignKey("Scheduleid")
                        .HasConstraintName("fk_sch_sch"),
                    j =>
                    {
                        j.HasKey("Scheduleid", "Teacherid").HasName("pk_teacher_schedule");
                        j.ToTable("teacher_schedule");
                        j.IndexerProperty<int>("Scheduleid").HasColumnName("scheduleid");
                        j.IndexerProperty<int>("Teacherid").HasColumnName("teacherid");
                    });
        });

        modelBuilder.Entity<StatusGrade>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("status_grade_pkey");

            entity.ToTable("status_grade");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Studentid)
                .HasDefaultValueSql("nextval('sequence_student'::regclass)")
                .HasColumnName("studentid");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Degree).HasColumnName("degree");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Program).HasColumnName("program");

            entity.HasOne(d => d.DegreeNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Degree)
                .HasConstraintName("fk_degree");

            entity.HasOne(d => d.ProgramNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Program)
                .HasConstraintName("fk_program");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Subjectid).HasName("subject_pkey");

            entity.ToTable("subject");

            entity.HasIndex(e => e.Subjectcode, "subject_subjectcode_key").IsUnique();

            entity.Property(e => e.Subjectid)
                .HasDefaultValueSql("nextval('sequence_subject'::regclass)")
                .HasColumnName("subjectid");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Program).HasColumnName("program");
            entity.Property(e => e.Subjectcode)
                .HasMaxLength(15)
                .HasColumnName("subjectcode");

            entity.HasOne(d => d.ProgramNavigation).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.Program)
                .HasConstraintName("fk_programsubject");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Teacherid).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.Teacherid)
                .HasDefaultValueSql("nextval('sequence_teacher'::regclass)")
                .HasColumnName("teacherid");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });
        modelBuilder.HasSequence("sequence_program")
            .StartsAt(107L)
            .IncrementsBy(7);
        modelBuilder.HasSequence("sequence_student")
            .StartsAt(10103L)
            .IncrementsBy(3);
        modelBuilder.HasSequence("sequence_subject")
            .StartsAt(20101L)
            .IncrementsBy(5);
        modelBuilder.HasSequence("sequence_teacher")
            .StartsAt(5001L)
            .IncrementsBy(3);
        modelBuilder.HasSequence("squence_degree");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
