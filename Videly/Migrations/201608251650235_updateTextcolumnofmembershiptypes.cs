namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTextcolumnofmembershiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET MEMBERSHIPTYPETEXT = 'PAY AS YOU GO' WHERE ID = 1 ");
            Sql("UPDATE MEMBERSHIPTYPES  SET MEMBERSHIPTYPETEXT = 'MONTHLY' WHERE ID = 2");
            Sql("UPDATE MEMBERSHIPTYPES SET MEMBERSHIPTYPETEXT = 'QUARTERLY' WHERE ID = 3" );
        }
        
        public override void Down()
        {
        }
    }
}
