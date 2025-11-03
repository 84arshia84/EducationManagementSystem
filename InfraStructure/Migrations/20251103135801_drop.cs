using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class drop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorCourse_MentorProfiles_MentorProfileId",
                table: "MentorCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_StudentProfiles_StudentProfileId",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles");

            migrationBuilder.DropIndex(
                name: "IX_StudentProfiles_UserId",
                table: "StudentProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorProfiles",
                table: "MentorProfiles");

            migrationBuilder.DropIndex(
                name: "IX_MentorProfiles_UserId",
                table: "MentorProfiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MentorProfiles");

            migrationBuilder.RenameColumn(
                name: "StudentProfileId",
                table: "StudentCourse",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_StudentProfileId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_StudentUserId");

            migrationBuilder.RenameColumn(
                name: "MentorProfileId",
                table: "MentorCourse",
                newName: "MentorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MentorCourse_MentorProfileId",
                table: "MentorCourse",
                newName: "IX_MentorCourse_MentorUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorProfiles",
                table: "MentorProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorCourse_MentorProfiles_MentorUserId",
                table: "MentorCourse",
                column: "MentorUserId",
                principalTable: "MentorProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_StudentProfiles_StudentUserId",
                table: "StudentCourse",
                column: "StudentUserId",
                principalTable: "StudentProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorCourse_MentorProfiles_MentorUserId",
                table: "MentorCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_StudentProfiles_StudentUserId",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MentorProfiles",
                table: "MentorProfiles");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "StudentCourse",
                newName: "StudentProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_StudentUserId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_StudentProfileId");

            migrationBuilder.RenameColumn(
                name: "MentorUserId",
                table: "MentorCourse",
                newName: "MentorProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_MentorCourse_MentorUserId",
                table: "MentorCourse",
                newName: "IX_MentorCourse_MentorProfileId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "MentorProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MentorProfiles",
                table: "MentorProfiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_UserId",
                table: "StudentProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MentorProfiles_UserId",
                table: "MentorProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorCourse_MentorProfiles_MentorProfileId",
                table: "MentorCourse",
                column: "MentorProfileId",
                principalTable: "MentorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_StudentProfiles_StudentProfileId",
                table: "StudentCourse",
                column: "StudentProfileId",
                principalTable: "StudentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
