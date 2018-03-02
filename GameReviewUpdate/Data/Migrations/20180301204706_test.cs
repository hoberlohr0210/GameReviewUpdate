using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameReviewUpdate.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Reviews_ReviewID",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Types_TypeID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ReviewID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReviewID",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameID",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeID",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GameID",
                table: "Reviews",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Types_TypeID",
                table: "Games",
                column: "TypeID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Games_GameID",
                table: "Reviews",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Types_TypeID",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Games_GameID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_GameID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "TypeID",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewID",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ReviewID",
                table: "Games",
                column: "ReviewID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Reviews_ReviewID",
                table: "Games",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Types_TypeID",
                table: "Games",
                column: "TypeID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
