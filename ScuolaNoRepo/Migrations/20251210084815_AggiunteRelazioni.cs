using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScuolaNoRepo.Migrations
{
    /// <inheritdoc />
    public partial class AggiunteRelazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Corsi_CorsoId",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_CorsoId",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "CorsoId",
                table: "Studenti");

            migrationBuilder.AlterColumn<string>(
                name: "matricola",
                table: "Studenti",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CorsoStudente",
                columns: table => new
                {
                    CorsiId = table.Column<int>(type: "int", nullable: false),
                    StudentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoStudente", x => new { x.CorsiId, x.StudentiId });
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Corsi_CorsiId",
                        column: x => x.CorsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Studenti_StudentiId",
                        column: x => x.StudentiId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_matricola",
                table: "Studenti",
                column: "matricola",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorsoStudente_StudentiId",
                table: "CorsoStudente",
                column: "StudentiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorsoStudente");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_matricola",
                table: "Studenti");

            migrationBuilder.AlterColumn<string>(
                name: "matricola",
                table: "Studenti",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CorsoId",
                table: "Studenti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_CorsoId",
                table: "Studenti",
                column: "CorsoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Corsi_CorsoId",
                table: "Studenti",
                column: "CorsoId",
                principalTable: "Corsi",
                principalColumn: "Id");
        }
    }
}
