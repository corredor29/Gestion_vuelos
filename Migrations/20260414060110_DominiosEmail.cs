using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_vuelos.Migrations
{
    /// <inheritdoc />
    public partial class DominiosEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "Country",
                type: "char(64)",
                maxLength: 64,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(64)",
                oldMaxLength: 64)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Country_id",
                table: "Cities",
                type: "char(64)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(64)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Country_Origen_Id",
                table: "airlines",
                type: "char(64)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(64)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "email_domains",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(64)", maxLength: 64, nullable: false, collation: "ascii_general_ci"),
                    Dominio = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_domains", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email_domains");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Country",
                type: "char(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(64)",
                oldMaxLength: 64)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Country_id",
                table: "Cities",
                type: "char(64)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(64)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Country_Origen_Id",
                table: "airlines",
                type: "char(64)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(64)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
