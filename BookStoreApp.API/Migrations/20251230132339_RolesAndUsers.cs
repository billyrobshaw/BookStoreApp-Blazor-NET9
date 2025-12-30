using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class RolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Authors__3214EC07CD37F485",
                table: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8343074e-8623-4ela-b0c1-84fb8678c8f3", null, "User", "USER" },
                    { "c7ac6cfe-1f10-4baf-b604-cde350db9554", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30a24107-d279-4e37-96fd-01af5b38cb27", 0, "060e09e1-5889-4f04-9185-6bff47794643", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEBUCiZRyC/7diEKArJPnh2AlziRjqqMVNoNGKTYyvkGuSHiJOf3ftpbOaMyIcqh3YA==", null, false, "edbc2bc3-92b2-438a-a8a8-5718d5fafb84", false, "user@bookstore.com" },
                    { "8e448afa-f008-446e-a52f-13c449803c2e", 0, "e2d53d18-ff4e-40b5-8daa-383278f83c04", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEPgxH7TUGDvEkmaBqxVmax3GW1gFFk3sxzsHcAdPxgh9zYNLk9PQ592ck8mRAeJj5g==", null, false, "6ecc6810-7fd1-4a0e-9c41-e8ad893b3080", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8343074e-8623-4ela-b0c1-84fb8678c8f3", "30a24107-d279-4e37-96fd-01af5b38cb27" },
                    { "c7ac6cfe-1f10-4baf-b604-cde350db9554", "8e448afa-f008-446e-a52f-13c449803c2e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8343074e-8623-4ela-b0c1-84fb8678c8f3", "30a24107-d279-4e37-96fd-01af5b38cb27" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7ac6cfe-1f10-4baf-b604-cde350db9554", "8e448afa-f008-446e-a52f-13c449803c2e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4ela-b0c1-84fb8678c8f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Authors__3214EC07CD37F485",
                table: "Authors",
                column: "Id");
        }
    }
}
