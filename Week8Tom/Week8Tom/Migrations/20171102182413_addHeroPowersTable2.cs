using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Week8Tom.Migrations
{
    public partial class addHeroPowersTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroPowersId",
                table: "HeroStats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HeroPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PowerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroPowers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroStats_HeroPowersId",
                table: "HeroStats",
                column: "HeroPowersId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroStats_HeroPowers_HeroPowersId",
                table: "HeroStats",
                column: "HeroPowersId",
                principalTable: "HeroPowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroStats_HeroPowers_HeroPowersId",
                table: "HeroStats");

            migrationBuilder.DropTable(
                name: "HeroPowers");

            migrationBuilder.DropIndex(
                name: "IX_HeroStats_HeroPowersId",
                table: "HeroStats");

            migrationBuilder.DropColumn(
                name: "HeroPowersId",
                table: "HeroStats");
        }
    }
}
