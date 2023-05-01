using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VLab.Models;

public partial class VirtualLabContext : DbContext
{
    public VirtualLabContext()
    {
    }

    public VirtualLabContext(DbContextOptions<VirtualLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryOfWork> CategoryOfWorks { get; set; }

    public virtual DbSet<Dust> Dusts { get; set; }

    public virtual DbSet<Electricity> Electricities { get; set; }

    public virtual DbSet<Ga> Gas { get; set; }

    public virtual DbSet<GasColor> GasColors { get; set; }

    public virtual DbSet<Gass> Gasses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<HumidityAir> HumidityAirs { get; set; }

    public virtual DbSet<Illumination> Illuminations { get; set; }

    public virtual DbSet<LabWork> LabWorks { get; set; }

    public virtual DbSet<LevelsOfNoise> LevelsOfNoises { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Microclimate> Microclimates { get; set; }

    public virtual DbSet<Mistake> Mistakes { get; set; }

    public virtual DbSet<Psychrometer> Psychrometers { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Tabel> Tabels { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TempAir> TempAirs { get; set; }

    public virtual DbSet<Thermometer> Thermometers { get; set; }

    public virtual DbSet<TimeOfYear> TimeOfYears { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryOfWork>(entity =>
        {
            entity.HasKey(e => e.IdCategoryOfWork);

            entity.ToTable("Category_Of_Work");

            entity.Property(e => e.IdCategoryOfWork).HasColumnName("id_Category_of_Work");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Dust>(entity =>
        {
            entity.HasKey(e => e.IdNumOfTest);

            entity.ToTable("Dust");

            entity.Property(e => e.IdNumOfTest).HasColumnName("id_num_of_test");
            entity.Property(e => e.AirThroughRotameter).HasColumnName("Air_Through_Rotameter");
            entity.Property(e => e.BarometricPressure).HasColumnName("Barometric_Pressure");
            entity.Property(e => e.DustConcentrationInAir).HasColumnName("Dust_Concentration_In_Air");
            entity.Property(e => e.FilterWeightAfter).HasColumnName("Filter_Weight_After");
            entity.Property(e => e.FilterWeightBefore).HasColumnName("Filter_Weight_Before");
            entity.Property(e => e.MaxAllowableConcentrationOfDust).HasColumnName("Max_Allowable_Concentration_Of_Dust");
            entity.Property(e => e.MeasurementTime).HasColumnName("Measurement_Time");
            entity.Property(e => e.TemperatureInRoom).HasColumnName("Temperature_in_room");
            entity.Property(e => e.VolumeOfAirReducedToStandard).HasColumnName("Volume_Of_Air_Reduced_To_Standard");
            entity.Property(e => e.VolumeOfAirThroughFilter).HasColumnName("Volume_Of_Air_Through_Filter");
        });

        modelBuilder.Entity<Electricity>(entity =>
        {
            entity.HasKey(e => e.IdElectricity);

            entity.ToTable("Electricity");

            entity.Property(e => e.IdElectricity).HasColumnName("id_Electricity");
            entity.Property(e => e.VoltageU2).HasColumnName("Voltage_U2");
            entity.Property(e => e.VoltageUpr).HasColumnName("Voltage_Upr");
        });

        modelBuilder.Entity<Ga>(entity =>
        {
            entity.HasKey(e => e.IdGas);

            entity.Property(e => e.IdGas).HasColumnName("id_Gas");
            entity.Property(e => e.AirVolume)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Air_Volume");
            entity.Property(e => e.ColorAfter).HasColumnName("Color_After");
            entity.Property(e => e.ColorBefore).HasColumnName("Color_Before");
            entity.Property(e => e.Pdk)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PDK");
            entity.Property(e => e.PoisonConcentration)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Poison_concentration");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.ColorAfterNavigation).WithMany(p => p.GaColorAfterNavigations)
                .HasForeignKey(d => d.ColorAfter)
                .HasConstraintName("FK_Gas_Gas_Colors");

            entity.HasOne(d => d.ColorBeforeNavigation).WithMany(p => p.GaColorBeforeNavigations)
                .HasForeignKey(d => d.ColorBefore)
                .HasConstraintName("FK_Gas_Gas_Colors1");

            entity.HasOne(d => d.GasNavigation).WithMany(p => p.Gas)
                .HasForeignKey(d => d.Gas)
                .HasConstraintName("FK_Gas_Gasses");
        });

        modelBuilder.Entity<GasColor>(entity =>
        {
            entity.HasKey(e => e.IdGasColors);

            entity.ToTable("Gas_Colors");

            entity.Property(e => e.IdGasColors).HasColumnName("id_Gas_Colors");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Gass>(entity =>
        {
            entity.HasKey(e => e.IdGases);

            entity.Property(e => e.IdGases).HasColumnName("id_Gases");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.ToTable("Group");

            entity.Property(e => e.IdGroup).HasColumnName("id_Group");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<HumidityAir>(entity =>
        {
            entity.HasKey(e => e.IdHumidityAir);

            entity.ToTable("HumidityAir");

            entity.Property(e => e.IdHumidityAir).HasColumnName("id_HumidityAir");
            entity.Property(e => e.IdMicroclimate).HasColumnName("id_Microclimate");
            entity.Property(e => e.PsychrometerDry)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Psychrometer_Dry");
            entity.Property(e => e.PsychrometerHumid)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Psychrometer_Humid");
            entity.Property(e => e.RelativeHumidityByFormula)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Relative_Humidity_By_Formula");
            entity.Property(e => e.RelativeHumidityByTabel)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Relative_Humidity_By_Tabel");

            entity.HasOne(d => d.IdMicroclimateNavigation).WithMany(p => p.HumidityAirs)
                .HasForeignKey(d => d.IdMicroclimate)
                .HasConstraintName("FK_HumidityAir_Microclimate");

            entity.HasOne(d => d.PsychrometerNavigation).WithMany(p => p.HumidityAirs)
                .HasForeignKey(d => d.Psychrometer)
                .HasConstraintName("FK_HumidityAir_Psychrometers");
        });

        modelBuilder.Entity<Illumination>(entity =>
        {
            entity.HasKey(e => e.IdIllumination);

            entity.ToTable("Illumination");

            entity.Property(e => e.IdIllumination).HasColumnName("id_Illumination");
            entity.Property(e => e.Bn).HasColumnName("BN");
            entity.Property(e => e.Bv).HasColumnName("BV");
            entity.Property(e => e.CategoryOfWorks)
                .HasMaxLength(50)
                .HasColumnName("Category_Of_Works");
            entity.Property(e => e.DiscriminationObjectSize).HasColumnName("Discrimination_Object_Size");
            entity.Property(e => e.KeoGarf).HasColumnName("KEO_Garf");
            entity.Property(e => e.KeoResults).HasColumnName("KEO_Results");
            entity.Property(e => e.MeasuringPoint)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Measuring_Point");
            entity.Property(e => e.TypeOfWork)
                .HasMaxLength(50)
                .HasColumnName("Type_Of_Work");
        });

        modelBuilder.Entity<LabWork>(entity =>
        {
            entity.HasKey(e => e.IdLabWork);

            entity.Property(e => e.IdLabWork).HasColumnName("id_LabWork");
            entity.Property(e => e.DateEnd)
                .HasColumnType("date")
                .HasColumnName("Date_End");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("Date_Start");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LevelsOfNoise>(entity =>
        {
            entity.HasKey(e => e.IdLevelsOfNoise);

            entity.ToTable("Levels_Of_Noise");

            entity.Property(e => e.IdLevelsOfNoise).HasColumnName("id_Levels_Of_Noise");
            entity.Property(e => e.LevelOfDba).HasColumnName("Level_Of_DBA");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e._1000Lvl).HasColumnName("1000_lvl");
            entity.Property(e => e._125Lvl).HasColumnName("125_lvl");
            entity.Property(e => e._2000Lvl).HasColumnName("2000_lvl");
            entity.Property(e => e._250Lvl).HasColumnName("250_lvl");
            entity.Property(e => e._4000Lvl).HasColumnName("4000_lvl");
            entity.Property(e => e._500Lvl).HasColumnName("500_lvl");
            entity.Property(e => e._63Lvl).HasColumnName("63_lvl");
            entity.Property(e => e._8000Lvl).HasColumnName("8000_lvl");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterials);

            entity.Property(e => e.IdMaterials).HasColumnName("id_Materials");
            entity.Property(e => e.IdLabWork).HasColumnName("id_LabWork");
            entity.Property(e => e.Material1).HasColumnName("Material");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdLabWorkNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdLabWork)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Materials_LabWorks");
        });

        modelBuilder.Entity<Microclimate>(entity =>
        {
            entity.HasKey(e => e.IdMicroclimate);

            entity.ToTable("Microclimate");

            entity.Property(e => e.IdMicroclimate).HasColumnName("id_Microclimate");
            entity.Property(e => e.CharacteristicIndustrialPlaces)
                .IsUnicode(false)
                .HasColumnName("Characteristic_\r\nindustrial_places");
            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.MicroclimateParamets)
                .IsUnicode(false)
                .HasColumnName("Microclimate_Paramets");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpeedAirFact)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Speed_Air_Fact");
            entity.Property(e => e.SpeedAirNorm)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Speed_Air_Norm");
            entity.Property(e => e.TempAirFact)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Temp_Air_Fact");
            entity.Property(e => e.TempAirNorm)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Temp_Air_Norm");
            entity.Property(e => e.TempHumFact)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Temp_Hum_Fact");
            entity.Property(e => e.TempHumNorm)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Temp_Hum_Norm");
            entity.Property(e => e.TimeOfYear).HasColumnName("Time_of_Year");
            entity.Property(e => e.СategoryOfWorks).HasColumnName("Сategory_of_works");

            entity.HasOne(d => d.TimeOfYearNavigation).WithMany(p => p.Microclimates)
                .HasForeignKey(d => d.TimeOfYear)
                .HasConstraintName("FK_Microclimate_Time_of_Year");

            entity.HasOne(d => d.СategoryOfWorksNavigation).WithMany(p => p.Microclimates)
                .HasForeignKey(d => d.СategoryOfWorks)
                .HasConstraintName("FK_Microclimate_Category_Of_Work");
        });

        modelBuilder.Entity<Mistake>(entity =>
        {
            entity.HasKey(e => e.IdMistake);

            entity.Property(e => e.IdMistake).HasColumnName("id_Mistake");
            entity.Property(e => e.DescriptionOfСonsequences).HasColumnName("Description_Of_Сonsequences");
        });

        modelBuilder.Entity<Psychrometer>(entity =>
        {
            entity.HasKey(e => e.IdPsychrometer);

            entity.Property(e => e.IdPsychrometer)
                .ValueGeneratedNever()
                .HasColumnName("id_Psychrometer");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.IdResults);

            entity.Property(e => e.IdResults).HasColumnName("id_Results");
            entity.Property(e => e.IdLabWork).HasColumnName("id_LabWork");
            entity.Property(e => e.IdStudent).HasColumnName("id_Student");
            entity.Property(e => e.IdTabel).HasColumnName("id_Tabel");

            entity.HasOne(d => d.IdLabWorkNavigation).WithMany(p => p.Results)
                .HasForeignKey(d => d.IdLabWork)
                .HasConstraintName("FK_Results_LabWorks");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Results)
                .HasForeignKey(d => d.IdStudent)
                .HasConstraintName("FK_Results_Students");

            entity.HasOne(d => d.IdTabelNavigation).WithMany(p => p.Results)
                .HasForeignKey(d => d.IdTabel)
                .HasConstraintName("FK_Results_Tabel");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudents);

            entity.Property(e => e.IdStudents).HasColumnName("id_Students");
            entity.Property(e => e.Emali).HasMaxLength(50);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("Full_Name");
            entity.Property(e => e.IdGroup).HasColumnName("id_Group");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK_Students_Group");
        });

        modelBuilder.Entity<Tabel>(entity =>
        {
            entity.HasKey(e => e.IdTabel);

            entity.ToTable("Tabel");

            entity.Property(e => e.IdTabel).HasColumnName("id_Tabel");
            entity.Property(e => e.IdGas).HasColumnName("id_Gas");
            entity.Property(e => e.IdMicroclimate).HasColumnName("id_Microclimate");
            entity.Property(e => e.IdStudent).HasColumnName("id_Student");

            entity.HasOne(d => d.IdGasNavigation).WithMany(p => p.Tabels)
                .HasForeignKey(d => d.IdGas)
                .HasConstraintName("FK_Tabel_Gas");

            entity.HasOne(d => d.IdMicroclimateNavigation).WithMany(p => p.Tabels)
                .HasForeignKey(d => d.IdMicroclimate)
                .HasConstraintName("FK_Tabel_Microclimate");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Tabels)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tabel_Students");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher);

            entity.Property(e => e.IdTeacher).HasColumnName("id_Teacher");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("Full_Name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TempAir>(entity =>
        {
            entity.HasKey(e => e.IdTempAir);

            entity.ToTable("TempAir");

            entity.Property(e => e.IdTempAir).HasColumnName("id_TempAir");
            entity.Property(e => e.IdMicroclimate).HasColumnName("id_Microclimate");
            entity.Property(e => e.Place).HasMaxLength(50);
            entity.Property(e => e.ThermometerId).HasColumnName("Thermometer_id");
            entity.Property(e => e._01M)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("0.1 m");
            entity.Property(e => e._10M)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("1.0 m");
            entity.Property(e => e._15M)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("1.5 m");

            entity.HasOne(d => d.IdMicroclimateNavigation).WithMany(p => p.TempAirs)
                .HasForeignKey(d => d.IdMicroclimate)
                .HasConstraintName("FK_TempAir_Microclimate");

            entity.HasOne(d => d.Thermometer).WithMany(p => p.TempAirs)
                .HasForeignKey(d => d.ThermometerId)
                .HasConstraintName("FK_TempAir_Thermometers");
        });

        modelBuilder.Entity<Thermometer>(entity =>
        {
            entity.HasKey(e => e.IdThermometer);

            entity.Property(e => e.IdThermometer).HasColumnName("id_Thermometer");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TimeOfYear>(entity =>
        {
            entity.HasKey(e => e.IdTimeOfYear);

            entity.ToTable("Time_of_Year");

            entity.Property(e => e.IdTimeOfYear).HasColumnName("id_Time_of_Year");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
