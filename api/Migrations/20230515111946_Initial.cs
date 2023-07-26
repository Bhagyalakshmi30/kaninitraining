using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empname = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fullname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__AF2EBFA1717C2998", x => x.Empid);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Donorid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Gender = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Empassit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Donors__053133A05FCBB78A", x => x.Donorid);
                    table.ForeignKey(
                        name: "FK__Donors__Empassit__4222D4EF",
                        column: x => x.Empassit,
                        principalTable: "Employee",
                        principalColumn: "Empid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_Empassit",
                table: "Donors",
                column: "Empassit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
