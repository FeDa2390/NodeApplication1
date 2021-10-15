using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameCandidate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurnameCandidate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vacancies = table.Column<int>(type: "int", nullable: false),
                    ContractPeriod = table.Column<int>(type: "int", nullable: false),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificatesOfStudy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertCandidateId = table.Column<int>(type: "int", nullable: true),
                    CertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolUniversity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificatesOfStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificatesOfStudy_Candidates_CertCandidateId",
                        column: x => x.CertCandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DossierCandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossiers_Candidates_DossierCandidateId",
                        column: x => x.DossierCandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateVacancy",
                columns: table => new
                {
                    CandidatesId = table.Column<int>(type: "int", nullable: false),
                    VacanciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateVacancy", x => new { x.CandidatesId, x.VacanciesId });
                    table.ForeignKey(
                        name: "FK_CandidateVacancy_Candidates_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateVacancy_Vacancies_VacanciesId",
                        column: x => x.VacanciesId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVacancy_VacanciesId",
                table: "CandidateVacancy",
                column: "VacanciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificatesOfStudy_CertCandidateId",
                table: "CertificatesOfStudy",
                column: "CertCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_DossierCandidateId",
                table: "Dossiers",
                column: "DossierCandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateVacancy");

            migrationBuilder.DropTable(
                name: "CertificatesOfStudy");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
