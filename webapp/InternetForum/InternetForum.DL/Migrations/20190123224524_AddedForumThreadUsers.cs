using Microsoft.EntityFrameworkCore.Migrations;

namespace InternetForum.DL.Migrations
{
    public partial class AddedForumThreadUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarURL",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ForumThreadUsers",
                columns: table => new
                {
                    ForumThreadId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThreadUsers", x => new { x.ForumThreadId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ForumThreadUsers_ForumThreads_ForumThreadId",
                        column: x => x.ForumThreadId,
                        principalTable: "ForumThreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumThreadUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreadUsers_UserId",
                table: "ForumThreadUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumThreadUsers");

            migrationBuilder.AddColumn<string>(
                name: "AvatarURL",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
