using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_Data.Migrations
{
    /// <inheritdoc />
    public partial class columnadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefID",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefID",
                table: "Category");
        }
    }
}
