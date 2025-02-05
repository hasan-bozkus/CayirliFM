using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CayirliFM.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_create_table_of_replytocontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Employees_EmployeeID",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "News",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ReplyToContacts",
                columns: table => new
                {
                    ReplyToContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyToContacts", x => x.ReplyToContactID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_News_Employees_EmployeeID",
                table: "News",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Employees_EmployeeID",
                table: "News");

            migrationBuilder.DropTable(
                name: "ReplyToContacts");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Employees_EmployeeID",
                table: "News",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
