using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnosAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdadCliente = table.Column<int>(type: "int", nullable: false),
                    SexoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoIdentificacionCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoIdentificacionCliente = table.Column<int>(type: "int", nullable: false),
                    DepartamentoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarrioCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicioCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoServicioId = table.Column<int>(type: "int", nullable: false),
                    NoTurno = table.Column<int>(type: "int", nullable: false),
                    TipoTurno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoTruno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicioCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioCliente_TipoServicio_TipoServicioId",
                        column: x => x.TipoServicioId,
                        principalTable: "TipoServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCliente_ClienteId",
                table: "ServicioCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioCliente_TipoServicioId",
                table: "ServicioCliente",
                column: "TipoServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioCliente");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoServicio");
        }
    }
}
