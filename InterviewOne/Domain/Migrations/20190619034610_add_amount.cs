using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class add_amount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "OrderDetail");
        }
    }
}
