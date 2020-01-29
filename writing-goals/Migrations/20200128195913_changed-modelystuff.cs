using Microsoft.EntityFrameworkCore.Migrations;

namespace writing_goals.Migrations
{
    public partial class changedmodelystuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Goals_SprintId",
                table: "Goals",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Sprints_SprintId",
                table: "Goals",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Sprints_SprintId",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_SprintId",
                table: "Goals");
        }
    }
}
