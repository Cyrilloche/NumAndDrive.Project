using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumAndDrive.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<sbyte>(
                name: "CountCreatedTravel",
                table: "User",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CountCreatedTravel", "PasswordHash" },
                values: new object[] { "6b0bd20d-4f04-4d1e-821f-bb6618a07277", (sbyte)0, "AQAAAAIAAYagAAAAEA+8z/L0wUMqi+sM2YpGxTHc4LlsI4yap+wUHM7aJ8Trhj40YnreMGuuiu6Dnb+F6w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountCreatedTravel",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f916f6c6-b6b2-4da9-93e8-ae25bb7e1aba", "AQAAAAIAAYagAAAAEGGJlciwCJfOlJT3IE/O2bHUmNbNja8j9Cyx8LwqyKPv0HPl6odpB3Gi5k7MJhS7Cg==" });
        }
    }
}
