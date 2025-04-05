using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital_Persistence_Layer.Migrations
{
    /// <inheritdoc />
    public partial class Init_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainCategorySubCategory");

            migrationBuilder.AddColumn<Guid>(
                name: "MainCategoryId",
                table: "SubCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_MainCategoryId",
                table: "SubCategories",
                column: "MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_MainCategories_MainCategoryId",
                table: "SubCategories",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_MainCategories_MainCategoryId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_MainCategoryId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "MainCategoryId",
                table: "SubCategories");

            migrationBuilder.CreateTable(
                name: "MainCategorySubCategory",
                columns: table => new
                {
                    MainCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCategoriesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategorySubCategory", x => new { x.MainCategoryId, x.SubCategoriesId });
                    table.ForeignKey(
                        name: "FK_MainCategorySubCategory_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainCategorySubCategory_SubCategories_SubCategoriesId",
                        column: x => x.SubCategoriesId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainCategorySubCategory_SubCategoriesId",
                table: "MainCategorySubCategory",
                column: "SubCategoriesId");
        }
    }
}
