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
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<string>(nullable: true),
                    LentTo = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.ApplicationId);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title" },
                values: new object[] { 1, "Comedy", "Ben Stiller", "yes", "Kat", "so funny", "PG13", "Zoolander" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title" },
                values: new object[] { 2, "Drama/Adventure", "Mitch Davis", "no", "church", "inspirational", "PG", "The Other Side of Heaven" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "LentTo", "Note", "Rating", "Title" },
                values: new object[] { 3, "Romance/Comedy", "Anne Fletcher", "yes", "Katherine", "My favorite movie", "PG13", "The Proposal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
