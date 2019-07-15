using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace my_own_json_api.Migrations
{
    public partial class AddDatePropToTodoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Todos",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Completed", "Date", "Title" },
                values: new object[] { "74c7c43c-724f-4b45-b8ea-113698cebb04", false, DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"), "lorem ipsum dolor sit amet" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Completed", "Date", "Title" },
                values: new object[] { "da99f04d-ec39-4ac1-94e9-1139fb2ec286", true, DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"), "dolor sit amet consectetur adipisicing" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Completed", "Date", "Title" },
                values: new object[] { "5488b6f2-7d1b-4f83-8550-8a331e2134f2", false, DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"), "iusto modi reiciendis voluptates corrupti minima saepe dolorum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
