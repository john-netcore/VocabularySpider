using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularySpider.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verbs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Infinitive = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerbTenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenseName = table.Column<string>(nullable: false),
                    VerbId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbTenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerbTenses_Verbs_VerbId",
                        column: x => x.VerbId,
                        principalTable: "Verbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conjugations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InflictedVerb = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    VerbTenseId = table.Column<int>(nullable: true),
                    Pronoun = table.Column<string>(nullable: true),
                    AuxiliaryVerb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjugations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conjugations_VerbTenses_VerbTenseId",
                        column: x => x.VerbTenseId,
                        principalTable: "VerbTenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conjugations_VerbTenseId",
                table: "Conjugations",
                column: "VerbTenseId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbTenses_VerbId",
                table: "VerbTenses",
                column: "VerbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conjugations");

            migrationBuilder.DropTable(
                name: "VerbTenses");

            migrationBuilder.DropTable(
                name: "Verbs");
        }
    }
}
