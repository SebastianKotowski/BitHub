namespace BitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bits", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bits", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Bits", new[] { "Artist_Id" });
            DropIndex("dbo.Bits", new[] { "Genre_Id" });
            AlterColumn("dbo.Bits", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Bits", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Bits", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Bits", "Artist_Id");
            CreateIndex("dbo.Bits", "Genre_Id");
            AddForeignKey("dbo.Bits", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bits", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bits", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Bits", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bits", new[] { "Genre_Id" });
            DropIndex("dbo.Bits", new[] { "Artist_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Bits", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Bits", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Bits", "Venue", c => c.String());
            CreateIndex("dbo.Bits", "Genre_Id");
            CreateIndex("dbo.Bits", "Artist_Id");
            AddForeignKey("dbo.Bits", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Bits", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
