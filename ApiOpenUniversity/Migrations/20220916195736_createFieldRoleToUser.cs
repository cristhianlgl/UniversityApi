using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiOpenUniversity.Migrations
{
    public partial class createFieldRoleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirtsName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FirtsName");
        }
    }
}
