using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.api.Migrations
{
    /// <inheritdoc />
    public partial class FixModelsRelatiosStudentandRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicRecords_RecordId",
                table: "Students");

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
                column: "RecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicRecords_RecordId",
                table: "Students",
                column: "RecordId",
                principalTable: "AcademicRecords",
                principalColumn: "RecordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicRecords_RecordId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RecordId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AcademicRecords");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RecordId",
                table: "Students",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicRecords_RecordId",
                table: "Students",
                column: "RecordId",
                principalTable: "AcademicRecords",
                principalColumn: "RecordID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
