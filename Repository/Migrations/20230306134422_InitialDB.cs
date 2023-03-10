using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAdmin",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    admin_phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    admin_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    admin_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    admin_role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    admin_status = table.Column<bool>(type: "bit", nullable: true),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblClub__BCAD3DD90EA330E9", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCateg__D54EE9B4014935CB", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "tblLocation",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location_status = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblLocat__771831EA145C0A3F", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    users_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    users_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    users_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    users_phone = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    users_address = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblUser__EAA7D14B1BFD2C07", x => x.users_id);
                });

            migrationBuilder.CreateTable(
                name: "tblEvent",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    event_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    event_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_start = table.Column<DateTime>(type: "datetime", nullable: true),
                    event_status = table.Column<bool>(type: "bit", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    admin_id = table.Column<int>(type: "int", nullable: true),
                    event_end = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEvent__2370F7270519C6AF", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_tblEvent_tblAdmin",
                        column: x => x.admin_id,
                        principalTable: "tblAdmin",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEvent_tblCategory",
                        column: x => x.category_id,
                        principalTable: "tblCategory",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_tblEvent_tblLocation",
                        column: x => x.location_id,
                        principalTable: "tblLocation",
                        principalColumn: "location_id");
                });

            migrationBuilder.CreateTable(
                name: "tblEventParticipated",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false),
                    users_id = table.Column<int>(type: "int", nullable: false),
                    date_participated = table.Column<DateTime>(type: "datetime", nullable: true),
                    payment_status = table.Column<bool>(type: "bit", nullable: true),
                    users_status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEvent__8DDA8A3308EA5793", x => new { x.event_id, x.users_id });
                    table.ForeignKey(
                        name: "FK_tblEventParticipated_tblEvent",
                        column: x => x.event_id,
                        principalTable: "tblEvent",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEventParticipated_tblUser",
                        column: x => x.users_id,
                        principalTable: "tblUser",
                        principalColumn: "users_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblImage",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblImage__DC9AC955108B795B", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_tblImage_tblEvent",
                        column: x => x.event_id,
                        principalTable: "tblEvent",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPayment",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_fee = table.Column<int>(type: "int", nullable: true),
                    payment_detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblPayme__ED1FC9EA182C9B23", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_tblPayment_tblEvent",
                        column: x => x.event_id,
                        principalTable: "tblEvent",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblVideo",
                columns: table => new
                {
                    video_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: true),
                    video_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblVideo__E8F11E1007020F21", x => x.video_id);
                    table.ForeignKey(
                        name: "FK_tblVideo_tblEvent",
                        column: x => x.event_id,
                        principalTable: "tblEvent",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFeedback",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    created_time = table.Column<DateTime>(type: "date", nullable: true),
                    event_id = table.Column<int>(type: "int", nullable: true),
                    users_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblFeedb__7A6B2B8C0CBAE877", x => x.feedback_id);
                    table.ForeignKey(
                        name: "FK_tblFeedback_tblEventParticipated",
                        columns: x => new { x.event_id, x.users_id },
                        principalTable: "tblEventParticipated",
                        principalColumns: new[] { "event_id", "users_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_admin_id",
                table: "tblEvent",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_category_id",
                table: "tblEvent",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_location_id",
                table: "tblEvent",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventParticipated_users_id",
                table: "tblEventParticipated",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblFeedback_event_id_users_id",
                table: "tblFeedback",
                columns: new[] { "event_id", "users_id" });

            migrationBuilder.CreateIndex(
                name: "IX_tblImage_event_id",
                table: "tblImage",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayment_event_id",
                table: "tblPayment",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblVideo_event_id",
                table: "tblVideo",
                column: "event_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFeedback");

            migrationBuilder.DropTable(
                name: "tblImage");

            migrationBuilder.DropTable(
                name: "tblPayment");

            migrationBuilder.DropTable(
                name: "tblVideo");

            migrationBuilder.DropTable(
                name: "tblEventParticipated");

            migrationBuilder.DropTable(
                name: "tblEvent");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblAdmin");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblLocation");
        }
    }
}
