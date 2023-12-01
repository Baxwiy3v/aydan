using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PesKit.Migrations
{
    public partial class CreateProjectsTableAndProjectImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideImage_Slides_SlideId",
                table: "SlideImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideImage",
                table: "SlideImage");

            migrationBuilder.RenameTable(
                name: "SlideImage",
                newName: "SlideImages");

            migrationBuilder.RenameIndex(
                name: "IX_SlideImage_SlideId",
                table: "SlideImages",
                newName: "IX_SlideImages_SlideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideImages",
                table: "SlideImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectImages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_ProjectId",
                table: "ProjectImages",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlideImages_Slides_SlideId",
                table: "SlideImages",
                column: "SlideId",
                principalTable: "Slides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideImages_Slides_SlideId",
                table: "SlideImages");

            migrationBuilder.DropTable(
                name: "ProjectImages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideImages",
                table: "SlideImages");

            migrationBuilder.RenameTable(
                name: "SlideImages",
                newName: "SlideImage");

            migrationBuilder.RenameIndex(
                name: "IX_SlideImages_SlideId",
                table: "SlideImage",
                newName: "IX_SlideImage_SlideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideImage",
                table: "SlideImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SlideImage_Slides_SlideId",
                table: "SlideImage",
                column: "SlideId",
                principalTable: "Slides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
