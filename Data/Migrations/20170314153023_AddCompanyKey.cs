using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtendIdentityUserRole.Data.Migrations
{
    public partial class AddCompanyKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_CompanyId",
                table: "AspNetUserRoles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Company_CompanyId",
                table: "AspNetUserRoles",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Company_CompanyId",
                table: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_CompanyId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUserRoles");
        }
    }
}
