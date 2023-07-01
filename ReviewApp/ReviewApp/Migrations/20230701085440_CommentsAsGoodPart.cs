using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class CommentsAsGoodPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Goods_GoodId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_GoodId",
                table: "Comment",
                newName: "IX_Comment_GoodId");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentGoodId",
                table: "Comment",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentGoodId",
                table: "Comment",
                column: "ParentGoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Goods_GoodId",
                table: "Comment",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Goods_ParentGoodId",
                table: "Comment",
                column: "ParentGoodId",
                principalTable: "Goods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
