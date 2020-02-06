using Microsoft.EntityFrameworkCore.Migrations;

namespace writing_goals.Migrations
{
    public partial class goalTimeIntToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WordCountActual",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "TimeActual",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WordCountActual",
                table: "Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "TimeActual",
                table: "Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
