namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviefix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "name");
        }
    }
}
