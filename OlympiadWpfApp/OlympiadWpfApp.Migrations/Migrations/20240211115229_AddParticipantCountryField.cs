using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympiadWpfApp.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddParticipantCountryField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Participant",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country",
                table: "Participant");
        }
    }
}
