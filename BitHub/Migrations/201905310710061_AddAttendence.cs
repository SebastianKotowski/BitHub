namespace BitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        BitId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.BitId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Bits", t => t.BitId)
                .Index(t => t.BitId)
                .Index(t => t.AttendeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "BitId", "dbo.Bits");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropIndex("dbo.Attendances", new[] { "BitId" });
            DropTable("dbo.Attendances");
        }
    }
}
