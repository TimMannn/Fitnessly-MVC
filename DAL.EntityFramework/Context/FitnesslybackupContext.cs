using System;
using System.Collections.Generic;
using DAL.EntityFramework.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DAL.EntityFramework.Context;

public partial class FitnesslybackupContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
	public FitnesslybackupContext(DbContextOptions<FitnesslybackupContext> options)
		: base(options)
	{
	}

	public DbSet<IdentityUser> IdentityUsers { get; set; }
	public DbSet<IdentityRole> IdentityRoles { get; set; }
	public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
	public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }
	public DbSet<IdentityUserLogin<string>> IdentityUserLogins { get; set; }
	public DbSet<IdentityRoleClaim<string>> IdentityRoleClaims { get; set; }
	public DbSet<IdentityUserToken<string>> IdentityUserTokens { get; set; }
	public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }
	public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }
	public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }
	public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }
	public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }
	public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }
	public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
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
		=> optionsBuilder.UseMySql("server=localhost;database=fitnesslybackup;user=root", ServerVersion.Parse("10.4.32-mariadb"));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<IdentityUserRole<string>>(entity =>
		{
			entity.HasKey(e => new { e.UserId, e.RoleId });
		});

		modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
		{
			entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
		});

		modelBuilder
			.UseCollation("utf8mb4_general_ci")
			.HasCharSet("utf8mb4");

		modelBuilder.Entity<Aspnetrole>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("aspnetroles");

			entity.Property(e => e.Id).HasMaxLength(450);
			entity.Property(e => e.ConcurrencyStamp).HasMaxLength(256);
			entity.Property(e => e.Name).HasMaxLength(256);
			entity.Property(e => e.NormalizedName).HasMaxLength(256);
		});

		modelBuilder.Entity<Aspnetroleclaim>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("aspnetroleclaims");

			entity.HasIndex(e => e.RoleId, "FK_AspNetRoleClaims_AspNetRoles_RoleId");

			entity.Property(e => e.Id).HasColumnType("int(11)");
			entity.Property(e => e.ClaimType).HasColumnType("text");
			entity.Property(e => e.ClaimValue).HasColumnType("text");
			entity.Property(e => e.RoleId).HasMaxLength(191);

			entity.HasOne(d => d.Role).WithMany(p => p.Aspnetroleclaims)
				.HasForeignKey(d => d.RoleId)
				.HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
		});

		modelBuilder.Entity<Aspnetuser>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("aspnetusers");

			entity.Property(e => e.Id).HasMaxLength(450);
			entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");
			entity.Property(e => e.ConcurrencyStamp).HasColumnType("text");
			entity.Property(e => e.Email).HasMaxLength(256);
			entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");
			entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");
			entity.Property(e => e.LockoutEnd).HasColumnType("datetime");
			entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
			entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
			entity.Property(e => e.PasswordHash).HasColumnType("text");
			entity.Property(e => e.PhoneNumber).HasColumnType("text");
			entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");
			entity.Property(e => e.SecurityStamp).HasColumnType("text");
			entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");
			entity.Property(e => e.UserName).HasMaxLength(256);

			entity.HasMany(d => d.Roles).WithMany(p => p.Users)
				.UsingEntity<Dictionary<string, object>>(
					"Aspnetuserrole",
					r => r.HasOne<Aspnetrole>().WithMany()
						.HasForeignKey("RoleId")
						.HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
					l => l.HasOne<Aspnetuser>().WithMany()
						.HasForeignKey("UserId")
						.HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
					j =>
					{
						j.HasKey("UserId", "RoleId")
							.HasName("PRIMARY")
							.HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
						j.ToTable("aspnetuserroles");
						j.HasIndex(new[] { "RoleId" }, "FK_AspNetUserRoles_AspNetRoles_RoleId");
						j.IndexerProperty<string>("UserId").HasMaxLength(191);
						j.IndexerProperty<string>("RoleId").HasMaxLength(191);
					});
		});

		modelBuilder.Entity<Aspnetuserclaim>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PRIMARY");

			entity.ToTable("aspnetuserclaims");

			entity.HasIndex(e => e.UserId, "FK_AspNetUserClaims_AspNetUsers_UserId");

			entity.Property(e => e.Id).HasColumnType("int(11)");
			entity.Property(e => e.ClaimType).HasColumnType("text");
			entity.Property(e => e.ClaimValue).HasColumnType("text");
			entity.Property(e => e.UserId).HasMaxLength(191);

			entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserclaims)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
		});

		modelBuilder.Entity<Aspnetuserlogin>(entity =>
		{
			entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
				.HasName("PRIMARY")
				.HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

			entity.ToTable("aspnetuserlogins");

			entity.HasIndex(e => e.UserId, "FK_AspNetUserLogins_AspNetUsers_UserId");

			entity.Property(e => e.LoginProvider).HasMaxLength(191);
			entity.Property(e => e.ProviderKey).HasMaxLength(191);
			entity.Property(e => e.ProviderDisplayName).HasColumnType("text");
			entity.Property(e => e.UserId).HasMaxLength(191);

			entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserlogins)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
		});

		modelBuilder.Entity<Aspnetusertoken>(entity =>
		{
			entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
				.HasName("PRIMARY")
				.HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

			entity.ToTable("aspnetusertokens");

			entity.Property(e => e.UserId).HasMaxLength(191);
			entity.Property(e => e.LoginProvider).HasMaxLength(191);
			entity.Property(e => e.Name).HasMaxLength(191);
			entity.Property(e => e.Value).HasColumnType("text");

			entity.HasOne(d => d.User).WithMany(p => p.Aspnetusertokens)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
		});

		modelBuilder.Entity<Efmigrationshistory>(entity =>
		{
			entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

			entity.ToTable("__efmigrationshistory");

			entity.Property(e => e.MigrationId).HasMaxLength(150);
			entity.Property(e => e.ProductVersion).HasMaxLength(32);
		});

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
			entity.Property(e => e.UserId)
				.HasMaxLength(255)
				.HasDefaultValueSql("''");
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
