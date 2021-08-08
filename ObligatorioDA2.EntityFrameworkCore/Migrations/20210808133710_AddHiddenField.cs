using Microsoft.EntityFrameworkCore.Migrations;

namespace ObligatorioDA2.EntityFrameworkCore.Migrations
{
    public partial class AddHiddenField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HiddenField",
                table: "WeatherForecasts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiddenField",
                table: "WeatherForecasts");
        }
    }
}
