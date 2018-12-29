namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorGenreChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "ReleaseData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ReleaseData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
