using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveModelsPolicyTodelrStudentandRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_RecordId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AcademicRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_RecordId",
                table: "Students",
                column: "RecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_RecordId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AcademicRecords");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RecordId",
                table: "Students",
                column: "RecordId",
                unique: true);
        }
    }
}
