using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbumStorer.Migrations
{
    /// <inheritdoc />
    public partial class updatedSongModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Albums",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Albums");
        }
    }
}
