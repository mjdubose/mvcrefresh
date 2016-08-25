namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTextPropertyToMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipTypeText", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipTypeText");
        }
    }
}
