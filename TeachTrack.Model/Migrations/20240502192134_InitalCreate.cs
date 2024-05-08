using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TeachTrack.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "sequence_subject",
                startValue: 11003L,
                incrementBy: 3);

            migrationBuilder.CreateSequence(
                name: "squence_student",
                startValue: 21000L,
                incrementBy: 2);

            migrationBuilder.CreateSequence(
                name: "studentsequence",
                startValue: 21000L,
                incrementBy: 2);

            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    careerid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    shortname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Career_pkey", x => x.careerid);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    degreeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    shortname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Degree_pkey", x => x.degreeid);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "integer", nullable: false),
                    subjectid = table.Column<int>(type: "integer", nullable: false),
                    scheduleid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    semesterid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    shortname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Semester_pkey", x => x.semesterid);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSchedule",
                columns: table => new
                {
                    scheduleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subjectid = table.Column<int>(type: "integer", nullable: false),
                    schedule = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SubjectSchedule_pkey", x => x.scheduleid);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('squence_student'::regclass)"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    score = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    degreeid = table.Column<int>(type: "integer", nullable: true),
                    careerid = table.Column<int>(type: "integer", nullable: true),
                    semesterid = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Student_pkey", x => x.studentid);
                    table.ForeignKey(
                        name: "fk_student1",
                        column: x => x.degreeid,
                        principalTable: "Degree",
                        principalColumn: "degreeid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_student2",
                        column: x => x.careerid,
                        principalTable: "Career",
                        principalColumn: "careerid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_student3",
                        column: x => x.semesterid,
                        principalTable: "Semester",
                        principalColumn: "semesterid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subjectid = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('sequence_subject'::regclass)"),
                    name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    shortname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    degreeid = table.Column<int>(type: "integer", nullable: true),
                    careerid = table.Column<int>(type: "integer", nullable: true),
                    semesterid = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Subject_pkey", x => x.subjectid);
                    table.ForeignKey(
                        name: "fk_subject1",
                        column: x => x.degreeid,
                        principalTable: "Degree",
                        principalColumn: "degreeid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_subject2",
                        column: x => x.careerid,
                        principalTable: "Career",
                        principalColumn: "careerid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_subject3",
                        column: x => x.semesterid,
                        principalTable: "Semester",
                        principalColumn: "semesterid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_careerid",
                table: "Student",
                column: "careerid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_degreeid",
                table: "Student",
                column: "degreeid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_semesterid",
                table: "Student",
                column: "semesterid");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_careerid",
                table: "Subject",
                column: "careerid");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_degreeid",
                table: "Subject",
                column: "degreeid");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_semesterid",
                table: "Subject",
                column: "semesterid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "SubjectSchedule");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropSequence(
                name: "sequence_subject");

            migrationBuilder.DropSequence(
                name: "squence_student");

            migrationBuilder.DropSequence(
                name: "studentsequence");
        }
    }
}
