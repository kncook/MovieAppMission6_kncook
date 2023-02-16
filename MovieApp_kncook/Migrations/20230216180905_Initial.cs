using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp_kncook.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: true),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.ApplicationId);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title", "Year" },
                values: new object[] { 1, "Comedy", "Ben Stiller", true, "Luke", "so funny", "PG13", "Zoolander", 2001 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title", "Year" },
                values: new object[] { 2, "Drama/Adventure", "Mitch Davis", false, "church", "inspirational", "PG", "The Other Side of Heaven", 2001 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title", "Year" },
                values: new object[] { 3, "Romance/Comedy", "Anne Fletcher", true, "Katherine", "My favorite movie", "PG13", "The Proposal", 2009 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
