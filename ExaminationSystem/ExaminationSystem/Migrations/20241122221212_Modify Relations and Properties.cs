using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRelationsandProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_Course",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_Course",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "RightAnswer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "ExamQuestion");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxTime",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionScore",
                table: "ExamQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Choices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Choices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Choices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_InstructorID",
                table: "Exams",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionID",
                table: "ExamQuestion",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionID",
                table: "ExamQuestion",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Instructors_InstructorID",
                table: "Exams",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionID",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Instructors_InstructorID",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_InstructorID",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_QuestionID",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "MaxTime",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "QuestionScore",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Choices");

            migrationBuilder.AlterColumn<int>(
                name: "Body",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RightAnswer",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "ExamQuestion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_Course",
                table: "ExamQuestion",
                column: "Course");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_Course",
                table: "ExamQuestion",
                column: "Course",
                principalTable: "Questions",
                principalColumn: "ID");
        }
    }
}
