using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CayirliFM.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_updated_socialmedia_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMail",
                table: "SocialMediaAccounts");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "SocialMediaAccounts");

            migrationBuilder.RenameColumn(
                name: "Youtube",
                table: "SocialMediaAccounts",
                newName: "SocialMediaUrl");

            migrationBuilder.RenameColumn(
                name: "XTwitter",
                table: "SocialMediaAccounts",
                newName: "SocialMediaName");

            migrationBuilder.RenameColumn(
                name: "Instagram",
                table: "SocialMediaAccounts",
                newName: "Icon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialMediaUrl",
                table: "SocialMediaAccounts",
                newName: "Youtube");

            migrationBuilder.RenameColumn(
                name: "SocialMediaName",
                table: "SocialMediaAccounts",
                newName: "XTwitter");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "SocialMediaAccounts",
                newName: "Instagram");

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "SocialMediaAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "SocialMediaAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
