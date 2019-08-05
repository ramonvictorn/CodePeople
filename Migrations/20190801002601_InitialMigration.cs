using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodePeople.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<int>(nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_Cpf_Email",
                table: "Peoples",
                columns: new[] { "Cpf", "Email" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples");
        }
    }
}
