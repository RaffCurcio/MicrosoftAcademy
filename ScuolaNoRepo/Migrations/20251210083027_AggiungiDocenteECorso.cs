using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScuolaNoRepo.Migrations
{
    /// <inheritdoc />
    public partial class AggiungiDocenteECorso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorsoId",
                table: "Studenti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codiceId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Docenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Materia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CorsoDocente",
                columns: table => new
                {
                    CorsiId = table.Column<int>(type: "int", nullable: false),
                    DocentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoDocente", x => new { x.CorsiId, x.DocentiId });
                    table.ForeignKey(
                        name: "FK_CorsoDocente_Corsi_CorsiId",
                        column: x => x.CorsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoDocente_Docenti_DocentiId",
                        column: x => x.DocentiId,
                        principalTable: "Docenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_CorsoId",
                table: "Studenti",
                column: "CorsoId");

            migrationBuilder.CreateIndex(
                name: "IX_CorsoDocente_DocentiId",
                table: "CorsoDocente",
                column: "DocentiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Corsi_CorsoId",
                table: "Studenti",
                column: "CorsoId",
                principalTable: "Corsi",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Corsi_CorsoId",
                table: "Studenti");

            migrationBuilder.DropTable(
                name: "CorsoDocente");

            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "Docenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_CorsoId",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "CorsoId",
                table: "Studenti");
        }
    }
}
