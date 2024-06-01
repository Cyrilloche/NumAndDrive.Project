using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumAndDrive.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTravelTableAddBoolToReturnTravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsAReturnTravel",
                table: "travel",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37ba0148-0c11-4208-86a1-cfc75f35ec4b", "AQAAAAIAAYagAAAAEN0OH/LQz1warsv4q4mrvWiE5EqAsQaHpxYWlSMOuSaZFzVNUPsdLD6hRne5D/+hXA==" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_travel_address_ArrivalAddressId",
                table: "travel");

            migrationBuilder.DropForeignKey(
                name: "FK_travel_address_DepartureAddressId",
                table: "travel");

            migrationBuilder.DropColumn(
                name: "IsAReturnTravel",
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
                values: new object[] { "6b0bd20d-4f04-4d1e-821f-bb6618a07277", "AQAAAAIAAYagAAAAEA+8z/L0wUMqi+sM2YpGxTHc4LlsI4yap+wUHM7aJ8Trhj40YnreMGuuiu6Dnb+F6w==" });

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
    }
}
