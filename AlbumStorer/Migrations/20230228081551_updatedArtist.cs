using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbumStorer.Migrations
{
    /// <inheritdoc />
    public partial class updatedArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Artists",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Artists");
        }
    }
}
