using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace laba_1.DAL.Migrations
{
    public partial class Ajax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AjaxGroups",
                columns: table => new
                {
                    AjaxGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjaxGroups", x => x.AjaxGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Ajaxes",
                columns: table => new
                {
                    DivicesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivicesName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    detection = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    AjaxGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ajaxes", x => x.DivicesID);
                    table.ForeignKey(
                        name: "FK_Ajaxes_AjaxGroups_AjaxGroupId",
                        column: x => x.AjaxGroupId,
                        principalTable: "AjaxGroups",
                        principalColumn: "AjaxGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ajaxes_AjaxGroupId",
                table: "Ajaxes",
                column: "AjaxGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ajaxes");

            migrationBuilder.DropTable(
                name: "AjaxGroups");
        }
    }
}
