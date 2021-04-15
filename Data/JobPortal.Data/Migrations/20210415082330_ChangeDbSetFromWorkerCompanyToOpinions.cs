using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Data.Migrations
{
    public partial class ChangeDbSetFromWorkerCompanyToOpinions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerCompanies_AspNetUsers_CompanyId",
                table: "WorkerCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerCompanies_AspNetUsers_WorkerId",
                table: "WorkerCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerCompanies",
                table: "WorkerCompanies");

            migrationBuilder.RenameTable(
                name: "WorkerCompanies",
                newName: "Opinions");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerCompanies_CompanyId",
                table: "Opinions",
                newName: "IX_Opinions_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions",
                columns: new[] { "WorkerId", "CompanyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_AspNetUsers_CompanyId",
                table: "Opinions",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_AspNetUsers_WorkerId",
                table: "Opinions",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_AspNetUsers_CompanyId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_AspNetUsers_WorkerId",
                table: "Opinions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions");

            migrationBuilder.RenameTable(
                name: "Opinions",
                newName: "WorkerCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_Opinions_CompanyId",
                table: "WorkerCompanies",
                newName: "IX_WorkerCompanies_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerCompanies",
                table: "WorkerCompanies",
                columns: new[] { "WorkerId", "CompanyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerCompanies_AspNetUsers_CompanyId",
                table: "WorkerCompanies",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerCompanies_AspNetUsers_WorkerId",
                table: "WorkerCompanies",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
