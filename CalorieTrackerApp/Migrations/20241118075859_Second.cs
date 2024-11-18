using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTrackerCookBookApp.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FullId",
                table: "AspNetUsers",
                type: "int",
                maxLength: 36,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullId",
                table: "AspNetUsers");
        }
    }
}
