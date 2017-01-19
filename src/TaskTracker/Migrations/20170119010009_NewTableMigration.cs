using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.Migrations
{
    public partial class NewTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTracker",
                table: "TaskTracker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDo",
                table: "TaskTracker",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "TaskTracker",
                newName: "ToDo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDo",
                table: "ToDo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTracker",
                table: "ToDo",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "ToDo",
                newName: "TaskTracker");
        }
    }
}
