using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InlamningsupgiftApi.Migrations
{
    public partial class AddedRemovedColumnToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Products");
        }
    }
}
