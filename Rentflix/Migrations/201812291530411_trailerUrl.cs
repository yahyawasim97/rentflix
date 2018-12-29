namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trailerUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "trailerUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "trailerUrl");
        }
    }
}
