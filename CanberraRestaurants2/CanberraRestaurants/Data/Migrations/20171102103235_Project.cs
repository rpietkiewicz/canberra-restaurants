using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CanberraRestaurants.Data.Migrations
{
    public partial class Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUserRoles_UserId",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            //migrationBuilder.CreateTable(
            //    name: "Review",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Agree = table.Column<int>(nullable: false),
            //        Comment = table.Column<string>(nullable: false),
            //        Date = table.Column<DateTime>(nullable: false),
            //        Disagree = table.Column<int>(nullable: false),
            //        Heading = table.Column<string>(nullable: false),
            //        IsClicked = table.Column<bool>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Rating = table.Column<string>(nullable: false),
            //        Restaurant = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Review", x => x.Id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Review");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_UserId",
            //    table: "AspNetUserRoles",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName");
        }
    }
}
