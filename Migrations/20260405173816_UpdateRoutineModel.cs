using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoMate_Project_by_Priya.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoutineModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Routines",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EnableAlarm",
                table: "Reminders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "EnableAlarm",
                table: "Reminders");
        }
    }
}
