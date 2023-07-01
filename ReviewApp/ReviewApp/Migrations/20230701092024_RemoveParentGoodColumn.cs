using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveParentGoodColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Goods_ParentGoodId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentGoodId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentGoodId",
                table: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
