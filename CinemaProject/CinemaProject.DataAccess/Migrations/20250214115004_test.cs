using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScreeningId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScreenID",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Screenings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScreeningId",
                table: "Tickets",
                column: "ScreeningId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Screenings_ScreeningId",
                table: "Tickets",
                column: "ScreeningId",
                principalTable: "Screenings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Screen_ScreenID",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Screenings_ScreeningId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ScreeningId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_ScreenID",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "ScreeningId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ScreenID",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Screenings");
        }
    }
}
