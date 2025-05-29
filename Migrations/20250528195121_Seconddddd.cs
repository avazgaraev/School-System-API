using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystemForSchool.Migrations
{
    /// <inheritdoc />
    public partial class Seconddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lessons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Lessons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
