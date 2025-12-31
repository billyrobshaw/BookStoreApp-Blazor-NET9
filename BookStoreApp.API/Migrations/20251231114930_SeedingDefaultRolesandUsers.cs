using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a793dd77-e0e2-4e9b-925b-4e3aa605c5dc", "f528ce09-e248-4fa0-b262-01ddbc65179d", "User", "USER" },
                    { "c191496a-d737-4d87-ae5d-51b520aae1c9", "8c837381-b6fd-4ee6-86af-a038137bb6de", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "40738840-7318-48f4-ad53-10c8d10351b5", 0, "19390174-c28c-4173-b294-bd2a05702669", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAENYlWU6yEUsTotbR6AYg26bkymZi52upkse2kQdcTXk/BsOqF3dpIgb01/JgbuEfAw==", null, false, "62e79141-7a8e-43f8-9012-4502ad9dda1d", false, "user@bookstore.com" },
                    { "9c964337-0cf3-4e74-87ca-0e815e8d8d5e", 0, "6715f036-272c-4af9-97ad-1a9a98bb3cd2", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEG5lJAlsPPb+tjeD+ftuiafMkgXFNtCy++IJH8mFLLTcCsu5iuRCWtd7ZK7DvsM6+Q==", null, false, "aeedfc4c-04a0-4c29-908d-1f51131a6137", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a793dd77-e0e2-4e9b-925b-4e3aa605c5dc", "40738840-7318-48f4-ad53-10c8d10351b5" },
                    { "c191496a-d737-4d87-ae5d-51b520aae1c9", "9c964337-0cf3-4e74-87ca-0e815e8d8d5e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a793dd77-e0e2-4e9b-925b-4e3aa605c5dc", "40738840-7318-48f4-ad53-10c8d10351b5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c191496a-d737-4d87-ae5d-51b520aae1c9", "9c964337-0cf3-4e74-87ca-0e815e8d8d5e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a793dd77-e0e2-4e9b-925b-4e3aa605c5dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c191496a-d737-4d87-ae5d-51b520aae1c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40738840-7318-48f4-ad53-10c8d10351b5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c964337-0cf3-4e74-87ca-0e815e8d8d5e");
        }
    }
}
