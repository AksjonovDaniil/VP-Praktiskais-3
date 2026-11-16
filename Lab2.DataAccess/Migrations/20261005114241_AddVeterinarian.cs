using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddVeterinarian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeterinarianId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Veterinarians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarians", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_VeterinarianId",
                table: "Animals",
                column: "VeterinarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Veterinarians_VeterinarianId",
                table: "Animals",
                column: "VeterinarianId",
                principalTable: "Veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Veterinarians_VeterinarianId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "Veterinarians");

            migrationBuilder.DropIndex(
                name: "IX_Animals_VeterinarianId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "VeterinarianId",
                table: "Animals");
        }
    }
}
