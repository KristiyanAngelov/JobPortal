using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Data.Migrations
{
    public partial class AddCompanyLogoPropertyToJobPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyLogo",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyLogo",
                table: "JobPosts");
        }
    }
}
