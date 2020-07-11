using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularySpider.Data.Migrations
{
    public partial class ReferentialDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conjugations_VerbTenses_VerbTenseId",
                table: "Conjugations");

            migrationBuilder.DropForeignKey(
                name: "FK_VerbTenses_Verbs_VerbId",
                table: "VerbTenses");

            migrationBuilder.AddForeignKey(
                name: "FK_Conjugations_VerbTenses_VerbTenseId",
                table: "Conjugations",
                column: "VerbTenseId",
                principalTable: "VerbTenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VerbTenses_Verbs_VerbId",
                table: "VerbTenses",
                column: "VerbId",
                principalTable: "Verbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conjugations_VerbTenses_VerbTenseId",
                table: "Conjugations");

            migrationBuilder.DropForeignKey(
                name: "FK_VerbTenses_Verbs_VerbId",
                table: "VerbTenses");

            migrationBuilder.AddForeignKey(
                name: "FK_Conjugations_VerbTenses_VerbTenseId",
                table: "Conjugations",
                column: "VerbTenseId",
                principalTable: "VerbTenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VerbTenses_Verbs_VerbId",
                table: "VerbTenses",
                column: "VerbId",
                principalTable: "Verbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
