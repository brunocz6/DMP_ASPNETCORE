using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternetForum.DL.Migrations
{
    public partial class AddedForumThreadEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_AuthorId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_Post_AuthorId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "ForumThreadId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ForumThreads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThreads", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumThreadId",
                table: "Posts",
                column: "ForumThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ForumThreads_ForumThreadId",
                table: "Posts",
                column: "ForumThreadId",
                principalTable: "ForumThreads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ForumThreads_ForumThreadId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "ForumThreads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ForumThreadId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ForumThreadId",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Post",
                newName: "IX_Post_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_AuthorId",
                table: "Post",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
