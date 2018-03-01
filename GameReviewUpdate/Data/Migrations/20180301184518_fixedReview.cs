using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameReviewUpdate.Data.Migrations
{
    public partial class fixedReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Reviews_ReviewGameID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ReviewGameID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReviewGameID",
                table: "Games");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Reviews_ReviewID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ReviewID",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "ReviewGameID",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ReviewGameID",
                table: "Games",
                column: "ReviewGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Reviews_ReviewGameID",
                table: "Games",
                column: "ReviewGameID",
                principalTable: "Reviews",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
