using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _05_ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesAndDueAt_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Todos_IsDone",
                table: "Todos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueAt",
                table: "Todos",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Todos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_IsDone_DueAt",
                table: "Todos",
                columns: new[] { "IsDone", "DueAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Todos_IsDone_DueAt",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "DueAt",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Todos");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_IsDone",
                table: "Todos",
                column: "IsDone");
        }
    }
}
