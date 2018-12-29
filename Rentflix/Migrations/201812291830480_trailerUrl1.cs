namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trailerUrl1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "trailerUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "trailerUrl", c => c.String());
        }
    }
}
