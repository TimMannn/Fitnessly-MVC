using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    exercise_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    exercise_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    exercise_gewicht = table.Column<double>(type: "double", nullable: false),
                    exercise_sets = table.Column<int>(type: "int(11)", nullable: false),
                    exercise_reps = table.Column<int>(type: "int(11)", nullable: false),
                    exercise_display = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.exercise_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "workout",
                columns: table => new
                {
                    workout_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    workout_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.workout_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "workoutsessie",
                columns: table => new
                {
                    workoutsessie_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    workoutsessie_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    workoutsessie_tijd = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.workoutsessie_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "workoutsessieexercise",
                columns: table => new
                {
                    workoutsessieexercise_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    workoutsessieexercise_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    workoutsessieexercise_sets = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.workoutsessieexercise_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "workoutsessiestats",
                columns: table => new
                {
                    workoutsessiestats_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    workoutsessiestats_gewicht = table.Column<double>(type: "double", nullable: false),
                    workoutsessiestats_reps = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.workoutsessiestats_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "workoutexercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    workout_id = table.Column<int>(type: "int(11)", nullable: false),
                    exercise_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "exercise_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workout_id",
                        column: x => x.workout_id,
                        principalTable: "workout",
                        principalColumn: "workout_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "workoutsessieworkoutsessieexercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    workoutsessie_id = table.Column<int>(type: "int(11)", nullable: false),
                    workoutsessieexercise_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk2_workoutsessieexercise_id",
                        column: x => x.workoutsessieexercise_id,
                        principalTable: "workoutsessieexercise",
                        principalColumn: "workoutsessieexercise_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workoutsessie_id",
                        column: x => x.workoutsessie_id,
                        principalTable: "workoutsessie",
                        principalColumn: "workoutsessie_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "workoutsessieexerciseworkoutsessiestats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    workoutsessieexercise_id = table.Column<int>(type: "int(11)", nullable: false),
                    workoutsessiestats_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "fk_workoutsessieexercise_id",
                        column: x => x.workoutsessieexercise_id,
                        principalTable: "workoutsessieexercise",
                        principalColumn: "workoutsessieexercise_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workoutsessiestats_id",
                        column: x => x.workoutsessiestats_id,
                        principalTable: "workoutsessiestats",
                        principalColumn: "workoutsessiestats_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_exercise_id",
                table: "workoutexercise",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "fk_workout_id",
                table: "workoutexercise",
                column: "workout_id");

            migrationBuilder.CreateIndex(
                name: "fk_workoutsessieexercise_id",
                table: "workoutsessieexerciseworkoutsessiestats",
                column: "workoutsessieexercise_id");

            migrationBuilder.CreateIndex(
                name: "fk_workoutsessiestats_id",
                table: "workoutsessieexerciseworkoutsessiestats",
                column: "workoutsessiestats_id");

            migrationBuilder.CreateIndex(
                name: "fk_workoutsessie_id",
                table: "workoutsessieworkoutsessieexercise",
                column: "workoutsessie_id");

            migrationBuilder.CreateIndex(
                name: "fk2_workoutsessieexercise_id",
                table: "workoutsessieworkoutsessieexercise",
                column: "workoutsessieexercise_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workoutexercise");

            migrationBuilder.DropTable(
                name: "workoutsessieexerciseworkoutsessiestats");

            migrationBuilder.DropTable(
                name: "workoutsessieworkoutsessieexercise");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "workout");

            migrationBuilder.DropTable(
                name: "workoutsessiestats");

            migrationBuilder.DropTable(
                name: "workoutsessieexercise");

            migrationBuilder.DropTable(
                name: "workoutsessie");
        }
    }
}
