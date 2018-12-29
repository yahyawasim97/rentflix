namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAddedMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieImage");
        }
    }
}
