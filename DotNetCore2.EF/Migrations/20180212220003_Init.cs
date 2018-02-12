using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DotNetCore2.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(2500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(2500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityProfileClaims",
                columns: table => new
                {
                    SecurityProfileId = table.Column<Guid>(nullable: false),
                    ClaimId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityProfileClaims", x => new { x.SecurityProfileId, x.ClaimId });
                    table.ForeignKey(
                        name: "FK_SecurityProfileClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecurityProfileClaims_SecurityProfiles_SecurityProfileId",
                        column: x => x.SecurityProfileId,
                        principalTable: "SecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(type: "nvarchar(2500)", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(type: "nvarchar(2500)", nullable: true),
                    SecurityProfileId = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(type: "nvarchar(2500)", nullable: true),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_SecurityProfiles_SecurityProfileId",
                        column: x => x.SecurityProfileId,
                        principalTable: "SecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityProfileClaims_ClaimId",
                table: "SecurityProfileClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SecurityProfileId",
                table: "Users",
                column: "SecurityProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityProfileClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "SecurityProfiles");
        }
    }
}
