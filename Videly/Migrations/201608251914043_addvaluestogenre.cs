namespace Videly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvaluestogenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES VALUES ('Comedy')");
            Sql("INSERT INTO GENRES VALUES ('Action')");
            Sql("INSERT INTO GENRES VALUES ('Family')");
            Sql("INSERT INTO GENRES VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
