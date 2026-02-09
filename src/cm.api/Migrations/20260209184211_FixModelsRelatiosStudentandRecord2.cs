using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.api.Migrations
{
    /// <inheritdoc />
    public partial class FixModelsRelatiosStudentandRecord2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicRecords_RecordId",
                table: "Students");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicRecords_RecordId",
                table: "Students",
                column: "RecordId",
                principalTable: "AcademicRecords",
                principalColumn: "RecordID");
        }
    }
}
