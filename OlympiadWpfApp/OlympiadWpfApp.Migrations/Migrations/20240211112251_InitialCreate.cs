using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OlympiadWpfApp.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Olympiad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<DateOnly>(type: "date", nullable: false),
                    host_country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_winter = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Olympiad_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    photo = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Participant_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sport_Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Sport_Type_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Olympiad_Participant",
                columns: table => new
                {
                    participant_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    olympiad_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Olympiad_Participant_pkey", x => x.participant_id);
                    table.ForeignKey(
                        name: "olympiad_fk",
                        column: x => x.olympiad_id,
                        principalTable: "Olympiad",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "participant_fk",
                        column: x => x.participant_id,
                        principalTable: "Participant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Sport_Type_Olympiad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sport_type_id = table.Column<int>(type: "integer", nullable: false),
                    olympiad_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Sport_Type_Olympiad_pkey", x => x.id);
                    table.ForeignKey(
                        name: "olymp_FK",
                        column: x => x.olympiad_id,
                        principalTable: "Olympiad",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "sport_type_FK",
                        column: x => x.sport_type_id,
                        principalTable: "Sport_Type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Sport_Type_Participant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sport_type_id = table.Column<int>(type: "integer", nullable: false),
                    participant_id = table.Column<int>(type: "integer", nullable: false),
                    gold_medals = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    silver_medals = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    bronze_medals = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Sport_Type_Participant_pkey", x => x.id);
                    table.ForeignKey(
                        name: "participant_id",
                        column: x => x.participant_id,
                        principalTable: "Participant",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "sport_type_fk",
                        column: x => x.sport_type_id,
                        principalTable: "Sport_Type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Olympiad_Participant_olympiad_id",
                table: "Olympiad_Participant",
                column: "olympiad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Type_Olympiad_olympiad_id",
                table: "Sport_Type_Olympiad",
                column: "olympiad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Type_Olympiad_sport_type_id",
                table: "Sport_Type_Olympiad",
                column: "sport_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Type_Participant_participant_id",
                table: "Sport_Type_Participant",
                column: "participant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Type_Participant_sport_type_id",
                table: "Sport_Type_Participant",
                column: "sport_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Olympiad_Participant");

            migrationBuilder.DropTable(
                name: "Sport_Type_Olympiad");

            migrationBuilder.DropTable(
                name: "Sport_Type_Participant");

            migrationBuilder.DropTable(
                name: "Olympiad");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Sport_Type");
        }
    }
}
