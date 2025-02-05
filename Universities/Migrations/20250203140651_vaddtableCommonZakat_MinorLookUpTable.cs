using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universities.Migrations
{
    /// <inheritdoc />
    public partial class vaddtableCommonZakat_MinorLookUpTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonZakat_MinorLookUpTable",
                columns: table => new
                {
                    minorid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    majorid = table.Column<int>(type: "int", nullable: false),
                    descs = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonZakat_MinorLookUpTable", x => x.minorid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonZakat_MinorLookUpTable");
        }
    }
}
