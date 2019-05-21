namespace BitHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(Id, Name) values(1, 'Jazz')");
            Sql("insert into Genres(Id, Name) values(2, 'Blues')");
            Sql("insert into Genres(Id, Name) values(3, 'Rock')");
            Sql("insert into Genres(Id, Name) values(4, 'Country')");
            Sql("insert into Genres(Id, Name) values(5, 'Pop')");
        }
        
        public override void Down()
        {
            Sql("delete fron Generes where Id in (1, 2, 3, 4, 5)");
        }
    }
}
