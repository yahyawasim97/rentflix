namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId)
                .Index(t => t.MembershipTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembershipTypes", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.MembershipTypes", new[] { "MembershipTypeId" });
            DropTable("dbo.MembershipTypes");
        }
    }
}
