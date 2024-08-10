using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_departament_DepartamentId",
                table: "city");

            migrationBuilder.DropTable(
                name: "departament");

            migrationBuilder.DropColumn(
                name: "Created_at",
                table: "country");

            migrationBuilder.DropColumn(
                name: "Deleted_at",
                table: "country");

            migrationBuilder.DropColumn(
                name: "State",
                table: "country");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "country");

            migrationBuilder.DropColumn(
                name: "Created_at",
                table: "city");

            migrationBuilder.DropColumn(
                name: "Deleted_at",
                table: "city");

            migrationBuilder.DropColumn(
                name: "State",
                table: "city");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "country",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "city",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "city",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_city_DepartamentId",
                table: "city",
                newName: "IX_city_DepartmentId");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_department_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_department_CountryId",
                table: "department",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_city_department_DepartmentId",
                table: "city",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_department_DepartmentId",
                table: "city");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "country",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "city",
                newName: "DepartamentId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "city",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_city_DepartmentId",
                table: "city",
                newName: "IX_city_DepartamentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_at",
                table: "country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_at",
                table: "country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "country",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_at",
                table: "city",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_at",
                table: "city",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "city",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "city",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "departament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departament_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departament_CountryId",
                table: "departament",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_city_departament_DepartamentId",
                table: "city",
                column: "DepartamentId",
                principalTable: "departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
