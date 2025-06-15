using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apbd_test_2.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNameFieldFromRecordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Record");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Record",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Record",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "record 1");

            migrationBuilder.UpdateData(
                table: "Record",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "record 2");
        }
    }
}
