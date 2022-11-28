﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace product.Migrations
{
    /// <inheritdoc />
    public partial class RateTableExtendedWithCommentAndGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentBody",
                schema: "product",
                table: "Rate",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommentTitle",
                schema: "product",
                table: "Rate",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                schema: "product",
                table: "Rate",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "product",
                table: "Rate",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentBody",
                schema: "product",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "CommentTitle",
                schema: "product",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "Grade",
                schema: "product",
                table: "Rate");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "product",
                table: "Rate");
        }
    }
}