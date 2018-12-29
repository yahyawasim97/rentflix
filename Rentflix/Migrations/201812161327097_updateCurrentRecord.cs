namespace Rentflix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCurrentRecord : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay As You Go' where Id= 1");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly' where Id= 2");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Quaterly' where Id= 3");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Yearly' where Id= 4");
        }
        
        public override void Down()
        {
        }
    }
}
