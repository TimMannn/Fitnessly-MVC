﻿// <auto-generated />
using System;
using DAL.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.EntityFramework.Migrations
{
    [DbContext(typeof(FitnesslybackupContext))]
    partial class FitnesslybackupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Aspnetuserrole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "RoleId" }, "RoleId");

                    b.ToTable("aspnetuserroles", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetrole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("aspnetroles", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetroleclaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleId" }, "RoleId")
                        .HasDatabaseName("RoleId1");

                    b.ToTable("aspnetroleclaims", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetuser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int(11)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<ulong>("EmailConfirmed")
                        .HasColumnType("bit(1)");

                    b.Property<ulong>("LockoutEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValueSql("b'0'");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<ulong>("PhoneNumberConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValueSql("b'0'");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<ulong>("TwoFactorEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit(1)")
                        .HasDefaultValueSql("b'0'");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("aspnetusers", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetuserclaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "UserId");

                    b.ToTable("aspnetuserclaims", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetuserlogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "UserId" }, "UserId")
                        .HasDatabaseName("UserId1");

                    b.ToTable("aspnetuserlogins", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetusertoken", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                    b.ToTable("aspnetusertokens", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__efmigrationshistory", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("exercise_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ExerciseId"));

                    b.Property<string>("ExerciseDisplay")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("exercise_display");

                    b.Property<double>("ExerciseGewicht")
                        .HasColumnType("double")
                        .HasColumnName("exercise_gewicht");

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("exercise_name");

                    b.Property<int>("ExerciseReps")
                        .HasColumnType("int(11)")
                        .HasColumnName("exercise_reps");

                    b.Property<int>("ExerciseSets")
                        .HasColumnType("int(11)")
                        .HasColumnName("exercise_sets");

                    b.HasKey("ExerciseId")
                        .HasName("PRIMARY");

                    b.ToTable("exercise", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("workout_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("WorkoutId"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("WorkoutName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("workout_name");

                    b.HasKey("WorkoutId")
                        .HasName("PRIMARY");

                    b.HasIndex("UserId");

                    b.ToTable("workout", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutexercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int(11)")
                        .HasColumnName("exercise_id");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int(11)")
                        .HasColumnName("workout_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ExerciseId" }, "fk_exercise_id");

                    b.HasIndex(new[] { "WorkoutId" }, "fk_workout_id");

                    b.ToTable("workoutexercise", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessie", b =>
                {
                    b.Property<int>("WorkoutsessieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessie_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("WorkoutsessieId"));

                    b.Property<string>("WorkoutsessieName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("workoutsessie_name");

                    b.Property<TimeOnly>("WorkoutsessieTijd")
                        .HasColumnType("time")
                        .HasColumnName("workoutsessie_tijd");

                    b.HasKey("WorkoutsessieId")
                        .HasName("PRIMARY");

                    b.ToTable("workoutsessie", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessieexercise", b =>
                {
                    b.Property<int>("WorkoutsessieexerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessieexercise_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("WorkoutsessieexerciseId"));

                    b.Property<string>("WorkoutsessieexerciseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("workoutsessieexercise_name");

                    b.Property<int>("WorkoutsessieexerciseSets")
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessieexercise_sets");

                    b.HasKey("WorkoutsessieexerciseId")
                        .HasName("PRIMARY");

                    b.ToTable("workoutsessieexercise", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessieexerciseworkoutsessiestat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("WorkoutsessieexerciseId")
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessieexercise_id");

                    b.Property<int>("WorkoutsessiestatsId")
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessiestats_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "WorkoutsessieexerciseId" }, "fk_workoutsessieexercise_id");

                    b.HasIndex(new[] { "WorkoutsessiestatsId" }, "fk_workoutsessiestats_id");

                    b.ToTable("workoutsessieexerciseworkoutsessiestats", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessiestat", b =>
                {
                    b.Property<int>("WorkoutsessiestatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessiestats_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("WorkoutsessiestatsId"));

                    b.Property<double>("WorkoutsessiestatsGewicht")
                        .HasColumnType("double")
                        .HasColumnName("workoutsessiestats_gewicht");

                    b.Property<int>("WorkoutsessiestatsReps")
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessiestats_reps");

                    b.HasKey("WorkoutsessiestatsId")
                        .HasName("PRIMARY");

                    b.ToTable("workoutsessiestats", (string)null);
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessieworkoutsessieexercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("WorkoutsessieId")
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessie_id");

                    b.Property<int>("WorkoutsessieexerciseId")
                        .HasColumnType("int(11)")
                        .HasColumnName("workoutsessieexercise_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "WorkoutsessieexerciseId" }, "fk2_workoutsessieexercise_id");

                    b.HasIndex(new[] { "WorkoutsessieId" }, "fk_workoutsessie_id");

                    b.ToTable("workoutsessieworkoutsessieexercise", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Aspnetuserrole", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Aspnetrole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("aspnetuserroles_ibfk_2");

                    b.HasOne("DAL.EntityFramework.Models.Aspnetuser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("aspnetuserroles_ibfk_1");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetroleclaim", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Aspnetrole", "Role")
                        .WithMany("Aspnetroleclaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("aspnetroleclaims_ibfk_1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetuserclaim", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Aspnetuser", "User")
                        .WithMany("Aspnetuserclaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("aspnetuserclaims_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetuserlogin", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Aspnetuser", "User")
                        .WithMany("Aspnetuserlogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("aspnetuserlogins_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetusertoken", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Aspnetuser", "User")
                        .WithMany("Aspnetusertokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("aspnetusertokens_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workout", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutexercise", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Exercise", "Exercise")
                        .WithMany("Workoutexercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_exercise_id");

                    b.HasOne("DAL.EntityFramework.Models.Workout", "Workout")
                        .WithMany("Workoutexercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workout_id");

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessieexerciseworkoutsessiestat", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Workoutsessieexercise", "Workoutsessieexercise")
                        .WithMany("Workoutsessieexerciseworkoutsessiestats")
                        .HasForeignKey("WorkoutsessieexerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workoutsessieexercise_id");

                    b.HasOne("DAL.EntityFramework.Models.Workoutsessiestat", "Workoutsessiestats")
                        .WithMany("Workoutsessieexerciseworkoutsessiestats")
                        .HasForeignKey("WorkoutsessiestatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workoutsessiestats_id");

                    b.Navigation("Workoutsessieexercise");

                    b.Navigation("Workoutsessiestats");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessieworkoutsessieexercise", b =>
                {
                    b.HasOne("DAL.EntityFramework.Models.Workoutsessie", "Workoutsessie")
                        .WithMany("Workoutsessieworkoutsessieexercises")
                        .HasForeignKey("WorkoutsessieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workoutsessie_id");

                    b.HasOne("DAL.EntityFramework.Models.Workoutsessieexercise", "Workoutsessieexercise")
                        .WithMany("Workoutsessieworkoutsessieexercises")
                        .HasForeignKey("WorkoutsessieexerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk2_workoutsessieexercise_id");

                    b.Navigation("Workoutsessie");

                    b.Navigation("Workoutsessieexercise");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetrole", b =>
                {
                    b.Navigation("Aspnetroleclaims");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Aspnetuser", b =>
                {
                    b.Navigation("Aspnetuserclaims");

                    b.Navigation("Aspnetuserlogins");

                    b.Navigation("Aspnetusertokens");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Exercise", b =>
                {
                    b.Navigation("Workoutexercises");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workout", b =>
                {
                    b.Navigation("Workoutexercises");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessie", b =>
                {
                    b.Navigation("Workoutsessieworkoutsessieexercises");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessieexercise", b =>
                {
                    b.Navigation("Workoutsessieexerciseworkoutsessiestats");

                    b.Navigation("Workoutsessieworkoutsessieexercises");
                });

            modelBuilder.Entity("DAL.EntityFramework.Models.Workoutsessiestat", b =>
                {
                    b.Navigation("Workoutsessieexerciseworkoutsessiestats");
                });
#pragma warning restore 612, 618
        }
    }
}