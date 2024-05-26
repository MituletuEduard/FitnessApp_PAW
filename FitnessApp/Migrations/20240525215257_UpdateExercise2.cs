using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercise2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Exercises",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Exercises");
        }
    }
}
