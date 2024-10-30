using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Web_api.Models;

public partial class FitnesslybackupContext : DbContext
{
    public FitnesslybackupContext()
    {
    }

    public FitnesslybackupContext(DbContextOptions<FitnesslybackupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<Workoutexercise> Workoutexercises { get; set; }

    public virtual DbSet<Workoutsessie> Workoutsessies { get; set; }

    public virtual DbSet<Workoutsessieexercise> Workoutsessieexercises { get; set; }

    public virtual DbSet<Workoutsessieexerciseworkoutsessiestat> Workoutsessieexerciseworkoutsessiestats { get; set; }

    public virtual DbSet<Workoutsessiestat> Workoutsessiestats { get; set; }

    public virtual DbSet<Workoutsessieworkoutsessieexercise> Workoutsessieworkoutsessieexercises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=fitnesslybackup", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PRIMARY");

            entity.ToTable("exercise");

            entity.Property(e => e.ExerciseId)
                .HasColumnType("int(11)")
                .HasColumnName("exercise_id");
            entity.Property(e => e.ExerciseDisplay)
                .HasMaxLength(50)
                .HasColumnName("exercise_display");
            entity.Property(e => e.ExerciseGewicht).HasColumnName("exercise_gewicht");
            entity.Property(e => e.ExerciseName)
                .HasMaxLength(50)
                .HasColumnName("exercise_name");
            entity.Property(e => e.ExerciseReps)
                .HasColumnType("int(11)")
                .HasColumnName("exercise_reps");
            entity.Property(e => e.ExerciseSets)
                .HasColumnType("int(11)")
                .HasColumnName("exercise_sets");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.WorkoutId).HasName("PRIMARY");

            entity.ToTable("workout");

            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(11)")
                .HasColumnName("workout_id");
            entity.Property(e => e.WorkoutName)
                .HasMaxLength(50)
                .HasColumnName("workout_name");
        });

        modelBuilder.Entity<Workoutexercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workoutexercise");

            entity.HasIndex(e => e.ExerciseId, "fk_exercise_id");

            entity.HasIndex(e => e.WorkoutId, "fk_workout_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ExerciseId)
                .HasColumnType("int(11)")
                .HasColumnName("exercise_id");
            entity.Property(e => e.WorkoutId)
                .HasColumnType("int(11)")
                .HasColumnName("workout_id");

            entity.HasOne(d => d.Exercise).WithMany(p => p.Workoutexercises)
                .HasForeignKey(d => d.ExerciseId)
                .HasConstraintName("fk_exercise_id");

            entity.HasOne(d => d.Workout).WithMany(p => p.Workoutexercises)
                .HasForeignKey(d => d.WorkoutId)
                .HasConstraintName("fk_workout_id");
        });

        modelBuilder.Entity<Workoutsessie>(entity =>
        {
            entity.HasKey(e => e.WorkoutsessieId).HasName("PRIMARY");

            entity.ToTable("workoutsessie");

            entity.Property(e => e.WorkoutsessieId)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessie_id");
            entity.Property(e => e.WorkoutsessieName)
                .HasMaxLength(50)
                .HasColumnName("workoutsessie_name");
            entity.Property(e => e.WorkoutsessieTijd)
                .HasColumnType("time")
                .HasColumnName("workoutsessie_tijd");
        });

        modelBuilder.Entity<Workoutsessieexercise>(entity =>
        {
            entity.HasKey(e => e.WorkoutsessieexerciseId).HasName("PRIMARY");

            entity.ToTable("workoutsessieexercise");

            entity.Property(e => e.WorkoutsessieexerciseId)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessieexercise_id");
            entity.Property(e => e.WorkoutsessieexerciseName)
                .HasMaxLength(50)
                .HasColumnName("workoutsessieexercise_name");
            entity.Property(e => e.WorkoutsessieexerciseSets)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessieexercise_sets");
        });

        modelBuilder.Entity<Workoutsessieexerciseworkoutsessiestat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workoutsessieexerciseworkoutsessiestats");

            entity.HasIndex(e => e.WorkoutsessieexerciseId, "fk_workoutsessieexercise_id");

            entity.HasIndex(e => e.WorkoutsessiestatsId, "fk_workoutsessiestats_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.WorkoutsessieexerciseId)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessieexercise_id");
            entity.Property(e => e.WorkoutsessiestatsId)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessiestats_id");

            entity.HasOne(d => d.Workoutsessieexercise).WithMany(p => p.Workoutsessieexerciseworkoutsessiestats)
                .HasForeignKey(d => d.WorkoutsessieexerciseId)
                .HasConstraintName("fk_workoutsessieexercise_id");

            entity.HasOne(d => d.Workoutsessiestats).WithMany(p => p.Workoutsessieexerciseworkoutsessiestats)
                .HasForeignKey(d => d.WorkoutsessiestatsId)
                .HasConstraintName("fk_workoutsessiestats_id");
        });

        modelBuilder.Entity<Workoutsessiestat>(entity =>
        {
            entity.HasKey(e => e.WorkoutsessiestatsId).HasName("PRIMARY");

            entity.ToTable("workoutsessiestats");

            entity.Property(e => e.WorkoutsessiestatsId)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessiestats_id");
            entity.Property(e => e.WorkoutsessiestatsGewicht).HasColumnName("workoutsessiestats_gewicht");
            entity.Property(e => e.WorkoutsessiestatsReps)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessiestats_reps");
        });

        modelBuilder.Entity<Workoutsessieworkoutsessieexercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("workoutsessieworkoutsessieexercise");

            entity.HasIndex(e => e.WorkoutsessieexerciseId, "fk2_workoutsessieexercise_id");

            entity.HasIndex(e => e.WorkoutsessieId, "fk_workoutsessie_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.WorkoutsessieId)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessie_id");
            entity.Property(e => e.WorkoutsessieexerciseId)
                .HasColumnType("int(11)")
                .HasColumnName("workoutsessieexercise_id");

            entity.HasOne(d => d.Workoutsessie).WithMany(p => p.Workoutsessieworkoutsessieexercises)
                .HasForeignKey(d => d.WorkoutsessieId)
                .HasConstraintName("fk_workoutsessie_id");

            entity.HasOne(d => d.Workoutsessieexercise).WithMany(p => p.Workoutsessieworkoutsessieexercises)
                .HasForeignKey(d => d.WorkoutsessieexerciseId)
                .HasConstraintName("fk2_workoutsessieexercise_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
