using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class UpdateSchemaDBContractPeriod1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "ContractsPeriod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "ContractsPeriod",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
