using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Data.Migrations
{
    public partial class AddCityPropertyinSeachJobPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "SearchJobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "SearchJobPosts");
        }
    }
}
