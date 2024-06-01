using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumAndDrive.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTravelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_travel_address_ArrivalAddressId",
                table: "travel");

            migrationBuilder.DropForeignKey(
                name: "FK_travel_address_DepartureAddressId",
                table: "travel");

            migrationBuilder.RenameColumn(
                name: "DepartureAddressId",
                table: "travel",
                newName: "SchoolAddressId");

            migrationBuilder.RenameColumn(
                name: "ArrivalAddressId",
                table: "travel",
                newName: "PersonnalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_travel_DepartureAddressId",
                table: "travel",
                newName: "IX_travel_SchoolAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_travel_ArrivalAddressId",
                table: "travel",
                newName: "IX_travel_PersonnalAddressId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f916f6c6-b6b2-4da9-93e8-ae25bb7e1aba", "AQAAAAIAAYagAAAAEGGJlciwCJfOlJT3IE/O2bHUmNbNja8j9Cyx8LwqyKPv0HPl6odpB3Gi5k7MJhS7Cg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_travel_address_PersonnalAddressId",
                table: "travel",
                column: "PersonnalAddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_travel_address_SchoolAddressId",
                table: "travel",
                column: "SchoolAddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_travel_address_PersonnalAddressId",
                table: "travel");

            migrationBuilder.DropForeignKey(
                name: "FK_travel_address_SchoolAddressId",
                table: "travel");

            migrationBuilder.RenameColumn(
                name: "SchoolAddressId",
                table: "travel",
                newName: "DepartureAddressId");

            migrationBuilder.RenameColumn(
                name: "PersonnalAddressId",
                table: "travel",
                newName: "ArrivalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_travel_SchoolAddressId",
                table: "travel",
                newName: "IX_travel_DepartureAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_travel_PersonnalAddressId",
                table: "travel",
                newName: "IX_travel_ArrivalAddressId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c96a26b-43c0-4dee-ae76-94ce4edd1df3", "AQAAAAIAAYagAAAAEDbV20xvlIli2oaYzODRf5lgqZY+Ed4vGA18Bwc579/psf0FRWxZQQSyXmLgwF8p+Q==" });

            migrationBuilder.AddForeignKey(
                name: "FK_travel_address_ArrivalAddressId",
                table: "travel",
                column: "ArrivalAddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_travel_address_DepartureAddressId",
                table: "travel",
                column: "DepartureAddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
