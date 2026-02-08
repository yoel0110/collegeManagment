using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.api.Migrations
{
    /// <inheritdoc />
    public partial class FixModelsStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicRecords_AcademicRecordRecordID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AcademicRecordRecordID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AcademicRecordRecordID",
                table: "Students");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicRecords_RecordId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RecordId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AcademicRecordRecordID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicRecordRecordID",
                table: "Students",
                column: "AcademicRecordRecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicRecords_AcademicRecordRecordID",
                table: "Students",
                column: "AcademicRecordRecordID",
                principalTable: "AcademicRecords",
                principalColumn: "RecordID");
        }
    }
}
