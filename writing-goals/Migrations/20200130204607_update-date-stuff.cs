using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace writing_goals.Migrations
{
    public partial class updatedatestuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Sprints",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Sprints",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateOnly",
                table: "Goals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeOnly",
                table: "Goals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOnly",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "TimeOnly",
                table: "Goals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Sprints",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Sprints",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
