using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cm.api.Migrations
{
    /// <inheritdoc />
    public partial class FixRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CatalogCourseSubjectId",
                table: "Professors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professors_CatalogCourseSubjectId",
                table: "Professors",
                column: "CatalogCourseSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_CatalogCourses_CatalogCourseSubjectId",
                table: "Professors",
                column: "CatalogCourseSubjectId",
                principalTable: "CatalogCourses",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professors_CatalogCourses_CatalogCourseSubjectId",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_Professors_CatalogCourseSubjectId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "CatalogCourseSubjectId",
                table: "Professors");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorID",
                table: "CatalogCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogCourses_ProfessorID",
                table: "CatalogCourses",
                column: "ProfessorID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogCourses_Professors_ProfessorID",
                table: "CatalogCourses",
                column: "ProfessorID",
                principalTable: "Professors",
                principalColumn: "ProfessorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
