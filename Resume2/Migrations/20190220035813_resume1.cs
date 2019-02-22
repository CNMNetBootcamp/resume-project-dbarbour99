using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Resume2.Migrations
{
    public partial class resume1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    ResumeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstLast = table.Column<string>(maxLength: 30, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.ResumeID);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    ResumeID = table.Column<int>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationID);
                    table.ForeignKey(
                        name: "FK_Education_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<string>(nullable: true),
                    CompanyDesc = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ResumeID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceID);
                    table.ForeignKey(
                        name: "FK_Experience_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<string>(nullable: true),
                    FirstLast = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ResumeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.ReferenceID);
                    table.ForeignKey(
                        name: "FK_Reference_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duty",
                columns: table => new
                {
                    DutyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ExperienceID = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duty", x => x.DutyID);
                    table.ForeignKey(
                        name: "FK_Duty_Experience_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experience",
                        principalColumn: "ExperienceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duty_ExperienceID",
                table: "Duty",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Education_ResumeID",
                table: "Education",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ResumeID",
                table: "Experience",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_ResumeID",
                table: "Reference",
                column: "ResumeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duty");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Resume");
        }
    }
}
