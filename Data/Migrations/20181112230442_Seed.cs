using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationTemplateManager.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Body", "CreatedDate", "IsInactive", "Name" },
                values: new object[] { 1, "HTML<>", new DateTime(2018, 11, 12, 23, 4, 42, 208, DateTimeKind.Local), false, "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
