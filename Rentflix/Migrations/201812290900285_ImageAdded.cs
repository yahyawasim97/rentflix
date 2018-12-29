namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieImageId", "dbo.MovieImages");
            DropIndex("dbo.Movies", new[] { "MovieImageId" });
            DropColumn("dbo.Movies", "MovieImageId");
            DropTable("dbo.MovieImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MovieImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieImageId");
            AddForeignKey("dbo.Movies", "MovieImageId", "dbo.MovieImages", "Id", cascadeDelete: true);
        }
    }
}
