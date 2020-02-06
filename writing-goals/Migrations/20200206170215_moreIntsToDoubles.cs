using Microsoft.EntityFrameworkCore.Migrations;

namespace writing_goals.Migrations
{
    public partial class moreIntsToDoubles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WordCountGoal",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WordCountGoal",
                table: "Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
