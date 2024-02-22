using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addedadditionalproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterPrefix",
                table: "Event",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterPrefix",
                table: "Event");
        }
    }
}
