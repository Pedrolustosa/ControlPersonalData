using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ControlPersonalData.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35b2e398-16e8-46f6-b5a5-453c30fb77ba", "1", "Admin", "Admin" },
                    { "e74ac9fa-b7a1-4192-990d-7a04286ff426", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35b2e398-16e8-46f6-b5a5-453c30fb77ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e74ac9fa-b7a1-4192-990d-7a04286ff426");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "AspNetUsers");
        }
    }
}
