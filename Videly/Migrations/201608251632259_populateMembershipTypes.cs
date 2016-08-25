namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MEMBERSHIPTYPES(ID, SIGNUPFEE, DURATIONINMONTHS, DISCOUNTRATE) VALUES (1,0,0,0)");
            Sql("INSERT INTO MEMBERSHIPTYPES(ID, SIGNUPFEE, DURATIONINMONTHS, DISCOUNTRATE) VALUES (2,30,1,10)");
            Sql("INSERT INTO MEMBERSHIPTYPES(ID, SIGNUPFEE, DURATIONINMONTHS, DISCOUNTRATE) VALUES (3,90,3,15)");
        }
        
        public override void Down()
        {
        }
    }
}
