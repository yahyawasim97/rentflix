namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAddedMovie2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "MovieImageFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieImageFile", c => c.Binary());
        }
    }
}
