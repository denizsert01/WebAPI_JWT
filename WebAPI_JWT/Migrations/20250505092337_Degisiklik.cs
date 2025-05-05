using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_JWT.Migrations
{
    /// <inheritdoc />
    public partial class Degisiklik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "129bcc93-d2d3-4963-95e1-6af190521fd0", "AQAAAAIAAYagAAAAELESPvYwAYQJuE+Gl+fGmWwFc1i9mFxcxA4bCElCAbMGhYLNXoqOwiEZAHZLFnAS9g==", "4f3f9d97-9dad-4460-b7be-6e8d57bb5a44" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "6d535902-5be7-475d-85c1-aa791a2be5c6", "cevdo@deneme.com", false, false, null, "CEVDO@DENEME.COM", "CEVDO", "AQAAAAIAAYagAAAAEA7K0tGGiufSS64qlTAQYPQ3d5Gs6MorOYqq2jrPywzo3jmfmSi7vYxuudwaO27AuA==", null, false, "6a2bd23c-99d9-4f5d-b8fa-a7bdd07afb81", false, "cevdo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69e765fd-d2c4-4c37-a72f-6eeae6af782f", "AQAAAAIAAYagAAAAEMZNATAFiXXjf/r69aJLwOMZpRlmCcdGYfopRVjXi0rFsqLItCu0Lprf50i1jbtVPA==", "4fd9cc91-8ed0-4057-80ca-105f8650f06b" });
        }
    }
}
