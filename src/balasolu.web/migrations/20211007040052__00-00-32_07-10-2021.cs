using Microsoft.EntityFrameworkCore.Migrations;

namespace balasolu.web.Migrations
{
    public partial class _000032_07102021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeaponType",
                table: "Items",
                newName: "ItemWeaponType");

            migrationBuilder.RenameColumn(
                name: "WeaponBase",
                table: "Items",
                newName: "ItemWeaponBase");

            migrationBuilder.RenameColumn(
                name: "Rarity",
                table: "Items",
                newName: "ItemRarity");

            migrationBuilder.RenameColumn(
                name: "Quality",
                table: "Items",
                newName: "ItemQuality");

            migrationBuilder.RenameColumn(
                name: "OtherType",
                table: "Items",
                newName: "ItemOtherType");

            migrationBuilder.RenameColumn(
                name: "OtherBase",
                table: "Items",
                newName: "ItemOtherBase");

            migrationBuilder.RenameColumn(
                name: "ArmorType",
                table: "Items",
                newName: "ItemArmorType");

            migrationBuilder.RenameColumn(
                name: "ArmorBase",
                table: "Items",
                newName: "ItemArmorBase");

            migrationBuilder.AddColumn<string>(
                name: "ItemFTId",
                table: "Posts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ItemISOId",
                table: "Posts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ItemFTId",
                table: "Posts",
                column: "ItemFTId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ItemISOId",
                table: "Posts",
                column: "ItemISOId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Items_ItemFTId",
                table: "Posts",
                column: "ItemFTId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Items_ItemISOId",
                table: "Posts",
                column: "ItemISOId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Items_ItemFTId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Items_ItemISOId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ItemFTId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ItemISOId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ItemFTId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ItemISOId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ItemWeaponType",
                table: "Items",
                newName: "WeaponType");

            migrationBuilder.RenameColumn(
                name: "ItemWeaponBase",
                table: "Items",
                newName: "WeaponBase");

            migrationBuilder.RenameColumn(
                name: "ItemRarity",
                table: "Items",
                newName: "Rarity");

            migrationBuilder.RenameColumn(
                name: "ItemQuality",
                table: "Items",
                newName: "Quality");

            migrationBuilder.RenameColumn(
                name: "ItemOtherType",
                table: "Items",
                newName: "OtherType");

            migrationBuilder.RenameColumn(
                name: "ItemOtherBase",
                table: "Items",
                newName: "OtherBase");

            migrationBuilder.RenameColumn(
                name: "ItemArmorType",
                table: "Items",
                newName: "ArmorType");

            migrationBuilder.RenameColumn(
                name: "ItemArmorBase",
                table: "Items",
                newName: "ArmorBase");
        }
    }
}
