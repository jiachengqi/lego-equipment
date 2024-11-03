using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "CurrentState", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Molding Machine A" },
                    { 2, 1, "Molding Machine B" },
                    { 3, 2, "Molding Machine C" },
                    { 4, 0, "Assembly Line A" },
                    { 5, 1, "Assembly Line B" },
                    { 6, 2, "Assembly Line C" },
                    { 7, 0, "Packaging Unit A" },
                    { 8, 1, "Packaging Unit B" },
                    { 9, 2, "Packaging Unit C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");
        }
    }
}
