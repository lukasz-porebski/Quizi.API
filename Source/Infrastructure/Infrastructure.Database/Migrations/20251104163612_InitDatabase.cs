using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "refreshtokens",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    hashedtoken = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    userid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    expiredat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refreshtokens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    hashedpassword = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    createdbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updatebyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    removedbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    removedat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    ownerid = table.Column<string>(type: "character varying(36)", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    questionscountinrunningquiz = table.Column<int>(type: "integer", nullable: false),
                    randomquestions = table.Column<bool>(type: "boolean", nullable: false),
                    randomanswers = table.Column<bool>(type: "boolean", nullable: false),
                    negativepoints = table.Column<bool>(type: "boolean", nullable: false),
                    copymode = table.Column<int>(type: "integer", nullable: false),
                    createdbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatebyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    removedbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    removedat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizzes", x => x.id);
                    table.ForeignKey(
                        name: "fk_quizzes_users_ownerid",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quizmultiplechoicequestions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizmultiplechoicequestions", x => new { x.id, x.no });
                    table.ForeignKey(
                        name: "fk_quizmultiplechoicequestions_quizzes_id",
                        column: x => x.id,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizopenquestions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    answer = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizopenquestions", x => new { x.id, x.no });
                    table.ForeignKey(
                        name: "fk_quizopenquestions_quizzes_id",
                        column: x => x.id,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizresults",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    quizid = table.Column<string>(type: "character varying(36)", nullable: false),
                    userid = table.Column<string>(type: "character varying(36)", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    quizrunningperiodstart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    quizrunningperiodend = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    maxduration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    negativepoints = table.Column<bool>(type: "boolean", nullable: false),
                    randomquestions = table.Column<bool>(type: "boolean", nullable: false),
                    randomanswers = table.Column<bool>(type: "boolean", nullable: false),
                    createdbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatebyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    removedbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    removedat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_quizresults_quizzes_quizid",
                        column: x => x.quizid,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_quizresults_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quizsinglechoicequestions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizsinglechoicequestions", x => new { x.id, x.no });
                    table.ForeignKey(
                        name: "fk_quizsinglechoicequestions_quizzes_id",
                        column: x => x.id,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sharedquizzes",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    quizid = table.Column<string>(type: "character varying(36)", nullable: false),
                    createdbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatebyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    updateat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    removedbyuserid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    removedat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sharedquizzes", x => x.id);
                    table.ForeignKey(
                        name: "fk_sharedquizzes_quizzes_quizid",
                        column: x => x.quizid,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quizmultiplechoicequestionanswers",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    subno = table.Column<int>(type: "integer", nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    iscorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizmultiplechoicequestionanswers", x => new { x.id, x.no, x.subno });
                    table.ForeignKey(
                        name: "fk_quizmultiplechoicequestionanswers_quizmultiplechoicequestio~",
                        columns: x => new { x.id, x.no },
                        principalTable: "quizmultiplechoicequestions",
                        principalColumns: new[] { "id", "no" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizresultmultiplechoicequestions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    scoredpoints = table.Column<float>(type: "real", nullable: false),
                    pointspossibletoget = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizresultmultiplechoicequestions", x => new { x.id, x.no });
                    table.ForeignKey(
                        name: "fk_quizresultmultiplechoicequestions_quizresults_id",
                        column: x => x.id,
                        principalTable: "quizresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizresultopenquestions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    correctanswer = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    givenanswer = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    scoredpoints = table.Column<float>(type: "real", nullable: false),
                    pointspossibletoget = table.Column<float>(type: "real", nullable: false),
                    iscorrect = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizresultopenquestions", x => new { x.id, x.no });
                    table.ForeignKey(
                        name: "fk_quizresultopenquestions_quizresults_id",
                        column: x => x.id,
                        principalTable: "quizresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizresultsinglechoicequestions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    scoredpoints = table.Column<float>(type: "real", nullable: false),
                    pointspossibletoget = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizresultsinglechoicequestions", x => new { x.id, x.no });
                    table.ForeignKey(
                        name: "fk_quizresultsinglechoicequestions_quizresults_id",
                        column: x => x.id,
                        principalTable: "quizresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizsinglechoicequestionanswers",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    subno = table.Column<int>(type: "integer", nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    iscorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizsinglechoicequestionanswers", x => new { x.id, x.no, x.subno });
                    table.ForeignKey(
                        name: "fk_quizsinglechoicequestionanswers_quizsinglechoicequestions_i~",
                        columns: x => new { x.id, x.no },
                        principalTable: "quizsinglechoicequestions",
                        principalColumns: new[] { "id", "no" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sharedquizusers",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    userid = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sharedquizusers", x => new { x.id, x.userid });
                    table.ForeignKey(
                        name: "fk_sharedquizusers_sharedquizzes_id",
                        column: x => x.id,
                        principalTable: "sharedquizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sharedquizusers_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quizresultmultiplechoicequestionanswers",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    subno = table.Column<int>(type: "integer", nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    iscorrect = table.Column<bool>(type: "boolean", nullable: false),
                    isselected = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizresultmultiplechoicequestionanswers", x => new { x.id, x.no, x.subno });
                    table.ForeignKey(
                        name: "fk_quizresultmultiplechoicequestionanswers_quizresultmultiplec~",
                        columns: x => new { x.id, x.no },
                        principalTable: "quizresultmultiplechoicequestions",
                        principalColumns: new[] { "id", "no" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizresultsinglechoicequestionanswers",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    subno = table.Column<int>(type: "integer", nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    ordinalnumber = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    iscorrect = table.Column<bool>(type: "boolean", nullable: false),
                    isselected = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quizresultsinglechoicequestionanswers", x => new { x.id, x.no, x.subno });
                    table.ForeignKey(
                        name: "fk_quizresultsinglechoicequestionanswers_quizresultsinglechoic~",
                        columns: x => new { x.id, x.no },
                        principalTable: "quizresultsinglechoicequestions",
                        principalColumns: new[] { "id", "no" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_quizresults_quizid",
                table: "quizresults",
                column: "quizid");

            migrationBuilder.CreateIndex(
                name: "ix_quizresults_userid",
                table: "quizresults",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_quizzes_ownerid",
                table: "quizzes",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "ix_refreshtokens_hashedtoken",
                table: "refreshtokens",
                column: "hashedtoken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sharedquizusers_userid",
                table: "sharedquizusers",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_sharedquizzes_quizid",
                table: "sharedquizzes",
                column: "quizid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quizmultiplechoicequestionanswers");

            migrationBuilder.DropTable(
                name: "quizopenquestions");

            migrationBuilder.DropTable(
                name: "quizresultmultiplechoicequestionanswers");

            migrationBuilder.DropTable(
                name: "quizresultopenquestions");

            migrationBuilder.DropTable(
                name: "quizresultsinglechoicequestionanswers");

            migrationBuilder.DropTable(
                name: "quizsinglechoicequestionanswers");

            migrationBuilder.DropTable(
                name: "refreshtokens");

            migrationBuilder.DropTable(
                name: "sharedquizusers");

            migrationBuilder.DropTable(
                name: "quizmultiplechoicequestions");

            migrationBuilder.DropTable(
                name: "quizresultmultiplechoicequestions");

            migrationBuilder.DropTable(
                name: "quizresultsinglechoicequestions");

            migrationBuilder.DropTable(
                name: "quizsinglechoicequestions");

            migrationBuilder.DropTable(
                name: "sharedquizzes");

            migrationBuilder.DropTable(
                name: "quizresults");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
