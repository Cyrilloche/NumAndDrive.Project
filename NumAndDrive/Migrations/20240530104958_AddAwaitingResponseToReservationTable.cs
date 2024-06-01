using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumAndDrive.Migrations
{
    /// <inheritdoc />
    public partial class AddAwaitingResponseToReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AwaitingResponse",
                table: "reservation",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "463f9f11-d9e2-4cef-a665-42374f923de9", "AQAAAAIAAYagAAAAEMYstjQqiBqM1moQJ2vLVOPpQk9YMCSVTE0M3AGhpMLPt950MLqPmsJAHhyx9qdawg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwaitingResponse",
                table: "reservation");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37ba0148-0c11-4208-86a1-cfc75f35ec4b", "AQAAAAIAAYagAAAAEN0OH/LQz1warsv4q4mrvWiE5EqAsQaHpxYWlSMOuSaZFzVNUPsdLD6hRne5D/+hXA==" });
        }
    }
}
