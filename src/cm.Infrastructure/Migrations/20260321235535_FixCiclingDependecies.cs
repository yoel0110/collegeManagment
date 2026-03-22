using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCiclingDependecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicRecords_Students_StudentId",
                table: "AcademicRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogCourses_Enrollments_EnrollmentID",
                table: "CatalogCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogCourses_Professors_ProfesorId",
                table: "CatalogCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_AcademicRecords_RecordID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_RecordID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_CatalogCourses_EnrollmentID",
                table: "CatalogCourses");

            migrationBuilder.DropIndex(
                name: "IX_CatalogCourses_ProfesorId",
                table: "CatalogCourses");

            migrationBuilder.DropIndex(
                name: "IX_AcademicRecords_StudentId",
                table: "AcademicRecords");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorID",
                table: "CatalogCourses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCourses_ProfessorID",
                table: "CatalogCourses",
                column: "ProfessorID");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogCourses_Professors_ProfessorID",
                table: "CatalogCourses",
                column: "ProfessorID",
                principalTable: "Professors",
                principalColumn: "ProfessorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogCourses_Professors_ProfessorID",
                table: "CatalogCourses");

            migrationBuilder.DropIndex(
                name: "IX_CatalogCourses_ProfessorID",
                table: "CatalogCourses");

            migrationBuilder.DropColumn(
                name: "ProfessorID",
                table: "CatalogCourses");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_RecordID",
                table: "Enrollments",
                column: "RecordID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCourses_EnrollmentID",
                table: "CatalogCourses",
                column: "EnrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCourses_ProfesorId",
                table: "CatalogCourses",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicRecords_StudentId",
                table: "AcademicRecords",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicRecords_Students_StudentId",
                table: "AcademicRecords",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogCourses_Enrollments_EnrollmentID",
                table: "CatalogCourses",
                column: "EnrollmentID",
                principalTable: "Enrollments",
                principalColumn: "EnrollMentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogCourses_Professors_ProfesorId",
                table: "CatalogCourses",
                column: "ProfesorId",
                principalTable: "Professors",
                principalColumn: "ProfessorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_AcademicRecords_RecordID",
                table: "Enrollments",
                column: "RecordID",
                principalTable: "AcademicRecords",
                principalColumn: "RecordID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
