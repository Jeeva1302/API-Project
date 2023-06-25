using System;
using System.Collections.Generic;
using api_project.Models;
using Microsoft.EntityFrameworkCore;

namespace api_project.Data;

public partial class RjHospitalContext : DbContext
{
    internal object DeleteDoctorsDetails;

    public RjHospitalContext()
    {
    }

    public RjHospitalContext(DbContextOptions<RjHospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentDetail> AppointmentDetails { get; set; }

    public virtual DbSet<CourseDetail> CourseDetails { get; set; }

    public virtual DbSet<DoctorsDetail> DoctorsDetails { get; set; }

    public virtual DbSet<FeedbackDetail> FeedbackDetails { get; set; }

    public virtual DbSet<PatientDetail> PatientDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS; Initial catalog=RJ Hospital; integrated security=SSPI; TrustServerCertificate= True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Appointment_Details");

            entity.Property(e => e.DateToVisit)
                .HasColumnType("date")
                .HasColumnName("Date_To_visit");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.MobileNumber).HasColumnName("Mobile_Number");
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PurposeOfVisit)
                .HasMaxLength(30)
                .HasColumnName("Purpose_of_Visit");
            entity.Property(e => e.SpecializationLookingFor)
                .HasMaxLength(25)
                .HasColumnName("Specialization_looking_for");
            entity.Property(e => e.TimeSlot)
                .HasMaxLength(20)
                .HasColumnName("Time_slot");

            entity.HasOne(d => d.Doctor).WithMany()
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_DID");

            entity.HasOne(d => d.Patient).WithMany()
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__5CD6CB2B");
        });

        modelBuilder.Entity<CourseDetail>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course_D__37E005FBF3C8CA97");

            entity.ToTable("Course_Details");

            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.CourseDuration)
                .HasMaxLength(30)
                .HasColumnName("Course_Duration");
            entity.Property(e => e.CourseName)
                .HasMaxLength(20)
                .HasColumnName("Course_Name");
            entity.Property(e => e.Fees).HasColumnType("money");

            entity.HasMany(d => d.Doctors).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseDoctorMapping",
                    r => r.HasOne<DoctorsDetail>().WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Course_Do__Docto__70DDC3D8"),
                    l => l.HasOne<CourseDetail>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Course_Do__Cours__6FE99F9F"),
                    j =>
                    {
                        j.HasKey("CourseId", "DoctorId").HasName("PK__Course_D__D9B9B0CBAB6617E7");
                        j.ToTable("Course_Doctor_Mapping");
                        j.IndexerProperty<int>("CourseId").HasColumnName("Course_ID");
                        j.IndexerProperty<int>("DoctorId").HasColumnName("Doctor_ID");
                    });
        });

        modelBuilder.Entity<DoctorsDetail>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors___E59B530F1BBCF87E");

            entity.ToTable("Doctors_details");

            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(25)
                .HasColumnName("Doctor_Name");
            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .HasColumnName("Email_ID");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.MobileNumber).HasColumnName("Mobile_Number");
            entity.Property(e => e.SpecialisedIn)
                .HasMaxLength(25)
                .HasColumnName("Specialised_In");
            entity.Property(e => e.WorkingHours)
                .HasMaxLength(30)
                .HasColumnName("Working_Hours");
        });

        modelBuilder.Entity<FeedbackDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("feedback_details");

            entity.Property(e => e.MobileNumber).HasColumnName("Mobile_number");
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.Query).HasMaxLength(60);

            entity.HasOne(d => d.Patient).WithMany()
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__feedback___Patie__3F466844");
        });

        modelBuilder.Entity<PatientDetail>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient___C1A88B5909CDDFC6");

            entity.ToTable("Patient_Details");

            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.MobileNumber).HasColumnName("Mobile_Number");
            entity.Property(e => e.PatientName)
                .HasMaxLength(30)
                .HasColumnName("Patient_Name");
            entity.Property(e => e.Problem).HasMaxLength(30);
            entity.Property(e => e.TypeOfPatient)
                .HasMaxLength(15)
                .HasColumnName("Type_of_patient");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal Task<string> DeleteFeedbackDetail(int id)
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
