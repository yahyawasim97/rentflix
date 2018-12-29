namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorMovieStructChang1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Movies");
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Id", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "DateAdded");
            AddPrimaryKey("dbo.Movies", "Id");
        }
    }
}
