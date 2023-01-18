using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YienExpressAPI.Migrations
{
    /// <inheritdoc />
    public partial class fifteenth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cPassword",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cPassword",
                table: "users");
        }
    }
}
