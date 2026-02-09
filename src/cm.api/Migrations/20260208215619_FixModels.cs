using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.api.Migrations
{
    /// <inheritdoc />
    public partial class FixModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicRecords_Students_StudentID",
                table: "AcademicRecords");

            migrationBuilder.DropIndex(
                name: "IX_AcademicRecords_StudentID",
                table: "AcademicRecords");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "AcademicRecords");

            migrationBuilder.AddColumn<int>(
                name: "AcademicRecordRecordID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Average",
                table: "AcademicRecords",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<float>(
                name: "Average",
                table: "AcademicRecords",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "AcademicRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicRecords_StudentID",
                table: "AcademicRecords",
                column: "StudentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicRecords_Students_StudentID",
                table: "AcademicRecords",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
