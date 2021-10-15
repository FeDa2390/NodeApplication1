using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class UpdateSkillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Vacancies_VacancyId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_VacancyId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "Skill");

            migrationBuilder.CreateTable(
                name: "SkillVacancy",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    VacanciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillVacancy", x => new { x.SkillsId, x.VacanciesId });
                    table.ForeignKey(
                        name: "FK_SkillVacancy_Skill_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillVacancy_Vacancies_VacanciesId",
                        column: x => x.VacanciesId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillVacancy_VacanciesId",
                table: "SkillVacancy",
                column: "VacanciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillVacancy");

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "Skill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_VacancyId",
                table: "Skill",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Vacancies_VacancyId",
                table: "Skill",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
