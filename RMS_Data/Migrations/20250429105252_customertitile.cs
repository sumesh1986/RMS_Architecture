using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_Data.Migrations
{
    /// <inheritdoc />
    public partial class customertitile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTitle",
                columns: table => new
                {
                    SysId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTitle", x => x.SysId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTitle");
        }
    }
}
