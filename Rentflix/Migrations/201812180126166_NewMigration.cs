namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "DateAdded");
        }
        
        public override void Down()
        {
            
        }
    }
}
