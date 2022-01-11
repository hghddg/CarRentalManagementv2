using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalManagement.Server.Migrations
{
    public partial class addnulltoDateIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIn",
                table: "Bookings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "51778758-dc41-4193-a903-8636bea6d8fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "7677e199-95e3-4889-867b-c8f496b6ab2d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0aa80d68-da02-4628-a909-2f5595e2e76b", "AQAAAAEAACcQAAAAEB4pN20+GI26DG7jqHtHdsbgUR0feYnxCWxKY+0l9jp1O1i4Owr8M2RX1LcrQOVVzw==", "2a04558d-fba0-414b-9cd9-48ea1c1e5cba" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 566, DateTimeKind.Local).AddTicks(368), new DateTime(2021, 9, 29, 2, 9, 33, 566, DateTimeKind.Local).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 566, DateTimeKind.Local).AddTicks(8137), new DateTime(2021, 9, 29, 2, 9, 33, 566, DateTimeKind.Local).AddTicks(8143) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 567, DateTimeKind.Local).AddTicks(9923), new DateTime(2021, 9, 29, 2, 9, 33, 567, DateTimeKind.Local).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 567, DateTimeKind.Local).AddTicks(9938), new DateTime(2021, 9, 29, 2, 9, 33, 567, DateTimeKind.Local).AddTicks(9939) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3498), new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3509), new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3512), new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3513) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3514), new DateTime(2021, 9, 29, 2, 9, 33, 568, DateTimeKind.Local).AddTicks(3515) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIn",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "2cfe36c8-2a6c-48d6-a29a-92567742cbe2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "096abc4d-61ba-4c43-8b21-89615a5c260c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b59bb5a1-6509-4f73-8d41-05afa51adfdd", "AQAAAAEAACcQAAAAEAZ5c+Ll7hlijYk5xNRc5wSdWbi4P7hwnpljrSYddTxM27JY1+B/Dp5ArhycuiTULw==", "12467d9b-eafd-4799-970f-e0c34f2fa3a0" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 612, DateTimeKind.Local).AddTicks(6320), new DateTime(2021, 9, 23, 17, 15, 52, 613, DateTimeKind.Local).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 613, DateTimeKind.Local).AddTicks(5058), new DateTime(2021, 9, 23, 17, 15, 52, 613, DateTimeKind.Local).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(5827), new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(5841), new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9704), new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9717), new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9718) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9720), new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9721) });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9757), new DateTime(2021, 9, 23, 17, 15, 52, 614, DateTimeKind.Local).AddTicks(9758) });
        }
    }
}
