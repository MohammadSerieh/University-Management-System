using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universities.Migrations
{
    /// <inheritdoc />
    public partial class vcorrectdatesnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityApplicationReserve",
                columns: table => new
                {
                    Appno = table.Column<decimal>(type: "numeric(10,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationCategory = table.Column<bool>(type: "bit", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StudentNameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ApplicationID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UniID = table.Column<int>(type: "int", nullable: true),
                    UniNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UniCollege = table.Column<int>(type: "int", nullable: true),
                    UniMajor = table.Column<int>(type: "int", nullable: true),
                    SemesterRate = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    CommulativeRate = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HighSchoolGrade = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    HighSchoolGraduate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UniGrantID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UniGrantDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UniGrantRateLimit = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    nationalityCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityApplicationReserve", x => x.Appno);
                    table.ForeignKey(
                        name: "FK_UniversityApplicationReserve_CommonZakat_MinorLookUpTable_UniCollege",
                        column: x => x.UniCollege,
                        principalTable: "CommonZakat_MinorLookUpTable",
                        principalColumn: "minorid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniversityApplicationReserve_CommonZakat_MinorLookUpTable_UniID",
                        column: x => x.UniID,
                        principalTable: "CommonZakat_MinorLookUpTable",
                        principalColumn: "minorid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniversityApplicationReserve_CommonZakat_MinorLookUpTable_UniMajor",
                        column: x => x.UniMajor,
                        principalTable: "CommonZakat_MinorLookUpTable",
                        principalColumn: "minorid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniversityApplicationReserve_CommonZakat_MinorLookUpTable_nationalityCategory",
                        column: x => x.nationalityCategory,
                        principalTable: "CommonZakat_MinorLookUpTable",
                        principalColumn: "minorid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniAppCoursesReserve",
                columns: table => new
                {
                    UniAppCoursesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appno = table.Column<decimal>(type: "numeric(10,0)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    CourseCenterID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CourseLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CourseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseAtt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniAppCoursesReserve", x => x.UniAppCoursesID);
                    table.ForeignKey(
                        name: "FK_UniAppCoursesReserve_CommonZakat_MinorLookUpTable_CourseID",
                        column: x => x.CourseID,
                        principalTable: "CommonZakat_MinorLookUpTable",
                        principalColumn: "minorid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniAppCoursesReserve_UniversityApplicationReserve_Appno",
                        column: x => x.Appno,
                        principalTable: "UniversityApplicationReserve",
                        principalColumn: "Appno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniAppCoursesReserve_Appno",
                table: "UniAppCoursesReserve",
                column: "Appno");

            migrationBuilder.CreateIndex(
                name: "IX_UniAppCoursesReserve_CourseID",
                table: "UniAppCoursesReserve",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityApplicationReserve_nationalityCategory",
                table: "UniversityApplicationReserve",
                column: "nationalityCategory");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityApplicationReserve_UniCollege",
                table: "UniversityApplicationReserve",
                column: "UniCollege");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityApplicationReserve_UniID",
                table: "UniversityApplicationReserve",
                column: "UniID");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityApplicationReserve_UniMajor",
                table: "UniversityApplicationReserve",
                column: "UniMajor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniAppCoursesReserve");

            migrationBuilder.DropTable(
                name: "UniversityApplicationReserve");
        }
    }
}
