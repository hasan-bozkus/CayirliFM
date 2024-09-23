using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CayirliFM.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_create_relationship_in_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewsID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryID",
                table: "News",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_News_EmployeeID",
                table: "News",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsID",
                table: "Comments",
                column: "NewsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsID",
                table: "Comments",
                column: "NewsID",
                principalTable: "News",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_CategoryID",
                table: "News",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Employees_EmployeeID",
                table: "News",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_NewsID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_CategoryID",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Employees_EmployeeID",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryID",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_EmployeeID",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Comments_NewsID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "News");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsID",
                table: "Comments");
        }
    }
}
