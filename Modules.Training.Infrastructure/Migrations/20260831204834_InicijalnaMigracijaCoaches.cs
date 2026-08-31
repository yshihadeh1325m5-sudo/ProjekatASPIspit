using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Coaches.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicijalnaMigracijaCoaches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoachesItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Licenca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisLicence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ekipa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachesItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachesItems");
        }
    }
}
