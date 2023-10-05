using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompnyEmployees.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18336756-cccc-4161-96ab-ff2d0788aba4", "d784328d-6a62-42a2-b1b5-1d510cce7cb2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2bc20be-6e0f-472f-8669-c3088e6d180c", "db6860c5-89d0-4fb6-b15a-e32df0f314f1", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18336756-cccc-4161-96ab-ff2d0788aba4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2bc20be-6e0f-472f-8669-c3088e6d180c");
        }
    }
}
