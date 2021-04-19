using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Data.Migrations
{
    public partial class ChangeJobTypesToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTypes",
                table: "SearchJobPosts");

            migrationBuilder.AddColumn<int>(
                name: "JobType",
                table: "SearchJobPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobType",
                table: "SearchJobPosts");

            migrationBuilder.AddColumn<string>(
                name: "JobTypes",
                table: "SearchJobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
