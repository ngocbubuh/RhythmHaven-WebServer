using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhythmHaven.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CartDuoKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Cart__3214EC076C3A46F3",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProductID",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Cart",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Cart",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_AccountID",
                table: "Cart",
                newName: "IX_Cart_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Cart",
                newName: "AccountID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cart",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_AccountId",
                table: "Cart",
                newName: "IX_Cart_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Cart__3214EC076C3A46F3",
                table: "Cart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductID",
                table: "Cart",
                column: "ProductID");
        }
    }
}
