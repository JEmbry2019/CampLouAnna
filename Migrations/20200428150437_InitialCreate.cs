using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampLouAnna.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    EnrollmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Gym = table.Column<int>(nullable: false),
                    RecRoom = table.Column<int>(nullable: false),
                    Computer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Breakfast = table.Column<int>(nullable: false),
                    Lunch = table.Column<int>(nullable: false),
                    Snack = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CamperID = table.Column<Guid>(nullable: false),
                    MealID = table.Column<Guid>(nullable: false),
                    GameID = table.Column<Guid>(nullable: false),
                    Grade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Campers_CamperID",
                        column: x => x.CamperID,
                        principalTable: "Campers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Meals_MealID",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CamperID",
                table: "Enrollments",
                column: "CamperID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GameID",
                table: "Enrollments",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_MealID",
                table: "Enrollments",
                column: "MealID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
