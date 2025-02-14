using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Screen_ScreenID",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_ScreenID",
                table: "Screenings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Screenings_ScreenID",
                table: "Screenings",
                column: "ScreenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Screen_ScreenID",
                table: "Screenings",
                column: "ScreenID",
                principalTable: "Screen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
