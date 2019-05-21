namespace BitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createBit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artist_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bits", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Bits", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bits", new[] { "Genre_Id" });
            DropIndex("dbo.Bits", new[] { "Artist_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Bits");
        }
    }
}
