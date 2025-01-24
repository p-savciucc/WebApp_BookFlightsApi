using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_BookFlightsApi.Migrations
{
    public partial class f9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTrip",
                table: "Tickets",
                newName: "trip2Id");

            migrationBuilder.AddColumn<long>(
                name: "IdTripDeparture",
                table: "Tickets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdTripReturn",
                table: "Tickets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_trip2Id",
                table: "Tickets",
                column: "trip2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Trips_trip2Id",
                table: "Tickets",
                column: "trip2Id",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Trips_trip2Id",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_trip2Id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IdTripDeparture",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IdTripReturn",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "trip2Id",
                table: "Tickets",
                newName: "IdTrip");
        }
    }
}
