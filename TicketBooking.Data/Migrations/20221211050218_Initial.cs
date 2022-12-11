﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBooking.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "EventHall",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HallName = table.Column<string>(maxLength: 100, nullable: false),
                    HallStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingMaster",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 100, nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    HallId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingMaster_EventHall_HallId",
                        column: x => x.HallId,
                        principalSchema: "dbo",
                        principalTable: "EventHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HallSeats",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SeatNumber = table.Column<string>(nullable: false),
                    SeatRow = table.Column<string>(nullable: false),
                    SeatColumn = table.Column<string>(nullable: false),
                    SeatStatus = table.Column<bool>(nullable: false),
                    HallId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HallSeats_EventHall_HallId",
                        column: x => x.HallId,
                        principalSchema: "dbo",
                        principalTable: "EventHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                schema: "dbo",
                columns: table => new
                {
                    BookingDetailId = table.Column<Guid>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    BookingId = table.Column<Guid>(nullable: false),
                    HallSeatId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => x.BookingDetailId);
                    table.ForeignKey(
                        name: "FK_BookingDetail_BookingMaster_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "dbo",
                        principalTable: "BookingMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingDetail_HallSeats_HallSeatId",
                        column: x => x.HallSeatId,
                        principalSchema: "dbo",
                        principalTable: "HallSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_BookingId",
                schema: "dbo",
                table: "BookingDetail",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_HallSeatId",
                schema: "dbo",
                table: "BookingDetail",
                column: "HallSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingMaster_HallId",
                schema: "dbo",
                table: "BookingMaster",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_HallSeats_HallId",
                schema: "dbo",
                table: "HallSeats",
                column: "HallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BookingMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HallSeats",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EventHall",
                schema: "dbo");
        }
    }
}
