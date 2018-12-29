namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenreAddedData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres( Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres( Name) VALUES ('Horror')");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.Int(nullable: false));
        }
    }
}
