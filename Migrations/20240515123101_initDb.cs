using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TaftaCRM.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    permissions = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_login = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email_verified = table.Column<bool>(type: "boolean", nullable: false),
                    failed_login_attempts = table.Column<int>(type: "integer", nullable: false),
                    security_stamp = table.Column<string>(type: "text", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    phone_number_verified = table.Column<bool>(type: "boolean", nullable: false),
                    ClientRoleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_accounts_client_roles_ClientRoleId",
                        column: x => x.ClientRoleId,
                        principalTable: "client_roles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "client_roles",
                columns: new[] { "Id", "permissions", "role_name" },
                values: new object[] { 1, 15, "Admin" });

            migrationBuilder.InsertData(
                table: "user_accounts",
                columns: new[] { "Id", "ClientRoleId", "user_name", "email_verified", "failed_login_attempts", "last_login", "password", "phone_number", "phone_number_verified", "security_stamp", "two_factor_enabled", "created", "expires", "role", "status" },
                values: new object[] { 1, 1, "admin@taftacrm.com", true, 0, null, "9mssKi>£4zpx?TY]@_i1.Wf8lFA9;", null, false, "fc0c7d56-a791-4cba-bc13-9b5782bd6d36", false, new DateTime(2024, 5, 15, 12, 31, 1, 249, DateTimeKind.Utc).AddTicks(6030), null, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_user_accounts_ClientRoleId",
                table: "user_accounts",
                column: "ClientRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_accounts");

            migrationBuilder.DropTable(
                name: "client_roles");
        }
    }
}
