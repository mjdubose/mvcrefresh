namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Membershiptypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Short(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershiptTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "Membershiptype_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "Membershiptype_Id");
            AddForeignKey("dbo.Customers", "Membershiptype_Id", "dbo.Membershiptypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Membershiptype_Id", "dbo.Membershiptypes");
            DropIndex("dbo.Customers", new[] { "Membershiptype_Id" });
            DropColumn("dbo.Customers", "Membershiptype_Id");
            DropColumn("dbo.Customers", "MembershiptTypeId");
            DropTable("dbo.Membershiptypes");
        }
    }
}
