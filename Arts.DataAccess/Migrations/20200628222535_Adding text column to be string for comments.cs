using Microsoft.EntityFrameworkCore.Migrations;

namespace Arts.DataAccess.Migrations
{
    public partial class Addingtextcolumntobestringforcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Text",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
