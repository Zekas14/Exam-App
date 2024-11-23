using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Migrations
{
    /// <inheritdoc />
    public partial class HandlesomeEntitiesandrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamResults",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "ExamResults",
                newName: "Grade");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ExamResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ExamResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ExamResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "ExamResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ExamResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ExamResults",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ExamResults");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ExamResults",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "ExamResults",
                newName: "Score");
        }
    }
}
