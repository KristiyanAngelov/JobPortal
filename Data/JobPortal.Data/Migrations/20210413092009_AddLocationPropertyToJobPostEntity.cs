using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Data.Migrations
{
    public partial class AddLocationPropertyToJobPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobPosts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobPosts");
        }
    }
}
