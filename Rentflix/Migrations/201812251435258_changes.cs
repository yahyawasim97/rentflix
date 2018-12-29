namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
