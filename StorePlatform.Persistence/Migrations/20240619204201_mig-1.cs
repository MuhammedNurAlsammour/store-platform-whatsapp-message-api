using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorePlatform.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "StorePlatform");

            migrationBuilder.CreateTable(
                name: "Examples",
                schema: "StorePlatform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    RowCreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowUpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowIsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowIsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples",
                schema: "StorePlatform");
        }
    }
}
