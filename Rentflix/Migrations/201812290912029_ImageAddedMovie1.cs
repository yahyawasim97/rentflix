namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAddedMovie1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieImageFile", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieImageFile");
        }
    }
}
