using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTiendita.Migrations
{
    public partial class Producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proovedor_Productos_ProductoId",
                table: "Proovedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Proovedor_Proovedor_proovedorId",
                table: "Proovedor");

            migrationBuilder.DropIndex(
                name: "IX_Proovedor_proovedorId",
                table: "Proovedor");

            migrationBuilder.DropColumn(
                name: "proovedorId",
                table: "Proovedor");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Proovedor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proovedor_Productos_ProductoId",
                table: "Proovedor",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proovedor_Productos_ProductoId",
                table: "Proovedor");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Proovedor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "proovedorId",
                table: "Proovedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Proovedor_proovedorId",
                table: "Proovedor",
                column: "proovedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proovedor_Productos_ProductoId",
                table: "Proovedor",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proovedor_Proovedor_proovedorId",
                table: "Proovedor",
                column: "proovedorId",
                principalTable: "Proovedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
