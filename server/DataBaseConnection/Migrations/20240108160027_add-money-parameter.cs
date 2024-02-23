using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseConnection.Migrations
{
    public partial class addmoneyparameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tokens",
                table: "Projects",
                newName: "TotalTokens");

            migrationBuilder.AddColumn<float>(
                name: "TotalMoney",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMoney",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "TotalTokens",
                table: "Projects",
                newName: "Tokens");
        }
    }
}
