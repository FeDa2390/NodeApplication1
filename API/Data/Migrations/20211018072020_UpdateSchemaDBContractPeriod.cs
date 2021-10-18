using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class UpdateSchemaDBContractPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkill_Skill_SkillsId",
                table: "CandidateSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillVacancy_Skill_SkillsId",
                table: "SkillVacancy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContractsPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsPeriod", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkill_Skills_SkillsId",
                table: "CandidateSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillVacancy_Skills_SkillsId",
                table: "SkillVacancy",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkill_Skills_SkillsId",
                table: "CandidateSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillVacancy_Skills_SkillsId",
                table: "SkillVacancy");

            migrationBuilder.DropTable(
                name: "ContractsPeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkill_Skill_SkillsId",
                table: "CandidateSkill",
                column: "SkillsId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillVacancy_Skill_SkillsId",
                table: "SkillVacancy",
                column: "SkillsId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
