using Microsoft.EntityFrameworkCore.Migrations;

namespace my_own_json_api.Migrations
{
    public partial class AddNewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Body", "Date", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { "53e705b2-5b35-4ca1-a8ef-74897bcb309e", "ipsum dolor sit amet, consectetur adipiscing elit. Sed ornare at nisi nec fermentum. Mauris commodo enim lorem, at congue leo volutpat quis. Fusce mollis justo dolor, sed malesuada ligula vehicula sit amet. Cras metus tortor, pharetra mollis nulla a, viverra vestibulum turpis. Quisque ultricies efficitur risus, sit amet laoreet nulla. Fusce auctor sapien in enim consectetur, vel feugiat ipsum varius. Sed non vestibulum risus.", "17-07-2019, 03:54:08", "http://hdwpro.com/wp-content/uploads/2019/01/Beautiful-Awesome-Wallpaper.jpg", "commodo enim lorem, at congue leo volutpat quis" },
                    { "6cda4851-7eea-4870-a1f6-52484373900d", "Donec mattis, est eget interdum eleifend, ligula lectus molestie velit, vitae bibendum ipsum augue et risus. Aliquam at erat a massa molestie accumsan id id sapien. Maecenas sagittis leo ac consequat gravida. Donec mattis nunc eget fringilla luctus. Fusce et sem tincidunt, tempor sem nec, pretium eros. Aenean quis finibus enim. Phasellus varius sem nulla, non dictum nisi maximus sed. Praesent porta velit vitae neque imperdiet, at malesuada risus accumsan.", "17-07-2019, 03:54:08", "http://www.photobackgroundhd.com/wp-content/uploads/2018/08/Full-HD-Nature-Images.jpg", "vitae bibendum ipsum augue et risus" },
                    { "586a8572-9099-45dd-88e2-a15f269050fb", "Sed et ligula non nisi cursus faucibus ut vitae sapien. Aenean id dictum arcu, at convallis lectus. Vestibulum faucibus luctus lectus, ut ultrices dolor sollicitudin nec. Vivamus quam diam, gravida non dui eu, rutrum semper odio. Praesent facilisis lobortis mi. Donec condimentum magna vitae mi pretium congue. Quisque ut fermentum orci, at volutpat nisl. Sed eget erat ac nisi sollicitudin ultrices. Praesent vel odio quam.", "17-07-2019, 03:54:08", "http://hdwpro.com/wp-content/uploads/2016/03/Cloudy-Weather-Full-HD-Wallpaper.jpg", "aenean id dictum arcu, at convallis lectus" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
