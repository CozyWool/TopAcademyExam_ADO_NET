using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympiadWpfApp.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixedOlympiad_ParticipantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Olympiad_Participant_pkey",
                table: "Olympiad_Participant");

            migrationBuilder.AddPrimaryKey(
                name: "Olympiad_Participant_pkey",
                table: "Olympiad_Participant",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Olympiad_Participant_participant_id",
                table: "Olympiad_Participant",
                column: "participant_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Olympiad_Participant_pkey",
                table: "Olympiad_Participant");

            migrationBuilder.DropIndex(
                name: "IX_Olympiad_Participant_participant_id",
                table: "Olympiad_Participant");

            migrationBuilder.AddPrimaryKey(
                name: "Olympiad_Participant_pkey",
                table: "Olympiad_Participant",
                column: "participant_id");
        }
    }
}
