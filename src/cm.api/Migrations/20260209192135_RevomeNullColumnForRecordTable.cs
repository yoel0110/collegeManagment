using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.api.Migrations
{
    /// <inheritdoc />
    public partial class RevomeNullColumnForRecordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AcademicRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AcademicRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
