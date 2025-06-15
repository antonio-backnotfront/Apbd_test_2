using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apbd_test_2.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDoubleToLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ExecutionTime",
                table: "Record",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ExecutionTime",
                table: "Record",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
