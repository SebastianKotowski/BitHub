namespace BitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeginKeyForBit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bits", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Bits", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Bits", name: "IX_Artist_Id", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.Bits", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Bits", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Bits", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Bits", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Bits", name: "ArtistId", newName: "Artist_Id");
        }
    }
}
