using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaNET_DiegoFelipeSalamanca.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomTypeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_occupancy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "price_per_night",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "max_occupancy",
                table: "RoomTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "price_per_night",
                table: "RoomTypes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_occupancy",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "price_per_night",
                table: "RoomTypes");

            migrationBuilder.AddColumn<int>(
                name: "max_occupancy",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "price_per_night",
                table: "Rooms",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
